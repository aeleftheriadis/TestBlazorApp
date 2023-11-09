using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TestBlazorApp.Infastructure.Libs;

namespace TestBlazorApp.Server.Tests.Bad
{
    public class PriceCalculatorTests
    {
        [Fact]
        public void GetDiscountedPrice_NotTuesday_ReturnsFullPrice()
        {
            var priceCalculator = new PriceCalculator();

            var actual = priceCalculator.GetDiscountedPrice(2);

            Assert.Equal(2, actual);
        }

        [Fact]
        public void GetDiscountedPrice_OnTuesday_ReturnsHalfPrice()
        {
            var priceCalculator = new PriceCalculator();

            var actual = priceCalculator.GetDiscountedPrice(2);

            Assert.Equal(1, actual);
        }
    }
}
