using NeonBlue.Expressions.Operators;

namespace NeonBlue.Expressions.Tests.OperatorsTests.LessThanOperatorsTests
{
    public class DoubleLessThanOperatorUnitTest
    {
        [Fact]
        public void DoubleLessThanByteReturnCorrectValueAndValueType()
        {
            // Given 
            LessThanOperatorOverloads equalOperatorOverloads = new();
            var operand1 = new Token(1.0, TokenType.Double);
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
        public void DoubleLessThanIntegerReturnCorrectValueAndValueType()
        {
            // Given 
            LessThanOperatorOverloads equalOperatorOverloads = new();
            var operand1 = new Token(1.0, TokenType.Double);
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
        public void DoubleLessThanLongReturnCorrectValueAndValueType()
        {
            // Given 
            LessThanOperatorOverloads equalOperatorOverloads = new();
            var operand1 = new Token(1.0, TokenType.Double);
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
        public void DoubleLessThanFloatReturnCorrectValueAndValueType()
        {
            // Given 
            LessThanOperatorOverloads equalOperatorOverloads = new();
            var operand1 = new Token(1.0, TokenType.Double);
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
        public void DoubleLessThanDoubleReturnCorrectValueAndValueType()
        {
            // Given 
            LessThanOperatorOverloads equalOperatorOverloads = new();
            var operand1 = new Token(1.0, TokenType.Double);
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
        public void DoubleLessThanDecimalReturnCorrectValueAndValueType()
        {
            // Given 
            LessThanOperatorOverloads equalOperatorOverloads = new();
            var operand1 = new Token(1.0, TokenType.Double);
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
        public void DoubleLessThanNullFunctionDefaultOption()
        {
            LessThanOperatorOverloads equalOperatorOverloads = new();
            var operand1 = new Token(1.0, TokenType.Double);
            var operand2 = new Token(null, TokenType.NULL);
            var result =
             equalOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Default));

            Assert.NotNull(result.Value);
            Assert.True(result.TokenType == TokenType.Boolean);
            Assert.False(Convert.ToBoolean(result.Value));
        }

        [Fact]
        public void DoubleLessThanNullFunctionPropgateOption()
        {
            LessThanOperatorOverloads equalOperatorOverloads = new();
            var operand1 = new Token(1.0, TokenType.Double);
            var operand2 = new Token(null, TokenType.NULL);
            var result =
             equalOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Propagate));

            Assert.Null(result.Value);
            Assert.True(result.TokenType == TokenType.NULL);
        }

        [Fact]
        public void DoubleLessThanNullFunctionThrowOption()
        {
            LessThanOperatorOverloads equalOperatorOverloads = new();
            var operand1 = new Token(1.0, TokenType.Double);
            var operand2 = new Token(null, TokenType.NULL);
            Assert.Throws<NullTokenException>(() =>
            {
                equalOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));
            });
        }
    }
}