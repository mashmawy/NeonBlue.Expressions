using NeonBlue.Expressions.Operators;

namespace NeonBlue.Expressions.Tests.OperatorsTests.LessThanOrEqualOperatorsTests
{
    public class ByteLessThanOrEqualOperatorUniTest
    {
        [Fact]
        public void ByteLessThanOrEqualByteReturnCorrectValueAndValueType()
        {
            // Given 
            LessThanOrEqualOperatorOverloads equalOperatorOverloads = new();
            var operand1 = new Token((byte)1, TokenType.Byte);
            var operand2 = new Token((byte)2, TokenType.Byte);
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
        public void ByteLessThanOrEqualIntegerReturnCorrectValueAndValueType()
        {
            // Given 
            LessThanOrEqualOperatorOverloads equalOperatorOverloads = new();
            var operand1 = new Token((byte)1, TokenType.Byte);
            var operand2 = new Token(2, TokenType.Integer);
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
        public void ByteLessThanOrEqualLongReturnCorrectValueAndValueType()
        {
            // Given 
            LessThanOrEqualOperatorOverloads equalOperatorOverloads = new();
            var operand1 = new Token((byte)1, TokenType.Byte);
            var operand2 = new Token((long)2, TokenType.Long);
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
        public void ByteLessThanOrEqualFloatReturnCorrectValueAndValueType()
        {
            // Given 
            LessThanOrEqualOperatorOverloads equalOperatorOverloads = new();
            var operand1 = new Token((byte)1, TokenType.Byte);
            var operand2 = new Token(2f, TokenType.Float);
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
        public void ByteLessThanOrEqualDoubleReturnCorrectValueAndValueType()
        {
            // Given 
            LessThanOrEqualOperatorOverloads equalOperatorOverloads = new();
            var operand1 = new Token((byte)1, TokenType.Byte);
            var operand2 = new Token(2.0, TokenType.Double);
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
        public void ByteLessThanOrEqualDecimalReturnCorrectValueAndValueType()
        {
            // Given 
            LessThanOrEqualOperatorOverloads equalOperatorOverloads = new();
            var operand1 = new Token((byte)1, TokenType.Byte);
            var operand2 = new Token(2m, TokenType.Decimal);
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
        public void ByteLessThanOrEqualNullFunctionDefaultOption()
        {
            LessThanOrEqualOperatorOverloads equalOperatorOverloads = new();
            var operand1 = new Token((byte)1, TokenType.Byte);
            var operand2 = new Token(null, TokenType.NULL);
            var result =
             equalOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Default));

            Assert.NotNull(result.Value);
            Assert.True(result.TokenType == TokenType.Boolean);
            Assert.False(Convert.ToBoolean(result.Value));
        }

        [Fact]
        public void ByteLessThanOrEqualNullFunctionPropgateOption()
        {
            LessThanOrEqualOperatorOverloads equalOperatorOverloads = new();
            var operand1 = new Token((byte)1, TokenType.Byte);
            var operand2 = new Token(null, TokenType.NULL);
            var result =
             equalOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Propagate));

            Assert.Null(result.Value);
            Assert.True(result.TokenType == TokenType.NULL);
        }

        [Fact]
        public void ByteLessThanOrEqualNullFunctionThrowOption()
        {
            LessThanOrEqualOperatorOverloads equalOperatorOverloads = new();
            var operand1 = new Token((byte)1, TokenType.Byte);
            var operand2 = new Token(null, TokenType.NULL);
            Assert.Throws<NullTokenException>(() =>
            {
                equalOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));
            });
        }




           [Fact]
        public void ByteLessThanOrEqualWhenEqualByteReturnCorrectValueAndValueType()
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
            Assert.True(result.Value is bool);
            Assert.True(Convert.ToBoolean(result.Value));
        }
        [Fact]
        public void ByteLessThanOrEqualWhenEqualIntegerReturnCorrectValueAndValueType()
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
            Assert.True(result.Value is bool);
            Assert.True(Convert.ToBoolean(result.Value));
        }
        [Fact]
        public void ByteLessThanOrEqualWhenEqualLongReturnCorrectValueAndValueType()
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
            Assert.True(result.Value is bool);
            Assert.True(Convert.ToBoolean(result.Value));
        }
        [Fact]
        public void ByteLessThanOrEqualWhenEqualFloatReturnCorrectValueAndValueType()
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
            Assert.True(result.Value is bool);
            Assert.True(Convert.ToBoolean(result.Value));
        }
        [Fact]
        public void ByteLessThanOrEqualWhenEqualDoubleReturnCorrectValueAndValueType()
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
            Assert.True(result.Value is bool);
            Assert.True(Convert.ToBoolean(result.Value));
        }
        [Fact]
        public void ByteLessThanOrEqualWhenEqualDecimalReturnCorrectValueAndValueType()
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
            Assert.True(result.Value is bool);
            Assert.True(Convert.ToBoolean(result.Value));
        }
    }
}