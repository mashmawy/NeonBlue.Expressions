using NeonBlue.Expressions;
using NeonBlue.Expressions.Exceptions;
using NeonBlue.Expressions.Functions;

namespace NeonBlue.Expressions.Functions.MathFunctions
{
    public class TruncateFunction : StackUpdateFunction
    {
        public override string FunctionName => "truncate";
        public override void Update(Stack<Token> x, IExecutionOptions executionOptions)
        {
            if (x is null || x.Count < 1)
            {
                throw new EmptyStackExecption();
            }
            var token = x.Pop();
            if (MathFunctionUtils.NullCheck(x, token, executionOptions.NullStrategy)) return;
            if (!TokensUtils.IsNumeric(token.TokenType))
            {
                throw new InvalidArgumentTypeExeception(FunctionName, typeof(DateTime));
            }


            try
            {
                if (token.TokenType == TokenType.Decimal)
                {
                    var arg1val = Convert.ToDecimal(token.Value);
                    x.Push(new Token(Math.Truncate(arg1val)));
                }
                else
                {
                    var arg1val = Convert.ToDouble(token.Value);
                    x.Push(new Token(Math.Truncate(arg1val)));
                }
            }
            catch (Exception ex)
            {
                throw new MathException(FunctionName, $"Math operation {FunctionName} can't be executed, see inner exception for more details", ex);
            }
        }

    }
}