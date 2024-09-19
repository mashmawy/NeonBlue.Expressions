using NeonBlue.Expressions;
using NeonBlue.Expressions;
using NeonBlue.Expressions.Operators;

namespace NeonBlue.Expressions.Tests.OperatorsTests.GreaterThanOrEqualOperatorsTests
{
    public class ByteGreaterThanOrEqualOperatorUniTest
    {
        [Fact]
        public void ByteGreaterThanOrEqualByteReturnCorrectValueAndValueType()
        {
            // Given 
            GreaterThanOrEqualOperatorOverloads equalOperatorOverloads = new();
            var operand1 = new Token((byte)20, TokenType.Byte);
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
        public void ByteGreaterThanOrEqualIntegerReturnCorrectValueAndValueType()
        {
            // Given 
            GreaterThanOrEqualOperatorOverloads equalOperatorOverloads = new();
            var operand1 = new Token((byte)20, TokenType.Byte);
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
        public void ByteGreaterThanOrEqualLongReturnCorrectValueAndValueType()
        {
            // Given 
            GreaterThanOrEqualOperatorOverloads equalOperatorOverloads = new();
            var operand1 = new Token((byte)20, TokenType.Byte);
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
        public void ByteGreaterThanOrEqualFloatReturnCorrectValueAndValueType()
        {
            // Given 
            GreaterThanOrEqualOperatorOverloads equalOperatorOverloads = new();
            var operand1 = new Token((byte)20, TokenType.Byte);
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
        public void ByteGreaterThanOrEqualDoubleReturnCorrectValueAndValueType()
        {
            // Given 
            GreaterThanOrEqualOperatorOverloads equalOperatorOverloads = new();
            var operand1 = new Token((byte)20, TokenType.Byte);
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
        public void ByteGreaterThanOrEqualDecimalReturnCorrectValueAndValueType()
        {
            // Given 
            GreaterThanOrEqualOperatorOverloads equalOperatorOverloads = new();
            var operand1 = new Token((byte)20, TokenType.Byte);
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
        public void ByteGreaterThanOrEqualNullFunctionDefaultOption()
        {
            GreaterThanOrEqualOperatorOverloads equalOperatorOverloads = new();
            var operand1 = new Token((byte)20, TokenType.Byte);
            var operand2 = new Token(null, TokenType.NULL);
            var result =
             equalOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Default));

            Assert.NotNull(result.Value);
            Assert.True(result.TokenType == TokenType.Boolean);
            Assert.False(Convert.ToBoolean(result.Value));
        }

        [Fact]
        public void ByteGreaterThanOrEqualNullFunctionPropgateOption()
        {
            GreaterThanOrEqualOperatorOverloads equalOperatorOverloads = new();
            var operand1 = new Token((byte)20, TokenType.Byte);
            var operand2 = new Token(null, TokenType.NULL);
            var result =
             equalOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Propagate));

            Assert.Null(result.Value);
            Assert.True(result.TokenType == TokenType.NULL);
        }

        [Fact]
        public void ByteGreaterThanOrEqualNullFunctionThrowOption()
        {
            GreaterThanOrEqualOperatorOverloads equalOperatorOverloads = new();
            var operand1 = new Token((byte)20, TokenType.Byte);
            var operand2 = new Token(null, TokenType.NULL);
            Assert.Throws<NullTokenExecption>(() =>
            {
                equalOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));
            });
        }














          [Fact]
        public void ByteGreaterThanOrEqualWhenEqualByteReturnCorrectValueAndValueType()
        {
            // Given 
            EqualOperatorOverloads equalOperatorOverloads = new();
            var operand1 = new Token((byte)2, TokenType.Byte);
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
        public void ByteGreaterThanOrEqualWhenEqualIntegerReturnCorrectValueAndValueType()
        {
            // Given 
            EqualOperatorOverloads equalOperatorOverloads = new();
            var operand1 = new Token((byte)2, TokenType.Byte);
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
        public void ByteGreaterThanOrEqualWhenEqualLongReturnCorrectValueAndValueType()
        {
            // Given 
            EqualOperatorOverloads equalOperatorOverloads = new();
            var operand1 = new Token((byte)2, TokenType.Byte);
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
        public void ByteGreaterThanOrEqualWhenEqualFloatReturnCorrectValueAndValueType()
        {
            // Given 
            EqualOperatorOverloads equalOperatorOverloads = new();
            var operand1 = new Token((byte)2, TokenType.Byte);
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
        public void ByteGreaterThanOrEqualWhenEqualDoubleReturnCorrectValueAndValueType()
        {
            // Given 
            EqualOperatorOverloads equalOperatorOverloads = new();
            var operand1 = new Token((byte)2, TokenType.Byte);
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
        public void ByteGreaterThanOrEqualWhenEqualDecimalReturnCorrectValueAndValueType()
        {
            // Given 
            EqualOperatorOverloads equalOperatorOverloads = new();
            var operand1 = new Token((byte)2, TokenType.Byte);
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

    }
}