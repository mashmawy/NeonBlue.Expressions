using NeonBlue.Expressions;
using NeonBlue.Expressions;
using NeonBlue.Expressions.Operators.NullValue;

namespace NeonBlue.Expressions.Tests.OperatorsTests.LogicalAndNullOperatorsTests
{
    public class NullComparerIntegerOperatorsUnitTest
    {


        [Fact]
        public void IntegerComparerNullFunctionDefaultOption()
        {
            NullValue_CompareOperatorsOverloads divideOperatorOverloads = new();
            var operand1 = new Token(null, TokenType.NULL);
            var operand2 = new Token(200, TokenType.Integer);
            var result =
             divideOperatorOverloads.Evaluate(operand1, operand2, new ExecutionOptions(NullStrategy.Default));
            
            Assert.NotNull(result.Value);
            Assert.True(result.TokenType == TokenType.Boolean);
            Assert.False(Convert.ToBoolean(result.Value ));
        }
        [Fact]
        public void IntegerComparerNullFunctionPropgateOption()
        {
            NullValue_CompareOperatorsOverloads divideOperatorOverloads = new();
               var operand1 = new Token(null, TokenType.NULL);
            var operand2 = new Token(200, TokenType.Integer);
            var result =
             divideOperatorOverloads.Evaluate(operand1, operand2, new ExecutionOptions(NullStrategy.Propagate));

            Assert.Null(result.Value);
            Assert.True(result.TokenType == TokenType.NULL);
        }

        [Fact]
        public void IntegerComparerNullFunctionThrowOption()
        {
            NullValue_CompareOperatorsOverloads divideOperatorOverloads = new();
            var operand1 = new Token(null, TokenType.NULL);
            var operand2 = new Token(200, TokenType.Integer);
            Assert.Throws<NullTokenExecption>(() =>
            {
                divideOperatorOverloads.Evaluate(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));
            });
        }
    }
}