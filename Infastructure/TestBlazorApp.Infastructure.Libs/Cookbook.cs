using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestBlazorApp.Infastructure.Libs
{
    public class Cookbook
    {
        private readonly ICollection<Recipe> recipes;

        public Cookbook(IEnumerable<Recipe> recipes)
        {
            this.recipes = new List<Recipe>(recipes);
        }

        public IEnumerable<Recipe> FindRecipies(params Ingredient[] ingredients)
        {
            return recipes.Where(r => r.Ingredients.Intersect(ingredients).Any());
        }

        public void AddRecipe(Recipe recipe)
        {
            this.recipes.Add(recipe);
        }
    }
}
