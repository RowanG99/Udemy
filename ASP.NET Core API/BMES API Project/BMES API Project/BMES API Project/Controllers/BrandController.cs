using BMES_API_Project.Messages.Request.Brand;
using BMES_API_Project.Messages.Response.Brand;
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
    public class BrandController : ControllerBase
    {
        private readonly iBrandService _brandService; 

        public BrandController(iBrandService brandService)
        {
            _brandService = brandService; 
        }

        [HttpGet(template:"{id}")]
        public ActionResult<GetBrandResponse> GetBrand(long id)
        {
            var getBrandRequest = new GetBrandRequest
            {
                Id = id
            };
            var getBrandResponse = _brandService.GetBrand(getBrandRequest);
            return getBrandResponse; 
        }

        [HttpGet()]
        public ActionResult<FetchBrandResponse> GetBrands()
        {
            var fetchBrandsRequest = new FetchBrandRequest { };
            var fetchBrandsResponse = _brandService.GetBrands(fetchBrandsRequest);
            return fetchBrandsResponse; 
        }

        [HttpPost]
        public ActionResult<CreateBrandResponse> PostBrand(CreateBrandRequest createBrandRequest)
        {
            var createBrandResponse = _brandService.SaveBrand(createBrandRequest);
            return createBrandResponse;
        }

        [HttpPut(template:"{id}")]
        public ActionResult<UpdateBrandResponse> PutBrand(UpdateBrandRequest updateBrandRequest)
        {
            var updateBrandResponse = _brandService.EditBrand(updateBrandRequest);
            return updateBrandResponse;
        }

        [HttpDelete(template:"{id}")]
        public ActionResult<DeleteBrandResponse> DeleteBrand(long id)
        {
            var deletedBrandRequest = new DeleteBrandRequest
            {
                Id = id
            };
            var deleteBrandResponse = _brandService.DeleteBrand(deletedBrandRequest);
            return deleteBrandResponse;
        }
    }
}
