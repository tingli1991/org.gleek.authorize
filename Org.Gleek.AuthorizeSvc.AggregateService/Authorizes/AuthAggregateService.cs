using Com.GleekFramework.CommonSdk;
using Com.GleekFramework.ContractSdk;
using Com.GleekFramework.RedisSdk;
using Org.Gleek.AuthorizeSvc.Entitys;
using Org.Gleek.AuthorizeSvc.Models;
using Org.Gleek.AuthorizeSvc.Service;

namespace Org.Gleek.AuthorizeSvc.AggregateService
{
    /// <summary>
    /// 登录聚合服务
    /// </summary>
    public class AuthAggregateService : BaseAggregateService
    {
        /// <summary>
        /// 用户服务
        /// </summary>
        public UserService UserService { get; set; }

        /// <summary>
        /// Token服务
        /// </summary>
        public UserAuthService UserAuthService { get; set; }

        /// <summary>
        /// Redis分布式锁仓储
        /// </summary>
        public RedisLockRepository RedisLockRepository { get; set; }

        /// <summary>
        /// 验证访问令牌
        /// </summary>
        /// <param name="accessToken">访问令牌</param>
        /// <returns></returns>
        public async Task<ContractResult<UserAuthModel>> ValidateAccessTokenAsync(string accessToken)
        {
            return await UserAuthService.ValidateAccessTokenAsync(accessToken);
        }

        /// <summary>
        /// 获取登录授权信息
        /// </summary>
        /// <param name="accessToken">访问令牌</param>
        /// <returns></returns>
        public async Task<ContractResult<UserAuthModel>> GetUserAuthAsync(string accessToken)
        {
            var result = new ContractResult<UserAuthModel>();
            var (userAuthInfo, expireTime) = await UserAuthService.ParseJwtSecurityTokenAsync(accessToken);
            if (userAuthInfo == null || !expireTime.HasValue)
            {
                result.SetError(MessageCode.UNKNOWN_USER);
                return result;
            }

            var cacheAccessToken = await UserAuthService.GetAccessTokenAsync(userAuthInfo.Id);
            if (cacheAccessToken == null || !cacheAccessToken.Equals(accessToken))
            {
                result.SetError(MessageCode.UNKNOWN_USER);
                return result;
            }
            return result.SetSuceccful(userAuthInfo);
        }

        /// <summary>
        /// 刷新访问令牌
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <param name="refreshToken">刷新令牌</param>
        /// <param name="accessToken">访问令牌</param>
        /// <returns></returns>
        public async Task<ContractResult<UserTokenModel>> RefreshAccessTokenAsync(long userId, string refreshToken, string accessToken)
        {
            var result = new ContractResult<UserTokenModel>();
            var refreshTokenLockKey = RedisCacheConstant.GetRefreshTokenLockKey(userId);
            using var lockClient = await RedisLockRepository.LockUpAsync(refreshTokenLockKey);
            if (lockClient == null)
            {
                result.SetError(MessageCode.FREQUENT_OPERATION);
                return result;
            }

            var (userAuthInfo, expireTime) = await UserAuthService.ParseJwtSecurityTokenAsync(accessToken);
            if (userAuthInfo == null || !expireTime.HasValue)
            {
                result.SetError(MessageCode.UNKNOWN_USER);
                return result;
            }

            if (userId != userAuthInfo.Id)
            {
                result.SetError(MessageCode.ILLEGAL_REQUEST);
                return result;
            }

            var cacheRefreshToken = await UserAuthService.GetRefreshTokenAsync(accessToken);
            if (cacheRefreshToken.IsNullOrEmpty() || !cacheRefreshToken.Equals(refreshToken, StringComparison.CurrentCultureIgnoreCase))
            {
                result.SetError(MessageCode.REFRESH_TOKEN_INVALID);
                return result;
            }

            var userInfo = await UserService.GetUserAsync(userAuthInfo.Id);
            if (userAuthInfo == null)
            {
                result.SetError(MessageCode.UNKNOWN_USER);
                return result;
            }

            userAuthInfo = userInfo.Map<User, UserAuthModel>();
            return await UserAuthService.GenAccessTokenAsync(userAuthInfo); //重新生成新的访问令牌
        }
    }
}