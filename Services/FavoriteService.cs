using System;
using System.Collections.Generic;
using Full_Stack_Food_Truck_Application.Data.Entities;
using Full_Stack_Food_Truck_Application.Data.Repositories;

namespace Full_Stack_Food_Truck_Application.Services
{
    public interface IFavoriteService
    {
        Favorite CreateFavorite(Favorite favoriteToCreate);
        void DeleteFavorite(string Id);
        IEnumerable<Favorite> GetAllFavorites();
        Favorite getFavorite(string Id);
    }
    public class FavoriteService : IFavoriteService
    {
        private IFavoritesRepository _favRepo;
        public FavoriteService(IFavoritesRepository favRepo)
        {
            _favRepo = favRepo;
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
        public void DeleteFavorite(string Id)
        {
            try
            {
                _favRepo.DeleteFavorite(Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
