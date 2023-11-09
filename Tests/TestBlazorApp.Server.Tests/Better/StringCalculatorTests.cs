using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TestBlazorApp.Infastructure.Libs;

namespace TestBlazorApp.Server.Tests.Better
{
    public class StringCalculatorTests
    {
        //[Fact]
        /////Good Naming Example
        //public void Add_SingleNumber_ReturnsSameNumber()
        //{
        //    //Arrange
        //    var stringCalculator = new StringCalculator();

        //    //Act
        //    var actual = stringCalculator.Add("0");

        //    //Assert
        //    Assert.Equal(0, actual);
        //}

        [Fact]
        //Good AAA
        public void Add_EmptyString_ReturnsZero()
        {
            // Arrange
            var stringCalculator = new StringCalculator();

            // Act
            var actual = stringCalculator.Add("");

            // Assert
            Assert.Equal(0, actual);
        }

        [Fact]
        //Good Minimal
        public void Add_SingleNumber_ReturnsSameNumber()
        {
            var stringCalculator = new StringCalculator();

            var actual = stringCalculator.Add("0");

            Assert.Equal(0, actual);
        }

        [Fact]
        //Good No Magic Strings
        public void Add_MaximumSumResult_ThrowsOverflowException()
        {
            var stringCalculator = new StringCalculator();
            const string MAXIMUM_RESULT = "1001";

            Action actual = () => stringCalculator.Add(MAXIMUM_RESULT);

            Assert.Throws<OverflowException>(actual);
        }

        [Theory]
        [InlineData("0,0,0", 0)]
        [InlineData("0,1,2", 3)]
        [InlineData("1,2,3", 6)]
        //Good no logic in tests
        public void Add_MultipleNumbers_ReturnsSumOfNumbers(string input, int expected)
        {
            var stringCalculator = new StringCalculator();

            var actual = stringCalculator.Add(input);

            Assert.Equal(expected, actual);
        }

        private StringCalculator CreateDefaultStringCalculator()
        {
            return new StringCalculator();
        }

        [Fact]
        //Good Setup
        public void Add_TwoNumbers_ReturnsSumOfNumbers()
        {
            var stringCalculator = CreateDefaultStringCalculator();

            var actual = stringCalculator.Add("0,1");

            Assert.Equal(1, actual);
        }


        [Theory]
        [InlineData("", 0)]
        [InlineData(",", 0)]
        //Good Act
        public void Add_EmptyEntries_ShouldBeTreatedAsZero(string input, int expected)
        {
            // Arrange
            var stringCalculator = new StringCalculator();

            // Act
            var actual = stringCalculator.Add(input);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
