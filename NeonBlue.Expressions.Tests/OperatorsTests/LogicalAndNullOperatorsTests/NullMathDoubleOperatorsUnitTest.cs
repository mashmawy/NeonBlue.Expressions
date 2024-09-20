using NeonBlue.Expressions.Operators.NullValue;

namespace NeonBlue.Expressions.Tests.OperatorsTests.LogicalAndNullOperatorsTests
{
    public class NullMathDoubleOperatorsUnitTest
    {


        [Fact]
        public void DoubleMathNullFunctionDefaultOption()
        {
            NullValue_MathOperatorsOverloads divideOperatorOverloads = new();
            var operand1 = new Token(null, TokenType.NULL);
            var operand2 = new Token(200, TokenType.Double);
            var result =
             divideOperatorOverloads.Evaluate(operand1, operand2, new ExecutionOptions(NullStrategy.Default));

            Assert.Null(result.Value);
            Assert.True(result.TokenType == TokenType.NULL);
        }
        [Fact]
        public void DoubleMathNullFunctionPropgateOption()
        {
            NullValue_MathOperatorsOverloads divideOperatorOverloads = new();
               var operand1 = new Token(null, TokenType.NULL);
            var operand2 = new Token(200, TokenType.Double);
            var result =
             divideOperatorOverloads.Evaluate(operand1, operand2, new ExecutionOptions(NullStrategy.Propagate));

            Assert.Null(result.Value);
            Assert.True(result.TokenType == TokenType.NULL);
        }

        [Fact]
        public void DoubleMathNullFunctionThrowOption()
        {
            NullValue_MathOperatorsOverloads divideOperatorOverloads = new();
            var operand1 = new Token(null, TokenType.NULL);
            var operand2 = new Token(200, TokenType.Double);
            Assert.Throws<NullTokenException>(() =>
            {
                divideOperatorOverloads.Evaluate(operand1, operand2, new ExecutionOptions(NullStrategy.Throw));
            });
        }
    }
}