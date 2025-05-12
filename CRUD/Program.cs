using CRUD.Services;
using CRUD.Models;
using CRUD.Services.Interfaces;
using System.Collections.Generic;
UserOrderService userOrderService = new UserOrderService();
List<Product> products = new List<Product>();
int userStartChoice = 0;
Console.WriteLine("Welcome to the Product Management System!");
Home:
Console.WriteLine("Please select an option:");
Console.WriteLine("1. Create Product");
Console.WriteLine("2. Update Product");
Console.WriteLine("3. Delete Product");
Console.WriteLine("4. View All Products");
userStartChoice = Convert.ToInt32(Console.ReadLine());

switch (userStartChoice)
{
    case 1:
        userOrderService.CreateProduct(products);
        goto Home;
    case 2:
        Console.WriteLine("Please select an option:");
        Console.WriteLine("1.Update ID:");
        Console.WriteLine("2.Update Name:");
        Console.WriteLine("3.Update Price:");
        Console.WriteLine("4.Update Description:");
        int userUpdateChoice = Convert.ToInt32(Console.ReadLine());
        switch (userUpdateChoice)
        {
            case 1:
                Console.WriteLine("Enter Product ID to update: ");
                int productIdToUpdate = Convert.ToInt32(Console.ReadLine());
                userOrderService.UpdateProductId(userOrderService.GetProductById(products, productIdToUpdate), products);
                goto Home;
            case 2:
                Console.WriteLine("Enter Product ID to update: ");
                productIdToUpdate = Convert.ToInt32(Console.ReadLine());
                userOrderService.UpdateProductName(userOrderService.GetProductById(products, productIdToUpdate), products);
                goto Home;
            case 3:
                Console.WriteLine("Enter Product ID to update: ");
                productIdToUpdate = Convert.ToInt32(Console.ReadLine());
                userOrderService.UpdateProductPrice(userOrderService.GetProductById(products, productIdToUpdate), products);
                goto Home;
            case 4:
                Console.WriteLine("Enter Product ID to update: ");
                productIdToUpdate = Convert.ToInt32(Console.ReadLine());
                userOrderService.UpdateProductDescription(userOrderService.GetProductById(products, productIdToUpdate), products);
                goto Home;
        }
        goto Home;
    case 3:
        Console.WriteLine("Enter Product ID to delete: ");
        int productIdToDelete = Convert.ToInt32(Console.ReadLine());
        userOrderService.Delete(productIdToDelete, products);
        goto Home;
    case 4:
        userOrderService.GetAllProducts(products);
        goto Home;
}