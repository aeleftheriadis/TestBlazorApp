using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TestBlazorApp.Infastructure.Libs;

namespace TestBlazorApp.Server.Tests.Better
{
    public class ParserTests
    {
        [Fact]
        public void ParseLogLine_StartsAndEndsWithSpace_ReturnsTrimmedResult()
        {
            var parser = new Parser();

            var result = parser.ParseLogLine(" a ");

            Assert.Equal("a", result);
        }
    }
}
