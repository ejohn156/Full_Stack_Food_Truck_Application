using System;
using Full_Stack_Food_Truck_Application.Data.Entities;
using Full_Stack_Food_Truck_Application.Data.Repositories;
using Full_Stack_Food_Truck_Application.Models.CoordinateModel;

namespace Full_Stack_Food_Truck_Application.Services
{
    public interface ICoordinateService
    {
        Coordinates CreateCoordinate(Coordinates coord);
        void DeleteCoordinate(string Id);
    }
    public class CoordinateService : ICoordinateService
    {
        private ICoordinateRepository _coordinateRepo;
        public CoordinateService(ICoordinateRepository coordinateRepo)
        {
            _coordinateRepo = coordinateRepo;
        }
        public Coordinates CreateCoordinate(Coordinates coord)
        {
            try
            {
                return _coordinateRepo.CreateCoordinate(coord);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void DeleteCoordinate(string Id)
        {
            try
            {
                _coordinateRepo.DeleteCoordinate(Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
