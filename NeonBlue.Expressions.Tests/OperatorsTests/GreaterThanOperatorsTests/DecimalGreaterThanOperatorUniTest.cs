using NeonBlue.Expressions.Operators;

namespace NeonBlue.Expressions.Tests.OperatorsTests.GreaterThanOperatorsTests
{
    public class DecimalGreaterThanOperatorUniTest
    {
        [Fact]
        public void DecimalGreaterThanByteReturnCorrectValueAndValueType()
        {
            // Given 
            GreaterThanOperatorOverloads equalOperatorOverloads = new();
            var operand1 = new Token(21m, TokenType.Decimal);
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
        public void DecimalGreaterThanIntegerReturnCorrectValueAndValueType()
        {
            // Given 
            GreaterThanOperatorOverloads equalOperatorOverloads = new();
            var operand1 = new Token(21m, TokenType.Decimal);
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
        public void DecimalGreaterThanLongReturnCorrectValueAndValueType()
        {
            // Given 
            GreaterThanOperatorOverloads equalOperatorOverloads = new();
            var operand1 = new Token(21m, TokenType.Decimal);
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
        public void DecimalGreaterThanFloatReturnCorrectValueAndValueType()
        {
            // Given 
            GreaterThanOperatorOverloads equalOperatorOverloads = new();
            var operand1 = new Token(21m, TokenType.Decimal);
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
        public void DecimalGreaterThanDoubleReturnCorrectValueAndValueType()
        {
            // Given 
            GreaterThanOperatorOverloads equalOperatorOverloads = new();
            var operand1 = new Token(21m, TokenType.Decimal);
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
        public void DecimalGreaterThanDecimalReturnCorrectValueAndValueType()
        {
            // Given 
            GreaterThanOperatorOverloads equalOperatorOverloads = new();
            var operand1 = new Token(21m, TokenType.Decimal);
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
        public void DecimalGreaterThanNullFunctionDefaultOption()
        {
            GreaterThanOperatorOverloads equalOperatorOverloads = new();
            var operand1 = new Token(21m, TokenType.Decimal);
            var operand2 = new Token(null, TokenType.NULL);
            var result =
             equalOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Default));

            Assert.NotNull(result.Value);
            Assert.True(result.TokenType == TokenType.Boolean);
            Assert.False(Convert.ToBoolean(result.Value));
        }

        [Fact]
        public void DecimalGreaterThanNullFunctionPropgateOption()
        {
            GreaterThanOperatorOverloads equalOperatorOverloads = new();
            var operand1 = new Token(21m, TokenType.Decimal);
            var operand2 = new Token(null, TokenType.NULL);
            var result =
             equalOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Propagate));

            Assert.Null(result.Value);
            Assert.True(result.TokenType == TokenType.NULL);
        }

        [Fact]
        public void DecimalGreaterThanNullFunctionThrowOption()
        {
            GreaterThanOperatorOverloads equalOperatorOverloads = new();
            var operand1 = new Token(21m, TokenType.Decimal);
            var operand2 = new Token(null, TokenType.NULL);
            Assert.Throws<NullTokenException>(() =>
            {
                equalOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));
            });
        }
    }
}