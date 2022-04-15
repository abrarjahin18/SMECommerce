using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SMECommerce.Models.EntityModels;

namespace SMECommerce.App.Models.ProductModels
{
    public class productShow
    {
        public string Title { get; set; }
        public string Description { get; set; }

        public List<Item> ItemList { get; set; }
    }
}
