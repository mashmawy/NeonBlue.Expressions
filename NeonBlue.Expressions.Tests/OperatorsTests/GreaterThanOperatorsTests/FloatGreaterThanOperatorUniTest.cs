using NeonBlue.Expressions.Operators;

namespace NeonBlue.Expressions.Tests.OperatorsTests.GreaterThanOperatorsTests
{
    public class FloatGreaterThanOperatorUniTest
    {
        [Fact]
        public void FloatGreaterThanByteReturnCorrectValueAndValueType()
        {
            // Given 
            GreaterThanOperatorOverloads equalOperatorOverloads = new();
            var operand1 = new Token(21f, TokenType.Float);
            var operand2 = new Token((byte)2, TokenType.Byte);
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
        public void FloatGreaterThanIntegerReturnCorrectValueAndValueType()
        {
            // Given 
            GreaterThanOperatorOverloads equalOperatorOverloads = new();
            var operand1 = new Token(21f, TokenType.Float);
            var operand2 = new Token(2, TokenType.Integer);
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
        public void FloatGreaterThanLongReturnCorrectValueAndValueType()
        {
            // Given 
            GreaterThanOperatorOverloads equalOperatorOverloads = new();
            var operand1 = new Token(21f, TokenType.Float);
            var operand2 = new Token((long)2, TokenType.Long);
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
        public void FloatGreaterThanFloatReturnCorrectValueAndValueType()
        {
            // Given 
            GreaterThanOperatorOverloads equalOperatorOverloads = new();
            var operand1 = new Token(21f, TokenType.Float);
            var operand2 = new Token(2f, TokenType.Float);
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
        public void FloatGreaterThanDoubleReturnCorrectValueAndValueType()
        {
            // Given 
            GreaterThanOperatorOverloads equalOperatorOverloads = new();
            var operand1 = new Token(21f, TokenType.Float);
            var operand2 = new Token(2.0, TokenType.Double);
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
        public void FloatGreaterThanDecimalReturnCorrectValueAndValueType()
        {
            // Given 
            GreaterThanOperatorOverloads equalOperatorOverloads = new();
            var operand1 = new Token(21f, TokenType.Float);
            var operand2 = new Token(2m, TokenType.Decimal);
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
        public void FloatGreaterThanNullFunctionDefaultOption()
        {
            GreaterThanOperatorOverloads equalOperatorOverloads = new();
            var operand1 = new Token(21f, TokenType.Float);
            var operand2 = new Token(null, TokenType.NULL);
            var result =
             equalOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Default));

            Assert.NotNull(result.Value);
            Assert.True(result.TokenType == TokenType.Boolean);
            Assert.False(Convert.ToBoolean(result.Value));
        }

        [Fact]
        public void FloatGreaterThanNullFunctionPropgateOption()
        {
            GreaterThanOperatorOverloads equalOperatorOverloads = new();
            var operand1 = new Token(21f, TokenType.Float);
            var operand2 = new Token(null, TokenType.NULL);
            var result =
             equalOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Propagate));

            Assert.Null(result.Value);
            Assert.True(result.TokenType == TokenType.NULL);
        }

        [Fact]
        public void FloatGreaterThanNullFunctionThrowOption()
        {
            GreaterThanOperatorOverloads equalOperatorOverloads = new();
            var operand1 = new Token(21f, TokenType.Float);
            var operand2 = new Token(null, TokenType.NULL);
            Assert.Throws<NullTokenException>(() =>
            {
                equalOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));
            });
        }
    }
}