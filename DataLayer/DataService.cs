using DataLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace DataLayer
{
    public class DataService : IDataService
    {
        private readonly NorthwindContext _db;
        public DataService()
        {
            this._db = new NorthwindContext();
        }

        public Category CreateCategory(string name, string description)
        {
            var category = new Category() { CategoryId = 9, Name = name, Description = description };
            _db.Categories.Add(category);
            _db.SaveChanges();
            
            return _db.Categories.Where(x => x.Name == name).FirstOrDefault()!;
        }

        public bool DeleteCategory(int id)
        {
            var cat = _db.Categories.Where(x => x.CategoryId == id).FirstOrDefault();
            if (cat == null)
            {
                return false;
            }
            _db.Categories.Remove(cat);
            _db.SaveChanges();
            
            return true;
        }

        public List<Category> GetAllCategories()
        {
            return _db.Categories.ToList();
        }

        public List<Order> GetAllOrders()
        {
            return _db.Orders.ToList();
        }

        public Category GetCategoryById(int categoryId)
        {
           return _db.Categories.Where(x => x.CategoryId == categoryId).FirstOrDefault()!;
        }

        // fix OrderDetails issue
        public List<OrderDetails> GetDetailsForSpecificProductId(string productId)
        {
            throw new NotImplementedException();
        }

        public Order GetOrderById(int id)
        {
            return _db.Orders.Where(x => x.Id == id).FirstOrDefault()!;
        }

        public List<Order> GetOrderByShippingName(string shippingName)
        {
            return _db.Orders.Where(x => x.ShipName == shippingName).ToList();
        }

        // fix OrderDetails issue
        public List<OrderDetailsWithProductName> GetOrderDetailsByOrderId(int orderId)
        {
            //return _db.OrderDetails
            //    .Where(x => x.Order.Id == orderId)
            //    .Select(x => new OrderDetailsWithProductName { ProductName = x.Product.Name, UnitPrice = x.UnitPrice , Quantity = x.Quantity })
            //    .ToList();
            throw new NotImplementedException();
        }

        public Product GetProductById(int productId)
        {
            return _db.Products.Where(x => x.Id == productId).FirstOrDefault()!;
        }

        public List<Product> GetProductsByCategoryId(int categoryId)
        {
            return _db.Products.Where(x => x.CategoryId == categoryId).ToList();
        }

        // return new object with product name and category name??
        public List<Product> GetProductsThatContainSubstring(string substring)
        {
            return _db.Products.Where(x => x.Name.Contains(substring)).ToList();
        }

        public bool UpdateCategory(int id, string name, string description)
        {

            var cat = _db.Categories.Where(x => x.CategoryId == id).FirstOrDefault();

            if (cat == null)
            {
                return false;
            }
            //var cat2Delete = new Category() { CategoryId = id, Name = name, Description = description };
            _db.Categories.Remove(cat);
            var newCat = new Category() {CategoryId = id, Name = name, Description = description };
            _db.Categories.Add(newCat);
            _db.SaveChanges();
            
            return true;
        }
    }
}
