using NeonBlue.Expressions.Operators;

namespace NeonBlue.Expressions.Tests.OperatorsTests.GreaterThanOrEqualOperatorsTests
{
    public class FloatGreaterThanOrEqualOperatorUnitTest
    {
        [Fact]
        public void FloatGreaterThanOrEqualByteReturnCorrectValueAndValueType()
        {
            // Given 
            GreaterThanOrEqualOperatorOverloads greaterThanOrEqualOperatorOverloads = new();
            var operand1 = new Token(21f, TokenType.Float);
            var operand2 = new Token((byte)2, TokenType.Byte);
            // When
            var result =
                     greaterThanOrEqualOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));

            // Then 
            Assert.NotNull(result.Value);
            Assert.True(result.TokenType == TokenType.Boolean);
            Assert.True(result.Value is bool);
            Assert.True(Convert.ToBoolean(result.Value));
        }
        [Fact]
        public void FloatGreaterThanOrEqualIntegerReturnCorrectValueAndValueType()
        {
            // Given 
            GreaterThanOrEqualOperatorOverloads greaterThanOrEqualOperatorOverloads = new();
            var operand1 = new Token(21f, TokenType.Float);
            var operand2 = new Token(2, TokenType.Integer);
            // When
            var result =
                     greaterThanOrEqualOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));
            // Then 
            Assert.NotNull(result.Value);
            Assert.True(result.TokenType == TokenType.Boolean);
            Assert.True(result.Value is bool);
            Assert.True(Convert.ToBoolean(result.Value));
        }
        [Fact]
        public void FloatGreaterThanOrEqualLongReturnCorrectValueAndValueType()
        {
            // Given 
            GreaterThanOrEqualOperatorOverloads greaterThanOrEqualOperatorOverloads = new();
            var operand1 = new Token(21f, TokenType.Float);
            var operand2 = new Token((long)2, TokenType.Long);
            // When
            var result =
                     greaterThanOrEqualOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));
            // Then 
            Assert.NotNull(result.Value);
            Assert.True(result.TokenType == TokenType.Boolean);
            Assert.True(result.Value is bool);
            Assert.True(Convert.ToBoolean(result.Value));
        }
        [Fact]
        public void FloatGreaterThanOrEqualFloatReturnCorrectValueAndValueType()
        {
            // Given 
            GreaterThanOrEqualOperatorOverloads greaterThanOrEqualOperatorOverloads = new();
            var operand1 = new Token(21f, TokenType.Float);
            var operand2 = new Token(2f, TokenType.Float);
            // When
            var result =
                     greaterThanOrEqualOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));
            // Then 
            Assert.NotNull(result.Value);
            Assert.True(result.TokenType == TokenType.Boolean);
            Assert.True(result.Value is bool);
            Assert.True(Convert.ToBoolean(result.Value));
        }
        [Fact]
        public void FloatGreaterThanOrEqualDoubleReturnCorrectValueAndValueType()
        {
            // Given 
            GreaterThanOrEqualOperatorOverloads greaterThanOrEqualOperatorOverloads = new();
            var operand1 = new Token(21f, TokenType.Float);
            var operand2 = new Token(2.0, TokenType.Double);
            // When
            var result =
                     greaterThanOrEqualOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));
            // Then 
            Assert.NotNull(result.Value);
            Assert.True(result.TokenType == TokenType.Boolean);
            Assert.True(result.Value is bool);
            Assert.True(Convert.ToBoolean(result.Value));
        }
        [Fact]
        public void FloatGreaterThanOrEqualDecimalReturnCorrectValueAndValueType()
        {
            // Given 
            GreaterThanOrEqualOperatorOverloads greaterThanOrEqualOperatorOverloads = new();
            var operand1 = new Token(21f, TokenType.Float);
            var operand2 = new Token(2m, TokenType.Decimal);
            // When
            var result =
                     greaterThanOrEqualOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));
            // Then 
            Assert.NotNull(result.Value);
            Assert.True(result.TokenType == TokenType.Boolean);
            Assert.True(result.Value is bool);
            Assert.True(Convert.ToBoolean(result.Value));
        }





        [Fact]
        public void FloatGreaterThanOrEqualNullFunctionDefaultOption()
        {
            GreaterThanOrEqualOperatorOverloads greaterThanOrEqualOperatorOverloads = new();
            var operand1 = new Token(21f, TokenType.Float);
            var operand2 = new Token(null, TokenType.NULL);
            var result =
             greaterThanOrEqualOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Default));

            Assert.NotNull(result.Value);
            Assert.True(result.TokenType == TokenType.Boolean);
            Assert.False(Convert.ToBoolean(result.Value));
        }

        [Fact]
        public void FloatGreaterThanOrEqualNullFunctionPropgateOption()
        {
            GreaterThanOrEqualOperatorOverloads greaterThanOrEqualOperatorOverloads = new();
            var operand1 = new Token(21f, TokenType.Float);
            var operand2 = new Token(null, TokenType.NULL);
            var result =
             greaterThanOrEqualOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Propagate));

            Assert.Null(result.Value);
            Assert.True(result.TokenType == TokenType.NULL);
        }

        [Fact]
        public void FloatGreaterThanOrEqualNullFunctionThrowOption()
        {
            GreaterThanOrEqualOperatorOverloads greaterThanOrEqualOperatorOverloads = new();
            var operand1 = new Token(21f, TokenType.Float);
            var operand2 = new Token(null, TokenType.NULL);
            Assert.Throws<NullTokenException>(() =>
            {
                greaterThanOrEqualOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));
            });
        }
 
          [Fact]
        public void FloatGreaterThanOrEqualWhenEqualByteReturnCorrectValueAndValueType()
        {
            // Given 
            GreaterThanOrEqualOperatorOverloads greaterThanOrEqualOperatorOverloads = new();
            var operand1 = new Token(2f, TokenType.Float);
            var operand2 = new Token((byte)2, TokenType.Byte);
            // When
            var result =
                     greaterThanOrEqualOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));

            // Then 
            Assert.NotNull(result.Value);
            Assert.True(result.TokenType == TokenType.Boolean);
            Assert.True(result.Value is bool);
            Assert.True(Convert.ToBoolean(result.Value));
        }
        [Fact]
        public void FloatGreaterThanOrEqualWhenEqualIntegerReturnCorrectValueAndValueType()
        {
            // Given 
            GreaterThanOrEqualOperatorOverloads greaterThanOrEqualOperatorOverloads = new();
            var operand1 = new Token(2f, TokenType.Float);
            var operand2 = new Token(2, TokenType.Integer);
            // When
            var result =
                     greaterThanOrEqualOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));
            // Then 
            Assert.NotNull(result.Value);
            Assert.True(result.TokenType == TokenType.Boolean);
            Assert.True(result.Value is bool);
            Assert.True(Convert.ToBoolean(result.Value));
        }
        [Fact]
        public void FloatGreaterThanOrEqualWhenEqualLongReturnCorrectValueAndValueType()
        {
            // Given 
            GreaterThanOrEqualOperatorOverloads greaterThanOrEqualOperatorOverloads = new();
            var operand1 = new Token(2f, TokenType.Float);
            var operand2 = new Token((long)2, TokenType.Long);
            // When
            var result =
                     greaterThanOrEqualOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));
            // Then 
            Assert.NotNull(result.Value);
            Assert.True(result.TokenType == TokenType.Boolean);
            Assert.True(result.Value is bool);
            Assert.True(Convert.ToBoolean(result.Value));
        }
        [Fact]
        public void FloatGreaterThanOrEqualWhenEqualFloatReturnCorrectValueAndValueType()
        {
            // Given 
            GreaterThanOrEqualOperatorOverloads greaterThanOrEqualOperatorOverloads = new();
            var operand1 = new Token(2f, TokenType.Float);
            var operand2 = new Token(2f, TokenType.Float);
            // When
            var result =
                     greaterThanOrEqualOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));
            // Then 
            Assert.NotNull(result.Value);
            Assert.True(result.TokenType == TokenType.Boolean);
            Assert.True(result.Value is bool);
            Assert.True(Convert.ToBoolean(result.Value));
        }
        [Fact]
        public void FloatGreaterThanOrEqualWhenEqualDoubleReturnCorrectValueAndValueType()
        {
            // Given 
            GreaterThanOrEqualOperatorOverloads greaterThanOrEqualOperatorOverloads = new();
            var operand1 = new Token(2f, TokenType.Float);
            var operand2 = new Token(2.0, TokenType.Double);
            // When
            var result =
                     greaterThanOrEqualOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));
            // Then 
            Assert.NotNull(result.Value);
            Assert.True(result.TokenType == TokenType.Boolean);
            Assert.True(result.Value is bool);
            Assert.True(Convert.ToBoolean(result.Value));
        }
        [Fact]
        public void FloatGreaterThanOrEqualWhenEqualDecimalReturnCorrectValueAndValueType()
        {
            // Given 
            GreaterThanOrEqualOperatorOverloads greaterThanOrEqualOperatorOverloads = new();
            var operand1 = new Token(2f, TokenType.Float);
            var operand2 = new Token(2m, TokenType.Decimal);
            // When
            var result =
                     greaterThanOrEqualOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));
            // Then 
            Assert.NotNull(result.Value);
            Assert.True(result.TokenType == TokenType.Boolean);
            Assert.True(result.Value is bool);
            Assert.True(Convert.ToBoolean(result.Value));
        }


    }
}