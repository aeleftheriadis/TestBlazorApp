using NSubstitute;

using System;
using System.Collections.Generic;

using TestBlazorApp.Infastructure.Libs;

using Xunit;

namespace TestBlazorApp.Server.Tests
{
    public class RecipeTests
    {
        [Theory, CookbookAutoData]
        public void FindRecipies_OneIngredient_ReturnsRecipiesWithSpecifiedIngredient(
            Cookbook sut,
            Ingredient ingredient)
        {
            // Act
            var recipes = sut.FindRecipies(ingredient);
            // Assert
            Assert.True(recipes.All(r => r.Ingredients.Contains(ingredient)));
        }

        [Theory, CookbookAutoData]
        public void FindRecipies_AddRecipe_ReturnsNewRecipeWithSpecifiedIngredient(
            Cookbook sut,
            Ingredient ingredient,
            Recipe recipeWithIngredient)
        {
            // Arrange
            sut.AddRecipe(recipeWithIngredient);
            // Act
            var recipes = sut.FindRecipies(ingredient);
            // Assert
            Assert.Contains(recipeWithIngredient, recipes);
        }
    }
}
