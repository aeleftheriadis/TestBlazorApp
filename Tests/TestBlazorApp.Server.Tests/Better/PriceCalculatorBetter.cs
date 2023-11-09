using NSubstitute;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TestBlazorApp.Infastructure.Libs.Better;

namespace TestBlazorApp.Server.Tests.Better
{
    public class PriceCalculatorBetter
    {
        [Fact]
        public void GetDiscountedPrice_NotTuesday_ReturnsFullPrice()
        {
            var priceCalculator = new PriceCalculator();
            var dateTimeProviderStub = Substitute.For<IDateTimeProvider>();
            
            dateTimeProviderStub.DayOfWeek().Returns(DayOfWeek.Friday);

            var actual = priceCalculator.GetDiscountedPrice(2, dateTimeProviderStub);

            Assert.Equal(2, actual);
        }

        [Fact]
        public void GetDiscountedPrice_OnTuesday_ReturnsHalfPrice()
        {
            var priceCalculator = new PriceCalculator();
            var dateTimeProviderStub = Substitute.For<IDateTimeProvider>();
            dateTimeProviderStub.DayOfWeek().Returns(DayOfWeek.Tuesday);

            var actual = priceCalculator.GetDiscountedPrice(2, dateTimeProviderStub);

            Assert.Equal(1, actual);
        }
    }
}
