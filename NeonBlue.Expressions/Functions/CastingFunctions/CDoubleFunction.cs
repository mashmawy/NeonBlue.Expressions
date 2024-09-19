using NeonBlue.Expressions;
using NeonBlue.Expressions;
using NeonBlue.Expressions.Functions;

namespace NeonBlue.Expressions.Functions.CastingFunctions
{
    public class CDoubleFunction : StackUpdateFunction
    {
        public override string FunctionName => "cdouble";

        public override void Update(Stack<Token> x, IExecutionOptions executionOptions)
        {
            if (x is null || x.Count < 1)
            {
                throw new EmptyStackException();
            }
            var arg1 = x.Pop();
            if (CastingFunctionsUtils.NullCheck(x, arg1, new Token(0.0, TokenType.Double), executionOptions))
            {
                return;
            }
            try
            {
                x.Push(new Token(Convert.ToDouble(arg1.Value)));
            }
            catch (Exception ex)
            {
                throw new CastingException($"Can't cast input of type {arg1.TokenType} to double, see inner exception", ex);
            }
        }
    }
}