using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestBlazorApp.Infastructure.Libs.Better
{
    public interface IDateTimeProvider
    {
        DayOfWeek DayOfWeek();
    }
    public class PriceCalculator
    {
        public int GetDiscountedPrice(int price, IDateTimeProvider dateTimeProvider)
        {
            if (dateTimeProvider.DayOfWeek() == DayOfWeek.Tuesday)
            {
                return price / 2;
            }
            else
            {
                return price;
            }

        }
    }
}
