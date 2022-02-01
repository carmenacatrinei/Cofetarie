using Cofetarie.Entities;
using Cofetarie.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cofetarie.Managers
{
    public interface IProductsManager
    {

        List<Product> GetProducts();
        //select
        List<int> GetProductsIds();

        List<Product> GetProductsWithJoin();

        List<ProductFirstOrderModel> GetProductsFiltered();

        List<ProductFirstOrderModel> GetProductsOrdered();

        Product GetProductById(int id);

 /*       void Create(string name);

        void Create(ProductModel model);*/

        Task Create(Product product);

        Task Update(ProductModel product);

        Task Delete(Product product);

        public void Delete(int id);

    }
}
