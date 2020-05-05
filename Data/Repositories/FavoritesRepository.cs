using System;
using System.Collections.Generic;
using System.Linq;
using Full_Stack_Food_Truck_Application.Data.Entities;
using Full_Stack_Food_Truck_Application.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace Full_Stack_Food_Truck_Application.Data.Repositories
{
    public interface IFavoritesRepository
    {
        Favorite CreateFavorite(Favorite fav);
        void DeleteFavorite(string Id);
        IEnumerable<Favorite> GetAllFavorites();
        Favorite GetFavorite(string Id);
    }
    public class FavoritesRepository : IFavoritesRepository
    {
        private DataContext _context;

        public FavoritesRepository(DataContext context)
        {
            _context = context;
        }

        public IEnumerable<Favorite> GetAllFavorites()
        {
            return _context.Favorites.Include("Coordinates");
        }
        public Favorite GetFavorite(string Id)
        {
            return _context.Favorites.Include("Coordinates").Where(x => x.Id.Equals(Id)).SingleOrDefault();
        }
        public Favorite CreateFavorite(Favorite fav)
        {

            _context.Favorites.Add(fav);
            _context.SaveChanges();
            return fav;
        }
        //will work to update favorite at another time, as data within this will come from yelp API
        //public void UpdateFavorite(Favorite fav)
        //{
        //    var favToUpdate = _context.Favorites.Find(fav.Id);
        //    favToUpdate.

        //}
        public void DeleteFavorite(string Id)
        {
            var FavoriteToDelete = _context.Favorites.Find(Id);
            if (FavoriteToDelete != null)
            {
                _context.Favorites.Remove(FavoriteToDelete);
                _context.SaveChanges();
            }

        }
    }
}