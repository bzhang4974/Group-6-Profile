using Group6_Profile.DTO.DTO;
using Group6_Profile.DTO.MessageBody;
using Group6_Profile.Service.Service;
using Group6_Profile.web.WebExtends;
using Microsoft.AspNetCore.Mvc;

namespace Group6_Profile.Web.Controllers
{
    /// <summary>
    /// login
    /// </summary>
    public class LoginController : Controller
    {
        private UserService _userService;
        private RoleService _roleService;
        /// <summary>
        /// login
        /// </summary>
        /// <param name="service"></param>
        public LoginController(UserService userService, RoleService roleService)
        {
            _userService = userService;
            _roleService = roleService;
        }
        public IActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// chack input accuont and password
        /// </summary>
        /// <param name="account"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public async Task<IActionResult> LoginCheckAsync(string account, string password)
        {
            var loginresult = await _userService.CheckLogin(account, password);
            if (loginresult != null)
            {
                //save userid to Session
                HttpContext.Session.Set<LoginUserDTO>("LoginUser", loginresult);
                return Json(new { Status = true, Msg = "login success" });
            }
            else
            {
                return Json(new { Status = false, Msg = "account or password error" });
            }
        }
        /// <summary>
        /// Logout
        /// </summary>
        /// <returns></returns>
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("LoginUser");
            return Redirect("~/Login");
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult> SignAsync()
        {
            this.ViewBag.roles = await _roleService.GetAllAdminRoleAsync();
            return View();
        }
        public async Task<MessageModel<string>> SignInforAsync(UserAddDTO user)
        {
            user.IsDelete = false;
            return await _userService.SaveDataAsync(user, 0);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult Forget()
        {
            return View();
        }
        /// <summary>
        /// ResetPassword 
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task<MessageModel<string>> ResetPasswordAsync(ResetPasswordDTO user)
        {
      
            return await _userService.ResetPasswordAsync(user, 0);
        }
    }
}
