using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestBlazorApp.Infastructure.Libs
{
    public class Parser
    {
        public string ParseLogLine(string input)
        {
            var sanitizedInput = TrimInput(input);
            return sanitizedInput;
        }

        private string TrimInput(string input)
        {
            return input.Trim();
        }
    }
}
