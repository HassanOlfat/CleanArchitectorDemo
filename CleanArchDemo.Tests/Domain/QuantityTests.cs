using CleanArchDemo.Domain.ValueObjects;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchDemo.Tests.Domain
{
    public class QuantityTests
    {
        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(-10)]
        public void Should_Throw_Exception_When_Value_Is_Zero_Or_Negative(int invalidValue)
        {
            // Act & Assert
            var ex = Assert.Throws<ArgumentException>(() => new Quantity(invalidValue));
            Assert.Equal("Quantity must be greater than zero", ex.Message);
        }


        [Theory]
        [InlineData(1)]
        [InlineData(5)]
        [InlineData(10)]
        public void Quantity_Should_Be_Created_With_Valid_Value(int value)
        {
            var q = new Quantity(value);

            Assert.Equal(value, q.Value);
        }


    }
}
