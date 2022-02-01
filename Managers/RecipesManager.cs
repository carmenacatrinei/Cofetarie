using Cofetarie.Entities;
using Cofetarie.Models;
using Cofetarie.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cofetarie.Managers
{
    public class RecipesManager : IRecipesManager
    {
        private readonly IRecipesRepository recipesRepository;

        public RecipesManager(IRecipesRepository repository)
        {
            this.recipesRepository = repository;
        }
        public async Task Create(Recipe recipe)
        {
            await recipesRepository.Create(recipe);
        }

        public Recipe GetRecipeById(int id)
        {
            var recipe = recipesRepository.GetRecipes()
                .FirstOrDefault(x => x.Id == id);

            return recipe;
        }

        public void Delete(int id)
        {
            var recipe = GetRecipeById(id);

            recipesRepository.Delete(recipe);
        }

        public async Task Delete(Recipe recipe)
        {
            await recipesRepository.Delete(recipe);
        }

        public List<Recipe> GetRecipes()
        {
            return recipesRepository.GetRecipes().ToList();
        }

        public List<RecipeFirstIngredientModel> GetRecipesFiltered()
        {
            var recipes = recipesRepository.GetRecipesWithJoin();
            var recipesFiltered = recipes.Where(x => x.RecipeIngredients.Count > 1)
                .Select(x => new RecipeFirstIngredientModel { Id = x.Id, FirstIngredientId = x.RecipeIngredients.FirstOrDefault().IngredientId })
                .ToList();

            return recipesFiltered;
        }

        public List<int> GetRecipesIds()
        {
            return recipesRepository.GetRecipesIds().ToList();
        }

/*        public List<object> GetRecipesOrdered()
        {
            throw new NotImplementedException();
        }*/

        public List<Recipe> GetRecipesWithJoin()
        {
            return recipesRepository.GetRecipesWithJoin().ToList();
        }

        public async Task Update(RecipeModel recipeModel)
        {
            var recipe = recipesRepository
                .GetRecipes()
                .FirstOrDefault(x => x.Id == recipeModel.Id);

            recipe.Time = recipeModel.Time;

            await recipesRepository.Update(recipe);
        }
    }
}
