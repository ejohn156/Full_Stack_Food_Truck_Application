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
        public IActionResult CreateCategory([FromBody]CreateCategoryModel newCategory)
        {
            try
            {
                var categoryToCreate = _mapper.Map<Category>(newCategory);
                _categoryService.CreateCategory(categoryToCreate);
                return Ok("Category has been successfully created");
            }
            catch (AppException ex)
            { return BadRequest(new { message = ex.Message }); }
        }
        [HttpPost("Delete/{Id}")]
        public IActionResult deleteCategory(string Id)
        {
            try
            {
                _categoryService.deleteCategory(Id);
                return Ok("Category has been successfully deleted");
            }
            catch (AppException ex)
            { return BadRequest(new { message = ex.Message }); }

        }
        [HttpPut("")]
        public IActionResult updateCategory([FromBody]UpdateCategoryModel updatedCategory)
        {
            try
            {
                var categoryToUpdate = _mapper.Map<Category>(updatedCategory);
                _categoryService.updateCategory(categoryToUpdate);
                return Ok("Category has been successfully updated");
            }
            catch (AppException ex)
            { return BadRequest(new { message = ex.Message }); }
        }
        [HttpGet("")]
        public IActionResult getAllCategories()
        {
            try {
                return Ok(_mapper.Map<List<GetCategoryModel>>(_categoryService.getAllCategories()));
            }
            catch (AppException ex)
            { return BadRequest(new { message = ex.Message }); }
        }
        [HttpGet("{categoryName}")]
        public IActionResult getAllCategoriesByName(string categoryName)
        {

            try {
                return Ok(_mapper.Map<List<GetCategoryModel>>(_categoryService.getAllCategoriesByName(categoryName)));
            }
            catch (AppException ex)
            { return BadRequest(new { message = ex.Message }); }

        }
    }
}
