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
    public class VehiculeServiceExceptionTest
    {
        private readonly BrokenArrowContext _dbContext;
        private readonly IVehiculeService _vehiculeService;
        private readonly Mock<ILogger<VehiculeServiceImpl>> _logger;
        private readonly Mock<IMapper> _mapper;

        public VehiculeServiceExceptionTest()
        {
            var options = new DbContextOptionsBuilder<BrokenArrowContext>()
            .UseSqlite("Data Source =:memory:")
            .Options;

            _dbContext = new BrokenArrowContext(options);
            _logger = new Mock<ILogger<VehiculeServiceImpl>>();
            _mapper = new Mock<IMapper>();
            _vehiculeService = new VehiculeServiceImpl(_dbContext, _mapper.Object, _logger.Object);
        }

        [Fact]
        public async Task GetVehiculesAsync_ShouldThrowMilitaryNuclearAccidentException_WhenDbExceptionOccurs()
        {
            var mockSet = new Mock<DbSet<Vehicule>>();
            mockSet.As<IQueryable<Vehicule>>().Setup(m => m.Provider).Throws(new MilitaryNuclearAccidentException("error", new Exception()));

            var exception = await Assert.ThrowsAsync<MilitaryNuclearAccidentException>(() => _vehiculeService.GetVehiculesAsync());

            Assert.Equal(ConstUtils.UNABLE_TO_RETRIEVE_ALL_VEHICULE, exception.Message);
        }

        [Fact]
        public async Task GetSingleVehiculeAsync_ShouldThrowMilitaryNuclearAccidentException_WhenDbExceptionOccurs()
        {
            var mockSet = new Mock<DbSet<Vehicule>>();
            mockSet.As<IQueryable<Vehicule>>().Setup(m => m.Provider).Throws(new MilitaryNuclearAccidentException("error", new Exception()));

            var exception = await Assert.ThrowsAsync<MilitaryNuclearAccidentException>(() => _vehiculeService.GetSingleVehiculeAsync(new Guid("d3aaceaa-7d01-4c45-bbd7-6738fb88201c")));

            Assert.Equal(ConstUtils.UNABLE_TO_RETRIEVE_SPECIFIC_VEHICULE, exception.Message);
        }

        [Fact]
        public async Task GetBrokenArrowsByVehiculeAsync_ShouldThrowMilitaryNuclearAccidentException_WhenDbExceptionOccurs()
        {
            var mockSet = new Mock<DbSet<Vehicule>>();
            mockSet.As<IQueryable<Vehicule>>().Setup(m => m.Provider).Throws(new MilitaryNuclearAccidentException("error", new Exception()));

            var exception = await Assert.ThrowsAsync<MilitaryNuclearAccidentException>(() => _vehiculeService.GetBrokenArrowsByVehiculeAsync(AvailableVehicule.CONVAIR));

            Assert.Equal(ConstUtils.UNABLE_TO_RETRIEVE_BA_BY_VEHICULE, exception.Message);
        }
    }
}
