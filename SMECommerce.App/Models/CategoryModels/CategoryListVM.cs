using SMECommerce.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMECommerce.App.Models.CategoryModels
{
    public class CategoryListVM
    {
        public string Title { get; set; }
        public string Description { get; set; }

        public List<Category> CategoryList { get; set; }
    }
}
