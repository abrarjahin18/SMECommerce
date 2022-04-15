using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using SMECommerce.App.Models.CategoryModels;
using SMECommerce.App.Models.ProductModels;
using SMECommerce.Models.EntityModels;

namespace SMECommerce.App.Profiles
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<CategoryCreate, Category>();
            CreateMap<CategoryListVM, Category>();
            CreateMap<CategoryEditVm, Category>();
            CreateMap<Category, CategoryCreate>();
            CreateMap<Category, CategoryListVM>();
            CreateMap<Category, CategoryEditVm>();

            CreateMap<ProductCreate, Item>();
            CreateMap<productShow, Item>();
            CreateMap<ProductEdit, Item>();
            CreateMap<Item, CategoryCreate>();
            CreateMap<Item, productShow>();
            CreateMap<Item, ProductEdit>();

            CreateMap<Category, CategoryResult>();
        }
    }
}
