using Com.GleekFramework.CommonSdk;
using Org.Gleek.AuthorizeSvc.Entitys;
using Org.Gleek.AuthorizeSvc.Models;

namespace Org.Gleek.AuthorizeSvc.Repository
{
    /// <summary>
    /// 用户仓储
    /// </summary>
    public class UserRepository : BaseRepository
    {
        /// <summary>
        /// 获取登录授权参数
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <returns></returns>
        public async Task<JwtTokenModel> GetJwtTokenAsync(string userName)
        {
            if (userName.IsNull())
            {
                return null;
            }

            var sql = @"select id,user_name,nick_name,avatar,gender,business_card,is_admin,register_time,last_login_time,last_logout_time 
            from user where user_name=@UserName and id_deleted=@IsDeleted";
            return await AuthorizeRepository.GetFirstOrDefaultAsync<JwtTokenModel>(sql, new { UserName = userName, IsDeleted = false });
        }

        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <param name="userName">用户名称</param>
        /// <returns></returns>
        public async Task<User> GetUserAsync(string userName)
        {
            if (userName.IsNull())
            {
                return null;
            }

            var sql = @"select id,user_name,password,nick_name,avatar,gender,status,business_card,signature,is_admin,
            register_time,last_login_time,last_logout_time,version,id_deleted,update_time,create_time,extend,remark 
            from user where user_name=@UserName and id_deleted=@IsDeleted";
            return await AuthorizeRepository.GetFirstOrDefaultAsync<User>(sql, new { UserName = userName, IsDeleted = false });
        }

        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <param name="userId">用户名称</param>
        /// <returns></returns>
        public async Task<User> GetUserAsync(long userId)
        {
            if (userId <= 0)
            {
                return null;
            }

            var sql = @"select id,user_name,password,nick_name,avatar,gender,status,business_card,signature,is_admin,
            register_time,last_login_time,last_logout_time,version,id_deleted,update_time,create_time,extend,remark 
            from user where user_name=@Id and id_deleted=@IsDeleted";
            return await AuthorizeRepository.GetFirstOrDefaultAsync<User>(sql, new { Id = userId, IsDeleted = false });
        }
    }
}