using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SMECommerce.App.Models.CategoryModels;
using SMECommerce.Models.EntityModels;
using SMECommerce.Repositories;
using SMECommerce.services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMECommerce.App.Controllers
{
    public class CategoryController : Controller
    {
        ICategoryService _categoryservice;
        IMapper mapper;

        public CategoryController(ICategoryService _categoryservice, IMapper mapper)
        {
            this._categoryservice = _categoryservice;
            this.mapper = mapper;
        }
        public string Index()
        {
            return "This is the default controller";
        }

        
        public IActionResult Create()
        {
           return View();
        }

        [HttpPost]
        public IActionResult Create(CategoryCreate model)
        {
           
            if (ModelState.IsValid)
            {
                //var category = new Category()
                //{
                //    Name = model.Name,
                //    Description = model.Description,
                //    Code = model.Code
                //};
                var category = mapper.Map<Category>(model);
                var isAdded = _categoryservice.Add(category);

                if (isAdded)
                {
                    return RedirectToAction("List");
                }
            }

            return View();
        }


        public IActionResult Edit(int? id)
        {
            if(id == null)
            {
                return RedirectToAction("List");
            }

            var category = _categoryservice.GetById((int)id);

            if(category == null)
            {
                return RedirectToAction("List");
            }

            var categoryEditVm = new CategoryEditVm()
            {
                Id = category.Id,
                Name = category.Name,
                Code = category.Code,
                Description = category.Description
            };

            return View(categoryEditVm);

        }

        [HttpPost]
        public IActionResult Edit(CategoryEditVm model)
        {
            if (ModelState.IsValid)
            {
                //var category = new Category()
                //{
                //    Id = model.Id,
                //    Name = model.Name,
                //    Code = model.Code,
                //    Description = model.Description
                //};

                var category = mapper.Map<Category>(model);
                bool isUpdated = _categoryservice.Update(category);
                if (isUpdated)
                {
                    return RedirectToAction("List");
                }
            }

            return View();
        }


        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("List");
            }

            var category = _categoryservice.GetById((int)id);
            if(category == null)
            {
                return RedirectToAction("List");
            }

            bool isRemoved = _categoryservice.Remove(category);

            if (isRemoved)
            {
                return RedirectToAction("List");
            }

            return RedirectToAction("List");
        }


        public IActionResult List()
        {
            var categoryList = _categoryservice.GetAll();

            var categoryListVm = new CategoryListVM()
            {
                Title = "Category Overview",
                Description = "You can manage categories from this page, you can create update, delete categories...",
                CategoryList = categoryList.ToList()
            };

            return View(categoryListVm);
        }

        public string CategoryListCreate(CategoryCreate[] categories)
        {
            string data = "Category List Create"+Environment.NewLine;
            if(categories!=null && categories.Any())
            {
                foreach(var category in categories)
                {
                    data += $"Category Create: {category.Name} Code: {category.Code}"+Environment.NewLine;
                }
            }

            return data;
        }
    }
}
