using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRUD.Models;

namespace CRUD.Services.Interfaces
{
    interface ICrudService
    {
        public Product CreateProduct(List<Product> products);
        public Product UpdateProductDescription (Product product, List<Product> products);
        public Product UpdateProductPrice(Product product, List<Product> products);
        public Product UpdateProductName(Product product, List<Product> products);
        public Product UpdateProductId(Product product, List<Product> products);
        public IEnumerable<Product> GetAllProducts(List<Product> products);
        public IEnumerable<Product> Delete(int ProductID, List<Product> products);
    }
}
