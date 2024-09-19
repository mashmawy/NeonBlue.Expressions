using NeonBlue.Expressions;
using NeonBlue.Expressions;
using NeonBlue.Expressions.Functions;

namespace NeonBlue.Expressions.Functions.CastingFunctions
{
    public class CByteFunction : StackUpdateFunction
    {
        public override string FunctionName => "cbyte";

        public override void Update(Stack<Token> x, IExecutionOptions executionOptions)
        {
            if (x is null || x.Count < 1)
            {
                throw new EmptyStackExecption();
            }
            var arg1 = x.Pop();
            if (CastingFunctionsUtils.NullCheck(x, arg1, new Token((byte)0, TokenType.Byte), executionOptions))
            {
                return;
            }
            try
            {
                x.Push(new Token(Convert.ToByte(arg1.Value)));
            }
            catch (Exception ex)
            {
                throw new CastingException($"Can't cast input of type {arg1.TokenType} to byte, see inner exception", ex);
            }
        }
    }

}