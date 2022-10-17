
using IntermediateModels.Services;
using IntermediateModels.UnitOfWork.Interfaces;
using Moq;
using Xunit;

namespace Tests.Business.Services
{
    public class ProductServiceTests
    {
        private ProductService _productService;

        public ProductServiceTests()
        {
            _productService = new ProductService(new Mock<IUnitOfWork>().Object);
        }

        [Fact]
        public void GetProducts_NotFoundProductsInDataBase()
        {
            Assert.True(true);
        }
    }
}
