using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Full_Stack_Food_Truck_Application.Data.Entities;
using Full_Stack_Food_Truck_Application.Data.Repositories;

namespace Full_Stack_Food_Truck_Application.Services
{
    public interface IFavoriteService
    {
        Favorite CreateFavorite(Favorite favoriteToCreate);
        Task DeleteFavorite(string Id);
        Task DeleteListOfFavorites(List<string> listOfFavoriteIds);
        IEnumerable<Favorite> GetAllFavorites();
        Favorite getFavorite(string Id);
    }
    public class FavoriteService : IFavoriteService
    {
        private IFavoritesRepository _favRepo;
        private ICategoryServices _categoryService;
        private ICoordinateService _coordinateService;

        public FavoriteService(IFavoritesRepository favRepo, ICategoryServices categoryService, ICoordinateService coordinateService)
        {
            _favRepo = favRepo;
            _categoryService = categoryService;
            _coordinateService = coordinateService;
        }

        public Favorite getFavorite(string Id)
        {
            try
            {
                return _favRepo.GetFavorite(Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public IEnumerable<Favorite> GetAllFavorites()
        {
            try
            {
                return _favRepo.GetAllFavorites();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Favorite CreateFavorite(Favorite favoriteToCreate)
        {
            try
            {
                return _favRepo.CreateFavorite(favoriteToCreate);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task DeleteFavorite(string Id)
        {
            try
            {
                var favToDelete = getFavorite(Id);
                var coordinateId = favToDelete.Coordinate_Id;

                await _categoryService.DeleteCategoriesOfFavorite(Id);

                _favRepo.DeleteFavorite(Id);
                _coordinateService.DeleteCoordinate(coordinateId);

                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task DeleteListOfFavorites(List<string> listOfFavoriteIds)
        {
            try
            {

                foreach (string Id in listOfFavoriteIds)
                {
                    await DeleteFavorite(Id);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
