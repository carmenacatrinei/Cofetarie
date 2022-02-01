using Cofetarie.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cofetarie.Repositories
{
    public interface IRecipesRepository
    {
        IQueryable<Recipe> GetRecipes();
        //select
        IQueryable<int> GetRecipesIds();

        IQueryable<Recipe> GetRecipesWithJoin();

        Task Create(Recipe recipe);

        Task Update(Recipe recipe);

        Task Delete(Recipe recipe);
    }
}
