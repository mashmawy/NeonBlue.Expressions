using NeonBlue.Expressions;
using NeonBlue.Expressions.Exceptions;
using NeonBlue.Expressions.Functions;

namespace NeonBlue.Expressions.Functions.BooleanFunctions
{
    public class ISNULLFunction : StackUpdateFunction
    {
        public override string FunctionName => "isnull";

        public override void Update(Stack<Token> x, IExecutionOptions executionOptions)
        {
            if (x is null || x.Count < 1)
            {
                throw new EmptyStackExecption();
            }
            var token1 = x.Pop();

            if (token1.TokenType == TokenType.NULL)
            {
                x.Push(new Token(true, TokenType.Boolean));
            }
            else
            {
                x.Push(new Token(false, TokenType.Boolean));
            }

        }
    }
}