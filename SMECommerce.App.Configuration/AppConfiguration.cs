using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SMECommerce.Databases.DbContexts;
using SMECommerce.Repositories;
using SMECommerce.Repositories.Abstractions;
using SMECommerce.services;
using SMECommerce.services.Abstractions;

namespace SMECommerce.App.Configurations
{
     public class AppConfiguration
    {
        //IServiceCollection services
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<SMECommerceDbContext>(c => c.UseSqlServer(@"Server=DESKTOP-QSU3AFC;Database=SMECommerceDB_assignment; Integrated Security=true"));
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<ICategoryService, CategoryService>();
            services.AddTransient<IProductRepository, ProductRepository>();
            //services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IProductService, ProductService>();
        }
    }
}
