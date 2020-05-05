using System;
using AutoMapper;
using Full_Stack_Food_Truck_Application.Data.Entities;
using Full_Stack_Food_Truck_Application.Models.CoordinateModel;
using Full_Stack_Food_Truck_Application.Models.FavoriteModels;
using Full_Stack_Food_Truck_Application.Models.UserModels;

namespace Full_Stack_Food_Truck_Application.Helpers
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<AuthenticateUserModel, User>();
            CreateMap<CreateUserModel, User>();
            CreateMap<DeleteUserModel, User>();
            CreateMap<GetUserModel, User>();
            CreateMap<UpdateUserModel, User>();
            CreateMap<GetCoordinatesModel, Coordinates>();
            CreateMap<GetFavoriteModel, Favorite>();
        }
    }
}
