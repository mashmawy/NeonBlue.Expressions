using NeonBlue.Expressions;
using NeonBlue.Expressions.Exceptions;

namespace NeonBlue.Expressions.Functions.MathFunctions
{
    public static class MathFunctionUtils
    {

        public static bool NullCheck(Stack<Token> x, Token token, NullStrategy nullStrategy)
        {
            if (token.TokenType == TokenType.NULL)
            {
                if (nullStrategy == NullStrategy.Throw)
                {
                    throw new NullTokenExecption(token);

                }
                else
                {
                    x.Push(new(null, TokenType.NULL));
                }
                return true;
            }
            return false;
        }
        public static Token NullCheck(Token token, NullStrategy nullStrategy)
        {
            if (nullStrategy == NullStrategy.Throw)
            {
                throw new NullTokenExecption(token);

            }
            else
            {
                return new(null, TokenType.NULL);
            }
        }
    }
}