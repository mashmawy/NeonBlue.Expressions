using NeonBlue.Expressions.Exceptions;
using NeonBlue.Expressions;
using NeonBlue.Expressions.Operators;

namespace NeonBlue.Expressions.Tests.OperatorsTests.GreaterThanOperatorsTests
{
    public class LongGreaterThanOperatorUnitTest
    {
        [Fact]
        public void LongGreaterThanByteReturnCorrectValueAndValueType()
        {
            // Given 
            GreaterThanOperatorOverloads equalOperatorOverloads = new();
            var operand1 = new Token(21, TokenType.Long);
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
        public void LongGreaterThanIntegerReturnCorrectValueAndValueType()
        {
            // Given 
            GreaterThanOperatorOverloads equalOperatorOverloads = new();
            var operand1 = new Token(21, TokenType.Long);
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
        public void LongGreaterThanLongReturnCorrectValueAndValueType()
        {
            // Given 
            GreaterThanOperatorOverloads equalOperatorOverloads = new();
            var operand1 = new Token(21, TokenType.Long);
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
        public void LongGreaterThanFloatReturnCorrectValueAndValueType()
        {
            // Given 
            GreaterThanOperatorOverloads equalOperatorOverloads = new();
            var operand1 = new Token(21, TokenType.Long);
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
        public void LongGreaterThanDoubleReturnCorrectValueAndValueType()
        {
            // Given 
            GreaterThanOperatorOverloads equalOperatorOverloads = new();
            var operand1 = new Token(21, TokenType.Long);
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
        public void LongGreaterThanDecimalReturnCorrectValueAndValueType()
        {
            // Given 
            GreaterThanOperatorOverloads equalOperatorOverloads = new();
            var operand1 = new Token(21, TokenType.Long);
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
        public void LongGreaterThanNullFunctionDefaultOption()
        {
            GreaterThanOperatorOverloads equalOperatorOverloads = new();
            var operand1 = new Token(21, TokenType.Long);
            var operand2 = new Token(null, TokenType.NULL);
            var result =
             equalOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Default));

            Assert.NotNull(result.Value);
            Assert.True(result.TokenType == TokenType.Boolean);
            Assert.False(Convert.ToBoolean(result.Value));
        }

        [Fact]
        public void LongGreaterThanNullFunctionPropgateOption()
        {
            GreaterThanOperatorOverloads equalOperatorOverloads = new();
            var operand1 = new Token(21, TokenType.Long);
            var operand2 = new Token(null, TokenType.NULL);
            var result =
             equalOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Propagate));

            Assert.Null(result.Value);
            Assert.True(result.TokenType == TokenType.NULL);
        }

        [Fact]
        public void LongGreaterThanNullFunctionThrowOption()
        {
            GreaterThanOperatorOverloads equalOperatorOverloads = new();
            var operand1 = new Token(21, TokenType.Long);
            var operand2 = new Token(null, TokenType.NULL);
            Assert.Throws<NullTokenExecption>(() =>
            {
                equalOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));
            });
        }
    }
}