using System.Globalization;
using NeonBlue.Expressions.Functions.DateFunctions;

namespace NeonBlue.Expressions.Tests.FunctionsTests.DateFunctionsTests
{
    public class MonthNameFunctionTest
    {
        [Fact]
        public void MonthNameFunctionReturnCorrectValueAndValueType()
        {
            MonthNameFunction monthNameFunction = new();
            Stack<Token> tokens = new();
            var testVal = DateTime.Now;
            tokens.Push(new Token(testVal, TokenType.Datetime));
            tokens.Push(new Token("en", TokenType.String));

            monthNameFunction.Update(tokens, new ExecutionOptions(NullStrategy.Throw));
            Assert.Single(tokens);
            var result = tokens.Pop();
            Assert.True(result.TokenType == TokenType.String);
            Assert.NotNull(result.Value);
            Assert.Equal(typeof(string), result.Value.GetType());
            Assert.Equal(testVal.ToString("MMMM", CultureInfo.CreateSpecificCulture("en")), Convert.ToString(result.Value));
        }


        [Fact]
        public void MonthsFunctionThrowForEmptyStackArgument()
        {
            MonthNameFunction monthNameFunction = new();
            Stack<Token> tokens = new();
            Assert.Throws<EmptyStackException>(() =>
            {
                monthNameFunction.Update(tokens, new ExecutionOptions(NullStrategy.Throw));
            });
        }
        [Fact]
        public void MonthsFunctionThrowForInvalidArgument()
        {
            MonthNameFunction monthNameFunction = new();
            Stack<Token> tokens = new();
            tokens.Push(new Token("hello"));
            tokens.Push(new Token("hello"));
            Assert.Throws<InvalidArgumentTypeException>(() =>
            {
                monthNameFunction.Update(tokens, new ExecutionOptions(NullStrategy.Throw));
            });
        }
        [Fact]
        public void MonthNameFunctionReturnNull()
        {
            MonthNameFunction monthNameFunction = new();
            Stack<Token> tokens = new();
            tokens.Push(new Token(null));
            tokens.Push(new Token(null));
            monthNameFunction.Update(tokens, new ExecutionOptions(NullStrategy.Propagate));
            Assert.Single(tokens);
            var result = tokens.Pop();
            Assert.True(result.TokenType == TokenType.NULL);
            Assert.Null(result.Value);
        }
        [Fact]
        public void MonthNameFunctionThrowForNull()
        {
            MonthNameFunction monthNameFunction = new();
            Stack<Token> tokens = new();
            tokens.Push(new Token(null));
            tokens.Push(new Token(null));
            Assert.Throws<NullTokenException>(() =>
            {
                monthNameFunction.Update(tokens, new ExecutionOptions(NullStrategy.Throw));
            });
        }

        [Fact]
        public void MonthNameFunctionReturnDefaultForNull()
        {

            MonthNameFunction monthNameFunction = new();
            Stack<Token> tokens = new();
            tokens.Push(new Token(null));
            tokens.Push(new Token(null));
            monthNameFunction.Update(tokens, new ExecutionOptions(NullStrategy.Propagate));
            Assert.Single(tokens);
            var result = tokens.Pop();
            Assert.True(result.TokenType == TokenType.NULL);
            Assert.Null(result.Value);

        }

    }
}