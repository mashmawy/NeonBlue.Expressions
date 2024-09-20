using NeonBlue.Expressions;
using NeonBlue.Expressions;
using NeonBlue.Expressions.Operators;

namespace NeonBlue.Expressions.Tests.OperatorsTests.NotEqualOperatorsTests
{
    public class LongNotEqualOperatorUniTest
    {
        [Fact]
        public void LongNotEqualByteReturnCorrectValueAndValueType()
        {
            // Given 
            NotEqualOperatorOverloads equalOperatorOverloads = new();
            var operand1 = new Token(2, TokenType.Long);
            var operand2 = new Token((byte)21, TokenType.Byte);
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
        public void LongNotEqualIntegerReturnCorrectValueAndValueType()
        {
            // Given 
            NotEqualOperatorOverloads equalOperatorOverloads = new();
            var operand1 = new Token(2, TokenType.Long);
            var operand2 = new Token(21, TokenType.Integer);
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
        public void LongNotEqualLongReturnCorrectValueAndValueType()
        {
            // Given 
            NotEqualOperatorOverloads equalOperatorOverloads = new();
            var operand1 = new Token(2, TokenType.Long);
            var operand2 = new Token((long)21, TokenType.Long);
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
        public void LongNotEqualFloatReturnCorrectValueAndValueType()
        {
            // Given 
            NotEqualOperatorOverloads equalOperatorOverloads = new();
            var operand1 = new Token(2, TokenType.Long);
            var operand2 = new Token(21f, TokenType.Float);
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
        public void LongNotEqualDoubleReturnCorrectValueAndValueType()
        {
            // Given 
            NotEqualOperatorOverloads equalOperatorOverloads = new();
            var operand1 = new Token(2, TokenType.Long);
            var operand2 = new Token(21.0, TokenType.Double);
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
        public void LongNotEqualDecimalReturnCorrectValueAndValueType()
        {
            // Given 
            NotEqualOperatorOverloads equalOperatorOverloads = new();
            var operand1 = new Token(2, TokenType.Long);
            var operand2 = new Token(21m, TokenType.Decimal);
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
        public void LongNotEqualNullFunctionDefaultOption()
        {
            NotEqualOperatorOverloads equalOperatorOverloads = new();
            var operand1 = new Token(2, TokenType.Long);
            var operand2 = new Token(null, TokenType.NULL);
            var result =
             equalOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Default));

            Assert.NotNull(result.Value);
            Assert.True(result.TokenType == TokenType.Boolean);
            Assert.False(Convert.ToBoolean(result.Value));
        }

        [Fact]
        public void LongNotEqualNullFunctionPropgateOption()
        {
            NotEqualOperatorOverloads equalOperatorOverloads = new();
            var operand1 = new Token(2, TokenType.Long);
            var operand2 = new Token(null, TokenType.NULL);
            var result =
             equalOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Propagate));

            Assert.Null(result.Value);
            Assert.True(result.TokenType == TokenType.NULL);
        }

        [Fact]
        public void LongNotEqualNullFunctionThrowOption()
        {
            NotEqualOperatorOverloads equalOperatorOverloads = new();
            var operand1 = new Token(2, TokenType.Long);
            var operand2 = new Token(null, TokenType.NULL);
            Assert.Throws<NullTokenException>(() =>
            {
                equalOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));
            });
        }
    }
}