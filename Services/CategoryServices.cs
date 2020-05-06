using System;
using System.Collections.Generic;
using Full_Stack_Food_Truck_Application.Data.Entities;
using Full_Stack_Food_Truck_Application.Data.Repositories;

namespace Full_Stack_Food_Truck_Application.Services
{
    public interface ICategoryServices
    {
        void CreateCategory(Category newCategory);
        void deleteCategory(string Id);
        IEnumerable<Category> getAllCategories();
        IEnumerable<Category> getAllCategoriesByName(string categoryName);
        void updateCategory(Category updatedCategory);
    }
    public class CategoryServices : ICategoryServices
    {
        private ICategoryRepository _categoryRepo;
        public CategoryServices(ICategoryRepository categoryRepository)
        {
            _categoryRepo = categoryRepository;
        }
        public void CreateCategory(Category newCategory)
        {
            Console.WriteLine(newCategory);
            _categoryRepo.CreateCategory(newCategory);
        }
        public void deleteCategory(string Id)
        {
            _categoryRepo.deleteCategory(Id);

        }
        public void updateCategory(Category updatedCategory)
        {
            _categoryRepo.updateCategory(updatedCategory);
        }

        public IEnumerable<Category> getAllCategories()
        {
            return _categoryRepo.getAllCategories();
        }
        public IEnumerable<Category> getAllCategoriesByName(string categoryName)
        {
            return _categoryRepo.getAllCategoriesByName(categoryName);
        }

    }
}
