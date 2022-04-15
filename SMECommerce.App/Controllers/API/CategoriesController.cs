using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SMECommerce.App.Models.CategoryModels;
using SMECommerce.Models.EntityModels;
using SMECommerce.services.Abstractions;

namespace SMECommerce.App.Controllers.API
{
    [Route("Api/categories")]
    [ApiController]
    public class CategoriesController:ControllerBase
    {
        ICategoryService categoryService;
        IMapper mapper;
        public CategoriesController(ICategoryService categoryService, IMapper mapper)
        {
            this.categoryService = categoryService;
            this.mapper = mapper;
        }
        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult GetCategories()
        {
            var categories = categoryService.GetAll();
          
            if (categories==null)
            {
                return NoContent();
            }

            var categoryResults = mapper.Map<IList<CategoryResult>>(categories);

            return Ok(categoryResults);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int? id)
        {
            if(id==null)
            {
                return BadRequest("Please provide id");
            }
            var category = categoryService.GetById((int)id);
            if (category == null)
            {
                return NotFound();
            }
            var categoryResult = mapper.Map<CategoryResult>(category);

            return Ok(categoryResult);
        }
        [HttpPost]
         public IActionResult post([FromBody]CategoryCreate model)
        {
            if(ModelState.IsValid)
            {
                var category = mapper.Map<Category>(model);

                var isSuccess = categoryService.Add(category);

                if(isSuccess)
                {
                    return Created($"Api/categories/{category.Id}",category);
                }
            }
            return BadRequest(ModelState);
        }
        [HttpPut("{id}")]
        public IActionResult Put(int? id,[FromBody]CategoryEditVm model)
        {
            if(id==null)
            {
                return BadRequest("please provide id");
            }

            var category = categoryService.GetById((int)id);

            if(category==null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                mapper.Map(model, category);

                bool isSuccess = categoryService.Update(category);
                if(isSuccess)
                {
                    return Ok(category);
                }
            }
            return BadRequest(ModelState);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return BadRequest("Please provide id");
            }
            var category = categoryService.GetById((int)id);
            if (category == null)
            {
                return NotFound();
            }
            categoryService.Remove(category);

            return Ok();
        }
    }
}
