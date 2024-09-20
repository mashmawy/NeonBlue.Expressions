using NeonBlue.Expressions.Operators;

namespace NeonBlue.Expressions.Tests.OperatorsTests.NotEqualOperatorsTests
{
    public class FloatNotEqualOperatorUniTest
    {
        [Fact]
        public void FloatNotEqualByteReturnCorrectValueAndValueType()
        {
            // Given 
            NotEqualOperatorOverloads equalOperatorOverloads = new();
            var operand1 = new Token(2f, TokenType.Float);
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
        public void FloatNotEqualIntegerReturnCorrectValueAndValueType()
        {
            // Given 
            NotEqualOperatorOverloads equalOperatorOverloads = new();
            var operand1 = new Token(2f, TokenType.Float);
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
        public void FloatNotEqualLongReturnCorrectValueAndValueType()
        {
            // Given 
            NotEqualOperatorOverloads equalOperatorOverloads = new();
            var operand1 = new Token(2f, TokenType.Float);
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
        public void FloatNotEqualFloatReturnCorrectValueAndValueType()
        {
            // Given 
            NotEqualOperatorOverloads equalOperatorOverloads = new();
            var operand1 = new Token(2f, TokenType.Float);
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
        public void FloatNotEqualDoubleReturnCorrectValueAndValueType()
        {
            // Given 
            NotEqualOperatorOverloads equalOperatorOverloads = new();
            var operand1 = new Token(2f, TokenType.Float);
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
        public void FloatNotEqualDecimalReturnCorrectValueAndValueType()
        {
            // Given 
            NotEqualOperatorOverloads equalOperatorOverloads = new();
            var operand1 = new Token(2f, TokenType.Float);
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
        public void FloatNotEqualNullFunctionDefaultOption()
        {
            NotEqualOperatorOverloads equalOperatorOverloads = new();
            var operand1 = new Token(2f, TokenType.Float);
            var operand2 = new Token(null, TokenType.NULL);
            var result =
             equalOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Default));

            Assert.NotNull(result.Value);
            Assert.True(result.TokenType == TokenType.Boolean);
            Assert.False(Convert.ToBoolean(result.Value));
        }

        [Fact]
        public void FloatNotEqualNullFunctionPropgateOption()
        {
            NotEqualOperatorOverloads equalOperatorOverloads = new();
            var operand1 = new Token(2f, TokenType.Float);
            var operand2 = new Token(null, TokenType.NULL);
            var result =
             equalOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Propagate));

            Assert.Null(result.Value);
            Assert.True(result.TokenType == TokenType.NULL);
        }

        [Fact]
        public void FloatNotEqualNullFunctionThrowOption()
        {
            NotEqualOperatorOverloads equalOperatorOverloads = new();
            var operand1 = new Token(2f, TokenType.Float);
            var operand2 = new Token(null, TokenType.NULL);
            Assert.Throws<NullTokenException>(() =>
            {
                equalOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));
            });
        }
    }
}