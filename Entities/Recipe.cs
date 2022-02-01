using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cofetarie.Entities
{
    public class Recipe
    {
        public int Id { get; set; }
        public int Time { get; set; }
        public int Temperature { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
        public virtual ICollection<RecipeIngredient> RecipeIngredients { get; set; }

    }
} 
