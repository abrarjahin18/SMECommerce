using Microsoft.EntityFrameworkCore;
using SMECommerce.Databases.DbContexts;
using SMECommerce.Models.EntityModels;
using SMECommerce.Repositories.Abstractions;
using System.Collections.Generic;
using System.Linq;

namespace SMECommerce.Repositories
{
    public class CategoryRepository: Repository<Category>,ICategoryRepository
    {
        SMECommerceDbContext db;
        public CategoryRepository(SMECommerceDbContext db):base(db)
        {
            this.db=db;
        }
        public override Category GetById(int id)
        {
            return db.Categories.FirstOrDefault(c => c.Id == id);
        }

        public override ICollection<Category> GetAll()
        {
            return db.Categories.Include(c => c.Items).ToList();
        }

        public override bool Add(Category category)
        {
            db.Categories.Add(category);

            int successCount = db.SaveChanges();

            return successCount > 0;

        }

        public override bool Update(Category category)
        {
            db.Categories.Update(category);
            return db.SaveChanges() > 0;
        }

        public override bool Remove(Category category)
        {
            db.Categories.Remove(category);
            return db.SaveChanges() > 0;
        }


    }
}
