using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using SMECommerce.Models.EntityModels;

namespace SMECommerce.App.Models.ProductModels
{
    public class ProductCreate
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public string ProductCode { get; set; }
        public DateTime ManufacturerDate { get; set; }
        public double Price { get; set; }

        public int CategoryId { get; set; }
       
        public SelectList CategoryList { get; set; }

    }
}
