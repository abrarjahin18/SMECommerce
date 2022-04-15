using System;
using System.Collections.Generic;
using System.Text;
using SMECommerce.Models.EntityModels;
using SMECommerce.Repositories.Abstractions;
using SMECommerce.services.Abstractions;

namespace SMECommerce.services
{
    public class ProductService: Service<Item>,IProductService
    {
        IProductRepository productrepository;
        public ProductService(IProductRepository productrepository):base(productrepository)
        {
            this.productrepository = productrepository;
        }

        public override bool Add(Item item)
        {
            return productrepository.Add(item);
        }

        public override ICollection<Item> GetAll()
        {
            return productrepository.GetAll();
        }

        public override Item GetById(int id)
        {
            return productrepository.GetById(id);
        }

        public Category GetCategoryName(int id)
        {
            return productrepository.GetCategoryName(id);
        }

        public List<Category> GetCategoryname()
        {
            return productrepository.GetCategoryname();
        }

        public override bool Remove(Item item)
        {
            return productrepository.Remove(item);
        }

        public override bool Update(Item item)
        {
            return productrepository.Update(item);
        }
    }
}
