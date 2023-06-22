using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BMES_API_Project.Messages.Request.Category
{
    public class FetchCategoryRequest
    {
        public int PageNumber { get; set; }
        public int CategoriesPerPage { get; set; }
    }
}
