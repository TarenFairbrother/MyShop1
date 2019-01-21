using MyShop1.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace MyShop1.DataAccess.InMemory
{
    public class ProductCategoryRepository
    {
        ObjectCache cache = MemoryCache.Default;
        List<ProductCategory> productsCategory = new List<ProductCategory>();

        public ProductCategoryRepository()
        {
            productsCategory = cache["productsCategory"] as List<ProductCategory>;
            if (productsCategory == null)
            {
                productsCategory = new List<ProductCategory>();
            }
        }

        public void Commit()
        {
            cache["productsCategory"] = productsCategory;
        }

        public void Insert(ProductCategory p)
        {
            productsCategory.Add(p);
        }

        public void Update(ProductCategory productCategory)
        {
            ProductCategory productCategoryToUpdate = productsCategory.Find(p => p.Id == productCategory.Id);

            if (productCategoryToUpdate != null)
            {
                productCategoryToUpdate = productCategory;
            }
            else
            {
                throw new Exception("Product not found");
            }
        }

        public ProductCategory Find(string id)
        {
            ProductCategory productCategory = productsCategory.Find(p => p.Id == id);

            if (productCategory != null)
            {
                return productCategory;
            }
            else
            {
                throw new Exception("Product not found");
            }
        }

        public IQueryable<ProductCategory> Collection()
        {
            return productsCategory.AsQueryable();
        }

        public void Delete(string id)
        {
            ProductCategory productCategoryToDelete = productsCategory.Find(p => p.Id == id);

            if (productCategoryToDelete != null)
            {
                productsCategory.Remove(productCategoryToDelete);
            }
            else
            {
                throw new Exception("Product not found");
            }
        }


    }
}

