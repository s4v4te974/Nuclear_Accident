using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MilitaryNuclearAccident.Src.Mna.Common.DbSet;
using MilitaryNuclearAccident.Src.Mna.Common.Enum;
using MilitaryNuclearAccident.Src.Mna.Common.Exceptions;
using MilitaryNuclearAccident.Src.Mna.Data;
using MilitaryNuclearAccident.Src.Mna.Services.Implementation;
using MilitaryNuclearAccident.Src.Mna.Services.Interfaces;
using MilitaryNuclearAccident.Src.Mna.UI.Utils;
using Moq;

namespace MilitaryNuclearAccidentTest.Tests.Mna.Services.ServicesException
{
    public class WeaponServiceExceptionTest
    {
        private readonly BrokenArrowContext _dbContext;
        private readonly IWeaponService _weaponService;
        private readonly Mock<ILogger<WeaponServiceImpl>> _logger;
        private readonly Mock<IMapper> _mapper;

        public WeaponServiceExceptionTest()
        {
            var options = new DbContextOptionsBuilder<BrokenArrowContext>()
            .UseSqlite("Data Source =:memory:")
            .Options;

            _dbContext = new BrokenArrowContext(options);
            _logger = new Mock<ILogger<WeaponServiceImpl>>();
            _mapper = new Mock<IMapper>();
            _weaponService = new WeaponServiceImpl(_dbContext, _mapper.Object, _logger.Object);
        }

        [Fact]
        public async Task GetWeaponsAsync_ShouldThrowMilitaryNuclearAccidentException_WhenDbExceptionOccurs()
        {
            var mockSet = new Mock<DbSet<Weapon>>();
            mockSet.As<IQueryable<Weapon>>().Setup(m => m.Provider).Throws(new MilitaryNuclearAccidentException("error", new Exception()));

            var exception = await Assert.ThrowsAsync<MilitaryNuclearAccidentException>(() => _weaponService.GetWeaponsAsync());

            Assert.Equal(ConstUtils.UNABLE_TO_RETRIEVE_ALL_WEAPON, exception.Message);
        }

        [Fact]
        public async Task GetSingleWeaponAsync_ShouldThrowMilitaryNuclearAccidentException_WhenDbExceptionOccurs()
        {
            var mockSet = new Mock<DbSet<Weapon>>();
            mockSet.As<IQueryable<Weapon>>().Setup(m => m.Provider).Throws(new MilitaryNuclearAccidentException("error", new Exception()));

            var exception = await Assert.ThrowsAsync<MilitaryNuclearAccidentException>(() => _weaponService.GetSingleWeaponAsync(new Guid("d3aaceaa-7d01-4c45-bbd7-6738fb88201c")));

            Assert.Equal(ConstUtils.UNABLE_TO_RETRIEVE_SPECIFIC_WEAPON, exception.Message);
        }

        [Fact]
        public async Task GetBrokenArrowsByWeaponAsync_ShouldThrowMilitaryNuclearAccidentException_WhenDbExceptionOccurs()
        {
            var mockSet = new Mock<DbSet<Weapon>>();
            mockSet.As<IQueryable<Weapon>>().Setup(m => m.Provider).Throws(new MilitaryNuclearAccidentException("error", new Exception()));

            var exception = await Assert.ThrowsAsync<MilitaryNuclearAccidentException>(() => _weaponService.GetBrokenArrowsByWeaponAsync(AvailableWeapon.MARK15));

            Assert.Equal(ConstUtils.UNABLE_TO_RETRIEVE_BA_BY_WEAPON, exception.Message);
        }
    }
}
