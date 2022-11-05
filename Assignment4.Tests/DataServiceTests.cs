using DataLayer;
using DataLayer.Models;

namespace Assignment4.Tests
{
    public class DataServiceTests
    {
        /* Categories */

        [Fact]
        public void Category_Object_HasIdNameDescription()
        {
            var category = new Category();
            Assert.Equal(0, category.CategoryId);
            Assert.Null(category.Name);
            Assert.Null(category.Description);
        }

        [Fact]
        public void GetAllCategories_NoArgument_ReturnsAllCategories()
        {
            var service = new DataService();
            var categories = service.GetAllCategories();
            Assert.Equal(8, categories.Count);
            Assert.Equal("Beverages", categories.First().Name);
        }

        [Fact]
        public void GetCategory_ValidId_ReturnsCategoryObject()
        {
            var service = new DataService();
            var category = service.GetCategoryById(1);
            Assert.Equal("Beverages", category.Name);
        }

        [Fact]
        public void CreateCategory_ValidData_CreteCategoryAndReturnsNewObject()
        {
            var service = new DataService();
            var category = service.CreateCategory("Test", "CreateCategory_ValidData_CreteCategoryAndReturnsNewObject");
            Assert.True(category.CategoryId > 0);
            Assert.Equal("Test", category.Name);
            Assert.Equal("CreateCategory_ValidData_CreteCategoryAndReturnsNewObject", category.Description);

            // cleanup
            service.DeleteCategory(category.CategoryId);
        }

        [Fact]
        public void DeleteCategory_ValidId_RemoveTheCategory()
        {
            var service = new DataService();
            var category = service.CreateCategory("Test", "DeleteCategory_ValidId_RemoveTheCategory");
            var result = service.DeleteCategory(category.CategoryId);
            Assert.True(result);
            category = service.GetCategoryById(category.CategoryId);
            Assert.Null(category);
        }

        [Fact]
        public void DeleteCategory_InvalidId_ReturnsFalse()
        {
            var service = new DataService();
            var result = service.DeleteCategory(-1);
            Assert.False(result);
        }

        [Fact]
        public void UpdateCategory_NewNameAndDescription_UpdateWithNewValues()
        {
            var service = new DataService();
            var category = service.CreateCategory("TestingUpdate", "UpdateCategory_NewNameAndDescription_UpdateWithNewValues");

            var result = service.UpdateCategory(category.CategoryId, "UpdatedName", "UpdatedDescription");
            Assert.True(result);

            category = service.GetCategoryById(category.CategoryId);

            Assert.Equal("UpdatedName", category.Name);
            Assert.Equal("UpdatedDescription", category.Description);

            // cleanup
            service.DeleteCategory(category.CategoryId);
        }

        [Fact]
        public void UpdateCategory_InvalidID_ReturnsFalse()
        {
            var service = new DataService();
            var result = service.UpdateCategory(-1, "UpdatedName", "UpdatedDescription");
            Assert.False(result);
        }


        /* products */

        [Fact]
        public void Product_Object_HasIdNameUnitPriceQuantityPerUnitAndUnitsInStock()
        {
            var product = new Product();
            Assert.Equal(0, product.Id);
            Assert.Null(product.Name);
            Assert.Equal(0.0, product.UnitPrice);
            Assert.Null(product.QuantityPerUnit);
            Assert.Equal(0, product.UnitsInStock);
        }

        [Fact]
        public void GetProduct_ValidId_ReturnsProductWithCategory()
        {
            var service = new DataService();
            var product = service.GetProductById(1);
            Assert.Equal("Chai", product.Name);
            //Assert.Equal("Beverages", product.Category?.Name);
        }

        [Fact]
        public void GetProductsByCategory_ValidId_ReturnsProductWithCategory()
        {
            var service = new DataService();
            var products = service.GetProductsByCategoryId(1);
            Assert.Equal(12, products.Count);
            Assert.Equal("Chai", products.First().Name);
            //Assert.Equal("Beverages", products.First().Name);
            Assert.Equal("Lakkalik��ri", products.Last().Name);
        }

        [Fact]
        public void GetProduct_NameSubString_ReturnsProductsThatMatchesTheSubString()
        {
            var service = new DataService();
            var products = service.GetProductsThatContainSubstring("em");
            Assert.Equal(4, products.Count);
            Assert.Equal("NuNuCa Nu�-Nougat-Creme", products.First().Name);
            Assert.Equal("Flotemysost", products.Last().Name);
        }

        /* orders */
        //[Fact]
        //public void Order_Object_HasIdDatesAndOrderDetails()
        //{
        //    var order = new Order();
        //    Assert.Equal(0, order.Id);
        //    Assert.Equal(new DateTime(), order.Date);
        //    Assert.Equal(new DateTime(), order.Require);
        //    //Assert.Null(order.OrderDetails);
        //    Assert.Null(order.ShipName);
        //    Assert.Null(order.ShipCity);
        //}

        //[Fact]
        //public void GetOrder_ValidId_ReturnsCompleteOrder()
        //{
        //    var service = new DataService();
        //    var order = service.GetOrderById(10248);
        //    Assert.Equal(3, order.OrderDetails?.Count);
        //    Assert.Equal("Queso Cabrales", order.OrderDetails?.First().Product?.Name);
        //    Assert.Equal("Dairy Products", order.OrderDetails?.First().Product?.Category?.Name);
        //}

        [Fact]
        public void GetOrders()
        {
            var service = new DataService();
            var orders = service.GetAllOrders();
            Assert.Equal(830, orders.Count);
        }


        /* order details */
        [Fact]
        public void OrderDetails_Object_HasOrderProductUnitPriceQuantityAndDiscount()
        {
            var orderDetails = new OrderDetails();
            Assert.Equal(0, orderDetails.OrderId);
            Assert.Null(orderDetails.Order);
            Assert.Equal(0, orderDetails.ProductId);
            Assert.Null(orderDetails.Product);
            Assert.Equal(0.0, orderDetails.UnitPrice);
            Assert.Equal(0.0, orderDetails.Quantity);
            Assert.Equal(0.0, orderDetails.Discount);
        }

        //[Fact]
        //public void GetOrderDetailByOrderId_ValidId_ReturnsProductNameUnitPriceAndQuantity()
        //{
        //    var service = new DataService();
        //    var orderDetails = service.GetOrderDetailsByOrderId(10248);
        //    Assert.Equal(3, orderDetails.Count);
        //    Assert.Equal("Queso Cabrales", orderDetails.First().Product?.Name);
        //    Assert.Equal(14, orderDetails.First().UnitPrice);
        //    Assert.Equal(12, orderDetails.First().Quantity);
        //}

        //[Fact]
        //public void GetOrderDetailByProductId_ValidId_ReturnsOrderDateUnitPriceAndQuantity()
        //{
        //    var service = new DataService();
        //    var orderDetails = service.GetOrderDetailsByProductId(11);
        //    Assert.Equal(38, orderDetails.Count);
        //    Assert.Equal("1996-07-04", orderDetails.First().Order?.Date.ToString("yyyy-MM-dd"));
        //    Assert.Equal(14, orderDetails.First().UnitPrice);
        //    Assert.Equal(12, orderDetails.First().Quantity);
        //}
#if COMMENT
#endif
    }
}
