using NeonBlue.Expressions.Operators;

namespace NeonBlue.Expressions.Tests.OperatorsTests.LessThanOrEqualOperatorsTests
{
    public class FloatLessThanOrEqualOperatorUnitTest
    {
        [Fact]
        public void FloatLessThanOrEqualByteReturnCorrectValueAndValueType()
        {
            // Given 
            LessThanOrEqualOperatorOverloads lessThanOrEqualOperatorOverloads = new();
            var operand1 = new Token(1f, TokenType.Float);
            var operand2 = new Token((byte)2, TokenType.Byte);
            // When
            var result =
                     lessThanOrEqualOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));

            // Then 
            Assert.NotNull(result.Value);
            Assert.True(result.TokenType == TokenType.Boolean);
            Assert.True(result.Value is bool);
            Assert.True(Convert.ToBoolean(result.Value));
        }
        [Fact]
        public void FloatLessThanOrEqualIntegerReturnCorrectValueAndValueType()
        {
            // Given 
            LessThanOrEqualOperatorOverloads lessThanOrEqualOperatorOverloads = new();
            var operand1 = new Token(1f, TokenType.Float);
            var operand2 = new Token(2, TokenType.Integer);
            // When
            var result =
                     lessThanOrEqualOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));
            // Then 
            Assert.NotNull(result.Value);
            Assert.True(result.TokenType == TokenType.Boolean);
            Assert.True(result.Value is bool);
            Assert.True(Convert.ToBoolean(result.Value));
        }
        [Fact]
        public void FloatLessThanOrEqualLongReturnCorrectValueAndValueType()
        {
            // Given 
            LessThanOrEqualOperatorOverloads lessThanOrEqualOperatorOverloads = new();
            var operand1 = new Token(1f, TokenType.Float);
            var operand2 = new Token((long)2, TokenType.Long);
            // When
            var result =
                     lessThanOrEqualOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));
            // Then 
            Assert.NotNull(result.Value);
            Assert.True(result.TokenType == TokenType.Boolean);
            Assert.True(result.Value is bool);
            Assert.True(Convert.ToBoolean(result.Value));
        }
        [Fact]
        public void FloatLessThanOrEqualFloatReturnCorrectValueAndValueType()
        {
            // Given 
            LessThanOrEqualOperatorOverloads lessThanOrEqualOperatorOverloads = new();
            var operand1 = new Token(1f, TokenType.Float);
            var operand2 = new Token(2f, TokenType.Float);
            // When
            var result =
                     lessThanOrEqualOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));
            // Then 
            Assert.NotNull(result.Value);
            Assert.True(result.TokenType == TokenType.Boolean);
            Assert.True(result.Value is bool);
            Assert.True(Convert.ToBoolean(result.Value));
        }
        [Fact]
        public void FloatLessThanOrEqualDoubleReturnCorrectValueAndValueType()
        {
            // Given 
            LessThanOrEqualOperatorOverloads lessThanOrEqualOperatorOverloads = new();
            var operand1 = new Token(1f, TokenType.Float);
            var operand2 = new Token(2.0, TokenType.Double);
            // When
            var result =
                     lessThanOrEqualOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));
            // Then 
            Assert.NotNull(result.Value);
            Assert.True(result.TokenType == TokenType.Boolean);
            Assert.True(result.Value is bool);
            Assert.True(Convert.ToBoolean(result.Value));
        }
        [Fact]
        public void FloatLessThanOrEqualDecimalReturnCorrectValueAndValueType()
        {
            // Given 
            LessThanOrEqualOperatorOverloads lessThanOrEqualOperatorOverloads = new();
            var operand1 = new Token(1f, TokenType.Float);
            var operand2 = new Token(2m, TokenType.Decimal);
            // When
            var result =
                     lessThanOrEqualOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));
            // Then 
            Assert.NotNull(result.Value);
            Assert.True(result.TokenType == TokenType.Boolean);
            Assert.True(result.Value is bool);
            Assert.True(Convert.ToBoolean(result.Value));
        }





        [Fact]
        public void FloatLessThanOrEqualNullFunctionDefaultOption()
        {
            LessThanOrEqualOperatorOverloads lessThanOrEqualOperatorOverloads = new();
            var operand1 = new Token(1f, TokenType.Float);
            var operand2 = new Token(null, TokenType.NULL);
            var result =
             lessThanOrEqualOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Default));

            Assert.NotNull(result.Value);
            Assert.True(result.TokenType == TokenType.Boolean);
            Assert.False(Convert.ToBoolean(result.Value));
        }

        [Fact]
        public void FloatLessThanOrEqualNullFunctionPropgateOption()
        {
            LessThanOrEqualOperatorOverloads lessThanOrEqualOperatorOverloads = new();
            var operand1 = new Token(1f, TokenType.Float);
            var operand2 = new Token(null, TokenType.NULL);
            var result =
             lessThanOrEqualOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Propagate));

            Assert.Null(result.Value);
            Assert.True(result.TokenType == TokenType.NULL);
        }

        [Fact]
        public void FloatLessThanOrEqualNullFunctionThrowOption()
        {
            LessThanOrEqualOperatorOverloads lessThanOrEqualOperatorOverloads = new();
            var operand1 = new Token(1f, TokenType.Float);
            var operand2 = new Token(null, TokenType.NULL);
            Assert.Throws<NullTokenException>(() =>
            {
                lessThanOrEqualOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));
            });
        }


        
          [Fact]
        public void FloatLessThanOrEqualWhenEqualByteReturnCorrectValueAndValueType()
        {
            // Given 
            LessThanOrEqualOperatorOverloads lessThanOrEqualOperatorOverloads = new();
            var operand1 = new Token(2f, TokenType.Float);
            var operand2 = new Token((byte)2, TokenType.Byte);
            // When
            var result =
                     lessThanOrEqualOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));

            // Then 
            Assert.NotNull(result.Value);
            Assert.True(result.TokenType == TokenType.Boolean);
            Assert.True(result.Value is bool);
            Assert.True(Convert.ToBoolean(result.Value));
        }
        [Fact]
        public void FloatLessThanOrEqualWhenEqualIntegerReturnCorrectValueAndValueType()
        {
            // Given 
            LessThanOrEqualOperatorOverloads lessThanOrEqualOperatorOverloads = new();
            var operand1 = new Token(2f, TokenType.Float);
            var operand2 = new Token(2, TokenType.Integer);
            // When
            var result =
                     lessThanOrEqualOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));
            // Then 
            Assert.NotNull(result.Value);
            Assert.True(result.TokenType == TokenType.Boolean);
            Assert.True(result.Value is bool);
            Assert.True(Convert.ToBoolean(result.Value));
        }
        [Fact]
        public void FloatLessThanOrEqualWhenEqualLongReturnCorrectValueAndValueType()
        {
            // Given 
            LessThanOrEqualOperatorOverloads lessThanOrEqualOperatorOverloads = new();
            var operand1 = new Token(2f, TokenType.Float);
            var operand2 = new Token((long)2, TokenType.Long);
            // When
            var result =
                     lessThanOrEqualOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));
            // Then 
            Assert.NotNull(result.Value);
            Assert.True(result.TokenType == TokenType.Boolean);
            Assert.True(result.Value is bool);
            Assert.True(Convert.ToBoolean(result.Value));
        }
        [Fact]
        public void FloatLessThanOrEqualWhenEqualFloatReturnCorrectValueAndValueType()
        {
            // Given 
            LessThanOrEqualOperatorOverloads lessThanOrEqualOperatorOverloads = new();
            var operand1 = new Token(2f, TokenType.Float);
            var operand2 = new Token(2f, TokenType.Float);
            // When
            var result =
                     lessThanOrEqualOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));
            // Then 
            Assert.NotNull(result.Value);
            Assert.True(result.TokenType == TokenType.Boolean);
            Assert.True(result.Value is bool);
            Assert.True(Convert.ToBoolean(result.Value));
        }
        [Fact]
        public void FloatLessThanOrEqualWhenEqualDoubleReturnCorrectValueAndValueType()
        {
            // Given 
            LessThanOrEqualOperatorOverloads lessThanOrEqualOperatorOverloads = new();
            var operand1 = new Token(2f, TokenType.Float);
            var operand2 = new Token(2.0, TokenType.Double);
            // When
            var result =
                     lessThanOrEqualOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));
            // Then 
            Assert.NotNull(result.Value);
            Assert.True(result.TokenType == TokenType.Boolean);
            Assert.True(result.Value is bool);
            Assert.True(Convert.ToBoolean(result.Value));
        }
        [Fact]
        public void FloatLessThanOrEqualWhenEqualDecimalReturnCorrectValueAndValueType()
        {
            // Given 
            LessThanOrEqualOperatorOverloads lessThanOrEqualOperatorOverloads = new();
            var operand1 = new Token(2f, TokenType.Float);
            var operand2 = new Token(2m, TokenType.Decimal);
            // When
            var result =
                     lessThanOrEqualOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));
            // Then 
            Assert.NotNull(result.Value);
            Assert.True(result.TokenType == TokenType.Boolean);
            Assert.True(result.Value is bool);
            Assert.True(Convert.ToBoolean(result.Value));
        }

    }
}