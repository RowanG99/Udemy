using BMES_API_Project.Messages.Request.Product;
using BMES_API_Project.Messages.Response.Product;
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
    public class ProductController : ControllerBase
    {
        private readonly iProductService _productService;
        public ProductController(iProductService productService)
        {
            _productService = productService;
        }

        [HttpGet(template: "{id}")]
        public ActionResult<GetProductResponse> GetProduct(long id)
        {
            var getProductRequest = new GetProductRequest
            {
                Id = id
            };
            var getProductResponse = _productService.GetProduct(getProductRequest);
            return getProductResponse;
        }

        [HttpGet(template: "{categorySlug}/{brandSlug}/{page}/{productsPerPage}")]
        public ActionResult<FetchProductResponse> GetProducts(string categorySlug, string brandSlug, int page, int productsPerPage)
        {
            var fetchProductsRequest = new FetchProductRequest
            {
                PageNumber = page,
                ProductsPerPage = productsPerPage,
                CategorySlug = categorySlug,
                BrandSlug = brandSlug
            };

            var fetchProductsResponse = _productService.GetProducts(fetchProductsRequest);
            return fetchProductsResponse;
        }

        [HttpPost]
        public ActionResult<CreateProductResponse> PostProduct(CreateProductRequest createProductRequest)
        {
            var createProductResponse = _productService.SaveProduct(createProductRequest);
            return createProductResponse;
        }

        [HttpPut(template: "{id}")]
        public ActionResult<UpdateProductResponse> PutProduct(UpdateProductRequest updateProductRequest)
        {
            var updateProductResponse = _productService.EditProduct(updateProductRequest);
            return updateProductResponse;
        }

        [HttpDelete(template:"{id}")]
        public ActionResult<DeleteProductResponse> DeleteProduct(long id)
        {
            var deleteProductRequest = new DeleteProductRequest
            {
                Id = id
            };
            var deleteProductResponse = _productService.DeleteProduct(deleteProductRequest);
            return deleteProductResponse;
        }
    }
}
