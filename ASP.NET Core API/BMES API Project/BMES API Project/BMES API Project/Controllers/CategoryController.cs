using BMES_API_Project.Messages.Request.Category;
using BMES_API_Project.Messages.Response.Category;
using BMES_API_Project.Services.Implementations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BMES_API_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly iCategoryService _categoryService; 

        public CategoryController(iCategoryService categoryService)
        {
            _categoryService = categoryService; 
        }

        [HttpGet(template:"{id}")]
        public ActionResult<GetCategoryResponse>GetCategory(long id)
        {
            var getCategoryRequest = new GetCategoryRequest
            {
                Id = id
            };
            var getCategoryResponse = _categoryService.GetCategory(getCategoryRequest);
            return getCategoryResponse;
        }

        [HttpGet]
        public ActionResult<FetchCategoryResponse> GetCategories()
        {
            var fetchCategoryRequest = new FetchCategoryRequest { };
            var fetchCategoriesResponse = _categoryService.GetCategories(fetchCategoryRequest);
            return fetchCategoriesResponse;
        }

        [HttpPost]
        public ActionResult<CreateCategoryResponse> PostCategory(CreateCategoryRequest createCategoryRequest)
        {
            var createCategoryResponse = _categoryService.SaveCategory(createCategoryRequest);
            return createCategoryResponse;
        }

        [HttpPut]
        public ActionResult<UpdateCategoryResponse>PutCategory(UpdateCategoryRequest updateCategoryRequest)
        {
            var updateCategoryResponse = _categoryService.EditCategory(updateCategoryRequest);
            return updateCategoryResponse; 
        }

        [HttpDelete]
        public ActionResult<DeleteCategoryResponse>DeleteCategory(long id)
        {
            var deleteCategoryRequest = new DeleteCategoryRequest
            {
                Id = id
            };
            var deleteCategoryResponse = _categoryService.DeleteCategory(deleteCategoryRequest);
            return deleteCategoryResponse;
        }
    }
}
