using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestBlazorApp.Infastructure.Libs
{
    public class Recipe
    {
        public readonly IEnumerable<Ingredient> Ingredients;

        public Recipe(IEnumerable<Ingredient> ingredients)
        {
            this.Ingredients = ingredients;
        }
    }
}
