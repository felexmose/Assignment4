using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public interface IDataService
    {
        Order GetOrderById(int id);
        List<Order> GetOrderByShippingName(string shippingName);
        List<Order> GetAllOrders();
        List<OrderDetailsWithProductName> GetOrderDetailsByOrderId(int orderId);
        List<OrderDetails> GetDetailsForSpecificProductId(string productId);
        Product GetProductById(int productId);
        List<Product> GetProductsThatContainSubstring(string substring);
        List<Product> GetProductsByCategoryId(int categoryId);
        Category GetCategoryById(int categoryId);
        List<Category> GetAllCategories();
        Category CreateCategory(string name, string description);
        bool UpdateCategory(int id, string name, string description);
        bool DeleteCategory(int id);

    }
}
