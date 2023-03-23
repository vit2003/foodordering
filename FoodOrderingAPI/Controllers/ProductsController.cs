using Domain.Repositories.Interface;
using FoodOrderingAPI.Resources;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Repository.Models;
using Repository.RequestObj.Basic;
using Repository.RequestObj.Product;
using Service.DTOs.BasicRes;
using Service.Implement;
using Service.Interface;

namespace FoodOrderingAPI.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductServices _productServices;
        private readonly IRepositoryManager _repository;

        public ProductsController(IProductServices productServices, IRepositoryManager repository)
        {
            _productServices = productServices;
            _repository = repository;
        }
        #region Create new product
        /// <summary>
        /// Create new product
        /// </summary>
        /// <param name="newProduct"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("createproducts")]
        [AllowAnonymous]
        public async Task<IActionResult> createProduct(CreateProductParam newproduct)
        {
            var id = await _productServices.CreateProduct(newproduct);
            await _repository.SaveAsync();
            return (Ok(new {ProductId = id}));
        }
        #endregion

        #region Update product information
        /// <summary>
        /// Update product information (Role: Admin)
        /// </summary>
        /// <param name="ProductName"></param>
        /// <param name="ProductImageUrl"></param>
        /// <param name="ProductDescription"></param>
        /// <param name="Quantity"></param>
        /// <param name="Price"></param>
        /// <param name="IsDeleted"></param>
        /// <param name="CategoryId"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("update/{ProductId}")]
        //Tạo mới Product ko cần truyền product id. IsDeleted khi tạo tự set = false luôn chứ nếu tạo mà set bằng true thì tạo làm gì.
        //Sau này tạo một object rồi để nó vào parameter của hàm chứ không để nhiều param như v được.
        public async Task<IActionResult> UpdateProduct(string ProductName, string ProductImageUrl, string ProductDescription, int CategoryId, int Quantity, double Price)
        {

            //Code chưa sửa
            //await _repository.Product.Update(ProductId, ProductName, ProductImageUrl, ProductDescription, CategoryId, Quantity, Price, IsDeleted, trackChanges: false);

            var product = new Product
            {
                CategoryId = CategoryId,
                ProductName = ProductName,
                IsDeleted = false,
                Price = Price,
                ProductDescription = ProductDescription,
                ProductImageUrl = ProductImageUrl,
                Quantity = Quantity
            };

            await _repository.SaveAsync();

            return Ok("Save changes success");
        }
        #endregion

        [HttpGet]
        [Route("category/{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetProduct([FromQuery] PagingRequest parameters, int id)
        {
            var param = new GetProductParam
            {
                CategoryId = id,
                PageCurrent = parameters.PageCurrent,
                PageSize = parameters.PageSize
            };
            var data = await _productServices.GetByCategoryProduct(param);

            var result = new ResponseObj
            {
                Data = data,
                ResponseCode = ResponseCode.Success
            };

            return Ok(result);
        }

        [HttpDelete]
        [Route("{productId}")]
        public async Task<IActionResult> DeleteProduct(int productId)
        {
            await _productServices.Delete(productId);

            return Ok(new { message = "Delete success" });
        }

        [HttpGet]
        [Route("{productId}/details")]
        public async Task<IActionResult> DetailsProduct(int productId)
        {
            var result = await _productServices.GetDetail(productId);

            return Ok(result);
        }
    }
}
