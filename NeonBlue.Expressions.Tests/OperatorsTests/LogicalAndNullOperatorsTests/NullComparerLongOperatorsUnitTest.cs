using NeonBlue.Expressions.Operators.NullValue;

namespace NeonBlue.Expressions.Tests.OperatorsTests.LogicalAndNullOperatorsTests
{
    public class NullComparerLongOperatorsUnitTest
    {


        [Fact]
        public void LongComparerNullFunctionDefaultOption()
        {
            NullValueCompareOperatorsOverloads divideOperatorOverloads = new();
            var operand1 = new Token(null, TokenType.NULL);
            var operand2 = new Token(200, TokenType.Long);
            var result =
             divideOperatorOverloads.Evaluate(operand1, operand2, new ExecutionOptions(NullStrategy.Default));
            
            Assert.NotNull(result.Value);
            Assert.True(result.TokenType == TokenType.Boolean);
            Assert.False(Convert.ToBoolean(result.Value ));
        }
        [Fact]
        public void LongComparerNullFunctionPropgateOption()
        {
            NullValueCompareOperatorsOverloads divideOperatorOverloads = new();
               var operand1 = new Token(null, TokenType.NULL);
            var operand2 = new Token(200, TokenType.Long);
            var result =
             divideOperatorOverloads.Evaluate(operand1, operand2, new ExecutionOptions(NullStrategy.Propagate));

            Assert.Null(result.Value);
            Assert.True(result.TokenType == TokenType.NULL);
        }

        [Fact]
        public void LongComparerNullFunctionThrowOption()
        {
            NullValueCompareOperatorsOverloads divideOperatorOverloads = new();
            var operand1 = new Token(null, TokenType.NULL);
            var operand2 = new Token(200, TokenType.Long);
            Assert.Throws<NullTokenException>(() =>
            {
                divideOperatorOverloads.Evaluate(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));
            });
        }
    }
}