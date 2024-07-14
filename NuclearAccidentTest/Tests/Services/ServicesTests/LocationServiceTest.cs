﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NuclearAccident.Src.Common.DbSet;
using NuclearAccident.Src.Common.Dtos;
using NuclearAccident.Src.Common.Enum;
using NuclearAccident.Src.Data;
using NuclearAccident.Src.Services.Implementation.Common;
using NuclearAccident.Src.UI.Profiles;
using NuclearAccidentTest.Utils;


namespace NuclearAccidentTest.Tests.Services.ServicesTests
{
    public class LocationServiceTest
    {

        private readonly NuclearAccidentContext _dbContext;
        private readonly Mapper _mapper;
        private readonly ILogger<LocationServiceImpl> _logger;
        private readonly LocationServiceImpl _locationService;

        private readonly Guid locationOneId = new("3a66857d-462d-4c5c-8f08-3960d23bd04b");
        private readonly string locationOneCountry = "Canada";
        private readonly string locationOnePositionLost = "Quebec";
        private readonly float locationOneXCoordonate = 3.14f;
        private readonly float locationOneYCoordonate = 3.14f;

        private readonly Guid locationTwoId = new("bee49c6c-c4bb-47d5-9ed0-e95155fd3e02");
        private readonly string locationTwoCountry = "US";
        private readonly string locationTwoPositionLost = "Savannah River, Georgie";
        private readonly float locationTwoXCoordonate = 3.14f;
        private readonly float locationTwoYCoordonate = 3.14f;

        public LocationServiceTest()
        {
            var options = new DbContextOptionsBuilder<NuclearAccidentContext>()
            .UseSqlite("Data Source =:memory:")
            .Options;

            _dbContext = new NuclearAccidentContext(options);
            _dbContext.Database.OpenConnection();
            _dbContext.Database.EnsureCreated();
            DataInitializer.Initialize(_dbContext);

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<LocationProfile>();
            });
            _mapper = (Mapper?)config.CreateMapper();

            _locationService = new LocationServiceImpl(_dbContext, _mapper, _logger);
        }

        private void InsertLocation()
        {
            _dbContext.Locations.AddRange(BuildLocation());
            _dbContext.SaveChanges();
        }

        private void ClearLocation()
        {
            _dbContext.RemoveRange(_dbContext.Locations);
            _dbContext.SaveChanges();
        }

        [Fact]
        public async Task Test_GetSingleLocationAsync()
        {
            InsertLocation();
            LocationResponse? location = await _locationService.GetSingleLocationAsync(locationOneId);
            Assert.NotNull(location);
            Assert.Equal(location.LocationId, locationOneId);
            Assert.Equal(location.Country, locationOneCountry);
            Assert.Equal(location.PositionLost, locationOnePositionLost);
            Assert.Equal(location.XCoordonate, locationOneXCoordonate);
            Assert.Equal(location.YCoordonate, locationOneYCoordonate);
            ClearLocation();
        }

        [Fact]
        public async Task Test_GetLocationAsync()
        {
            InsertLocation();
            IEnumerable<LocationResponse?> locations = await _locationService.GetLocationAsync();
            Assert.NotNull(locations);
            Assert.True(locations.Any());
            Assert.Equal(2, locations.Count());
            ClearLocation();
        }

        [Fact]
        public async Task Test_GetAccidentsByLocationAsync()
        {
            InsertLocation();
            IEnumerable<LocationResponse?> Locations = await _locationService.GetAccidentsByLocationAsync(AvailableLocation.CANADA);
            Assert.NotNull(Locations);
            Assert.True(Locations.Any());
            LocationResponse? expectedLocation = Locations.First();
            Assert.Equal(expectedLocation.LocationId, locationOneId);
            Assert.Equal(expectedLocation.Country, locationOneCountry);
            Assert.Equal(expectedLocation.PositionLost, locationOnePositionLost);
            Assert.Equal(expectedLocation.XCoordonate, locationOneXCoordonate);
            Assert.Equal(expectedLocation.YCoordonate, locationOneYCoordonate);
            ClearLocation();
        }

        [Fact]
        public async Task Test_GetLocationAsync_ShouldReturnNull_WhenNoLocationExist()
        {
            ClearLocation();
            LocationResponse? vehicule = await _locationService.GetSingleLocationAsync(locationOneId);
            Assert.Null(vehicule);
        }

        [Fact]
        public async Task Test_GetLocationAsync_ShouldReturnEmptyList_WhenNoLocationExist()
        {
            ClearLocation();
            IEnumerable<LocationResponse?> Locations = await _locationService.GetLocationAsync();
            Assert.Empty(Locations);
        }

        [Fact]
        public async Task Test_Test_GetAccidentsByLocationAsync_ShouldReturnEmptyList_WhenNoLocationExist()
        {
            ClearLocation();
            IEnumerable<LocationResponse?> Locations = await _locationService.GetAccidentsByLocationAsync(AvailableLocation.CANADA);
            Assert.Empty(Locations);
        }

        private List<Location> BuildLocation()
        {
            Location location = new()
            {
                LocationId = locationOneId,
                Country = locationOneCountry,
                PositionLost = locationOnePositionLost,
                XCoordonate = locationOneXCoordonate,
                YCoordonate = locationOneYCoordonate,

            };
            Location locationTwo = new()
            {
                LocationId = locationTwoId,
                Country = locationTwoCountry,
                PositionLost = locationTwoPositionLost,
                XCoordonate = locationTwoXCoordonate,
                YCoordonate = locationTwoYCoordonate,

            };
            return [location, locationTwo];
        }
    }
}