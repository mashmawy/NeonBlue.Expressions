using NeonBlue.Expressions;
using NeonBlue.Expressions;
using NeonBlue.Expressions.Functions;

namespace NeonBlue.Expressions.Functions.CastingFunctions
{
    public class CDecimalFunction : StackUpdateFunction
    {
        public override string FunctionName => "cdecimal";

        public override void Update(Stack<Token> x, IExecutionOptions executionOptions)
        {
            if (x is null || x.Count < 1)
            {
                throw new EmptyStackExecption();
            }
            var arg1 = x.Pop();
            if (CastingFunctionsUtils.NullCheck(x, arg1, new Token(0m, TokenType.Decimal), executionOptions))
            {
                return;
            }
            try
            {
                x.Push(new Token(Convert.ToDecimal(arg1.Value)));
            }
            catch (Exception ex)
            {
                throw new CastingException($"Can't cast input of type {arg1.TokenType} to decimal, see inner exception", ex);
            }
        }
    }
}