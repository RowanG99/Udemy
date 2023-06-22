using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BMES_API_Project.Messages.Request.Product
{
    public class FetchProductRequest
    {
        public int PageNumber { get; set; }
        public int ProductsPerPage { get; set; }
        public string CategorySlug { get; set; }
        public string BrandSlug { get; set; }
    }
}
