using Group6_Profile.DTO.DTO;
using Group6_Profile.DTO.MessageBody;
using Group6_Profile.Service.Service;
using Group6_Profile.web.WebExtends;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Group6_Profile.Web.Controllers
{
    [CheckCustomer]
    /// <summary>
    /// user manage
    /// </summary>
    public class UserManageController : Controller
    {
        private readonly UserService _userService;
        private readonly RoleService _roleService;
        public UserManageController(UserService userService, RoleService roleService)
        {
            _userService = userService;
            _roleService = roleService;
        }
        /// <summary>
        /// index
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// load page data
        /// </summary>
        /// <param name="page"></param>
        /// <param name="limit"></param>
        /// <param name="userid"></param>
        /// <param name="username"></param>
        /// <returns></returns>
        public async Task<DataWithPage<UserGridDTO>> GetUserDataAsync(int page, int limit, string account = "", string username = "")
        {
            var data = await _userService.GetAdminUserInforAsync(page, limit, account, username);

            return data;
        }
        /// <summary>
        /// add or edit data
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async System.Threading.Tasks.Task<ActionResult> Edit(long? id)
        {
            UserAddDTO user = new UserAddDTO();
            if (id.HasValue)
            {
                user = await _userService.GetByIdAsync(id.Value);
            }
            this.ViewBag.roles = await _roleService.GetAllRoleAsync();
            return View(user);
        }

        /// <summary>
        /// save data
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async System.Threading.Tasks.Task<MessageModel<string>> SaveData(UserAddDTO user)
        {
            var userId = this.GetLoginUserId();
            return await _userService.SaveDataAsync(user, userId.Value);
        }
        /// <summary>
        /// delete
        /// </summary>
        /// <param name="id">id</param>
        /// <returns></returns>
        public async System.Threading.Tasks.Task<MessageModel<string>> deleteData(long id)
        {
            return await _userService.Delete(id);
        }
    }
}
