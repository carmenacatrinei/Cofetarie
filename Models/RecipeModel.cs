using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cofetarie.Models
{
    public class RecipeModel
    {
        public int Id { get; set; }
        public int Time { get; set; }
        public int Temperature { get; set; }

        public int ProductId { get; set; }
    }
}
