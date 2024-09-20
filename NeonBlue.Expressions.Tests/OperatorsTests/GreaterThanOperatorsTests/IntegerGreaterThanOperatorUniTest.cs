using NeonBlue.Expressions;
using NeonBlue.Expressions;
using NeonBlue.Expressions.Operators;

namespace NeonBlue.Expressions.Tests.OperatorsTests.GreaterThanOperatorsTests
{
    public class IntegerGreaterThanOperatorUniTest
    {
        [Fact]
        public void IntegerGreaterThanByteReturnCorrectValueAndValueType()
        {
            // Given 
            GreaterThanOperatorOverloads equalOperatorOverloads = new();
            var operand1 = new Token(21, TokenType.Integer);
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
        public void IntegerGreaterThanIntegerReturnCorrectValueAndValueType()
        {
            // Given 
            GreaterThanOperatorOverloads equalOperatorOverloads = new();
            var operand1 = new Token(21, TokenType.Integer);
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
        public void IntegerGreaterThanLongReturnCorrectValueAndValueType()
        {
            // Given 
            GreaterThanOperatorOverloads equalOperatorOverloads = new();
            var operand1 = new Token(21, TokenType.Integer);
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
        public void IntegerGreaterThanFloatReturnCorrectValueAndValueType()
        {
            // Given 
            GreaterThanOperatorOverloads equalOperatorOverloads = new();
            var operand1 = new Token(21, TokenType.Integer);
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
        public void IntegerGreaterThanDoubleReturnCorrectValueAndValueType()
        {
            // Given 
            GreaterThanOperatorOverloads equalOperatorOverloads = new();
            var operand1 = new Token(21, TokenType.Integer);
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
        public void IntegerGreaterThanDecimalReturnCorrectValueAndValueType()
        {
            // Given 
            GreaterThanOperatorOverloads equalOperatorOverloads = new();
            var operand1 = new Token(21, TokenType.Integer);
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
        public void IntegerGreaterThanNullFunctionDefaultOption()
        {
            GreaterThanOperatorOverloads equalOperatorOverloads = new();
            var operand1 = new Token(21, TokenType.Integer);
            var operand2 = new Token(null, TokenType.NULL);
            var result =
             equalOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Default));

            Assert.NotNull(result.Value);
            Assert.True(result.TokenType == TokenType.Boolean);
            Assert.False(Convert.ToBoolean(result.Value));
        }

        [Fact]
        public void IntegerGreaterThanNullFunctionPropgateOption()
        {
            GreaterThanOperatorOverloads equalOperatorOverloads = new();
            var operand1 = new Token(21, TokenType.Integer);
            var operand2 = new Token(null, TokenType.NULL);
            var result =
             equalOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Propagate));

            Assert.Null(result.Value);
            Assert.True(result.TokenType == TokenType.NULL);
        }

        [Fact]
        public void IntegerGreaterThanNullFunctionThrowOption()
        {
            GreaterThanOperatorOverloads equalOperatorOverloads = new();
            var operand1 = new Token(21, TokenType.Integer);
            var operand2 = new Token(null, TokenType.NULL);
            Assert.Throws<NullTokenException>(() =>
            {
                equalOperatorOverloads.Run(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));
            });
        }
    }
}