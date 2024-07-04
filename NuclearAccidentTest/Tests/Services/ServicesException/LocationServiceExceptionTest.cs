using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using NuclearAccident.Src.Common.DbSet;
using NuclearAccident.Src.Common.Enum;
using NuclearAccident.Src.Common.Exceptions;
using NuclearAccident.Src.Common.Utils;
using NuclearAccident.Src.Data;
using NuclearAccident.Src.Services.Implementation;
using NuclearAccident.Src.Services.Interfaces;

namespace MilitaryNuclearAccidentTest.Tests.Mna.Services.ServicesException
{
    public class LocationServiceExceptionTest
    {
        private readonly NuclearAccidentContext _dbContext;
        private readonly ILocationService _locationService;
        private readonly Mock<ILogger<LocationServiceImpl>> _logger;
        private readonly Mock<IMapper> _mapper;

        public LocationServiceExceptionTest()
        {
            var options = new DbContextOptionsBuilder<NuclearAccidentContext>()
            .UseSqlite("Data Source =:memory:")
            .Options;

            _dbContext = new NuclearAccidentContext(options);
            _logger = new Mock<ILogger<LocationServiceImpl>>();
            _mapper = new Mock<IMapper>();
            _locationService = new LocationServiceImpl(_dbContext, _mapper.Object, _logger.Object);
        }

        [Fact]
        public async Task GetLocationAsync_ShouldThrowNuclearAccidentException_WhenDbExceptionOccurs()
        {
            var mockSet = new Mock<DbSet<Location>>();
            mockSet.As<IQueryable<Location>>().Setup(m => m.Provider).Throws(new NuclearAccidentException("error", new Exception()));

            var exception = await Assert.ThrowsAsync<NuclearAccidentException>(() => _locationService.GetLocationAsync());

            Assert.Equal(ConstUtils.UNABLE_TO_RETRIEVE_BA_BY_LOCATION, exception.Message);
        }

        [Fact]
        public async Task GetSingleLocationAsync_ShouldThrowNuclearAccidentException_WhenDbExceptionOccurs()
        {
            var mockSet = new Mock<DbSet<Location>>();
            mockSet.As<IQueryable<Location>>().Setup(m => m.Provider).Throws(new NuclearAccidentException("error", new Exception()));

            var exception = await Assert.ThrowsAsync<NuclearAccidentException>(() => _locationService.GetSingleLocationAsync(new Guid("d3aaceaa-7d01-4c45-bbd7-6738fb88201c")));

            Assert.Equal(ConstUtils.UNABLE_TO_RETRIEVE_SPECIFIC_LOCATION, exception.Message);
        }

        [Fact]
        public async Task GetBrokenArrowsByLocationAsync_ShouldThrowNuclearAccidentException_WhenDbExceptionOccurs()
        {
            var mockSet = new Mock<DbSet<Location>>();
            mockSet.As<IQueryable<Location>>().Setup(m => m.Provider).Throws(new NuclearAccidentException("error", new Exception()));

            var exception = await Assert.ThrowsAsync<NuclearAccidentException>(() => _locationService.GetAccidentsByLocationAsync(AvailableLocation.CANADA));

            Assert.Equal(ConstUtils.UNABLE_TO_RETRIEVE_BA_BY_LOCATION, exception.Message);
        }
    }
}
