using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NuclearInccidentTest.Utils;
using NuclearIncident.Src.Common.DbSet;
using NuclearIncident.Src.Common.Dtos;
using NuclearIncident.Src.Common.Enum;
using NuclearIncident.Src.Data;
using NuclearIncident.Src.Services.Implementation.Common;
using NuclearIncident.Src.UI.Profiles;

namespace NuclearInccidentTest.Tests.Services.ServicesTests
{
    public class VehiculeServiceTest
    {

        private readonly NuclearAccidentContext _dbContext;
        private readonly Mapper _mapper;
        private readonly ILogger<VehiculeServiceImpl> _logger;
        private readonly VehiculeServiceImpl _vehiculeService;

        private readonly Guid vehiculeOneId = new("80935672-1953-4f70-84bc-feb187fe5f9d");
        private readonly string vehiculeOneType = "Transport";
        private readonly string vehiculeOneBuilder = "Douglas";
        private readonly string vehiculeOneName = "C-124 Globemaster II";
        private readonly string vehiculeOneDescription = "This is a plane";

        private readonly Guid vehiculeTwoId = new("3f7c2af1-0292-47f3-a623-7ff06e5db0c9");
        private readonly string vehiculeTwoType = "Bombardier";
        private readonly string vehiculeTwoBuilder = "Convair";
        private readonly string vehiculeTwoName = "B-58";
        private readonly string vehiculeTwoDescription = "This is another plane";

        public VehiculeServiceTest()

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
                cfg.AddProfile<VehiculeProfile>();
            });
            _mapper = (Mapper?)config.CreateMapper();

            _vehiculeService = new VehiculeServiceImpl(_dbContext, _mapper, _logger);
        }

        private void InsertVehicule()
        {
            _dbContext.Vehicules.AddRange(BuildVehicules());
            _dbContext.SaveChanges();
        }

        private void ClearVehicule()
        {
            _dbContext.RemoveRange(_dbContext.Vehicules);
            _dbContext.SaveChanges();
        }

        [Fact]
        public async Task Test_GetSingleVehiculeAsync()
        {
            InsertVehicule();
            VehiculeResponse? vehicule = await _vehiculeService.GetSingleVehiculeAsync(vehiculeOneId);
            Assert.NotNull(vehicule);
            Assert.NotNull(vehicule.Accidents);
            Assert.True(vehicule.Accidents.Any());
            Assert.Equal(vehicule.VehiculeId, vehiculeOneId);
            Assert.Equal(vehicule.Type, vehiculeOneType);
            Assert.Equal(vehicule.Builder, vehiculeOneBuilder);
            Assert.Equal(vehicule.Name, vehiculeOneName);
            Assert.Equal(vehicule.Description, vehiculeOneDescription);
            Assert.Equal(2, vehicule.Accidents.Count);
            ClearVehicule();
        }

        [Fact]
        public async Task Test_GetVehiculesAsync()
        {
            InsertVehicule();
            IEnumerable<VehiculeResponse?> vehicules = await _vehiculeService.GetVehiculesAsync();
            Assert.NotNull(vehicules);
            Assert.True(vehicules.Any());
            Assert.Equal(2, vehicules.Count());
            ClearVehicule();
        }

        [Fact]
        public async Task Test_GetAccidentsByVehiculeAsync()
        {
            InsertVehicule();
            IEnumerable<VehiculeResponse?> vehicules = await _vehiculeService.GetAccidentsByVehiculeAsync(AvailableVehicule.DOUGLAS);
            Assert.NotNull(vehicules);
            Assert.True(vehicules.Any());
            VehiculeResponse? expectedVehicule = vehicules.First();
            Assert.NotNull(expectedVehicule.Accidents);
            Assert.True(expectedVehicule.Accidents.Any());
            Assert.Equal(expectedVehicule.VehiculeId, vehiculeOneId);
            Assert.Equal(expectedVehicule.Type, vehiculeOneType);
            Assert.Equal(expectedVehicule.Builder, vehiculeOneBuilder);
            Assert.Equal(expectedVehicule.Name, vehiculeOneName);
            Assert.Equal(expectedVehicule.Description, vehiculeOneDescription);
            ClearVehicule();
        }

        [Fact]
        public async Task Test_GetSingleVehiculeAsync_ShouldReturnNull_WhenNoVehiculeExist()
        {
            ClearVehicule();
            VehiculeResponse? vehicule = await _vehiculeService.GetSingleVehiculeAsync(vehiculeOneId);
            Assert.Null(vehicule);
        }

        [Fact]
        public async Task Test_GetVehiculesAsync_ShouldReturnEmptyList_WhenNoVehiculeExist()
        {
            ClearVehicule();
            IEnumerable<VehiculeResponse?> vehicules = await _vehiculeService.GetVehiculesAsync();
            Assert.Empty(vehicules);
        }

        [Fact]
        public async Task Test_GetAccidentsByWeaponAsync_ShouldReturnEmptyList_WhenNoVehiculeExist()
        {
            ClearVehicule();
            IEnumerable<VehiculeResponse?> vehicules = await _vehiculeService.GetAccidentsByVehiculeAsync(AvailableVehicule.DOUGLAS);
            Assert.Empty(vehicules);
        }



        private List<Vehicule> BuildVehicules()
        {
            Vehicule vehicule = new()
            {
                VehiculeId = vehiculeOneId,
                Type = vehiculeOneType,
                Builder = vehiculeOneBuilder,
                Name = vehiculeOneName,
                Description = vehiculeOneDescription,
                Accidents =
                [
                    new() { Brokenarrowid = Guid.NewGuid(), ShortDescription = "Short description 1" },
                    new() { Brokenarrowid = Guid.NewGuid(), ShortDescription = "Short description 2"  }
                ]
            };
            Vehicule vehiculeTwo = new()
            {
                VehiculeId = vehiculeTwoId,
                Type = vehiculeTwoType,
                Builder = vehiculeTwoBuilder,
                Name = vehiculeTwoName,
                Description = vehiculeTwoDescription,
                Accidents =
                    [
                    new() { Brokenarrowid = Guid.NewGuid() },
                    new() { Brokenarrowid = Guid.NewGuid() }
                ]
            };
            return [vehicule, vehiculeTwo];
        }
    }
}