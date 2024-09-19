using NeonBlue.Expressions;
using NeonBlue.Expressions;
using NeonBlue.Expressions.Operators.NullValue;

namespace NeonBlue.Expressions.Tests.OperatorsTests.LogicalAndNullOperatorsTests
{
    public class NullMathLongOperatorsUnitTest
    {


        [Fact]
        public void LongMathNullFunctionDefaultOption()
        {
            NullValue_MathOperatorsOverloads divideOperatorOverloads = new();
            var operand1 = new Token(null, TokenType.NULL);
            var operand2 = new Token(200, TokenType.Long);
            var result =
             divideOperatorOverloads.Evaluate(operand1, operand2, new ExecutionOptions(NullStrategy.Default));

            Assert.Null(result.Value);
            Assert.True(result.TokenType == TokenType.NULL);
        }
        [Fact]
        public void LongMathNullFunctionPropgateOption()
        {
            NullValue_MathOperatorsOverloads divideOperatorOverloads = new();
               var operand1 = new Token(null, TokenType.NULL);
            var operand2 = new Token(200, TokenType.Long);
            var result =
             divideOperatorOverloads.Evaluate(operand1, operand2, new ExecutionOptions(NullStrategy.Propagate));

            Assert.Null(result.Value);
            Assert.True(result.TokenType == TokenType.NULL);
        }

        [Fact]
        public void LongMathNullFunctionThrowOption()
        {
            NullValue_MathOperatorsOverloads divideOperatorOverloads = new();
            var operand1 = new Token(null, TokenType.NULL);
            var operand2 = new Token(200, TokenType.Long);
            Assert.Throws<NullTokenExecption>(() =>
            {
                divideOperatorOverloads.Evaluate(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));
            });
        }
    }
}