using BMES_API_Project.Messages.Request.Product;
using BMES_API_Project.Messages.Response.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BMES_API_Project.Services
{
    public interface iCatalogueService
    {
        FetchProductResponse FetchProducts(FetchProductRequest fetchProductsRequest);
    }
}
