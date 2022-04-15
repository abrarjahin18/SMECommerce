using System;
using System.Collections.Generic;
using System.Text;
using SMECommerce.Models.EntityModels;
using SMECommerce.Repositories;
using SMECommerce.Repositories.Abstractions;
using SMECommerce.services.Abstractions;

namespace SMECommerce.services
{
    public class CategoryService : Service<Category>, ICategoryService
    {

        ICategoryRepository _categoryRepository;
        public CategoryService(ICategoryRepository _categoryRepository):base(_categoryRepository)
        {
            this._categoryRepository = _categoryRepository;
        }
        public override Category GetById(int id)
        {
            return _categoryRepository.GetById(id);
        }
        public override ICollection<Category>GetAll()
        {
            return _categoryRepository.GetAll();
        }
        public override bool Add(Category category)
        {
            return _categoryRepository.Add(category);
        }
        public override bool Update (Category category)
        {
            return _categoryRepository.Update(category);
        }

       

        public override bool  Remove(Category category)
        {
            return _categoryRepository.Remove(category);
        }
    }
}
