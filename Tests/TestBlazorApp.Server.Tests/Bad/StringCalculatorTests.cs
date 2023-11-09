using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TestBlazorApp.Infastructure.Libs;

namespace TestBlazorApp.Server.Tests.Bad
{
    public class StringCalculatorTests
    {
        [Fact]
        ///Bad Naming Example
        public void Test_Single()
        {
            //Arrange
            var stringCalculator = new StringCalculator();

            //Act
            var actual = stringCalculator.Add("0");

            //Assert
            Assert.Equal(0, actual);
        }

        [Fact]
        //Bad AAA
        public void Add_EmptyString_ReturnsZero()
        {
            // Arrange
            var stringCalculator = new StringCalculator();

            // Assert
            Assert.Equal(0, stringCalculator.Add(""));
        }

        [Fact]
        //Bad Minimal
        public void Add_SingleNumber_ReturnsSameNumber()
        {
            var stringCalculator = new StringCalculator();

            var actual = stringCalculator.Add("42");

            Assert.Equal(42, actual);
        }

        [Fact]
        //Bad Magic Strings
        public void Add_BigNumber_ThrowsOverflowException()
        {
            var stringCalculator = new StringCalculator();

            Action actual = () => stringCalculator.Add("1001");

            Assert.Throws<OverflowException>(actual);
        }

        [Fact]
        //Bad logic in tests
        public void Add_MultipleNumbers_ReturnsCorrectResults()
        {
            var stringCalculator = new StringCalculator();
            var expected = 0;
            var testCases = new[]
            {
                "0,0,0",
                "0,1,2",
                "1,2,3"
            };

            foreach (var test in testCases)
            {
                Assert.Equal(expected, stringCalculator.Add(test));
                expected += 3;
            }
        }


        private readonly StringCalculator stringCalculator;
        public StringCalculatorTests()
        {
            stringCalculator = new StringCalculator();
        }

        [Fact]
        //Bad Setup
        public void Add_TwoNumbers_ReturnsSumOfNumbers()
        {
            var result = stringCalculator.Add("0,1");

            Assert.Equal(1, result);
        }


        [Fact]
        //Bad Act
        public void Add_EmptyEntries_ShouldBeTreatedAsZero()
        {
            // Act
            var actual1 = stringCalculator.Add("");
            var actual2 = stringCalculator.Add(",");

            // Assert
            Assert.Equal(0, actual1);
            Assert.Equal(0, actual2);
        }
    }
}
