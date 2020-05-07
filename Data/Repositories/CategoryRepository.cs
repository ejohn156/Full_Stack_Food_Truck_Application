using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        Task DeleteCategoriesOfFavorite(string Id);
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
        public async Task DeleteCategoriesOfFavorite(string Id)
        {

            try
            {
                var categoriesToRemove = _context.Categories.ToList().Where(s => s.Favorite_Id == Id);
                _context.Categories.RemoveRange(categoriesToRemove);
                await _context.SaveChangesAsync();

            }
            catch (Exception ex) {
                throw ex;
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
