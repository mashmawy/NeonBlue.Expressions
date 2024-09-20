using NeonBlue.Expressions.Operators;

namespace NeonBlue.Expressions.Tests.OperatorsTests.NotEqualOperatorsTests
{
    public class IntegerNotEqualOperatorUniTest
    {
        [Fact]
        public void IntegerNotEqualByteReturnCorrectValueAndValueType()
        {
            // Given 
            NotEqualOperatorOverloads equalOperatorOverloads = new();
            var operand1 = new Token(2, TokenType.Integer);
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
        public void IntegerNotEqualIntegerReturnCorrectValueAndValueType()
        {
            // Given 
            NotEqualOperatorOverloads equalOperatorOverloads = new();
            var operand1 = new Token(2, TokenType.Integer);
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
        public void IntegerNotEqualLongReturnCorrectValueAndValueType()
        {
            // Given 
            NotEqualOperatorOverloads equalOperatorOverloads = new();
            var operand1 = new Token(2, TokenType.Integer);
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
        public void IntegerNotEqualFloatReturnCorrectValueAndValueType()
        {
            // Given 
            NotEqualOperatorOverloads equalOperatorOverloads = new();
            var operand1 = new Token(2, TokenType.Integer);
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
        public void IntegerNotEqualDoubleReturnCorrectValueAndValueType()
        {
            // Given 
            NotEqualOperatorOverloads equalOperatorOverloads = new();
            var operand1 = new Token(2, TokenType.Integer);
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
        public void IntegerNotEqualDecimalReturnCorrectValueAndValueType()
        {
            // Given 
            NotEqualOperatorOverloads equalOperatorOverloads = new();
            var operand1 = new Token(2, TokenType.Integer);
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
        public void IntegerNotEqualNullFunctionDefaultOption()
        {
            NotEqualOperatorOverloads equalOperatorOverloads = new();
            var operand1 = new Token(2, TokenType.Integer);
            var operand2 = new Token(null, TokenType.NULL);
            var result =
             equalOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Default));

            Assert.NotNull(result.Value);
            Assert.True(result.TokenType == TokenType.Boolean);
            Assert.False(Convert.ToBoolean(result.Value));
        }

        [Fact]
        public void IntegerNotEqualNullFunctionPropgateOption()
        {
            NotEqualOperatorOverloads equalOperatorOverloads = new();
            var operand1 = new Token(2, TokenType.Integer);
            var operand2 = new Token(null, TokenType.NULL);
            var result =
             equalOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Propagate));

            Assert.Null(result.Value);
            Assert.True(result.TokenType == TokenType.NULL);
        }

        [Fact]
        public void IntegerNotEqualNullFunctionThrowOption()
        {
            NotEqualOperatorOverloads equalOperatorOverloads = new();
            var operand1 = new Token(2, TokenType.Integer);
            var operand2 = new Token(null, TokenType.NULL);
            Assert.Throws<NullTokenException>(() =>
            {
                equalOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));
            });
        }
    }
}