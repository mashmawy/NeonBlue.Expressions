using NeonBlue.Expressions.Exceptions;
using NeonBlue.Expressions;
using NeonBlue.Expressions.Operators;

namespace NeonBlue.Expressions.Tests.OperatorsTests.EqualOperatorsTests
{
    public class DateTimeEqualOperatorUniTest
    {
        [Fact]
        public void DateTimeEqualDateTimeReturnCorrectValueAndValueType()
        {
            // Given 
            EqualOperatorOverloads equalOperatorOverloads = new();
            var operand1 = new Token(DateTime.Today, TokenType.Datetime);
            var operand2 = new Token(DateTime.Today, TokenType.Datetime);
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
        public void DateTimeEqualNullFunctionDefaultOption()
        {
            EqualOperatorOverloads equalOperatorOverloads = new();
            var operand1 = new Token(DateTime.Today, TokenType.Datetime);
            var operand2 = new Token(null, TokenType.NULL);
            var result =
             equalOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Default));

            Assert.NotNull(result.Value);
            Assert.True(result.Value.GetType() == typeof(bool));
            Assert.False(Convert.ToBoolean(result.Value));
        }

        [Fact]
        public void DateTimeEqualNullFunctionPropgateOption()
        {
            EqualOperatorOverloads equalOperatorOverloads = new();
            var operand1 = new Token(DateTime.Today, TokenType.Datetime);
            var operand2 = new Token(null, TokenType.NULL);
            var result =
             equalOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Propagate));

            Assert.Null(result.Value);
            Assert.True(result.TokenType == TokenType.NULL);
        }

        [Fact]
        public void DateTimeEqualNullFunctionThrowOption()
        {
            EqualOperatorOverloads equalOperatorOverloads = new();
            var operand1 = new Token(DateTime.Today, TokenType.Datetime);
            var operand2 = new Token(null, TokenType.NULL);
            Assert.Throws<NullTokenExecption>(() =>
            {
                equalOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));
            });
        }
    }
}