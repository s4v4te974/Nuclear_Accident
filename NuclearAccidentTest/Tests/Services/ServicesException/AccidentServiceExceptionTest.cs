using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using NuclearAccident.Src.Common.DbSet;
using NuclearAccident.Src.Common.Exceptions;
using NuclearAccident.Src.Common.Utils;
using NuclearAccident.Src.Data;
using NuclearAccident.Src.Services.Implementation;
using NuclearAccident.Src.Services.Interfaces;

namespace NuclearAccidentTest.Tests.Mna.Services.ServicesException
{
    public class AccidentServiceExceptionTest
    {
        private readonly NuclearAccidentContext _dbContext;
        private readonly IAccidentService _brokenArrowService;
        private readonly Mock<ILogger<AccidentServiceImpl>> _logger;
        private readonly Mock<IMapper> _mapper;

        public AccidentServiceExceptionTest()
        {
            var options = new DbContextOptionsBuilder<NuclearAccidentContext>()
            .UseSqlite("Data Source =:memory:")
            .Options;

            _dbContext = new NuclearAccidentContext(options);
            _logger = new Mock<ILogger<AccidentServiceImpl>>();
            _mapper = new Mock<IMapper>();
            _brokenArrowService = new AccidentServiceImpl(_dbContext, _mapper.Object, _logger.Object);
        }

        [Fact]
        public async Task GetBrokenArrowsAsync_ShouldThrowNuclearAccidentException_WhenDbExceptionOccurs()
        {
            var mockSet = new Mock<DbSet<Accident>>();
            mockSet.As<IQueryable<Accident>>().Setup(m => m.Provider).Throws(new NuclearAccidentException("error", new Exception()));

            var exception = await Assert.ThrowsAsync<NuclearAccidentException>(() => _brokenArrowService.GetAccidentsAsync());

            Assert.Equal(ConstUtils.UNABLE_TO_RETRIEVE_ALL_BA, exception.Message);
        }

        [Fact]
        public async Task GetBrokenArrowsByYearsAsync_ShouldThrowNuclearAccidentException_WhenDbExceptionOccurs()
        {
            var mockSet = new Mock<DbSet<Accident>>();
            mockSet.As<IQueryable<Accident>>().Setup(m => m.Provider).Throws(new NuclearAccidentException("error", new Exception()));

            var exception = await Assert.ThrowsAsync<NuclearAccidentException>(() => _brokenArrowService.GetAccidentsByYearsAsync(1950));

            Assert.Equal(ConstUtils.UNABLE_TO_RETRIEVE_BA_BY_YEAR, exception.Message);
        }

        [Fact]
        public async Task GetSingleBrokenArrowAsync_ShouldThrowNuclearAccidentException_WhenDbExceptionOccurs()
        {
            var mockSet = new Mock<DbSet<Accident>>();
            mockSet.As<IQueryable<Accident>>().Setup(m => m.Provider).Throws(new NuclearAccidentException("error", new Exception()));

            var exception = await Assert.ThrowsAsync<NuclearAccidentException>(() => _brokenArrowService.GetSingleAccidentAsync(new Guid("d3aaceaa-7d01-4c45-bbd7-6738fb88201c")));

            Assert.Equal(ConstUtils.UNABLE_TO_RETRIEVE_SINGLE_BA, exception.Message);
        }
    }
}
