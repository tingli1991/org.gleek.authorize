using Com.GleekFramework.CommonSdk;

namespace Org.Gleek.AuthorizeSvc.Models
{
    /// <summary>
    /// Redis缓存常量
    /// </summary>
    public static class RedisCacheConstant
    {
        /// <summary>
        /// 获取缓存KEYS
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        private static string GetCacheKey(string key) => $"gleek:authorize:{key.Trim(':')}";

        /// <summary>
        /// 获取用户信息缓存键
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <returns></returns>
        public static string GetUserCacheKey(long userId) => GetCacheKey($"tables:user:{userId}");

        /// <summary>
        /// 获取访问令牌缓存锁键
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <returns></returns>
        public static string GetAccessTokenLockKey(long userId) => GetCacheKey($"authorizes:access_token_lock:{userId}");

        /// <summary>
        /// 获取刷新令牌的缓存锁键
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <returns></returns>
        public static string GetRefreshTokenLockKey(long userId) => GetCacheKey($"authorizes:refresh_token:{userId}");

        /// <summary>
        /// 获取访问令牌缓存键
        /// </summary>
        /// <param name="userId">访问令牌</param>
        /// <returns></returns>
        public static string GetAccessTokenKey(long userId) => GetCacheKey($"authorizes:access_token:{userId}");

        /// <summary>
        /// 获取刷新令牌的缓存键
        /// </summary>
        /// <param name="accessToken">访问令牌</param>
        /// <returns></returns>
        public static string GetRefreshTokenKey(string accessToken) => GetCacheKey($"authorizes:refresh_token:{accessToken.EncryptMd5()}");
    }
}