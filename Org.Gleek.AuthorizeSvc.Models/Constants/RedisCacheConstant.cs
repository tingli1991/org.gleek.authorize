namespace Org.Gleek.AuthorizeSvc.Models
{
    /// <summary>
    /// Redis缓存常量
    /// </summary>
    public static class RedisCacheConstant
    {
        /// <summary>
        /// 获取用户信息缓存键
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <returns></returns>
        public static string GetUserCacheKey(long userId) => $"gleek:authorize:user:{userId}";

        /// <summary>
        /// 获取用户Id缓存键
        /// </summary>
        public static string GetUserIdKey(string fieldName) => $"gleek:authorize:userid:{fieldName}";
    }
}