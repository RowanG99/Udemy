using BMES_API_Project.Messages.DTOs.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BMES_API_Project.Messages.Request.Product
{
    public class UpdateProductRequest
    {
        public int Id { get; set; }
        public ProductDTO Product { get; set; }
    }
}
