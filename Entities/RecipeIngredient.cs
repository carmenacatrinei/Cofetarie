using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cofetarie.Entities
{
    public class RecipeIngredient
    {
        public int RecipeId { get; set; }
        public virtual Recipe Recipe { get; set; }
        public int IngredientId { get; set; }
        public virtual Ingredient Ingredient { get; set; }
        public string Quantity { get; set; }
    }
}
