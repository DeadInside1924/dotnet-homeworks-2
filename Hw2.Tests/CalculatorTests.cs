using Hw2;
using Xunit;

namespace Hw2.Test
{
    public class CalculatorTests
    {
        [Theory]
        [InlineData(15, 5, CalculatorOperation.Plus, 20)]
        [InlineData(15, 5, CalculatorOperation.Minus, 10)]
        [InlineData(15, 5, CalculatorOperation.Multiply, 75)]
        [InlineData(15, 5, CalculatorOperation.Divide, 3)]
        public void TestAllOperations(int value1, int value2, CalculatorOperation operation, int expectedValue)
        {
            //act
            var result = Calculator.Calculate(value1, operation, value2);
            
            //assert
            Assert.Equal(expectedValue, result);
        }
        
        [Fact]
        public void TestInvalidOperation()
        {
            //assert
            Assert.Throws<ArgumentOutOfRangeException>(() =>
                Calculator.Calculate(1, CalculatorOperation.Undefined, 10));
        }

        [Fact]
        public void TestDividingNonZeroByZero()
        {
            //act
            var result = Calculator.Calculate(10, CalculatorOperation.Divide, 0);

            //assert
            Assert.Equal(double.PositiveInfinity, result);
        }

        [Fact]
        public void TestDividingZeroByNonZero()
        {
            //act
            var result = Calculator.Calculate(0, CalculatorOperation.Divide, 10);

            //assert
            Assert.Equal(0, result);
        }
        
        [Fact]
        public void TestDividingZeroByZero()
        {
            //act
            var result = Calculator.Calculate(0, CalculatorOperation.Divide, 0);

            //assert
            Assert.Equal(double.NaN, result);
        }
    }
}