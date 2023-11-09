using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestBlazorApp.Infastructure.Libs
{

    public class PriceCalculator
    {
        public int GetDiscountedPrice(int price)
        {
            if (DateTime.Now.DayOfWeek == DayOfWeek.Tuesday)
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
