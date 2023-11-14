using AutoFixture;
using AutoFixture.Xunit2;

using NSubstitute;

using System;

using TestBlazorApp.Infastructure.Libs;

using Xunit;

namespace TestBlazorApp.Server.Tests
{
    public class BankAccountTests
    {

        [Theory, AutoDomainData]
        public void Debit_PositiveDecimal_ReturnsCorrectAmount([Frozen]decimal amount, [Frozen] BankAccount sut)
        {
            // Arrange
            var initialBalance = sut.Balance;

            // Act
            sut.Debit(amount);

            // Assert
            Assert.Equal(initialBalance - amount, sut.Balance);
            Assert.NotNull(sut.CustomerName);
        }

        [Theory, AutoDomainData]
        public void Credit_PositiveDecimal_ReturnsCorrectAmount([Frozen] decimal amount, [Frozen] BankAccount sut)
        {
            // Arrange
            var initialBalance = sut.Balance;

            // Act
            sut.Credit(amount);

            // Assert
            Assert.Equal(initialBalance + amount, sut.Balance);
            Assert.NotNull(sut.CustomerName);
        }

        [Theory, AutoDomainData]
        public void Credit_NegativeDecimal_ThrowsOutOfRangeException([Frozen] BankAccount sut)
        {
            //Arrange
            var amount = new decimal(-1);
            var exceptionType = typeof(ArgumentOutOfRangeException);

            // Act            
            var ex = Record.Exception(() => {
                sut.Credit(amount);
            });

            // Assert
            Assert.IsType(exceptionType, ex);

        }


        [Theory, AutoDomainData]
        public void Debit_NegativeDecimal_ThrowsOutOfRangeException([Frozen] BankAccount sut)
        {
            //Arrange
            var amount = new decimal(-1);

            // Act
            // Assert
            Assert.Throws<ArgumentOutOfRangeException>(() =>  sut.Debit(amount));

        }

        [Theory, AutoDomainData]
        public void Debit_AmountLargerThanBalance_ThrowsOutOfRangeException(decimal updatedAmount, [Frozen] BankAccount sut)
        {
            //Arrange
            var amount = sut.Balance + updatedAmount;
            var exceptionType = typeof(ArgumentOutOfRangeException);

            // Act            
            var ex = Record.Exception(() => {
                sut.Debit(amount);
            });

            // Assert
            Assert.IsType(exceptionType, ex);

        }
    }
}
