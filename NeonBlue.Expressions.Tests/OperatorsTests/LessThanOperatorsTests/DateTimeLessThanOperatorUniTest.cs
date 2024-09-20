using NeonBlue.Expressions.Operators;

namespace NeonBlue.Expressions.Tests.OperatorsTests.LessThanOperatorsTests
{
    public class DateTimeLessThanOperatorUniTest
    {
        [Fact]
        public void DateTimeLessThanDateTimeReturnCorrectValueAndValueType()
        {
            // Given 
            LessThanOperatorOverloads equalOperatorOverloads = new();
            var operand1 = new Token(DateTime.Today.AddDays(-1), TokenType.Datetime);
            var operand2 = new Token(DateTime.Today, TokenType.Datetime);
            // When
            var result =
                     equalOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));

            // Then 
            Assert.NotNull(result.Value);
            Assert.True(result.TokenType == TokenType.Boolean);
            Assert.True(result.Value is bool);
            Assert.True(Convert.ToBoolean(result.Value));
        }
         

        [Fact]
        public void DateTimeLessThanNullFunctionDefaultOption()
        {
            LessThanOperatorOverloads equalOperatorOverloads = new();
            var operand1 = new Token(DateTime.Today, TokenType.Datetime);
            var operand2 = new Token(null, TokenType.NULL);
            var result =
             equalOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Default));

            Assert.NotNull(result.Value);
            Assert.True(result.Value is bool);
            Assert.False(Convert.ToBoolean(result.Value));
        }

        [Fact]
        public void DateTimeLessThanNullFunctionPropgateOption()
        {
            LessThanOperatorOverloads equalOperatorOverloads = new();
            var operand1 = new Token(DateTime.Today, TokenType.Datetime);
            var operand2 = new Token(null, TokenType.NULL);
            var result =
             equalOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Propagate));

            Assert.Null(result.Value);
            Assert.True(result.TokenType == TokenType.NULL);
        }

        [Fact]
        public void DateTimeLessThanNullFunctionThrowOption()
        {
            LessThanOperatorOverloads equalOperatorOverloads = new();
            var operand1 = new Token(DateTime.Today, TokenType.Datetime);
            var operand2 = new Token(null, TokenType.NULL);
            Assert.Throws<NullTokenException>(() =>
            {
                equalOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));
            });
        }
    }
}