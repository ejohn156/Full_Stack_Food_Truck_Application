using System;
using System.Collections.Generic;
using AutoMapper;
using Full_Stack_Food_Truck_Application.Data.Entities;
using Full_Stack_Food_Truck_Application.Helpers;
using Full_Stack_Food_Truck_Application.Models.FavoriteModels;
using Full_Stack_Food_Truck_Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Full_Stack_Food_Truck_Application.Controllers
{
    [Authorize]
    public class FavoriteController : APIController
    {
        private readonly IFavoriteService _favService;
        private readonly IMapper _mapper;
        private readonly AppSettings _appSettings;
        private readonly ICoordinateService _coordService;

        public FavoriteController(
                   IFavoriteService favService,
                   IMapper mapper,
                   IOptions<AppSettings> appSettings,
                   ICoordinateService coordService
            )
        {
            _favService = favService;
            _mapper = mapper;
            _appSettings = appSettings.Value;
            _coordService = coordService;
        }
        [HttpGet("{Id}")]
        public IActionResult GetFavorite(string Id) {
            try {
                var favorite = _mapper.Map<GetFavoriteModel>(_favService.getFavorite(Id));
                return Ok(favorite);
            }
            catch (AppException ex)
            { return BadRequest(new { message = ex.Message }); }
        }
        [HttpGet("")]
        public IActionResult GetAllFavorites() {
            try
            {
                var favorites = _mapper.Map <List<GetFavoriteModel>>(_favService.GetAllFavorites());
                return Ok(favorites);
            }
            catch (AppException ex)
            { return BadRequest(new { message = ex.Message }); }
        }
        [HttpPost("Create")]
        public IActionResult CreateFavorite(CreateFavoriteModel model) {
            try
            {
                var coordToCreate = new Coordinates();
                coordToCreate.Latitude = model.Latitude;
                coordToCreate.Longitude = model.Longitude;
                coordToCreate.Truck_Id = model.Truck_Id;

                var newCoordinate = _coordService.CreateCoordinate(coordToCreate);
                var favoriteToCreate = _mapper.Map<Favorite>(model);
                favoriteToCreate.Coordinate_Id = newCoordinate.Id;
                favoriteToCreate.Coordinates = newCoordinate;
                var createdFav = _favService.CreateFavorite(favoriteToCreate);

                return Ok(createdFav);
            }
            catch (AppException ex)
            { return BadRequest(new { message = ex.Message }); }
        }
        [HttpPost("Delete/{Id}")]
        public IActionResult DeleteFavorite(string Id)
        {
            try
            {
                var favToDelete = _favService.getFavorite(Id);
                var coordinateId = favToDelete.Coordinate_Id;
                _favService.DeleteFavorite(Id);
                _coordService.DeleteCoordinate(coordinateId);
                return Ok("Favorite has been deleted");
            }
            catch (AppException ex)
            { return BadRequest(new { message = ex.Message }); }
        }
    }
}
