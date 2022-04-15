using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SMECommerce.Databases.DbContexts;
using SMECommerce.Models.EntityModels;
using SMECommerce.Repositories.Abstractions;

namespace SMECommerce.Repositories
{
    public class ProductRepository: Repository<Item>, IProductRepository
    {
        SMECommerceDbContext db;
        public ProductRepository(SMECommerceDbContext db):base(db)
        {
            this.db = db;
        }
        public override Item GetById(int id)
        {
            return db.Products.FirstOrDefault(c => c.Id == id);
        }

        public Category GetCategoryName(int id)
        {
            return db.Categories.FirstOrDefault(c => c.Id == id);
        }
        //public string GetAll()
        //{
        //    return "asd";
        //    //return db.Products.Include(c => c.Items).ToList();
        //}
        public override ICollection<Item> GetAll()
        {
            return db.Products.ToList();
        }
        public List<Category> GetCategoryname()
        {
            return db.Products.Select(p => new Category() { Name = p.Name }).ToList();
        }

        public override bool Add(Item item)
        {
            db.Products.Add(item);

            int successCount = db.SaveChanges();

            return successCount > 0;

        }

        public override bool Update(Item item)
        {
            db.Products.Update(item);
            return db.SaveChanges() > 0;
        }

        public override bool Remove(Item item)
        {
            db.Products.Remove(item);
            return db.SaveChanges() > 0;
        }

    }
}
