using Cofetarie.Entities;
using Cofetarie.Managers;
using Cofetarie.Models;
using Cofetarie.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cofetarie.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProductsManager manager;

        public ProductController(IProductsManager productsManager)
        {
            this.manager = productsManager;
        }

        [HttpGet]
        [Authorize(Policy = "BasicUser")]
        public async Task<IActionResult> GetProducts()
        {

            var products = manager.GetProducts();

            //select * from Products;

            return Ok(products);
        }

        //Eager Loading
        [HttpGet("select")]
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> GetProductsIds()
        {
            //select Id from Products;
            var productsIds = manager.GetProductsIds();

            return Ok(productsIds);
        }

        [HttpGet("eager-join")]
        public async Task<IActionResult> JoinEager()
        {

            var products = manager.GetProductsWithJoin();
            /*var db = new CofetarieContext();
            var products = db.Products
                .Include(x => x.Recipe)
                .ToList();*/

            foreach (var x in products)
            {
                var y = x.Recipe;
            }
            return Ok(products);
        }

        [HttpGet("filter")]
        public async Task<IActionResult> Filter()
        {

            var products = manager.GetProductsFiltered();

            return Ok(products);
        }

        [HttpGet("orderby")]
        public async Task<IActionResult> OrderBy()
        {
            var products = manager.GetProductsOrdered();
           /* var db = new CofetarieContext();
            var products = db.Products
                .Include(x => x.Recipe)
                .Include(x => x.OrderProducts)
                //select * from products left join recipes left join orderproducts
                //were count(orderproducts) > 1
                .Where(x => x.OrderProducts.Count > 1)
                .Select(x => new { Id = x.Id, FirstOrderId = x.OrderProducts.FirstOrDefault().OrderId })
                .ToList()
                //sau orderbydescending simplu
                .OrderBy(x => x.FirstOrderId)
                .ToList();*/

            return Ok(products);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] string name)
        {
            var newProduct = new Product
            {
                Name = name,
                Description = "Your perfect coffee friend",
                Price = 2
            };

            await manager.Create(newProduct);

            return Ok();
        }

        [HttpPost("withObj")]
        public async Task<IActionResult> Create([FromBody] ProductModel productModel)
        {
            var newProduct = new Product
            {
                Name = productModel.Name,
                Description = productModel.Description,
                Price = productModel.Price 
            };

            await manager.Create(newProduct);

            return Ok();
        }

        [HttpPut("withObj")] 
        public async Task<IActionResult> Update([FromBody] ProductModel productModel)
        {
            await manager.Update(productModel);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            manager.Delete(id);

            return Ok();
        }

    }
} 
