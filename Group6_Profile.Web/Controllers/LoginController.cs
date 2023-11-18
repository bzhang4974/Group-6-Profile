using Group6_Profile.DTO.DTO;
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
        /// <summary>
        /// login
        /// </summary>
        /// <param name="service"></param>
        public LoginController(UserService userService)
        {
            _userService = userService;
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
        /// 退出登陆
        /// </summary>
        /// <returns></returns>
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("LoginUser");
            return Redirect("~/Login");
        }
    }
}
