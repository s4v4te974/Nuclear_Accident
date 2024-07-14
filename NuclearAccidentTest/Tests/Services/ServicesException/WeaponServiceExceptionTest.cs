using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using NuclearIncident.Src.Common.DbSet;
using NuclearIncident.Src.Common.Enum;
using NuclearIncident.Src.Common.Exceptions;
using NuclearIncident.Src.Common.Utils;
using NuclearIncident.Src.Data;
using NuclearIncident.Src.Services.Implementation.Common;
using NuclearIncident.Src.Services.Interfaces.Common;

namespace NuclearInccidentTest.Tests.Services.ServicesException
{
    public class WeaponServiceExceptionTest
    {
        private readonly NuclearBrokenArrowsContext _dbContext;
        private readonly IWeaponService _weaponService;
        private readonly Mock<ILogger<WeaponServiceImpl>> _logger;
        private readonly Mock<IMapper> _mapper;

        public WeaponServiceExceptionTest()
        {
            var options = new DbContextOptionsBuilder<NuclearBrokenArrowsContext>()
            .UseSqlite("Data Source =:memory:")
            .Options;

            _dbContext = new NuclearBrokenArrowsContext(options);
            _logger = new Mock<ILogger<WeaponServiceImpl>>();
            _mapper = new Mock<IMapper>();
            _weaponService = new WeaponServiceImpl(_dbContext, _mapper.Object, _logger.Object);
        }

        [Fact]
        public async Task GetWeaponsAsync_ShouldThrowNuclearBrokenArrowsException_WhenDbExceptionOccurs()
        {
            var mockSet = new Mock<DbSet<Weapon>>();
            mockSet.As<IQueryable<Weapon>>().Setup(m => m.Provider).Throws(new NuclearIncidentException("error", new Exception()));

            var exception = await Assert.ThrowsAsync<NuclearIncidentException>(() => _weaponService.GetWeaponsAsync());

            Assert.Equal(ConstUtils.UNABLE_TO_RETRIEVE_ALL_WEAPON, exception.Message);
        }

        [Fact]
        public async Task GetSingleWeaponAsync_ShouldThrowNuclearBrokenArrowsException_WhenDbExceptionOccurs()
        {
            var mockSet = new Mock<DbSet<Weapon>>();
            mockSet.As<IQueryable<Weapon>>().Setup(m => m.Provider).Throws(new NuclearIncidentException("error", new Exception()));

            var exception = await Assert.ThrowsAsync<NuclearIncidentException>(() => _weaponService.GetSingleWeaponAsync(new Guid("d3aaceaa-7d01-4c45-bbd7-6738fb88201c")));

            Assert.Equal(ConstUtils.UNABLE_TO_RETRIEVE_SPECIFIC_WEAPON, exception.Message);
        }

        [Fact]
        public async Task GetBrokenArrowssByWeaponAsync_ShouldThrowNuclearBrokenArrowsException_WhenDbExceptionOccurs()
        {
            var mockSet = new Mock<DbSet<Weapon>>();
            mockSet.As<IQueryable<Weapon>>().Setup(m => m.Provider).Throws(new NuclearIncidentException("error", new Exception()));

            var exception = await Assert.ThrowsAsync<NuclearIncidentException>(() => _weaponService.GetBrokenArrowssByWeaponAsync(AvailableWeapon.MARK15));

            Assert.Equal(ConstUtils.UNABLE_TO_RETRIEVE_BA_BY_WEAPON, exception.Message);
        }
    }
}
