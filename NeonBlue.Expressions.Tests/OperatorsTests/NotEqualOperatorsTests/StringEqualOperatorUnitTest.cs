using NeonBlue.Expressions;
using NeonBlue.Expressions;
using NeonBlue.Expressions.Operators;

namespace NeonBlue.Expressions.Tests.OperatorsTests.NotEqualOperatorsTests
{
    public class StringNotEqualOperatorUnitTest
    {

        [Fact]
        public void StringNotEqualStringReturnCorrectValueAndValueType()
        {
            // Given 
            NotEqualOperatorOverloads equalOperatorOverloads = new();
            var operand1 = new Token("Ahmed", TokenType.String);
            var operand2 = new Token("Ahmedq", TokenType.String);
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
        public void StringNotEqualNullFunctionDefaultOption()
        {
            NotEqualOperatorOverloads equalOperatorOverloads = new();
            var operand1 = new Token("Ahmed", TokenType.String);
            var operand2 = new Token(null, TokenType.NULL);
            var result =
             equalOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Default));

            Assert.NotNull(result.Value);
            Assert.True(result.TokenType == TokenType.Boolean);
            Assert.False(Convert.ToBoolean(result.Value));
        }

        [Fact]
        public void StringNotEqualNullFunctionPropgateOption()
        {
            NotEqualOperatorOverloads equalOperatorOverloads = new();
            var operand1 = new Token("Ahmed", TokenType.String);
            var operand2 = new Token(null, TokenType.NULL);
            var result =
             equalOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Propagate));

            Assert.Null(result.Value);
            Assert.True(result.TokenType == TokenType.NULL);
        }

        [Fact]
        public void StringNotEqualNullFunctionThrowOption()
        {
            NotEqualOperatorOverloads equalOperatorOverloads = new();
            var operand1 = new Token("Ahmed", TokenType.String);
            var operand2 = new Token(null, TokenType.NULL);
            Assert.Throws<NullTokenExecption>(() =>
            {
                equalOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));
            });
        }
    }
}