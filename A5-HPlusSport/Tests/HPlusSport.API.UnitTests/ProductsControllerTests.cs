using HPlusSport.API.Controllers;
using HPlusSport.API.DataStore;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace HPlusSport.API.UnitTests
{
    public class ProductsControllerTests
    {
        [Fact]
        public void When_ProductsController_Is_Created_With_Valid_Parameters()
        {
            // Arrange
            var mockDbContextOptions = new Mock<DbContextOptions<ShopDbContext>>();
            var mockShopDbContext = new Mock<ShopDbContext>(new DbContextOptions<ShopDbContext>());

            var controller = new ProductsController(mockShopDbContext.Object);

        }
    }
}