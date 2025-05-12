using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRUD.Models;

namespace CRUD.Services.Interfaces
{
    interface IProductID
    {
        public bool CheckProductIDAvaibilaty(List<Product> products, int inputID);
        public Product GetProductById(List<Product> products, int id);
    }
}
