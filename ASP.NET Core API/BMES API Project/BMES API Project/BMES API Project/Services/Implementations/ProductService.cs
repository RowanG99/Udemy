using BMES_API_Project.Messages;
using BMES_API_Project.Messages.Request.Product;
using BMES_API_Project.Messages.Response.Product;
using BMES_API_Project.Repository;
using BMES_API_Project.Services.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BMES_API_Project.Services
{
    public class ProductService:iProductService
    {
        private readonly iProductRepo _productRepository;
        private readonly iCatalogueService _catalogueService;
        private MessageMapper _messageMapper;
        public ProductService(iProductRepo productRepository, iCatalogueService catalogueService)
        {
            _productRepository = productRepository;
            _catalogueService = catalogueService;
            _messageMapper = new MessageMapper();
        }

        public CreateProductResponse SaveProduct(CreateProductRequest createProductRequest)
        {
            var product = _messageMapper.MapToProduct(createProductRequest.Product);
            _productRepository.SaveProduct(product);
            var productDto = _messageMapper.MapToProductDto(product);

            var createProductResponse = new CreateProductResponse
            {
                Product = productDto
            };

            return createProductResponse;
        }

        public UpdateProductResponse EditProduct(UpdateProductRequest updateProductRequest)
        {
            UpdateProductResponse updateProductResponse = null;

            if (updateProductRequest.Id == updateProductRequest.Product.Id)
            {
                var product = _messageMapper.MapToProduct(updateProductRequest.Product);
                _productRepository.UpdateProduct(product);
                var productDto = _messageMapper.MapToProductDto(product);

                updateProductResponse = new UpdateProductResponse
                {

                };
            }
            return updateProductResponse;
        }

        public GetProductResponse GetProduct(GetProductRequest getProductRequest)
        {
            GetProductResponse getProductResponse = null;

            if (getProductRequest.Id > 0)
            {
                var product = _productRepository.FindProductById(getProductRequest.Id);
                var productDto = _messageMapper.MapToProductDto(product);

                getProductResponse = new GetProductResponse
                {
                    Product = productDto
                };
            }

            return getProductResponse;
        }

        public FetchProductResponse GetProducts(FetchProductRequest fetchProductsRequest)
        {
            var fetchProductsResponse = _catalogueService.FetchProducts(fetchProductsRequest);
            return fetchProductsResponse;
        }

        public DeleteProductResponse DeleteProduct(DeleteProductRequest deleteProductRequest)
        {
            var product = _productRepository.FindProductById(deleteProductRequest.Id);
            _productRepository.DeleteProduct(product);
            var productDto = _messageMapper.MapToProductDto(product);

            return new DeleteProductResponse
            {
                Product = productDto
            };
        }
    }
}
