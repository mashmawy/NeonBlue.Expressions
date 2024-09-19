using NeonBlue.Expressions;
using NeonBlue.Expressions;
using NeonBlue.Expressions.Operators.NullValue;

namespace NeonBlue.Expressions.Tests.OperatorsTests.LogicalAndNullOperatorsTests
{
    public class NullComparerBooleanOperatorsUnitTest
    { 
        [Fact]
        public void BooleanComparerNullFunctionDefaultOption()
        {
            NullValue_CompareOperatorsOverloads divideOperatorOverloads = new();
            var operand1 = new Token(null, TokenType.NULL);
            var operand2 = new Token(false, TokenType.Datetime);
            var result =
             divideOperatorOverloads.Evaluate(operand1, operand2, new ExecutionOptions(NullStrategy.Default));

            Assert.NotNull(result.Value);
            Assert.True(result.TokenType == TokenType.Boolean);
            Assert.False(Convert.ToBoolean(result.Value));
        }
        [Fact]
        public void BooleanComparerNullFunctionPropgateOption()
        {
            NullValue_CompareOperatorsOverloads divideOperatorOverloads = new();
            var operand1 = new Token(null, TokenType.NULL);
            var operand2 = new Token(false, TokenType.Datetime);
            var result =
             divideOperatorOverloads.Evaluate(operand1, operand2, new ExecutionOptions(NullStrategy.Propagate));

            Assert.Null(result.Value);
            Assert.True(result.TokenType == TokenType.NULL);
        }

        [Fact]
        public void BooleanComparerNullFunctionThrowOption()
        {
            NullValue_CompareOperatorsOverloads divideOperatorOverloads = new();
            var operand1 = new Token(null, TokenType.NULL);
            var operand2 = new Token(false, TokenType.Datetime);
            Assert.Throws<NullTokenExecption>(() =>
            {
                divideOperatorOverloads.Evaluate(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));
            });
        }
    }
}