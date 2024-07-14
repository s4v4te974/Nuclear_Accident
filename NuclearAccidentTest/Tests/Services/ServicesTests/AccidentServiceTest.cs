using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NuclearInccidentTest.Utils;
using NuclearIncident.Src.Common.DbSet;
using NuclearIncident.Src.Common.Dtos.BrokenArrow;
using NuclearIncident.Src.Data;
using NuclearIncident.Src.Services.Implementation.BrokenArrows;
using NuclearIncident.Src.UI.Profiles;

namespace NuclearInccidentTest.Tests.Services.ServicesTests
{
    public class BrokenArrowsServiceTest
    {
        private readonly NuclearBrokenArrowsContext _dbContext;
        private readonly Mapper _mapper;
        private readonly ILogger<BrokenArrowsServiceImpl> _logger;
        private readonly BrokenArrowsServiceImpl _BrokenArrowsService;

        private readonly Guid BrokenArrowsOneId = new("45795bfc-2ae5-49ed-87e3-54cac6f9d77e");
        private readonly DateTime BrokenArrowsOneDisasterDate = new(1950, 1, 1);
        private readonly string BrokenArrowsOneShortDescription = "Short description 1";
        private readonly string BrokenArrowsOneBubbleDescription = "bubble description 1";

        private readonly Guid BrokenArrowsTwoId = new("2c1c5672-74af-4ffd-8660-5d7eaaeff608");
        private readonly DateTime BrokenArrowsTwoDisasterDate = DateTime.Now;
        private readonly string BrokenArrowsTwoShortDescription = "Short description 2";
        private readonly string BrokenArrowsTwoBubbleDescription = "bubble description 2";

        private readonly Guid locationOneId = new("9223a7d1-5dea-46da-9b74-879bc36603e2");
        private readonly Guid locationTwoId = new("2d5fe2b4-1e30-49eb-bdc8-5819b222d50b");
        private readonly Guid vehiculeOneId = new("d26d4560-84b0-489b-8ae5-2b4607541526");
        private readonly Guid vehiculeTwoId = new("ca24ce94-1150-4218-96fb-a1a88cffda37");
        private readonly Guid weaponOneId = new("0afa052e-cf9d-4b33-b530-3683ac71f250");
        private readonly Guid weaponTwoId = new("95738c3d-30fc-4152-ae7a-c37f2e8c5e2c");

        public BrokenArrowsServiceTest()
        {
            var options = new DbContextOptionsBuilder<NuclearBrokenArrowsContext>()
            .UseSqlite("Data Source =:memory:")
            .Options;

            _dbContext = new NuclearBrokenArrowsContext(options);
            _dbContext.Database.OpenConnection();
            _dbContext.Database.EnsureCreated();
            DataInitializer.Initialize(_dbContext);

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<BrokenArrowsProfile>();
            });
            _mapper = (Mapper?)config.CreateMapper();

            _BrokenArrowsService = new BrokenArrowsServiceImpl(_dbContext, _mapper, _logger);
        }

        private void InsertBrokenArrows()
        {
            _dbContext.Locations.AddRange(BuildLocation());
            _dbContext.Weapons.AddRange(BuildWeapons());
            _dbContext.Vehicules.AddRange(BuildVehicules());
            _dbContext.BrokenArrows.AddRange(BuildBrokenArrows());
            _dbContext.SaveChanges();
        }

        private void ClearBrokenArrows()
        {
            _dbContext.RemoveRange(_dbContext.Locations);
            _dbContext.RemoveRange(_dbContext.Weapons);
            _dbContext.RemoveRange(_dbContext.Vehicules);
            _dbContext.RemoveRange(_dbContext.BrokenArrows);
            _dbContext.SaveChanges();
        }

        [Fact]
        public async Task Test_GetSingleBrokenArrowsAsync()
        {
            InsertBrokenArrows();
            BrokenArrowResponse? BrokenArrows = await _BrokenArrowsService.GetSingleBrokenArrowsAsync(BrokenArrowsOneId);
            Assert.NotNull(BrokenArrows);
            Assert.NotNull(BrokenArrows.Location);
            Assert.NotNull(BrokenArrows.Weapon);
            Assert.NotNull(BrokenArrows.Vehicule);
            Assert.Equal(BrokenArrows.DisasterDate, BrokenArrowsOneDisasterDate);
            Assert.Equal(BrokenArrows.ShortDescription, BrokenArrowsOneShortDescription);
            Assert.Equal(BrokenArrows.BubbleDescription, BrokenArrowsOneBubbleDescription);
            ClearBrokenArrows();
        }

        [Fact]
        public async Task Test_GetBrokenArrowssAsync()
        {
            InsertBrokenArrows();
            IEnumerable<BrokenArrowResponse?> BrokenArrowss = await _BrokenArrowsService.GetBrokenArrowssAsync();
            Assert.NotNull(BrokenArrowss);
            Assert.True(BrokenArrowss.Any());
            Assert.Equal(2, BrokenArrowss.Count());
            ClearBrokenArrows();
        }

        [Fact]
        public async Task Test_GetBrokenArrowssByYearsAsync()
        {
            InsertBrokenArrows();
            IEnumerable<BrokenArrowResponse?> BrokenArrowss = await _BrokenArrowsService.GetBrokenArrowssByYearsAsync(1950);
            Assert.NotNull(BrokenArrowss);
            Assert.True(BrokenArrowss.Any());
            BrokenArrowResponse? expectedBrokenArrows = BrokenArrowss.First();
            Assert.NotNull(expectedBrokenArrows);
            Assert.NotNull(expectedBrokenArrows.Location);
            Assert.NotNull(expectedBrokenArrows.Weapon);
            Assert.NotNull(expectedBrokenArrows.Vehicule);
            Assert.Equal(expectedBrokenArrows.DisasterDate, BrokenArrowsOneDisasterDate);
            Assert.Equal(expectedBrokenArrows.ShortDescription, BrokenArrowsOneShortDescription);
            Assert.Equal(expectedBrokenArrows.BubbleDescription, BrokenArrowsOneBubbleDescription);
            ClearBrokenArrows();
        }

        [Fact]
        public async Task Test_GetSingleBrokenArrowsAsync_ShouldReturnNull_WhenNoBrokenArrowsExist()
        {
            ClearBrokenArrows();
            BrokenArrowResponse? BrokenArrows = await _BrokenArrowsService.GetSingleBrokenArrowsAsync(BrokenArrowsOneId);
            Assert.Null(BrokenArrows);
        }

        [Fact]
        public async Task Test_GetBrokenArrowssAsync_ShouldReturnEmptyList_WhenNoBrokenArrowsExist()
        {
            ClearBrokenArrows();
            IEnumerable<BrokenArrowResponse?> BrokenArrowss = await _BrokenArrowsService.GetBrokenArrowssAsync();
            Assert.Empty(BrokenArrowss);
        }

        [Fact]
        public async Task Test_GetBrokenArrowssByLocationAsync_ShouldReturnEmptyList_WhenNoBrokenArrowsExist()
        {
            ClearBrokenArrows();
            IEnumerable<BrokenArrowResponse?> BrokenArrowss = await _BrokenArrowsService.GetBrokenArrowssByYearsAsync(1950);
            Assert.Empty(BrokenArrowss);
        }

        private List<BrokenArrow> BuildBrokenArrows()
        {
            BrokenArrow BrokenArrowsOne = new()
            {
                BrokenArrowsId = BrokenArrowsOneId,
                LocationId = locationOneId,
                VehiculeId = vehiculeOneId,
                WeaponId = weaponOneId,
                DisasterDate = BrokenArrowsOneDisasterDate,
                ShortDescription = BrokenArrowsOneShortDescription,
                BubbleDescription = BrokenArrowsOneBubbleDescription
            };
            BrokenArrow BrokenArrowsTwo = new()
            {
                BrokenArrowsId = BrokenArrowsTwoId,
                LocationId = locationTwoId,
                VehiculeId = vehiculeTwoId,
                WeaponId = weaponTwoId,
                DisasterDate = BrokenArrowsTwoDisasterDate,
                ShortDescription = BrokenArrowsTwoShortDescription,
                BubbleDescription = BrokenArrowsTwoBubbleDescription
            };
            return [BrokenArrowsOne, BrokenArrowsTwo];
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
                BrokenArrows = null
            };
            Vehicule vehiculeTwo = new()
            {
                VehiculeId = vehiculeTwoId,
                BrokenArrows = null
            };
            return [vehicule, vehiculeTwo];
        }

        private List<Weapon> BuildWeapons()
        {
            Weapon weapon = new()
            {
                WeaponId = weaponOneId,
                BrokenArrows = null
            };
            Weapon weaponTwo = new()
            {
                WeaponId = weaponTwoId,
                BrokenArrows = null
            };
            return [weapon, weaponTwo];
        }
    }
}