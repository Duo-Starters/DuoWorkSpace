using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRUD.Models;
using CRUD.Services.Interfaces;

namespace CRUD.Services
{
    class UserOrderService : ICrudService, IProductID
    {
        public bool CheckProductIDAvaibilaty(List<Product> products, int inputID)
        {
            foreach (Product product in products)
            {
                if (product.ProductId == inputID)
                {
                    return false;
                }
            }
            return true;
        }

        public Product CreateProduct(List<Product> products)
        {
            Product product = new Product();
            while (true)
            {
                try
                {
                    Console.WriteLine("Enter Product ID: ");
                    product.ProductId = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input. Please enter a valid integer for Product ID.");
                    continue;
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Input is too large. Please enter a smaller integer for Product ID.");
                    continue;
                }
                    if (CheckProductIDAvaibilaty(products, product.ProductId))
                {
                    Console.WriteLine("Enter Product Name: ");
                    product.ProductName = Console.ReadLine();
                    try
                    {
                        Console.WriteLine("Enter Product Price: ");
                        product.ProductPrice = Convert.ToInt32(Console.ReadLine());
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Invalid input. Please enter a valid integer/double for Product Price.");
                        continue;
                    }
                    catch (OverflowException)
                    {
                        Console.WriteLine("Input is too large. Please enter a smaller integer for Product Price.");
                        continue;
                    }
                    Console.WriteLine("Enter Product Description: ");
                    product.ProductDescription = Console.ReadLine();
                    Console.WriteLine("Product created successfully!");
                    break;
                }
                else
                {
                    Console.WriteLine("Product ID already exists. Please enter a different ID.");
                }
            }
            products.Add(product);
            return product;
        }

        public IEnumerable<Product> Delete(int ProductID, List<Product> products)
        {
            var product = GetProductById(products, ProductID);
            if (product == null)
            {
                Console.WriteLine("Product not found.");
                return products;
            }
            products.Remove(GetProductById(products, ProductID));
            Console.WriteLine("Product deleted successfully!");
            return products;
        }

        public IEnumerable<Product> GetAllProducts(List<Product> products)
        {
            foreach (Product product in products)
            {
                Console.WriteLine($"Product ID: {product.ProductId}");
                Console.WriteLine($"Product Name: {product.ProductName}");
                Console.WriteLine($"Product Price: {product.ProductPrice}");
                Console.WriteLine($"Product Description: {product.ProductDescription}");
                Console.WriteLine("====================================================");
            }
            return products;
        }

        public Product GetProductById(List<Product> products, int id)
        {
            var product = products.FirstOrDefault(p => p.ProductId == id);
            if (product == null)
            {
                return null;
            }
            else
            {
                return product;
            }
        }

        public Product UpdateProductDescription(Product product, List<Product> products)
        {
            var updatedProduct = GetProductById(products, product.ProductId);
            if (updatedProduct != null)
            {
                products.Remove(product);
                Console.WriteLine("Enter new Product Description: ");
                updatedProduct.ProductDescription = Console.ReadLine();
                products.Add(updatedProduct);
                return updatedProduct;
            }
            else
            {
                Console.WriteLine("Product not found.");
                return null;
            }
        }


        public Product UpdateProductId(Product product, List<Product> products)
        {
            var updatedProduct = GetProductById(products, product.ProductId);
            if (updatedProduct != null)
            {
                products.Remove(product);
                Console.WriteLine("Enter new Product ID: ");
                updatedProduct.ProductId = Convert.ToInt32(Console.ReadLine());
                if (CheckProductIDAvaibilaty(products, updatedProduct.ProductId))
                {
                    products.Add(updatedProduct);
                }
                return updatedProduct;
            }
            else
            {
                Console.WriteLine("Product not found.");
                return null;
            }
        }

        public Product UpdateProductName(Product product, List<Product> products)
        {
            var updatedProduct = GetProductById(products, product.ProductId);
            if (updatedProduct != null)
            {
                products.Remove(product);
                Console.WriteLine("Enter new Product Name: ");
                updatedProduct.ProductName = Console.ReadLine();
                products.Add(updatedProduct);
                return updatedProduct;
            }
            else
            {
                Console.WriteLine("Product not found.");
                return null;
            }
        }

        public Product UpdateProductPrice(Product product, List<Product> products)
        {
            var updatedProduct = GetProductById(products, product.ProductId);
            if (updatedProduct != null)
            {
                products.Remove(product);
                Console.WriteLine("Enter new Product Price: ");
                updatedProduct.ProductPrice = Convert.ToInt32(Console.ReadLine());
                products.Add(updatedProduct);
                return updatedProduct;
            }
            else
            {
                Console.WriteLine("Product not found.");
                return null;
            }
        }
    }
}
