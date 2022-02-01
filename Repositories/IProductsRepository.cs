using Cofetarie.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cofetarie.Repositories
{
    public interface IProductsRepository
    {
        IQueryable<Product> GetProducts();
        //select
        IQueryable<int> GetProductsIds();

        IQueryable<Product> GetProductsWithJoin();

        Task Create(Product product);

        Task Update(Product product);

        Task Delete(Product product);
    }
}
