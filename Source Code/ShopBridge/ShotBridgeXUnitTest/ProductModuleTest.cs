using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using ShopBridge.Entities;
using ShopBridge.Controllers;
using Moq;
using ShopBridge.Repository;

namespace ShotBridgeXUnitTest
{
    public class ProductModuleTest
    {
        public Mock<IProductRepository> mockProductRepo = new Mock<IProductRepository>();
        [Fact]
        public async Task AddProductTest_ForNullProductName()
        {
            //Arrange
            var tblProductDetails = new tblProductDetails()
            {
                Brand = Guid.NewGuid().ToString(),
                Description = Guid.NewGuid().ToString(),
                DiscountInPercentage = new Random().Next(99),
                IsReplaceable = false,
                IsReturnable = false,
                Manufacturer = Guid.NewGuid().ToString(),
                PDID = 0,
                Price = new Random().Next(1000),
                Status = "Active"
            };
            mockProductRepo.Setup(a => a.AddProductAsync(tblProductDetails)).ReturnsAsync(tblProductDetails);
            ProductController product = new ProductController(mockProductRepo.Object);
            //Act            
            var result = await product.AddProductAsync(tblProductDetails);
            //Assert            
            Assert.True(!tblProductDetails.Equals(result));
        }
    }
}
