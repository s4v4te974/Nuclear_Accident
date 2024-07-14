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
        private readonly NuclearAccidentContext _dbContext;
        private readonly IWeaponService _weaponService;
        private readonly Mock<ILogger<WeaponServiceImpl>> _logger;
        private readonly Mock<IMapper> _mapper;

        public WeaponServiceExceptionTest()
        {
            var options = new DbContextOptionsBuilder<NuclearAccidentContext>()
            .UseSqlite("Data Source =:memory:")
            .Options;

            _dbContext = new NuclearAccidentContext(options);
            _logger = new Mock<ILogger<WeaponServiceImpl>>();
            _mapper = new Mock<IMapper>();
            _weaponService = new WeaponServiceImpl(_dbContext, _mapper.Object, _logger.Object);
        }

        [Fact]
        public async Task GetWeaponsAsync_ShouldThrowNuclearAccidentException_WhenDbExceptionOccurs()
        {
            var mockSet = new Mock<DbSet<Weapon>>();
            mockSet.As<IQueryable<Weapon>>().Setup(m => m.Provider).Throws(new NuclearIncidentException("error", new Exception()));

            var exception = await Assert.ThrowsAsync<NuclearIncidentException>(() => _weaponService.GetWeaponsAsync());

            Assert.Equal(ConstUtils.UNABLE_TO_RETRIEVE_ALL_WEAPON, exception.Message);
        }

        [Fact]
        public async Task GetSingleWeaponAsync_ShouldThrowNuclearAccidentException_WhenDbExceptionOccurs()
        {
            var mockSet = new Mock<DbSet<Weapon>>();
            mockSet.As<IQueryable<Weapon>>().Setup(m => m.Provider).Throws(new NuclearIncidentException("error", new Exception()));

            var exception = await Assert.ThrowsAsync<NuclearIncidentException>(() => _weaponService.GetSingleWeaponAsync(new Guid("d3aaceaa-7d01-4c45-bbd7-6738fb88201c")));

            Assert.Equal(ConstUtils.UNABLE_TO_RETRIEVE_SPECIFIC_WEAPON, exception.Message);
        }

        [Fact]
        public async Task GetAccidentsByWeaponAsync_ShouldThrowNuclearAccidentException_WhenDbExceptionOccurs()
        {
            var mockSet = new Mock<DbSet<Weapon>>();
            mockSet.As<IQueryable<Weapon>>().Setup(m => m.Provider).Throws(new NuclearIncidentException("error", new Exception()));

            var exception = await Assert.ThrowsAsync<NuclearIncidentException>(() => _weaponService.GetAccidentsByWeaponAsync(AvailableWeapon.MARK15));

            Assert.Equal(ConstUtils.UNABLE_TO_RETRIEVE_BA_BY_WEAPON, exception.Message);
        }
    }
}
