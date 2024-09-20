using NeonBlue.Expressions.Operators;

namespace NeonBlue.Expressions.Tests.OperatorsTests.LogicalAndNullOperatorsTests
{
    public class LogicalOperatorsUnitTests
    {
        [Fact]
        public void AndOperatorShouldReturnCorrectValueAndValueTypeWhenFalse()
        {
            LogicalAndOperatorOverloads logicalOperatorOverloads = new();
            var operand1 = new Token(true, TokenType.Boolean);
            var operand2 = new Token(false, TokenType.Boolean);
            var result =
             logicalOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));

            Assert.NotNull(result.Value);
            Assert.True(result.TokenType == TokenType.Boolean);
            Assert.True(result.Value.GetType() == typeof(bool));
            Assert.False(Convert.ToBoolean(result.Value));
        }
        [Fact]
        public void AndOperatorShouldReturnCorrectValueAndValueTypeWhenTrue()
        {
            LogicalAndOperatorOverloads logicalOperatorOverloads = new();
            var operand1 = new Token(true, TokenType.Boolean);
            var operand2 = new Token(true, TokenType.Boolean);
            var result =
             logicalOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));

            Assert.NotNull(result.Value);
            Assert.True(result.TokenType == TokenType.Boolean);
            Assert.True(result.Value.GetType() == typeof(bool));
            Assert.True(Convert.ToBoolean(result.Value));
        }






        [Fact]
        public void OrOperatorShouldReturnCorrectValueAndValueTypeWhenFalse()
        {
            LogicalOrOperatorOverloads logicalOperatorOverloads = new();
            var operand1 = new Token(false, TokenType.Boolean);
            var operand2 = new Token(false, TokenType.Boolean);
            var result =
             logicalOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));

            Assert.NotNull(result.Value);
            Assert.True(result.TokenType == TokenType.Boolean);
            Assert.True(result.Value.GetType() == typeof(bool));
            Assert.False(Convert.ToBoolean(result.Value));
        }
        [Fact]
        public void OrOperatorShouldReturnCorrectValueAndValueTypeWhenTrue()
        {
            LogicalOrOperatorOverloads logicalOperatorOverloads = new();
            var operand1 = new Token(true, TokenType.Boolean);
            var operand2 = new Token(false, TokenType.Boolean);
            var result =
             logicalOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));

            Assert.NotNull(result.Value);
            Assert.True(result.TokenType == TokenType.Boolean);
            Assert.True(result.Value.GetType() == typeof(bool));
            Assert.True(Convert.ToBoolean(result.Value));
        }








        [Fact]
        public void NotOperatorShouldReturnCorrectValueAndValueTypeWhenFalse()
        {
            Token? nullToken  = null;
            LogicalNotOperatorOverloads logicalOperatorOverloads = new();
            var operand1 = new Token(true, TokenType.Boolean);
            var result =
             logicalOperatorOverloads.Run(operand1, nullToken, new ExecutionOptions(NullStrategy.Throw));

            Assert.NotNull(result.Value);
            Assert.True(result.TokenType == TokenType.Boolean);
            Assert.True(result.Value.GetType() == typeof(bool));
            Assert.False(Convert.ToBoolean(result.Value));
        }
        [Fact]
        public void NotOperatorShouldReturnCorrectValueAndValueTypeWhenTrue()
        {
            Token? nullToken  = null;
            LogicalNotOperatorOverloads logicalOperatorOverloads = new();
            var operand1 = new Token(false, TokenType.Boolean);
            var result =
             logicalOperatorOverloads.Run(operand1, nullToken, new ExecutionOptions(NullStrategy.Throw));

            Assert.NotNull(result.Value);
            Assert.True(result.TokenType == TokenType.Boolean);
            Assert.True(result.Value.GetType() == typeof(bool));
            Assert.True(Convert.ToBoolean(result.Value));
        }
    }
}