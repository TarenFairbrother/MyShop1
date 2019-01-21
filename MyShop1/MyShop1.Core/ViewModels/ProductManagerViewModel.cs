using MyShop1.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop1.Core.ViewModels
{
   public class ProductManagerViewModel
    {
        public Product product { get; set; }
        public IEnumerable<ProductCategory> ProductCategories { get; set; }
    }
}
