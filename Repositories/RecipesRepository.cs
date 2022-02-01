using Cofetarie.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cofetarie.Repositories
{
    public class RecipesRepository :IRecipesRepository
    {
        private readonly CofetarieContext db;

        public RecipesRepository(CofetarieContext db)
        {
            this.db = db;
        }

        public IQueryable<Recipe> GetRecipes()
        {
            var recipes = db.Recipes;

            return recipes;
        }

        public IQueryable<int> GetRecipesIds()
        {
            var recipesIds = db.Recipes.Select(x => x.Id);

            return recipesIds;
        }

        public IQueryable<Recipe> GetRecipesWithJoin()
        {

            var recipesJoin = db.Recipes
                .Include(x => x.Product)
                .Include(x => x.RecipeIngredients);

            return recipesJoin;
        }

        public async Task Create(Recipe recipe)
        {
            await db.Recipes.AddAsync(recipe);

            await db.SaveChangesAsync();
        }

        public async Task Update(Recipe recipe)
        {
            db.Recipes.Update(recipe);

            await db.SaveChangesAsync();
        }

        public async Task Delete(Recipe recipe)
        {
            db.Recipes.Remove(recipe);

            await db.SaveChangesAsync();
        }
    }
}
