using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestBlazorApp.Infastructure.Libs
{
    public class Ingredient
    {
        public readonly string Name;

        public Ingredient(string name)
        {
            this.Name = name;
        }
    }
}
