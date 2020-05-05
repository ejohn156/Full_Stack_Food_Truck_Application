using System;
using System.Collections.Generic;
using System.Linq;
using Full_Stack_Food_Truck_Application.Data.Entities;
using Full_Stack_Food_Truck_Application.Data.Repositories;
using Full_Stack_Food_Truck_Application.Helpers;
namespace Full_Stack_Food_Truck_Application.Services
{

    public interface IUserServices
    {
        User Authenticate(string email, string password);
        User Create(User user, string password);
        void Delete(string id);
        IEnumerable<User> GetAll();
        User GetById(string id);
        void Update(User userParam, string password = null);
    }

    public class UserServices : IUserServices
    {
        private IUserRepository _userRepo;

        public UserServices(IUserRepository repo)
        {
            _userRepo = repo;
        }
        
        public User Authenticate(string email, string password)
        {
            try
            {
                return _userRepo.Authenticate(email, password);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<User> GetAll()
        {
            try {
                return _userRepo.GetAll();
            }
            catch (Exception ex) {
                throw ex;
            }
        }

        public User GetById(string id)
        {
            try
            {
                return _userRepo.GetById(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public User Create(User user, string password)
        {
            try
            {
                return _userRepo.Create(user, password);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update(User userToUpdate, string password = null)
        {
            try
            {
                _userRepo.Update(userToUpdate, password);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete(string id)
        {
            try
            {
                _userRepo.Delete(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

