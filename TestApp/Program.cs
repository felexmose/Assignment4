using DataLayer;

var ds = new DataService();

var category = ds.GetCategoryById(2);
var order = ds.GetOrderById(10500);
var orderByShippingNameList = ds.GetOrderByShippingName("Ernst Handel");
var productById = ds.GetProductById(3);
var GetProductsByCategoryId = ds.GetProductsByCategoryId(1);
var GetAllCategories = ds.GetAllCategories();
var GetAllOrders = ds.GetAllOrders();

Console.WriteLine($"The category name: {category.Name}");
Console.WriteLine($"The order date: {order.Date}");
Console.WriteLine($"The number of orders by shipping name Ernst Handel: {orderByShippingNameList.Count()}");
Console.WriteLine($"The product by id: {productById.Name}");
Console.WriteLine($"The number of product by category id 2: {GetProductsByCategoryId.Count()}");
Console.WriteLine($"The get all categories count: {GetAllCategories.Count()}");
Console.WriteLine($"The get all orders count: {GetAllOrders.Count()}");