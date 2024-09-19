using NeonBlue.Expressions;
using NeonBlue.Expressions;
using NeonBlue.Expressions.Functions;

namespace NeonBlue.Expressions.Functions.CastingFunctions
{
    public class CFloatFunction : StackUpdateFunction
    {
        public override string FunctionName => "cfloat";

        public override void Update(Stack<Token> x, IExecutionOptions executionOptions)
        {
            if (x is null || x.Count < 1)
            {
                throw new EmptyStackException();
            }
            var arg1 = x.Pop();
            if (CastingFunctionsUtils.NullCheck(x, arg1, new Token(0f, TokenType.Float), executionOptions))
            {
                return;
            }
            try
            {
                x.Push(new Token(Convert.ToSingle(arg1.Value)));
            }
            catch (Exception ex)
            {
                throw new CastingException($"Can't cast input of type {arg1.TokenType} to float, see inner exception", ex);
            }
        }
    }
}