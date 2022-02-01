using Cofetarie.Entities;
using Cofetarie.Models;
using Cofetarie.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cofetarie.Managers
{
    public class ProductsManager : IProductsManager
    {
        private readonly IProductsRepository productsRepository;

        public ProductsManager(IProductsRepository repository)
        {
            this.productsRepository = repository;
        }

        public Product GetProductById(int id)
        {
            var product = productsRepository.GetProducts()
                .FirstOrDefault(x => x.Id == id);

            return product;
        }

        public void Delete(int id)
        {
            var product = GetProductById(id);

            productsRepository.Delete(product);
        }

        public async Task Create(Product product)
        {
            await productsRepository.Create(product);
        }

        public async Task Delete(Product product)
        {
            await productsRepository.Delete(product);
        }

        public List<Product> GetProducts()
        {
            return productsRepository.GetProducts().ToList();
        }

        public List<ProductFirstOrderModel> GetProductsFiltered()
        {
            //select * from products left join recipes left join orderproducts
            //where count(orderproducts) > 1

            var products = productsRepository.GetProductsWithJoin();
            var productsFiltered = products.Where(x => x.OrderProducts.Count > 1)
                .Select(x => new ProductFirstOrderModel { Id = x.Id, FirstOrderId = x.OrderProducts.FirstOrDefault().OrderId })
                .ToList();

            return productsFiltered;
        }

        public List<int> GetProductsIds()
        {
            return productsRepository.GetProductsIds().ToList();
        }

        public List<ProductFirstOrderModel> GetProductsOrdered()
        {
            //sau
        /*    var productsFiltered = GetProductsFiltered();
            var productsOrdered = productsOrdered.OrderByDescending(x => x.FirstOrderId)
                .ToList();*/

            var products = productsRepository.GetProductsWithJoin();
            var productsOrdered = products.Where(x => x.OrderProducts.Count > 1)
                .Select(x => new ProductFirstOrderModel  { Id = x.Id, FirstOrderId = x.OrderProducts.FirstOrDefault().OrderId })
                .ToList()
                //sau orderbydescending simplu
                .OrderBy(x => x.FirstOrderId)
                .ToList();

            return productsOrdered;
        }

        public List<Product> GetProductsWithJoin()
        {
            return productsRepository.GetProductsWithJoin().ToList();
        }

        public async Task Update(ProductModel productModel)
        {
            var product = productsRepository
                .GetProducts()
                .FirstOrDefault(x => x.Id == productModel.Id);

            product.Name = productModel.Name;

            await productsRepository.Update(product);
        }
    }
}
