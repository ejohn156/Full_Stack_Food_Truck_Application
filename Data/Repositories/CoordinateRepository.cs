using System;
using Full_Stack_Food_Truck_Application.Data.Entities;
using Full_Stack_Food_Truck_Application.Helpers;
using Full_Stack_Food_Truck_Application.Models.CoordinateModel;

namespace Full_Stack_Food_Truck_Application.Data.Repositories
{
    public interface ICoordinateRepository
    {
        Coordinates CreateCoordinate(Coordinates coord);
        void DeleteCoordinate(string Id);
    }
    public class CoordinateRepository : ICoordinateRepository
    {
        private DataContext _context;

        public CoordinateRepository(DataContext context)
        {
            _context = context;
        }

        public Coordinates CreateCoordinate(Coordinates coord)
        {
           
            _context.Coordinates.Add(coord);
            _context.SaveChanges();
            return coord;

        }
        public void DeleteCoordinate(string Id)
        {
            var coordinateToDelete = _context.Coordinates.Find(Id);
            if (coordinateToDelete != null)
            {
                _context.Coordinates.Remove(coordinateToDelete);
                _context.SaveChanges();
            }
        }
    }
}
