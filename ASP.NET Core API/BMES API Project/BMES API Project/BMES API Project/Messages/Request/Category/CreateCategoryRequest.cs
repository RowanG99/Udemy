﻿using BMES_API_Project.Messages.DTOs.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BMES_API_Project.Messages.Request.Category
{
    public class CreateCategoryRequest
    {
        public CategoryDTO Category { get; set; }
    }
}
