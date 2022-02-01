using Cofetarie.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cofetarie.Repositories
{
    public class ProductsRepository : IProductsRepository
    {
        private readonly CofetarieContext db;

        public ProductsRepository(CofetarieContext db)
        {
            this.db = db;
        }

        public IQueryable<Product> GetProducts()
        {
            var products = db.Products;

            return products;
        }

        public IQueryable<int> GetProductsIds()
        {
            var productsIds = db.Products.Select(x => x.Id);

            return productsIds;
        }

         public IQueryable<Product> GetProductsWithJoin()
        {

            var productsJoin = db.Products
                .Include(x => x.Recipe)
                .Include(x => x.OrderProducts);

            return productsJoin;
        }

        public async Task Create(Product product)
        {
            await db.Products.AddAsync(product);

            await db.SaveChangesAsync();
        }

        public async Task Update(Product product)
        {
            db.Products.Update(product);

            await db.SaveChangesAsync();
        }

        public async Task Delete(Product product)
        {
            db.Products.Remove(product);

            await db.SaveChangesAsync();
        }

    }
}
