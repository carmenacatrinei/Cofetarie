using Cofetarie.Entities;
using Cofetarie.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cofetarie.Managers
{
    public interface IRecipesManager
    {
        List<Recipe> GetRecipes();
        //select
        List<int> GetRecipesIds();

        List<Recipe> GetRecipesWithJoin();

        List<RecipeFirstIngredientModel> GetRecipesFiltered();
        Recipe GetRecipeById(int id);

        // List<object> GetRecipesOrdered();

        Task Create(Recipe product);

        Task Update(RecipeModel product);

        Task Delete(Recipe product);

        public void Delete(int id);
    }
}
