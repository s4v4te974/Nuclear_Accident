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
    public class LocationServiceExceptionTest
    {
        private readonly BrokenArrowContext _dbContext;
        private readonly ILocationService _locationService;
        private readonly Mock<ILogger<LocationServiceImpl>> _logger;
        private readonly Mock<IMapper> _mapper;

        public LocationServiceExceptionTest()
        {
            var options = new DbContextOptionsBuilder<BrokenArrowContext>()
            .UseSqlite("Data Source =:memory:")
            .Options;

            _dbContext = new BrokenArrowContext(options);
            _logger = new Mock<ILogger<LocationServiceImpl>>();
            _mapper = new Mock<IMapper>();
            _locationService = new LocationServiceImpl(_dbContext, _mapper.Object, _logger.Object);
        }

        [Fact]
        public async Task GetLocationAsync_ShouldThrowMilitaryNuclearAccidentException_WhenDbExceptionOccurs()
        {
            var mockSet = new Mock<DbSet<Location>>();
            mockSet.As<IQueryable<Location>>().Setup(m => m.Provider).Throws(new MilitaryNuclearAccidentException("error", new Exception()));

            var exception = await Assert.ThrowsAsync<MilitaryNuclearAccidentException>(() => _locationService.GetLocationAsync());

            Assert.Equal(ConstUtils.UNABLE_TO_RETRIEVE_BA_BY_LOCATION, exception.Message);
        }

        [Fact]
        public async Task GetSingleLocationAsync_ShouldThrowMilitaryNuclearAccidentException_WhenDbExceptionOccurs()
        {
            var mockSet = new Mock<DbSet<Location>>();
            mockSet.As<IQueryable<Location>>().Setup(m => m.Provider).Throws(new MilitaryNuclearAccidentException("error", new Exception()));

            var exception = await Assert.ThrowsAsync<MilitaryNuclearAccidentException>(() => _locationService.GetSingleLocationAsync(new Guid("d3aaceaa-7d01-4c45-bbd7-6738fb88201c")));

            Assert.Equal(ConstUtils.UNABLE_TO_RETRIEVE_SPECIFIC_LOCATION, exception.Message);
        }

        [Fact]
        public async Task GetBrokenArrowsByLocationAsync_ShouldThrowMilitaryNuclearAccidentException_WhenDbExceptionOccurs()
        {
            var mockSet = new Mock<DbSet<Location>>();
            mockSet.As<IQueryable<Location>>().Setup(m => m.Provider).Throws(new MilitaryNuclearAccidentException("error", new Exception()));

            var exception = await Assert.ThrowsAsync<MilitaryNuclearAccidentException>(() => _locationService.GetBrokenArrowsByLocationAsync(AvailableLocation.CANADA));

            Assert.Equal(ConstUtils.UNABLE_TO_RETRIEVE_BA_BY_LOCATION, exception.Message);
        }
    }
}
