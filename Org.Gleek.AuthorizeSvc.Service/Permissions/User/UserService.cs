using Com.GleekFramework.CommonSdk;
using Com.GleekFramework.RedisSdk;
using Org.Gleek.AuthorizeSvc.Entitys;
using Org.Gleek.AuthorizeSvc.Models;
using Org.Gleek.AuthorizeSvc.Repository;

namespace Org.Gleek.AuthorizeSvc.Service
{
    /// <summary>
    /// 用户领域服务
    /// </summary>
    public class UserService : BaseService
    {
        /// <summary>
        /// 用户仓储
        /// </summary>
        public UserRepository UserRepository { get; set; }

        /// <summary>
        /// Redis字符串仓储类
        /// </summary>
        public RedisStringRepository RedisStringRepository { get; set; }

        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <param name="userName">用户名称</param>
        /// <returns></returns>
        public async Task<User> GetUserAsync(string userName)
        {
            return await UserRepository.GetUserAsync(userName);
        }

        /// <summary>
        /// 获取登录授权参数
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <returns></returns>
        public async Task<UserAuthModel> GetUserAuthAsync(long userId)
        {
            var userInfo = await GetUserAsync(userId);
            return userInfo.Map<User, UserAuthModel>();
        }

        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <param name="userId">用户名称</param>
        /// <returns></returns>
        public async Task<User> GetUserAsync(long userId)
        {
            var cacheKey = RedisCacheConstant.GetUserCacheKey(userId);
            var userInfo = await RedisStringRepository.GetAsync<User>(cacheKey);
            if (userInfo == null)
            {
                userInfo = await UserRepository.GetUserAsync(userId);//获取用户信息
                var expireSeconds = RedisStringRepository.GetExpireSeconds(3600 * 24 * 3, 3600 * 24 * 7);//缓存过期时间
                await RedisStringRepository.SetAsync(cacheKey, userInfo ?? new User(), expireSeconds);//设置缓存
            }
            else
            {
                if (userInfo.Id <= 0)
                {
                    return null;
                }
            }
            return userInfo;
        }
    }
}