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


    public class RecipeController : ControllerBase
    {

        private IRecipesManager manager;

        public RecipeController(IRecipesManager recipesManager)
        {
            this.manager = recipesManager;
        }

        [HttpGet]
        [Authorize(Policy = "BasicUser")]
        public async Task<IActionResult> GetProducts()
        {

            //select * from Products;
            var recipes = manager.GetRecipes();

            return Ok(recipes);
        }

        //Eager Loading
        [HttpGet("select")]
        public async Task<IActionResult> GetRecipesIds()
        {

            //select Id from Recipes;
            var recipesIds = manager.GetRecipesIds();

            return Ok(recipesIds);
        }

        [HttpGet("eager-join")]
        public async Task<IActionResult> JoinEager()
        {
            /*var recipes = db.Recipes
                .Include(x => x.Product)
                .ToList();*/
            var recipes = manager.GetRecipesWithJoin();

            foreach (var x in recipes)
            {
                var y = x.Product;
            }
            return Ok(recipes);
        }

        [HttpGet("filter")]
        public async Task<IActionResult> Filter()
        {
            var recipes = manager.GetRecipesFiltered();
            /*var recipes = db.Recipes
                .Include(x => x.Product)
                .Include(x => x.RecipeIngredients)
                //select * from recipes left join products left join recipeingredients
                //were count(recipeingredients) > 1
                .Where(x => x.RecipeIngredients.Count > 1)
                .Select(x => new { Id = x.Id, FirstIngredientId = x.RecipeIngredients.FirstOrDefault().IngredientId })
                .ToList();*/

            return Ok(recipes);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] int time)
        {
            var newRecipe = new Recipe
            {
                Time = time,
                Temperature = 180
            };

            await manager.Create(newRecipe);

            return Ok();
        }

        [HttpPost("withObj")]
        public async Task<IActionResult> Create([FromBody] RecipeModel recipeModel)
        {
            var newRecipe = new Recipe
            {
                Time = recipeModel.Time,
                Temperature = recipeModel.Temperature,
                ProductId = recipeModel.ProductId
            };

            await manager.Create(newRecipe);

            return Ok();
        }
        [HttpPut("withObj")]
        public async Task<IActionResult> Update([FromBody] RecipeModel recipeModel)
        {
            await manager.Update(recipeModel);

            return Ok();
        }



        /*        [HttpGet("groupby")]
                public async Task<IActionResult> GroupBy()
                {
        *//*              select r.Id, count(ri.IngredientId) as "IngredientsNo"
                        from Recipes r
                        left
                        join RecipeIngredients ri on r.Id = ri.RecipeId
                        group by r.Id
                        having count(ri.IngredientId) > 0;*//*

                    var db = new CofetarieContext();
                    var recipes = db.Recipes
                        .Include(x => x.RecipeIngredients)
                        .Where(x => x.RecipeIngredients.Count > 1)
                        .Select(x => new { Id = x.Id, FirstIngredientId = x.RecipeIngredients.FirstOrDefault().IngredientId })
                        .ToList()
                        .GroupBy()
                        .ToList();

                    return Ok(recipes);
                }*/

            [HttpDelete("{id}")]
            [Authorize(Policy = "Admin")]
        public async Task<IActionResult> Delete([FromRoute] int id)
            {
                manager.Delete(id);

                return Ok();
            }
    }
}
