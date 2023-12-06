using Group6_Profile.DTO.DTO;
using Group6_Profile.DTO.MessageBody;
using Group6_Profile.Service.Service;
using Microsoft.AspNetCore.Mvc;

namespace Group6_Profile.Web.Controllers
{
    /// <summary>
    /// Profile
    /// </summary>
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ProfileController : ControllerBase
    {
        private UserService _userService;
        /// <summary>
        /// userService
        /// </summary>
        /// <param name="userService"></param>
        public ProfileController(UserService userService)
        {
            _userService = userService;
        }
        /// <summary>
        /// Get Seller  Infor 
        /// </summary>
        /// <param name="UID"></param>
        /// <returns></returns>
        [HttpGet]
        public MessageModel<UserInforDTO> GetSellerInfo(string UID)
        {
            return _userService.GetSeller(UID);
        }
        /// <summary>
        /// Get Buyer  Infor 
        /// </summary>
        /// <param name="UID"></param>
        /// <returns></returns>
        [HttpGet]
        public MessageModel<UserInforDTO> GetBuyerInfo(string UID)
        {
            return _userService.GetBuyer(UID);
        }
    }
}
