using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cofetarie.Entities
{
    public class Ingredient
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<RecipeIngredient> RecipeIngredients { get; set; }

    }
}
