using Group6_Profile.DTO.DTO;
using Group6_Profile.DTO.MessageBody;
using Group6_Profile.Service.Service;
using Group6_Profile.web.WebExtends;
using Microsoft.AspNetCore.Mvc;

namespace Group6_Profile.Web.Controllers
{
    [CheckCustomer]
    /// <summary>
    /// role manege
    /// </summary>
    public class RoleManageController : Controller
    {
        /// <summary>
        /// role service
        /// </summary>
        private readonly RoleService _roleService;
        /// <summary>
        /// menu service
        /// </summary>
        private readonly MenuService _menuService;
        /// <summary>
        ///  
        /// </summary>
        /// <param name="roleService"></param>
        public RoleManageController(RoleService roleService, MenuService menuService)
        {
            _roleService = roleService;
            _menuService = menuService;
        }

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
        public async Task<DataWithPage<RoleGridDTO>> GetUserDataAsync(int page, int limit, string name = "")
        {
            return await _roleService.GetRoleInforAsync(page, limit, name);
        }
        /// <summary>
        /// add or edit data
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async System.Threading.Tasks.Task<ActionResult> Edit(long? id)
        {
            RoleAddDTO role = new RoleAddDTO();
            if (id.HasValue)
            {
                role = await _roleService.GetByIdAsync(id.Value);
                this.ViewBag.menus = await _menuService.GetAllLeftMenu(role.Id.Value);
            }
            else
            {
                this.ViewBag.menus = new List<MenuSelectDTO>();
            }
            this.ViewBag.firstMenus = await _menuService.GetAllFirstPage();
            return View(role);
        }

        /// <summary>
        /// save data
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async System.Threading.Tasks.Task<MessageModel<string>> SaveData(RoleAddDTO role)
        {
            var userId = this.GetLoginUserId();
            return await _roleService.SaveDataAsync(role, userId.Value);
        }
        /// <summary>
        /// delete
        /// </summary>
        /// <param name="id">id</param>
        /// <returns></returns>
        public async System.Threading.Tasks.Task<MessageModel<string>> deleteData(long id)
        {
            return await _roleService.Delete(id);
        }
    }
}
