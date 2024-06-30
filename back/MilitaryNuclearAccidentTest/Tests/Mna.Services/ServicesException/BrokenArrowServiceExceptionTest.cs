using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MilitaryNuclearAccident.Src.Mna.Common.DbSet;
using MilitaryNuclearAccident.Src.Mna.Common.Exceptions;
using MilitaryNuclearAccident.Src.Mna.Data;
using MilitaryNuclearAccident.Src.Mna.Services.Implementation;
using MilitaryNuclearAccident.Src.Mna.Services.Interfaces;
using MilitaryNuclearAccident.Src.Mna.UI.Utils;
using Moq;

namespace MilitaryNuclearAccidentTest.Tests.Mna.Services.ServicesException
{
    public class BrokenArrowServiceExceptionTest
    {
        private readonly BrokenArrowContext _dbContext;
        private readonly IBrokenArrowService _brokenArrowService;
        private readonly Mock<ILogger<BrokenArrowServiceImpl>> _logger;
        private readonly Mock<IMapper> _mapper;

        public BrokenArrowServiceExceptionTest()
        {
            var options = new DbContextOptionsBuilder<BrokenArrowContext>()
            .UseSqlite("Data Source =:memory:")
            .Options;

            _dbContext = new BrokenArrowContext(options);
            _logger = new Mock<ILogger<BrokenArrowServiceImpl>>();
            _mapper = new Mock<IMapper>();
            _brokenArrowService = new BrokenArrowServiceImpl(_dbContext, _mapper.Object, _logger.Object);
        }

        [Fact]
        public async Task GetBrokenArrowsAsync_ShouldThrowMilitaryNuclearAccidentException_WhenDbExceptionOccurs()
        {
            var mockSet = new Mock<DbSet<BrokenArrow>>();
            mockSet.As<IQueryable<BrokenArrow>>().Setup(m => m.Provider).Throws(new MilitaryNuclearAccidentException("error", new Exception()));

            var exception = await Assert.ThrowsAsync<MilitaryNuclearAccidentException>(() => _brokenArrowService.GetBrokenArrowsAsync());

            Assert.Equal(ConstUtils.UNABLE_TO_RETRIEVE_ALL_BA, exception.Message);
        }

        [Fact]
        public async Task GetBrokenArrowsByYearsAsync_ShouldThrowMilitaryNuclearAccidentException_WhenDbExceptionOccurs()
        {
            var mockSet = new Mock<DbSet<BrokenArrow>>();
            mockSet.As<IQueryable<BrokenArrow>>().Setup(m => m.Provider).Throws(new MilitaryNuclearAccidentException("error", new Exception()));

            var exception = await Assert.ThrowsAsync<MilitaryNuclearAccidentException>(() => _brokenArrowService.GetBrokenArrowsByYearsAsync(1950));

            Assert.Equal(ConstUtils.UNABLE_TO_RETRIEVE_BA_BY_YEAR, exception.Message);
        }

        [Fact]
        public async Task GetSingleBrokenArrowAsync_ShouldThrowMilitaryNuclearAccidentException_WhenDbExceptionOccurs()
        {
            var mockSet = new Mock<DbSet<BrokenArrow>>();
            mockSet.As<IQueryable<BrokenArrow>>().Setup(m => m.Provider).Throws(new MilitaryNuclearAccidentException("error", new Exception()));

            var exception = await Assert.ThrowsAsync<MilitaryNuclearAccidentException>(() => _brokenArrowService.GetSingleBrokenArrowAsync(new Guid("d3aaceaa-7d01-4c45-bbd7-6738fb88201c")));

            Assert.Equal(ConstUtils.UNABLE_TO_RETRIEVE_SINGLE_BA, exception.Message);
        }
    }
}
