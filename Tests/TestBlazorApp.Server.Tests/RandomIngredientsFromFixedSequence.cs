using AutoFixture;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TestBlazorApp.Infastructure.Libs;

namespace TestBlazorApp.Server.Tests
{
    public class RandomIngredientsFromFixedSequence : ICustomization
    {
        private readonly Random randomizer = new Random();
        private IEnumerable<Ingredient> sequence;

        public void Customize(IFixture fixture)
        {
            InitializeIngredientSequence(fixture);
            fixture.Register(PickRandomIngredientFromSequence);
        }

        private void InitializeIngredientSequence(IFixture fixture)
        {
            this.sequence = fixture.CreateMany<Ingredient>();
        }

        private Ingredient PickRandomIngredientFromSequence()
        {
            var randomIndex = this.randomizer.Next(0, sequence.Count());
            return sequence.ElementAt(randomIndex);
        }
    }
}
