using Group6_Profile.DTO.DTO;
using Group6_Profile.DTO.MessageBody;
using Group6_Profile.Service.Service;

using Group6_Profile.web.WebExtends;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Group6_Profile.web.Controllers
{
    [CheckCustomer]
    public class HomeController : Controller
    {
        /// <summary>
        /// role and Menu relationship
        /// </summary>
        private readonly RoleMenuService _roleMenuService;
        private readonly UserService _userService;
        public HomeController(RoleMenuService roleMenuService, UserService userService)
        {
            _roleMenuService = roleMenuService;
            _userService = userService;
        }
        /// <summary>
        /// First Page  
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Index()
        {
            var roleid = this.GetLoginUserRoleId();
            if (roleid == null || roleid.Length == 0)
                return View();
            string url = await _roleMenuService.GetFirstMenuAsync(roleid);
            //TODO:go to 404 page
            if (string.IsNullOrEmpty(url))
                return View();
            return Redirect(url);
        }
        /// <summary>
        /// menu page
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> MenuPageAsync()
        {
            var roleid = this.GetLoginUserRoleId();
            List<MenuDTO> menus = await _roleMenuService.GetMenuAsync(roleid);
            this.ViewBag.user = this.GetLoginUser();
            return View(menus);
        }
        /// <summary>
        /// change password
        /// </summary>
        /// <returns></returns>
        public ActionResult ChangePasswordAsync()
        {
            var userid = this.GetLoginUserId();
            if (userid == null)
            {
                return Redirect("~/Login");
            }

            return View();
        }
        /// <summary>
        /// save password
        /// </summary>
        /// <param name="sourcePassword"></param>
        /// <param name="aimPassowrd"></param>
        /// <returns></returns>
        public async Task<MessageModel<string>> SavePassword(string sourcePassword, string aimPassowrd)
        {
            var userid = this.GetLoginUserId();
            if (userid == null)
            {
                return MessageModel<string>.Fail("please login");
            }
            return await _userService.ChangePassword(this.GetLoginUserId().Value, sourcePassword, aimPassowrd);

        }
        /// <summary>
        /// logout
        /// </summary>
        /// <returns>redirect to login page</returns>
        public ActionResult Logout()
        {
            return Redirect("~/Login");
        }
        /// <summary>
        /// Userinfor
        /// </summary>
        /// <returns> </returns>
        public async Task<ActionResult> UserInforAsync()
        {
            UserAddDTO user = await _userService.GetByIdAsync(this.GetLoginUserId().Value);

            return View(user);
        }
    }
}