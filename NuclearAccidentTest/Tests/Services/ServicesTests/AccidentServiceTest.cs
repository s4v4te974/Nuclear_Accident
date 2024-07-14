using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NuclearAccident.Src.Common.DbSet;
using NuclearAccident.Src.Common.Dtos;
using NuclearAccident.Src.Data;
using NuclearAccident.Src.Services.Implementation.BrokenArrows;
using NuclearAccident.Src.UI.Profiles;
using NuclearAccidentTest.Utils;

namespace NuclearAccidentTest.Tests.Services.ServicesTests
{
    public class AccidentServiceTest
    {
        private readonly NuclearAccidentContext _dbContext;
        private readonly Mapper _mapper;
        private readonly ILogger<BrokenArrowsServiceImpl> _logger;
        private readonly BrokenArrowsServiceImpl _AccidentService;

        private readonly Guid AccidentOneId = new("45795bfc-2ae5-49ed-87e3-54cac6f9d77e");
        private readonly DateTime AccidentOneDisasterDate = new(1950, 1, 1);
        private readonly string AccidentOneShortDescription = "Short description 1";
        private readonly string AccidentOneBubbleDescription = "bubble description 1";

        private readonly Guid AccidentTwoId = new("2c1c5672-74af-4ffd-8660-5d7eaaeff608");
        private readonly DateTime AccidentTwoDisasterDate = DateTime.Now;
        private readonly string AccidentTwoShortDescription = "Short description 2";
        private readonly string AccidentTwoBubbleDescription = "bubble description 2";

        private readonly Guid locationOneId = new("9223a7d1-5dea-46da-9b74-879bc36603e2");
        private readonly Guid locationTwoId = new("2d5fe2b4-1e30-49eb-bdc8-5819b222d50b");
        private readonly Guid vehiculeOneId = new("d26d4560-84b0-489b-8ae5-2b4607541526");
        private readonly Guid vehiculeTwoId = new("ca24ce94-1150-4218-96fb-a1a88cffda37");
        private readonly Guid weaponOneId = new("0afa052e-cf9d-4b33-b530-3683ac71f250");
        private readonly Guid weaponTwoId = new("95738c3d-30fc-4152-ae7a-c37f2e8c5e2c");

        public AccidentServiceTest()
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
                cfg.AddProfile<AccidentProfile>();
            });
            _mapper = (Mapper?)config.CreateMapper();

            _AccidentService = new BrokenArrowsServiceImpl(_dbContext, _mapper, _logger);
        }

        private void InsertAccident()
        {
            _dbContext.Locations.AddRange(BuildLocation());
            _dbContext.Weapons.AddRange(BuildWeapons());
            _dbContext.Vehicules.AddRange(BuildVehicules());
            _dbContext.Accidents.AddRange(BuildAccident());
            _dbContext.SaveChanges();
        }

        private void ClearAccident()
        {
            _dbContext.RemoveRange(_dbContext.Locations);
            _dbContext.RemoveRange(_dbContext.Weapons);
            _dbContext.RemoveRange(_dbContext.Vehicules);
            _dbContext.RemoveRange(_dbContext.Accidents);
            _dbContext.SaveChanges();
        }

        [Fact]
        public async Task Test_GetSingleAccidentAsync()
        {
            InsertAccident();
            AccidentResponse? Accident = await _AccidentService.GetSingleAccidentAsync(AccidentOneId);
            Assert.NotNull(Accident);
            Assert.NotNull(Accident.Location);
            Assert.NotNull(Accident.Weapon);
            Assert.NotNull(Accident.Vehicule);
            Assert.Equal(Accident.DisasterDate, AccidentOneDisasterDate);
            Assert.Equal(Accident.ShortDescription, AccidentOneShortDescription);
            Assert.Equal(Accident.BubbleDescription, AccidentOneBubbleDescription);
            ClearAccident();
        }

        [Fact]
        public async Task Test_GetAccidentsAsync()
        {
            InsertAccident();
            IEnumerable<AccidentResponse?> Accidents = await _AccidentService.GetAccidentsAsync();
            Assert.NotNull(Accidents);
            Assert.True(Accidents.Any());
            Assert.Equal(2, Accidents.Count());
            ClearAccident();
        }

        [Fact]
        public async Task Test_GetAccidentsByYearsAsync()
        {
            InsertAccident();
            IEnumerable<AccidentResponse?> Accidents = await _AccidentService.GetAccidentsByYearsAsync(1950);
            Assert.NotNull(Accidents);
            Assert.True(Accidents.Any());
            AccidentResponse? expectedAccident = Accidents.First();
            Assert.NotNull(expectedAccident);
            Assert.NotNull(expectedAccident.Location);
            Assert.NotNull(expectedAccident.Weapon);
            Assert.NotNull(expectedAccident.Vehicule);
            Assert.Equal(expectedAccident.DisasterDate, AccidentOneDisasterDate);
            Assert.Equal(expectedAccident.ShortDescription, AccidentOneShortDescription);
            Assert.Equal(expectedAccident.BubbleDescription, AccidentOneBubbleDescription);
            ClearAccident();
        }

        [Fact]
        public async Task Test_GetSingleAccidentAsync_ShouldReturnNull_WhenNoAccidentExist()
        {
            ClearAccident();
            AccidentResponse? Accident = await _AccidentService.GetSingleAccidentAsync(AccidentOneId);
            Assert.Null(Accident);
        }

        [Fact]
        public async Task Test_GetAccidentsAsync_ShouldReturnEmptyList_WhenNoAccidentExist()
        {
            ClearAccident();
            IEnumerable<AccidentResponse?> Accidents = await _AccidentService.GetAccidentsAsync();
            Assert.Empty(Accidents);
        }

        [Fact]
        public async Task Test_GetAccidentsByLocationAsync_ShouldReturnEmptyList_WhenNoAccidentExist()
        {
            ClearAccident();
            IEnumerable<AccidentResponse?> Accidents = await _AccidentService.GetAccidentsByYearsAsync(1950);
            Assert.Empty(Accidents);
        }

        private List<Accident> BuildAccident()
        {
            Accident AccidentOne = new()
            {
                Brokenarrowid = AccidentOneId,
                LocationId = locationOneId,
                VehiculeId = vehiculeOneId,
                WeaponId = weaponOneId,
                DisasterDate = AccidentOneDisasterDate,
                ShortDescription = AccidentOneShortDescription,
                BubbleDescription = AccidentOneBubbleDescription
            };
            Accident AccidentTwo = new()
            {
                Brokenarrowid = AccidentTwoId,
                LocationId = locationTwoId,
                VehiculeId = vehiculeTwoId,
                WeaponId = weaponTwoId,
                DisasterDate = AccidentTwoDisasterDate,
                ShortDescription = AccidentTwoShortDescription,
                BubbleDescription = AccidentTwoBubbleDescription
            };
            return [AccidentOne, AccidentTwo];
        }

        private List<Location> BuildLocation()
        {
            Location location = new()
            {
                LocationId = locationOneId,
                BrokenArrows = null
            };
            Location locationTwo = new()
            {
                LocationId = locationTwoId,
                BrokenArrows = null
            };
            return [location, locationTwo];
        }

        private List<Vehicule> BuildVehicules()
        {
            Vehicule vehicule = new()
            {
                VehiculeId = vehiculeOneId,
                Accidents = null
            };
            Vehicule vehiculeTwo = new()
            {
                VehiculeId = vehiculeTwoId,
                Accidents = null
            };
            return [vehicule, vehiculeTwo];
        }

        private List<Weapon> BuildWeapons()
        {
            Weapon weapon = new()
            {
                WeaponId = weaponOneId,
                Accidents = null
            };
            Weapon weaponTwo = new()
            {
                WeaponId = weaponTwoId,
                Accidents = null
            };
            return [weapon, weaponTwo];
        }
    }
}