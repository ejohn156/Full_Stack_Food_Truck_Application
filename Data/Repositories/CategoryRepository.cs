using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Full_Stack_Food_Truck_Application.Data.Entities;
using Full_Stack_Food_Truck_Application.Helpers;
using Microsoft.EntityFrameworkCore;

namespace Full_Stack_Food_Truck_Application.Data.Repositories
{
    public interface ICategoryRepository
    {
        void CreateCategory(Category newCategory);
        void deleteCategory(string Id);
        IEnumerable<Category> getAllCategories();
        IEnumerable<Category> getAllCategoriesByName(string categoryName);
        void updateCategory(Category updatedCategory);
    }
    public class CategoryRepository : ICategoryRepository
    {
        private DataContext _context;

        public CategoryRepository(DataContext context)
        {
            _context = context;
        }

        public void CreateCategory(Category newCategory)
        {
            try
            {
                Console.WriteLine("category getting to repo");
                _context.Categories.Add(newCategory);
                _context.SaveChanges();
            }
            catch (Exception ex) {
                throw ex;
            }
        }
        public void deleteCategory(string Id)
        {
            var categoryToDelete = _context.Categories.Find(Id);
            if (categoryToDelete != null)
            {
                _context.Categories.Remove(categoryToDelete);
                _context.SaveChanges();
            }

        }
        public void updateCategory(Category updatedCategory)
        {
            var categoryToUpdate = _context.Categories.Find(updatedCategory.Id);
            if (categoryToUpdate != null)
            {
                if (!string.IsNullOrWhiteSpace(updatedCategory.Description))
                {
                    categoryToUpdate.Description = updatedCategory.Description;
                }
                
                    categoryToUpdate.Rating = updatedCategory.Rating;
                
                _context.Categories.Update(categoryToUpdate);
                _context.SaveChanges();
            }
        }

        public IEnumerable<Category> getAllCategories()
        {
            return _context.Categories;
        }
        public IEnumerable<Category> getAllCategoriesByName(string categoryName)
        {
            return _context.Categories.Include("Favorite").Where(category => category.Name == categoryName);
        }
    }
}
