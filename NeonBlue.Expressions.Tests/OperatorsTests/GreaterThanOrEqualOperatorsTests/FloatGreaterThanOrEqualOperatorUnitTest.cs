using NeonBlue.Expressions.Exceptions;
using NeonBlue.Expressions;
using NeonBlue.Expressions.Operators;

namespace NeonBlue.Expressions.Tests.OperatorsTests.GreaterThanOrEqualOperatorsTests
{
    public class FloatGreaterThanOrEqualOperatorUnitTest
    {
        [Fact]
        public void FloatGreaterThanOrEqualByteReturnCorrectValueAndValueType()
        {
            // Given 
            GreaterThanOrEqualOperatorOverloads equalOperatorOverloads = new();
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
        public void FloatGreaterThanOrEqualIntegerReturnCorrectValueAndValueType()
        {
            // Given 
            GreaterThanOrEqualOperatorOverloads equalOperatorOverloads = new();
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
        public void FloatGreaterThanOrEqualLongReturnCorrectValueAndValueType()
        {
            // Given 
            GreaterThanOrEqualOperatorOverloads equalOperatorOverloads = new();
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
        public void FloatGreaterThanOrEqualFloatReturnCorrectValueAndValueType()
        {
            // Given 
            GreaterThanOrEqualOperatorOverloads equalOperatorOverloads = new();
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
        public void FloatGreaterThanOrEqualDoubleReturnCorrectValueAndValueType()
        {
            // Given 
            GreaterThanOrEqualOperatorOverloads equalOperatorOverloads = new();
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
        public void FloatGreaterThanOrEqualDecimalReturnCorrectValueAndValueType()
        {
            // Given 
            GreaterThanOrEqualOperatorOverloads equalOperatorOverloads = new();
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
        public void FloatGreaterThanOrEqualNullFunctionDefaultOption()
        {
            GreaterThanOrEqualOperatorOverloads equalOperatorOverloads = new();
            var operand1 = new Token(21f, TokenType.Float);
            var operand2 = new Token(null, TokenType.NULL);
            var result =
             equalOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Default));

            Assert.NotNull(result.Value);
            Assert.True(result.TokenType == TokenType.Boolean);
            Assert.False(Convert.ToBoolean(result.Value));
        }

        [Fact]
        public void FloatGreaterThanOrEqualNullFunctionPropgateOption()
        {
            GreaterThanOrEqualOperatorOverloads equalOperatorOverloads = new();
            var operand1 = new Token(21f, TokenType.Float);
            var operand2 = new Token(null, TokenType.NULL);
            var result =
             equalOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Propagate));

            Assert.Null(result.Value);
            Assert.True(result.TokenType == TokenType.NULL);
        }

        [Fact]
        public void FloatGreaterThanOrEqualNullFunctionThrowOption()
        {
            GreaterThanOrEqualOperatorOverloads equalOperatorOverloads = new();
            var operand1 = new Token(21f, TokenType.Float);
            var operand2 = new Token(null, TokenType.NULL);
            Assert.Throws<NullTokenExecption>(() =>
            {
                equalOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));
            });
        }
 
          [Fact]
        public void FloatGreaterThanOrEqualWhenEqualByteReturnCorrectValueAndValueType()
        {
            // Given 
            EqualOperatorOverloads equalOperatorOverloads = new();
            var operand1 = new Token(2f, TokenType.Float);
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
        public void FloatGreaterThanOrEqualWhenEqualIntegerReturnCorrectValueAndValueType()
        {
            // Given 
            EqualOperatorOverloads equalOperatorOverloads = new();
            var operand1 = new Token(2f, TokenType.Float);
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
        public void FloatGreaterThanOrEqualWhenEqualLongReturnCorrectValueAndValueType()
        {
            // Given 
            EqualOperatorOverloads equalOperatorOverloads = new();
            var operand1 = new Token(2f, TokenType.Float);
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
        public void FloatGreaterThanOrEqualWhenEqualFloatReturnCorrectValueAndValueType()
        {
            // Given 
            EqualOperatorOverloads equalOperatorOverloads = new();
            var operand1 = new Token(2f, TokenType.Float);
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
        public void FloatGreaterThanOrEqualWhenEqualDoubleReturnCorrectValueAndValueType()
        {
            // Given 
            EqualOperatorOverloads equalOperatorOverloads = new();
            var operand1 = new Token(2f, TokenType.Float);
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
        public void FloatGreaterThanOrEqualWhenEqualDecimalReturnCorrectValueAndValueType()
        {
            // Given 
            EqualOperatorOverloads equalOperatorOverloads = new();
            var operand1 = new Token(2f, TokenType.Float);
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