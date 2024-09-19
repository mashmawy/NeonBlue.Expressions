using NeonBlue.Expressions.Exceptions;
using NeonBlue.Expressions;
using NeonBlue.Expressions.Operators;

namespace NeonBlue.Expressions.Tests.OperatorsTests.GreaterThanOperatorsTests
{
    public class DoubleGreaterThanOperatorUniTest
    {
        [Fact]
        public void DoubleGreaterThanByteReturnCorrectValueAndValueType()
        {
            // Given 
            GreaterThanOperatorOverloads equalOperatorOverloads = new();
            var operand1 = new Token(21.0, TokenType.Double);
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
        public void DoubleGreaterThanIntegerReturnCorrectValueAndValueType()
        {
            // Given 
            GreaterThanOperatorOverloads equalOperatorOverloads = new();
            var operand1 = new Token(21.0, TokenType.Double);
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
        public void DoubleGreaterThanLongReturnCorrectValueAndValueType()
        {
            // Given 
            GreaterThanOperatorOverloads equalOperatorOverloads = new();
            var operand1 = new Token(21.0, TokenType.Double);
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
        public void DoubleGreaterThanFloatReturnCorrectValueAndValueType()
        {
            // Given 
            GreaterThanOperatorOverloads equalOperatorOverloads = new();
            var operand1 = new Token(21.0, TokenType.Double);
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
        public void DoubleGreaterThanDoubleReturnCorrectValueAndValueType()
        {
            // Given 
            GreaterThanOperatorOverloads equalOperatorOverloads = new();
            var operand1 = new Token(21.0, TokenType.Double);
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
        public void DoubleGreaterThanDecimalReturnCorrectValueAndValueType()
        {
            // Given 
            GreaterThanOperatorOverloads equalOperatorOverloads = new();
            var operand1 = new Token(21.0, TokenType.Double);
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
        public void DoubleGreaterThanNullFunctionDefaultOption()
        {
            GreaterThanOperatorOverloads equalOperatorOverloads = new();
            var operand1 = new Token(21.0, TokenType.Double);
            var operand2 = new Token(null, TokenType.NULL);
            var result =
             equalOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Default));

            Assert.NotNull(result.Value);
            Assert.True(result.TokenType == TokenType.Boolean);
            Assert.False(Convert.ToBoolean(result.Value));
        }

        [Fact]
        public void DoubleGreaterThanNullFunctionPropgateOption()
        {
            GreaterThanOperatorOverloads equalOperatorOverloads = new();
            var operand1 = new Token(21.0, TokenType.Double);
            var operand2 = new Token(null, TokenType.NULL);
            var result =
             equalOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Propagate));

            Assert.Null(result.Value);
            Assert.True(result.TokenType == TokenType.NULL);
        }

        [Fact]
        public void DoubleGreaterThanNullFunctionThrowOption()
        {
            GreaterThanOperatorOverloads equalOperatorOverloads = new();
            var operand1 = new Token(21.0, TokenType.Double);
            var operand2 = new Token(null, TokenType.NULL);
            Assert.Throws<NullTokenExecption>(() =>
            {
                equalOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));
            });
        }
    }
}