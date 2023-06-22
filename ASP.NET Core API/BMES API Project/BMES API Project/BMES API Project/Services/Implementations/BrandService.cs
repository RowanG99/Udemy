﻿using BMES_API_Project.Messages;
using BMES_API_Project.Messages.Request.Brand;
using BMES_API_Project.Messages.Request.Category;
using BMES_API_Project.Messages.Response.Brand;
using BMES_API_Project.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BMES_API_Project.Services.Implementations
{
    public class BrandService:iBrandService
    {
        private readonly iBrandRepo _brandRepository;
        private MessageMapper _messageMapper; 

        public BrandService(iBrandRepo brandRepo)
        {
            _brandRepository = brandRepo;
            _messageMapper = new MessageMapper(); 
        }

        public CreateBrandResponse SaveBrand(CreateBrandRequest brandRequest)
        {
            var brand = _messageMapper.MapToBrand(brandRequest.Brand);
            _brandRepository.SaveBrand(brand);
            var brandDto = _messageMapper.MapToBrandDto(brand);

            var createBrandResponse = new CreateBrandResponse
            {
                Brand = brandDto
            };

            return createBrandResponse;
        }

        public GetBrandResponse GetBrand(GetBrandRequest getBrandRequest)
        {
            GetBrandResponse getBrandResponse = null;
            if (getBrandRequest.Id > 0)
            {
                var brand = _brandRepository.FindBrandById(getBrandRequest.Id);
                var brandDto = _messageMapper.MapToBrandDto(brand);

                getBrandResponse = new GetBrandResponse
                {
                    Brand = brandDto
                };
            }
            return getBrandResponse;
        }

        public FetchBrandResponse GetBrands(FetchBrandRequest fetchBrandsRequest)
        {
            var brands = _brandRepository.GetAllBrands();
            var brandDtos = _messageMapper.MapToBrandDtos(brands);

            return new FetchBrandResponse
            {
                Brands = brandDtos
            };
        }

        public DeleteBrandResponse DeleteBrand(DeleteBrandRequest deleteBrandRequest)
        {
            var brand = _brandRepository.FindBrandById(deleteBrandRequest.Id);
            _brandRepository.DeleteBrand(brand);
            var brandDto = _messageMapper.MapToBrandDto(brand);

            return new DeleteBrandResponse
            {
                Brand = brandDto
            };
        }

        public UpdateBrandResponse EditBrand(UpdateBrandRequest updateBrandRequest)
        {
            UpdateBrandResponse updateBrandResponse = null; 
            if(updateBrandRequest.Id == updateBrandRequest.Brand.Id)
            {
                var brand = _messageMapper.MapToBrand(updateBrandRequest.Brand);
                _brandRepository.UpdateBrand(brand);
                var brandDto = _messageMapper.MapToBrandDto(brand);

                updateBrandResponse = new UpdateBrandResponse
                {

                }; 
            }
            return updateBrandResponse;
        }
    }
}
