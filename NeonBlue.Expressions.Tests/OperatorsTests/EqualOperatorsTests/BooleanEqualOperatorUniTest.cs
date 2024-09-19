using NeonBlue.Expressions;
using NeonBlue.Expressions;
using NeonBlue.Expressions.Operators;

namespace NeonBlue.Expressions.Tests.OperatorsTests.EqualOperatorsTests
{
    public class BooleanEqualOperatorUniTest
    {
        [Fact]
        public void BooleanEqualBooleanReturnCorrectValueAndValueType()
        {
            // Given 
            EqualOperatorOverloads equalOperatorOverloads = new();
            var operand1 = new Token(true, TokenType.Boolean);
            var operand2 = new Token(true, TokenType.Boolean);
            // When
            var result =
                     equalOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));

            // Then 
            Assert.NotNull(result.Value);
            Assert.True(result.TokenType == TokenType.Boolean);
            Assert.True(result.Value.GetType() == typeof(bool));
            Assert.True(Convert.ToBoolean(result.Value));
        }
         

        [Fact]
        public void BooleanEqualNullFunctionDefaultOption()
        {
            EqualOperatorOverloads equalOperatorOverloads = new();
            var operand1 = new Token(true, TokenType.Boolean);
            var operand2 = new Token(null, TokenType.NULL);
            var result =
             equalOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Default));

            Assert.NotNull(result.Value);
            Assert.True(result.TokenType == TokenType.Boolean);
            Assert.True(Convert.ToBoolean(result.Value));
        }

        [Fact]
        public void BooleanEqualNullFunctionPropgateOption()
        {
            EqualOperatorOverloads equalOperatorOverloads = new();
            var operand1 = new Token(true, TokenType.Boolean);
            var operand2 = new Token(null, TokenType.NULL);
            var result =
             equalOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Propagate));

            Assert.Null(result.Value);
            Assert.True(result.TokenType == TokenType.NULL);
        }

        [Fact]
        public void BooleanEqualNullFunctionThrowOption()
        {
            EqualOperatorOverloads equalOperatorOverloads = new();
            var operand1 = new Token(true, TokenType.Boolean);
            var operand2 = new Token(null, TokenType.NULL);
            Assert.Throws<NullTokenExecption>(() =>
            {
                equalOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));
            });
        }
    }
}