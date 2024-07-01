using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MilitaryNuclearAccident.Src.Mna.Common.DbSet;
using MilitaryNuclearAccident.Src.Mna.Common.Dtos;
using MilitaryNuclearAccident.Src.Mna.Data;
using MilitaryNuclearAccident.Src.Mna.Services.Implementation;
using MilitaryNuclearAccident.Src.Mna.UI.Controllers.Profiles;
using MilitaryNuclearAccidentTest.Utils;

namespace MilitaryNuclearAccidentTest.Tests.Mna.Services.ServicesTests
{
    public class BrokenArrowServiceTest
    {
        private readonly BrokenArrowContext _dbContext;
        private readonly Mapper _mapper;
        private readonly ILogger<BrokenArrowServiceImpl> _logger;
        private readonly BrokenArrowServiceImpl _brokenArrowService;

        private readonly Guid brokenArrowOneId = new("45795bfc-2ae5-49ed-87e3-54cac6f9d77e");
        private readonly DateTime brokenArrowOneDisasterDate = new(1950, 1, 1);
        private readonly string brokenArrowOneShortDescription = "Short description 1";
        private readonly string brokenArrowOneBubbleDescription = "bubble description 1";

        private readonly Guid brokenArrowTwoId = new("2c1c5672-74af-4ffd-8660-5d7eaaeff608");
        private readonly DateTime brokenArrowTwoDisasterDate = DateTime.Now;
        private readonly string brokenArrowTwoShortDescription = "Short description 2";
        private readonly string brokenArrowTwoBubbleDescription = "bubble description 2";

        private readonly Guid locationOneId = new("9223a7d1-5dea-46da-9b74-879bc36603e2");
        private readonly Guid locationTwoId = new("2d5fe2b4-1e30-49eb-bdc8-5819b222d50b");
        private readonly Guid vehiculeOneId = new("d26d4560-84b0-489b-8ae5-2b4607541526");
        private readonly Guid vehiculeTwoId = new("ca24ce94-1150-4218-96fb-a1a88cffda37");
        private readonly Guid weaponOneId = new("0afa052e-cf9d-4b33-b530-3683ac71f250");
        private readonly Guid weaponTwoId = new("95738c3d-30fc-4152-ae7a-c37f2e8c5e2c");
        private readonly Guid descriptionOneId = new("c2e70545-36c1-4d59-952a-5cc738c6542f");
        private readonly Guid descriptionTwoId = new("b293cf39-49e8-4f18-a2ad-a38a5e7cf158");

        public BrokenArrowServiceTest()
        {
            var options = new DbContextOptionsBuilder<BrokenArrowContext>()
            .UseSqlite("Data Source =:memory:")
            .Options;

            _dbContext = new BrokenArrowContext(options);
            _dbContext.Database.OpenConnection();
            _dbContext.Database.EnsureCreated();
            DataInitializer.Initialize(_dbContext);

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<BrokenArrowProfile>();
            });
            _mapper = (Mapper?)config.CreateMapper();

            _brokenArrowService = new BrokenArrowServiceImpl(_dbContext, _mapper, _logger);
        }

        private void InsertBrokenArrow()
        {
            _dbContext.Locations.AddRange(BuildLocation());
            _dbContext.Weapons.AddRange(BuildWeapons());
            _dbContext.Descriptions.AddRange(BuildDescription());
            _dbContext.Vehicules.AddRange(BuildVehicules());
            _dbContext.BrokenArrows.AddRange(BuildBrokenArrow());
            _dbContext.SaveChanges();
        }

        private void ClearBrokenArrow()
        {
            _dbContext.RemoveRange(_dbContext.Locations);
            _dbContext.RemoveRange(_dbContext.Weapons);
            _dbContext.RemoveRange(_dbContext.Descriptions);
            _dbContext.RemoveRange(_dbContext.Vehicules);
            _dbContext.RemoveRange(_dbContext.BrokenArrows);
            _dbContext.SaveChanges();
        }

        [Fact]
        public async Task Test_GetSingleBrokenArrowAsync()
        {
            InsertBrokenArrow();
            BrokenArrowResponse? brokenArrow = await _brokenArrowService.GetSingleBrokenArrowAsync(brokenArrowOneId);
            Assert.NotNull(brokenArrow);
            Assert.NotNull(brokenArrow.LocationId);
            Assert.NotNull(brokenArrow.WeaponId);
            Assert.NotNull(brokenArrow.VehiculeId);
            Assert.NotNull(brokenArrow.FullDescriptionId);
            Assert.Equal(brokenArrow.DisasterDate, brokenArrowOneDisasterDate);
            Assert.Equal(brokenArrow.ShortDescription, brokenArrowOneShortDescription);
            Assert.Equal(brokenArrow.BubbleDescription, brokenArrowOneBubbleDescription);
            ClearBrokenArrow();
        }

        [Fact]
        public async Task Test_GetBrokenArrowsAsync()
        {
            InsertBrokenArrow();
            IEnumerable<BrokenArrowResponse?> brokenArrows = await _brokenArrowService.GetBrokenArrowsAsync();
            Assert.NotNull(brokenArrows);
            Assert.True(brokenArrows.Any());
            Assert.Equal(2, brokenArrows.Count());
            ClearBrokenArrow();
        }

        [Fact]
        public async Task Test_GetBrokenArrowsByYearsAsync()
        {
            InsertBrokenArrow();
            IEnumerable<BrokenArrowResponse?> brokenArrows = await _brokenArrowService.GetBrokenArrowsByYearsAsync(1950);
            Assert.NotNull(brokenArrows);
            Assert.True(brokenArrows.Any());
            BrokenArrowResponse? expectedbrokenArrow = brokenArrows.First();
            Assert.NotNull(expectedbrokenArrow);
            Assert.NotNull(expectedbrokenArrow.LocationId);
            Assert.NotNull(expectedbrokenArrow.WeaponId);
            Assert.NotNull(expectedbrokenArrow.VehiculeId);
            Assert.NotNull(expectedbrokenArrow.FullDescriptionId);
            Assert.Equal(expectedbrokenArrow.DisasterDate, brokenArrowOneDisasterDate);
            Assert.Equal(expectedbrokenArrow.ShortDescription, brokenArrowOneShortDescription);
            Assert.Equal(expectedbrokenArrow.BubbleDescription, brokenArrowOneBubbleDescription);
            ClearBrokenArrow();
        }

        [Fact]
        public async Task Test_GetSingleBrokenArrowAsync_ShouldReturnNull_WhenNoBrokenArrowExist()
        {
            ClearBrokenArrow();
            BrokenArrowResponse? brokenArrow = await _brokenArrowService.GetSingleBrokenArrowAsync(brokenArrowOneId);
            Assert.Null(brokenArrow);
        }

        [Fact]
        public async Task Test_GetBrokenArrowsAsync_ShouldReturnEmptyList_WhenNoBrokenArrowExist()
        {
            ClearBrokenArrow();
            IEnumerable<BrokenArrowResponse?> brokenArrows = await _brokenArrowService.GetBrokenArrowsAsync();
            Assert.Empty(brokenArrows);
        }

        [Fact]
        public async Task Test_GetBrokenArrowsByLocationAsync_ShouldReturnEmptyList_WhenNoBrokenArrowExist()
        {
            ClearBrokenArrow();
            IEnumerable<BrokenArrowResponse?> brokenArrows = await _brokenArrowService.GetBrokenArrowsByYearsAsync(1950);
            Assert.Empty(brokenArrows);
        }

        private List<BrokenArrow> BuildBrokenArrow()
        {
            BrokenArrow brokenArrowOne = new()
            {
                BrokenArrowId = brokenArrowOneId,
                LocationId = locationOneId,
                FullDescriptionId = descriptionOneId,
                VehiculeId = vehiculeOneId,
                WeaponId = weaponOneId,
                DisasterDate = brokenArrowOneDisasterDate,
                ShortDescription = brokenArrowOneShortDescription,
                BubbleDescription = brokenArrowOneBubbleDescription
            };
            BrokenArrow brokenArrowTwo = new()
            {
                BrokenArrowId = brokenArrowTwoId,
                LocationId = locationTwoId,
                FullDescriptionId = descriptionTwoId,
                VehiculeId = vehiculeTwoId,
                WeaponId = weaponTwoId,
                DisasterDate = brokenArrowTwoDisasterDate,
                ShortDescription = brokenArrowTwoShortDescription,
                BubbleDescription = brokenArrowTwoBubbleDescription
            };
            return [brokenArrowOne, brokenArrowTwo];
        }

        private List<Location> BuildLocation()
        {
            Location location = new()
            {
                LocationId = locationOneId,
                BrokenArrow = null
            };
            Location locationTwo = new()
            {
                LocationId = locationTwoId,
                BrokenArrow = null
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

        private List<Description> BuildDescription()
        {
            Description desc = new()
            {
                FullDescriptionId = descriptionOneId,
                FullDescription = null
            };
            Description descTwo = new()
            {
                FullDescriptionId = descriptionTwoId,
                FullDescription = null
            };
            return [desc, descTwo];
        }
    }
}