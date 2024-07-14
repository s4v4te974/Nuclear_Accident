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
            mockSet.As<IQueryable<Location>>().Setup(m => m.Provider).Throws(new NuclearIncidentException("error", new Exception()));

            var exception = await Assert.ThrowsAsync<NuclearIncidentException>(() => _locationService.GetLocationAsync());

            Assert.Equal(ConstUtils.UNABLE_TO_RETRIEVE_BA_BY_LOCATION, exception.Message);
        }

        [Fact]
        public async Task GetSingleLocationAsync_ShouldThrowNuclearAccidentException_WhenDbExceptionOccurs()
        {
            var mockSet = new Mock<DbSet<Location>>();
            mockSet.As<IQueryable<Location>>().Setup(m => m.Provider).Throws(new NuclearIncidentException("error", new Exception()));

            var exception = await Assert.ThrowsAsync<NuclearIncidentException>(() => _locationService.GetSingleLocationAsync(new Guid("d3aaceaa-7d01-4c45-bbd7-6738fb88201c")));

            Assert.Equal(ConstUtils.UNABLE_TO_RETRIEVE_SPECIFIC_LOCATION, exception.Message);
        }

        [Fact]
        public async Task GetAccidentsByLocationAsync_ShouldThrowNuclearAccidentException_WhenDbExceptionOccurs()
        {
            var mockSet = new Mock<DbSet<Location>>();
            mockSet.As<IQueryable<Location>>().Setup(m => m.Provider).Throws(new NuclearIncidentException("error", new Exception()));

            var exception = await Assert.ThrowsAsync<NuclearIncidentException>(() => _locationService.GetAccidentsByLocationAsync(AvailableLocation.CANADA));

            Assert.Equal(ConstUtils.UNABLE_TO_RETRIEVE_BA_BY_LOCATION, exception.Message);
        }
    }
}
