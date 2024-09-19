using NeonBlue.Expressions;
using NeonBlue.Expressions;
using NeonBlue.Expressions.Functions;

namespace NeonBlue.Expressions.Functions.CastingFunctions
{
    public class CStringFunction : StackUpdateFunction
    {
        public override string FunctionName => "cstring";

        public override void Update(Stack<Token> x, IExecutionOptions executionOptions)
        {
            // var token1 = x.Pop();
            // if (StringFunctionsHelper.NullCheck(x, token1, executionOptions)) return;

            // var arg1 = token1.Value!.ToString();
            // x.Push(new Token(Convert.ToString(arg1)));


            if (x is null || x.Count < 1)
            {
                throw new EmptyStackExecption();
            }
            var token1 = x.Pop();
            if (StringFunctionsHelper.NullCheck(x, token1, executionOptions)) return;
            try
            {
                var arg1 = token1.Value!.ToString();
                x.Push(new Token(arg1, TokenType.String));


            }
            catch (Exception ex)
            {
                throw new CastingException($"Can't cast input of type {token1.TokenType} to long, see inner exception", ex);
            }
        }
    }
}