using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Prasanjit.BDD.WebAPIDemo.Models
{    
    public class ProductsDTO
    {
        public int NumberOfProducts { get; set; }
        public IEnumerable<Product> Products { get; set; }
    }
}