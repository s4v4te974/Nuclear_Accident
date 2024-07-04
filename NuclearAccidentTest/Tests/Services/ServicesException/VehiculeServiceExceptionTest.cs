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
    public class VehiculeServiceExceptionTest
    {
        private readonly NuclearAccidentContext _dbContext;
        private readonly IVehiculeService _vehiculeService;
        private readonly Mock<ILogger<VehiculeServiceImpl>> _logger;
        private readonly Mock<IMapper> _mapper;

        public VehiculeServiceExceptionTest()
        {
            var options = new DbContextOptionsBuilder<NuclearAccidentContext>()
            .UseSqlite("Data Source =:memory:")
            .Options;

            _dbContext = new NuclearAccidentContext(options);
            _logger = new Mock<ILogger<VehiculeServiceImpl>>();
            _mapper = new Mock<IMapper>();
            _vehiculeService = new VehiculeServiceImpl(_dbContext, _mapper.Object, _logger.Object);
        }

        [Fact]
        public async Task GetVehiculesAsync_ShouldThrowNuclearAccidentException_WhenDbExceptionOccurs()
        {
            var mockSet = new Mock<DbSet<Vehicule>>();
            mockSet.As<IQueryable<Vehicule>>().Setup(m => m.Provider).Throws(new NuclearAccidentException("error", new Exception()));

            var exception = await Assert.ThrowsAsync<NuclearAccidentException>(() => _vehiculeService.GetVehiculesAsync());

            Assert.Equal(ConstUtils.UNABLE_TO_RETRIEVE_ALL_VEHICULE, exception.Message);
        }

        [Fact]
        public async Task GetSingleVehiculeAsync_ShouldThrowNuclearAccidentException_WhenDbExceptionOccurs()
        {
            var mockSet = new Mock<DbSet<Vehicule>>();
            mockSet.As<IQueryable<Vehicule>>().Setup(m => m.Provider).Throws(new NuclearAccidentException("error", new Exception()));

            var exception = await Assert.ThrowsAsync<NuclearAccidentException>(() => _vehiculeService.GetSingleVehiculeAsync(new Guid("d3aaceaa-7d01-4c45-bbd7-6738fb88201c")));

            Assert.Equal(ConstUtils.UNABLE_TO_RETRIEVE_SPECIFIC_VEHICULE, exception.Message);
        }

        [Fact]
        public async Task GetBrokenArrowsByVehiculeAsync_ShouldThrowNuclearAccidentException_WhenDbExceptionOccurs()
        {
            var mockSet = new Mock<DbSet<Vehicule>>();
            mockSet.As<IQueryable<Vehicule>>().Setup(m => m.Provider).Throws(new NuclearAccidentException("error", new Exception()));

            var exception = await Assert.ThrowsAsync<NuclearAccidentException>(() => _vehiculeService.GetAccidentsByVehiculeAsync(AvailableVehicule.CONVAIR));

            Assert.Equal(ConstUtils.UNABLE_TO_RETRIEVE_BA_BY_VEHICULE, exception.Message);
        }
    }
}
