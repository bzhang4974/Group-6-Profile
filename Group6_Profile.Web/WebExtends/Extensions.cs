using Group6_Profile.DTO.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Group6_Profile.web.WebExtends
{
    /// <summary>
    ///  
    /// </summary>
    /// <creater> </creater>
    /// <createTime>2022-08-10</createTime>
    internal static partial class Extensions
    {
        /// <summary>
        /// Get Login User
        /// </summary>
        /// <param name="controller"></param>
        /// <returns> </returns>
   
        public static LoginUserDTO GetLoginUser(this ControllerBase controller)
        {
            return controller?.HttpContext?.Session?.Get<LoginUserDTO>("LoginUser");
        }
        /// <summary>
        ///  
        /// </summary>
        /// <param name="controller"></param>
        /// <returns> </returns>
      
        public static long[] GetLoginUserRoleId(this ControllerBase controller)
        {
            return controller?.HttpContext?.Session?.Get<LoginUserDTO>("LoginUser")?.RoleId;
        }
        /// <summary>
        ///  
        /// </summary>
        /// <param name="controller"></param>
        /// <returns> </returns>
       
        public static long? GetLoginUserId(this ControllerBase controller)
        {
            return controller?.HttpContext?.Session?.Get<LoginUserDTO>("LoginUser")?.Id;
        }
        /// <summary>
        ///  
        /// </summary>
        /// <param name="controller"></param>
        /// <returns> </returns>
   
        public static string GetLoginUserName(this ControllerBase controller)
        {
            return controller?.HttpContext?.Session?.Get<LoginUserDTO>("LoginUser")?.UserName;
        }
        /// <summary>
        ///  
        /// </summary>
        /// <param name="controller"></param>
        /// <returns> </returns>
    
        public static long? GetLoginAgentId(this ControllerBase controller)
        {
            return controller?.HttpContext?.Session?.Get<LoginUserDTO>("LoginUser")?.AgentId;
        }
        
    }
}
