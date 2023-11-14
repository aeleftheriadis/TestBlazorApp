using AutoFixture;
using AutoFixture.Xunit2;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestBlazorApp.Server.Tests
{
    public class CookbookAutoDataAttribute : AutoDataAttribute
    {
        public CookbookAutoDataAttribute()
          : base(() => new Fixture().Customize(new RandomIngredientsFromFixedSequence()))
        {
        }
    }

}
