using Hw2;
using Xunit;

namespace Hw2.Tests
{
    public class ParserTests
    {
        [Theory]
        [InlineData("+", CalculatorOperation.Plus)]
        [InlineData("-", CalculatorOperation.Minus)]
        [InlineData("*", CalculatorOperation.Multiply)]
        [InlineData("/", CalculatorOperation.Divide)]
        public void TestCorrectOperations(string operation, CalculatorOperation operationExpected)
        {
            //arrange
            var args = new[] { "10", operation, "2" };
            
            //act
            Parser.ParseCalcArguments(args, out var val1, out var operationRes, out var val2);
            
            //assert
            Assert.Equal(10,val1);
            Assert.Equal(operationExpected,operationRes);
            Assert.Equal(2,val2);
            
        }
        
        [Theory]
        [InlineData("f", "+", "3")]
        [InlineData("3", "+", "f")]
        [InlineData("a", "+", "f")]
        public void TestParserWrongValues(string val1, string operation, string val2)
        {
            // arrange
            var args = new[] { val1, operation, val2 };
            
            //assert
            Assert.Throws<ArgumentException>(() => Parser.ParseCalcArguments(args, out _, out _, out _));
        }
        
        [Fact]
        public void TestParserWrongOperation()
        {
            //arrange
            var args = new[] { "8", ",", "15" };
            
            //assert
            Assert.Throws<InvalidOperationException>(() => Parser.ParseCalcArguments(args, out _, out _, out _));
        }

        [Fact]
        public void TestParserWrongLength()
        {
            //arrange
            var args = new[] { "25", "/", "2", "5", "6" };
            
            //assert
            Assert.Throws<ArgumentException>(() => Parser.ParseCalcArguments(args, out _, out _, out _));
        }
    }
}