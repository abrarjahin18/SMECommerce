using System;
using System.Collections.Generic;
using System.Text;
using SMECommerce.Models.EntityModels;

namespace SMECommerce.services.Abstractions
{
    public interface IProductService: IService<Item>
    {
      
        public Category GetCategoryName(int id);
          
        public List<Category> GetCategoryname();
      
     
        
    }
}
