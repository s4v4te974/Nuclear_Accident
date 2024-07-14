using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using NuclearIncident.Src.Common.DbSet;
using NuclearIncident.Src.Common.Exceptions;
using NuclearIncident.Src.Common.Utils;
using NuclearIncident.Src.Data;
using NuclearIncident.Src.Services.Implementation.BrokenArrows;
using NuclearIncident.Src.Services.Interfaces.BrokenArrows;

namespace NuclearInccidentTest.Tests.Services.ServicesException
{
    public class BrokenArrowsServiceExceptionTest
    {
        private readonly NuclearBrokenArrowsContext _dbContext;
        private readonly IbrokenArrowsService _BrokenArrowsService;
        private readonly Mock<ILogger<BrokenArrowsServiceImpl>> _logger;
        private readonly Mock<IMapper> _mapper;

        public BrokenArrowsServiceExceptionTest()
        {
            var options = new DbContextOptionsBuilder<NuclearBrokenArrowsContext>()
            .UseSqlite("Data Source =:memory:")
            .Options;

            _dbContext = new NuclearBrokenArrowsContext(options);
            _logger = new Mock<ILogger<BrokenArrowsServiceImpl>>();
            _mapper = new Mock<IMapper>();
            _BrokenArrowsService = new BrokenArrowsServiceImpl(_dbContext, _mapper.Object, _logger.Object);
        }

        [Fact]
        public async Task GetBrokenArrowssAsync_ShouldThrowNuclearBrokenArrowsException_WhenDbExceptionOccurs()
        {
            var mockSet = new Mock<DbSet<BrokenArrow>>();
            mockSet.As<IQueryable<BrokenArrow>>().Setup(m => m.Provider).Throws(new NuclearIncidentException("error", new Exception()));

            var exception = await Assert.ThrowsAsync<NuclearIncidentException>(() => _BrokenArrowsService.GetBrokenArrowssAsync());

            Assert.Equal(ConstUtils.UNABLE_TO_RETRIEVE_ALL_BA, exception.Message);
        }

        [Fact]
        public async Task GetBrokenArrowssByYearsAsync_ShouldThrowNuclearBrokenArrowsException_WhenDbExceptionOccurs()
        {
            var mockSet = new Mock<DbSet<BrokenArrow>>();
            mockSet.As<IQueryable<BrokenArrow>>().Setup(m => m.Provider).Throws(new NuclearIncidentException("error", new Exception()));

            var exception = await Assert.ThrowsAsync<NuclearIncidentException>(() => _BrokenArrowsService.GetBrokenArrowssByYearsAsync(1950));

            Assert.Equal(ConstUtils.UNABLE_TO_RETRIEVE_BA_BY_YEAR, exception.Message);
        }

        [Fact]
        public async Task GetSingleBrokenArrowsAsync_ShouldThrowNuclearBrokenArrowsException_WhenDbExceptionOccurs()
        {
            var mockSet = new Mock<DbSet<BrokenArrow>>();
            mockSet.As<IQueryable<BrokenArrow>>().Setup(m => m.Provider).Throws(new NuclearIncidentException("error", new Exception()));

            var exception = await Assert.ThrowsAsync<NuclearIncidentException>(() => _BrokenArrowsService.GetSingleBrokenArrowsAsync(new Guid("d3aaceaa-7d01-4c45-bbd7-6738fb88201c")));

            Assert.Equal(ConstUtils.UNABLE_TO_RETRIEVE_SINGLE_BA, exception.Message);
        }
    }
}
