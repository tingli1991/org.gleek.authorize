using Microsoft.AspNetCore.Mvc;
using Org.Gleek.AuthorizeSvc.AggregateService;
using Org.Gleek.AuthorizeSvc.Attributes;
using Org.Gleek.AuthorizeSvc.Entitys;

namespace Org.Gleek.AuthorizeSvc.Controllers
{
    /// <summary>
    /// �û�������
    /// </summary>
    [Route("api/user")]
    public class UserController : UserAuthController
    {
        /// <summary>
        /// �û��ۺϷ���
        /// </summary>
        public UserAggregateService UserAggregateService { get; set; }

        /// <summary>
        /// ��ȡ�û�����
        /// </summary>
        /// <param name="userId">�û�����</param>
        /// <returns></returns>
        [UserAuth()]
        [HttpGet("get-user-detail/{user_id}")]
        public async Task<User> GetUserAsync([FromRoute(Name = "user_id")] long userId)
        {
            return await UserAggregateService.GetUserAsync(userId);
        }
    }
}