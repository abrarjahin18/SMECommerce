using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SMECommerce.App.Models.ProductModels;
using SMECommerce.Models.EntityModels;
using SMECommerce.Repositories;
using SMECommerce.services;
using SMECommerce.services.Abstractions;

namespace SMECommerce.App.Controllers
{
    public class productController : Controller
    {
        //ProductRepository _productRepository = new ProductRepository();
        IProductService productservice;
        ICategoryService categoryservice;
        IMapper mapper;
        //public void function(ICategoryService _categoryservice)
        // {
        //     categoryservice = _categoryservice;
        // }
        public productController(IProductService productservice, ICategoryService categoryservice, IMapper mapper)
        {
            this.productservice = productservice;
            this.categoryservice = categoryservice;
            this.mapper = mapper;
        }      
        public IActionResult ProductCreate()
        {
            //CategoryRepository _categoryRepository= new CategoryRepository();
           

            ProductCreate model = new ProductCreate();

            List<Category> CategoryList = (List<Category>)categoryservice.GetAll();
            model.CategoryList = new SelectList(CategoryList,"Id", "Name");
           
            return View(model);
          
        }

        [HttpPost]
        public IActionResult ProductCreate(ProductCreate model)
        {

            if (ModelState.IsValid)
            {
                //string b = model.CategoryName;
                //var categoryname = _productRepository.GetCategoryId(b);
                //var item = new Item()
                //{
                //    Name = model.Name,
                //    Description = model.Description,
                //    ProductCode = model.ProductCode,
                //    ManufacturerDate = model.ManufacturerDate,
                //    Price = model.Price,
                //    CategoryId = model.CategoryId
                //};
                var item = mapper.Map<Item>(model);
                var isAdded = productservice.Add(item);

                if (isAdded)
                {
                    return RedirectToAction("ProductList");
                }
            }

            return View();
        }
        
        public IActionResult ProductList()
        {
            var itemList = productservice.GetAll();

            var productShow = new productShow()
            {
                Title = "product Overview",
                Description = "You can manage products from this page, you can create update, delete product...",
                ItemList = itemList.ToList()
            };

                return View(productShow);
          //  return View();
        }

        public IActionResult ProductEdit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("ProductList");
            }

            var product = productservice.GetById((int)id);

            if (product == null)
            {
                return RedirectToAction("ProductList");
            }
            //CategoryRepository _categoryRepository= new CategoryRepository();
            List<Category> CategoryList = (List<Category>)categoryservice.GetAll();
         
            var productEdit = new ProductEdit()
            {
                Id = product.Id,
                Name = product.Name,
                ProductCode = product.ProductCode,
                Description = product.Description,
                ManufacturerDate=product.ManufacturerDate,
                Price=product.Price,
              //  CategoryId= (int)product.CategoryId,
                CategoryList = new SelectList(CategoryList, "Id", "Name")
        };
         
            return View(productEdit);

        }

        [HttpPost]
        public IActionResult ProductEdit(ProductEdit model)
        {
        //    if (id == null)
        //    {
        //        return RedirectToAction("ProductList");
        //    }

        //    var product = _productRepository.GetById((int)id);

        //    if (product == null)
        //    {
        //        return RedirectToAction("ProductList");
        //    }
            //CategoryRepository _categoryRepository = new CategoryRepository();
            //List<Category> CategoryList = (List<Category>)_categoryRepository.GetAll();

            //var productEdit = new ProductEdit()
            //{
            //    Id = product.Id,
            //    Name = product.Name,
            //    ProductCode = product.ProductCode,
            //    Description = product.Description,
            //    ManufacturerDate = product.ManufacturerDate,
            //    Price = product.Price,
            //    CategoryId = (int)product.CategoryId,
            //    CategoryList = new SelectList(CategoryList, "Id", "Name")
            //};
               if (ModelState.IsValid)
            {
               // CategoryRepository _categoryRepository = new CategoryRepository();
                List<Category> CategoryList = (List<Category>)categoryservice.GetAll();

                //var productEdit = new Item()
                //{
                //    Id = model.Id,
                //    Name = model.Name,
                //    ProductCode = model.ProductCode,
                //    Description = model.Description,
                //    ManufacturerDate = model.ManufacturerDate,
                //    Price = model.Price,
                //    CategoryId = model.CategoryId,
                //   // CategoryList = new SelectList(CategoryList, "Id", "Name")
                //};
                //        var category = new Category()
                //        {
                //            Id = model.Id,
                //            Name = model.Name,
                //            Code = model.Code,
                //            Description = model.Description
                //        };

                var productEdit = mapper.Map<Item>(model);
                bool isUpdated = productservice.Update(productEdit);
                if (isUpdated)
                {
                    return RedirectToAction("ProductList");
                }
            }

             return View();
        }

        public IActionResult ProductDelete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("ProductList");
            }

            var product = productservice.GetById((int)id);
            if (product == null)
            {
                return RedirectToAction("ProductList");
            }

            bool isRemoved = productservice.Remove(product);

            if (isRemoved)
            {
                return RedirectToAction("ProductList");
            }

            return RedirectToAction("ProductList");
        }
        public IActionResult ProductDetails(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("ProductList");
            }

            var product = productservice.GetById((int)id);
            if (product == null)
            {
                return RedirectToAction("ProductList");
            }

            //  bool isRemoved = _productRepository.Remove(product);
            ProductEdit model = new ProductEdit();
            model.Name = product.Name;
            model.ProductCode = product.ProductCode;
            model.Price = product.Price;
            model.Description=product.Description;
            model.ManufacturerDate=product.ManufacturerDate;
            return View(model);
        }


    }
}
