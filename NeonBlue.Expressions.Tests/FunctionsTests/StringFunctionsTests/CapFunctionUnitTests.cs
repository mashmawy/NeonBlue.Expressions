
using NeonBlue.Expressions;
using NeonBlue.Expressions;
using NeonBlue.Expressions.Functions.StringFunctions;

namespace NeonBlue.Expressions.Tests.FunctionsTests.StringFunctionsTests
{
    public class CapFunctionUnitTests
    {
        [Fact]
        public void CapFunctionReturnCorrectValueAndValueType()
        {

            CapFunction capFunction = new();
            Stack<Token> tokens = new();
            tokens.Push(new Token("mohamed", TokenType.String));
            capFunction.Update(tokens, new ExecutionOptions(NullStrategy.Throw));
            Assert.Single(tokens);
            var result = tokens.Pop();
            Assert.True(result.TokenType == TokenType.String);
            Assert.NotNull(result.Value);
            Assert.Equal(typeof(string), result.Value.GetType());
            Assert.Equal("Mohamed", Convert.ToString(result.Value));
        }


         [Fact]
        public void CapFunctionThrowForEmptyStackArgument()
        {
            CapFunction capFunction = new();
            Stack<Token> tokens = new();
            Assert.Throws<EmptyStackException>(() =>
         {
             capFunction.Update(tokens, new ExecutionOptions(NullStrategy.Throw));
         });
        }
        
        [Fact]
        public void CapFunctionReturnNull()
        {
            CapFunction capFunction = new();
            Stack<Token> tokens = new();
            tokens.Push(new Token(null));
            capFunction.Update(tokens, new ExecutionOptions(NullStrategy.Propagate));
            Assert.Single(tokens);
            var result = tokens.Pop();
            Assert.True(result.TokenType == TokenType.NULL);
            Assert.Null(result.Value);
        }
        [Fact]
        public void CapFunctionThrowForNull()
        {
            CapFunction capFunction = new();
            Stack<Token> tokens = new();
            tokens.Push(new Token(null));
            Assert.Throws<NullTokenException>(() =>
            {
                capFunction.Update(tokens, new ExecutionOptions(NullStrategy.Throw));
            });
        }

        [Fact]
        public void CapFunctionReturnDefaultForNull()
        {
            CapFunction capFunction = new();
            Stack<Token> tokens = new();
            tokens.Push(new Token(null));
            capFunction.Update(tokens, new ExecutionOptions(NullStrategy.Propagate));
            Assert.Single(tokens);
            var result = tokens.Pop();
            Assert.True(result.TokenType == TokenType.NULL);
            Assert.Null(result.Value);

        }
    }
}