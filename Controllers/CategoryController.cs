using System;
using System.Collections.Generic;
using AutoMapper;
using Full_Stack_Food_Truck_Application.Data.Entities;
using Full_Stack_Food_Truck_Application.Helpers;
using Full_Stack_Food_Truck_Application.Models.CategoryModels;
using Full_Stack_Food_Truck_Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Full_Stack_Food_Truck_Application.Controllers
{
    [Authorize]
    public class CategoryController : APIController
    {
        private readonly ICategoryServices _categoryService;
        private readonly IMapper _mapper;
        
        public CategoryController(ICategoryServices categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }
        [HttpPost("Create")]
        public void CreateCategory(CreateCategoryModel newCategory)
        {
            var categoryToCreate = _mapper.Map<Category>(newCategory);
            _categoryService.CreateCategory(categoryToCreate);
        }
        [HttpDelete("{id}")]
        public void deleteCategory(string Id)
        {
            _categoryService.deleteCategory(Id);

        }
        [HttpPut("")]
        public void updateCategory(UpdateCategoryModel updatedCategory)
        {
            var categoryToUpdate = _mapper.Map<Category>(updatedCategory);
            _categoryService.updateCategory(categoryToUpdate);
        }
        [HttpGet("")]
        public IActionResult getAllCategories()
        {
            return Ok(_mapper.Map<List<GetCategoryModel>>(_categoryService.getAllCategories()));
        }
        [HttpGet("{categoryName}")]
        public IActionResult getAllCategoriesByName(string categoryName)
        {
            
            return Ok(_mapper.Map<List<GetCategoryModel>>(_categoryService.getAllCategoriesByName(categoryName)));
               
        }
    }
}
