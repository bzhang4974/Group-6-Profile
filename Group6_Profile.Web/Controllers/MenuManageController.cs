using Group6_Profile.DTO.DTO;
using Group6_Profile.DTO.MessageBody;
using Group6_Profile.Service.Service;
using Group6_Profile.web.WebExtends;
using Microsoft.AspNetCore.Mvc;

namespace Group6_Profile.Web.Controllers
{
    [CheckCustomer]
    /// <summary>
    /// menu manage
    /// </summary>
    public class MenuManageController : Controller
    {
        /// <summary>
        /// /menu service
        /// </summary>
        private readonly MenuService _menuService;
        private readonly RoleService _roleService;
        /// <summary>
        ///  
        /// </summary>
        /// <param name="menuService"></param>
        public MenuManageController(MenuService menuService, RoleService roleService)
        {
            _menuService = menuService;
            _roleService = roleService;
        }

        /// <summary>
        /// page
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
        public async Task<DataWithPage<MenuGridDTO>> GetUserDataAsync(int page, int limit, string name = "")
        {
            return await _menuService.GetMenuInforAsync(page, limit, name);
        }
        /// <summary>
        /// add or edit data
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async System.Threading.Tasks.Task<ActionResult> Edit(long? id)
        {
            MenuAddDTO user = new MenuAddDTO();
            if (id.HasValue)
            {
                user = await _menuService.GetByIdAsync(id.Value);
            }
            this.ViewBag.Roles = await _roleService.GetAllRoleAsync();
            return View(user);
        }

        /// <summary>
        /// save data
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async System.Threading.Tasks.Task<MessageModel<string>> SaveData(MenuAddDTO role)
        {
            var userId = this.GetLoginUserId();
            return await _menuService.SaveDataAsync(role, userId.Value);
        }
        /// <summary>
        /// delete data
        /// </summary>
        /// <param name="id">id</param>
        /// <returns></returns>
        public async System.Threading.Tasks.Task<MessageModel<string>> deleteData(long id)
        {
            return await _menuService.Delete(id);
        }
    }
}
