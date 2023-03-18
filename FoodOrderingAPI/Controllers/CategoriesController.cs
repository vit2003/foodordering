﻿using Domain.Repositories.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repository.Models;
using Service.Interface;

namespace FoodOrderingAPI.Controllers
{
    [Route("api/categories")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly ICategoriesServices _categoriesServices;

        public CategoriesController(IRepositoryManager repository, ICategoriesServices categoriesServices)
        {
            _repository = repository;
            _categoriesServices = categoriesServices;
        }

        #region Create new Category
        /// <summary>
        /// Create new category
        /// </summary>
        /// <param name="newcategory"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Create")]
        //ID của các object khi create ko cần truyền. Sau khi SaveAsync chạy nó sẽ tự gắn id cho object luôn. Cụ thể sau khi dòng 35 chạy. category create ở dòng 28 sẽ tự động có ID
        //Tạo folder Category, Tạo class CreateCategoryParam trong đó xong đặt vào dòng 27. Không làm thế này được.
        public async Task<IActionResult> createCategory(Category newcategory)
        {
            var category = new Category
            {
                CategoryName = newcategory.CategoryName,
                CategoryImageUrl = newcategory.CategoryImageUrl,
            };
            _repository.Category.Create(category);
            await _repository.SaveAsync();
            //Khúc này trả về id của category
            //return (Ok("New category added"));
            return Ok(new {CategoryId = category.CategoryId});
        }
        #endregion

        #region Update Category information
        /// <summary>
        /// Update information of category (Role: Admin)
        /// </summary>
        /// <param name="CategoryId"></param>
        /// <param name="name"></param>
        /// <param name="imageurl"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("Update/{CategoryId}")]
        //Tạo class UpdateCategoryParam
        public async Task<IActionResult> UpdateCategory(int CategoryId, string CategoryName, string ImageUrl)
        {

            //RepositoryBase đã có hàm update rồi. Chỉ cần gọi ra ở đây là được. Tạo object Model.Category rồi truyền nó vào ko cần viết lại hàm.
            //await _repository.Category.Update(CategoryId, CategoryName, ImageUrl, trackChanges: false);
            //Update thì phải get lên trước để kiểm tra xem có object chưa rồi mới cho update
            var category = await _repository.Category.FindByCondition(x => x.CategoryId == CategoryId, true).FirstOrDefaultAsync();
            if(category == null)
            {
                return Ok(new { UpdateStatus = "Invalid object" });
            }
            category.CategoryName = CategoryName;
            category.CategoryImageUrl= ImageUrl;
            _repository.Category.Update(category);
            await _repository.SaveAsync();

            return Ok("Save changes success");
        }
        #endregion

        [HttpGet]
        public async Task<IActionResult> GetListCategories()
        {
            var result = await _categoriesServices.GetListCategories();

            return Ok(result);
        }
    }
}