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
    public class VehiculeServiceExceptionTest
    {
        private readonly NuclearBrokenArrowsContext _dbContext;
        private readonly IVehiculeService _vehiculeService;
        private readonly Mock<ILogger<VehiculeServiceImpl>> _logger;
        private readonly Mock<IMapper> _mapper;

        public VehiculeServiceExceptionTest()
        {
            var options = new DbContextOptionsBuilder<NuclearBrokenArrowsContext>()
            .UseSqlite("Data Source =:memory:")
            .Options;

            _dbContext = new NuclearBrokenArrowsContext(options);
            _logger = new Mock<ILogger<VehiculeServiceImpl>>();
            _mapper = new Mock<IMapper>();
            _vehiculeService = new VehiculeServiceImpl(_dbContext, _mapper.Object, _logger.Object);
        }

        [Fact]
        public async Task GetVehiculesAsync_ShouldThrowNuclearBrokenArrowsException_WhenDbExceptionOccurs()
        {
            var mockSet = new Mock<DbSet<Vehicule>>();
            mockSet.As<IQueryable<Vehicule>>().Setup(m => m.Provider).Throws(new NuclearIncidentException("error", new Exception()));

            var exception = await Assert.ThrowsAsync<NuclearIncidentException>(() => _vehiculeService.GetVehiculesAsync());

            Assert.Equal(ConstUtils.UNABLE_TO_RETRIEVE_ALL_VEHICULE, exception.Message);
        }

        [Fact]
        public async Task GetSingleVehiculeAsync_ShouldThrowNuclearBrokenArrowsException_WhenDbExceptionOccurs()
        {
            var mockSet = new Mock<DbSet<Vehicule>>();
            mockSet.As<IQueryable<Vehicule>>().Setup(m => m.Provider).Throws(new NuclearIncidentException("error", new Exception()));

            var exception = await Assert.ThrowsAsync<NuclearIncidentException>(() => _vehiculeService.GetSingleVehiculeAsync(new Guid("d3aaceaa-7d01-4c45-bbd7-6738fb88201c")));

            Assert.Equal(ConstUtils.UNABLE_TO_RETRIEVE_SPECIFIC_VEHICULE, exception.Message);
        }

        [Fact]
        public async Task GetBrokenArrowssByVehiculeAsync_ShouldThrowNuclearBrokenArrowsException_WhenDbExceptionOccurs()
        {
            var mockSet = new Mock<DbSet<Vehicule>>();
            mockSet.As<IQueryable<Vehicule>>().Setup(m => m.Provider).Throws(new NuclearIncidentException("error", new Exception()));

            var exception = await Assert.ThrowsAsync<NuclearIncidentException>(() => _vehiculeService.GetBrokenArrowssByVehiculeAsync(AvailableVehicule.CONVAIR));

            Assert.Equal(ConstUtils.UNABLE_TO_RETRIEVE_BA_BY_VEHICULE, exception.Message);
        }
    }
}
