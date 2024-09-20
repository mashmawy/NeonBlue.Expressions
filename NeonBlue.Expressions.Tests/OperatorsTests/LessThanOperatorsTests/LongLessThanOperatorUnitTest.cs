using NeonBlue.Expressions.Operators;

namespace NeonBlue.Expressions.Tests.OperatorsTests.LessThanOperatorsTests
{
    public class LongLessThanOperatorUnitTest
    {
        [Fact]
        public void LongLessThanByteReturnCorrectValueAndValueType()
        {
            // Given 
            LessThanOperatorOverloads equalOperatorOverloads = new();
            var operand1 = new Token(1, TokenType.Long);
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
        public void LongLessThanIntegerReturnCorrectValueAndValueType()
        {
            // Given 
            LessThanOperatorOverloads equalOperatorOverloads = new();
            var operand1 = new Token(1, TokenType.Long);
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
        public void LongLessThanLongReturnCorrectValueAndValueType()
        {
            // Given 
            LessThanOperatorOverloads equalOperatorOverloads = new();
            var operand1 = new Token(1, TokenType.Long);
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
        public void LongLessThanFloatReturnCorrectValueAndValueType()
        {
            // Given 
            LessThanOperatorOverloads equalOperatorOverloads = new();
            var operand1 = new Token(1, TokenType.Long);
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
        public void LongLessThanDoubleReturnCorrectValueAndValueType()
        {
            // Given 
            LessThanOperatorOverloads equalOperatorOverloads = new();
            var operand1 = new Token(1, TokenType.Long);
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
        public void LongLessThanDecimalReturnCorrectValueAndValueType()
        {
            // Given 
            LessThanOperatorOverloads equalOperatorOverloads = new();
            var operand1 = new Token(1, TokenType.Long);
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
        public void LongLessThanNullFunctionDefaultOption()
        {
            LessThanOperatorOverloads equalOperatorOverloads = new();
            var operand1 = new Token(1, TokenType.Long);
            var operand2 = new Token(null, TokenType.NULL);
            var result =
             equalOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Default));

            Assert.NotNull(result.Value);
            Assert.True(result.TokenType == TokenType.Boolean);
            Assert.False(Convert.ToBoolean(result.Value));
        }

        [Fact]
        public void LongLessThanNullFunctionPropgateOption()
        {
            LessThanOperatorOverloads equalOperatorOverloads = new();
            var operand1 = new Token(1, TokenType.Long);
            var operand2 = new Token(null, TokenType.NULL);
            var result =
             equalOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Propagate));

            Assert.Null(result.Value);
            Assert.True(result.TokenType == TokenType.NULL);
        }

        [Fact]
        public void LongLessThanNullFunctionThrowOption()
        {
            LessThanOperatorOverloads equalOperatorOverloads = new();
            var operand1 = new Token(1, TokenType.Long);
            var operand2 = new Token(null, TokenType.NULL);
            Assert.Throws<NullTokenException>(() =>
            {
                equalOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));
            });
        }
    }
}