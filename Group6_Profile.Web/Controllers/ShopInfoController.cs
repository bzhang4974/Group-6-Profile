using Group6_Profile.DTO.DTO;
using Group6_Profile.DTO.MessageBody;
using Group6_Profile.Service.Service;
using Group6_Profile.web.WebExtends;
using Microsoft.AspNetCore.Mvc;

namespace Group6_Profile.Web.Controllers
{
    [CheckCustomer]
    public class ShopInfoController : Controller
    {
        private readonly ShopInfoService _shopInfoService;
        public ShopInfoController(ShopInfoService shopInfoService)
        {
            _shopInfoService = shopInfoService;
        }
        public IActionResult Index()
        {
            var userId = this.GetLoginUserId();
            ShopInfoDTO shopInfoDTO = _shopInfoService.GetById(userId.Value);
            this.ViewBag.UserName = this.GetLoginUserName();
            return View(shopInfoDTO);
        }
        /// <summary>
        /// save data
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async System.Threading.Tasks.Task<MessageModel<string>> SaveData(ShopInfoDTO shopinfo)
        {
            var userId = this.GetLoginUserId();
            shopinfo.SellerId = userId;
            return await _shopInfoService.SaveDataAsync(shopinfo);
        }
    }
}
