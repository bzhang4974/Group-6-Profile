using Group6_Profile.DTO.DTO;
using Group6_Profile.DTO.MessageBody;
using Group6_Profile.Service.Service;
using Microsoft.AspNetCore.Mvc;

namespace Group6_Profile.Web.Controllers
{ /// <summary>
  /// Profile
  /// </summary>
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ProductController : ControllerBase
    {
        private readonly ProductService _productService;
        public ProductController(ProductService productService)
        {
            _productService = productService;
        }
        /// <summary>
        /// Add Product
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<MessageModel<string>> AddProduct(ProductDTO product)
        {
            return await _productService.Add(product);
        }
        /// <summary>
        ///  Edit Product
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<MessageModel<string>> EditProduct(ProductDTO product)
        {
            return await _productService.Edit(product);
        }
        /// <summary>
        ///  Delete Product
        /// </summary>
        /// <returns></returns>
        [HttpDelete]
        public MessageModel<string> DeleteProduct(string pid)
        {
            return _productService.Delete(pid);
        }
    }
}
