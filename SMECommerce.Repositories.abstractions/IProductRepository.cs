using System;
using System.Collections.Generic;
using System.Text;
using SMECommerce.Models.EntityModels;

namespace SMECommerce.Repositories.Abstractions
{
    public interface IProductRepository : IRepository<Item>
    {
       
        public Category GetCategoryName(int id);

        public List<Category> GetCategoryname();

       
    }
}
