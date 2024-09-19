using NeonBlue.Expressions;
using NeonBlue.Expressions;

namespace NeonBlue.Expressions.Functions.BooleanFunctions
{
    public static class BooleanFunctionsUtils
    {
        public static bool IsBoolean(Token token)
        {
            if (token == null || token.Value is null)
            {
                return false;
            }
            return token.TokenType == TokenType.Boolean || token.Value.ToString() == "true" || token.Value.ToString() == "false"
             || token.Value.ToString() == "1" || token.Value.ToString() == "0";
        }
        public static void AssertBoolean(Token token, string function)
        {
            if (!IsBoolean(token) && token.Value is not null)
            {

                throw new InvalidArgumentTypeExeception
                    (function, token.Value.GetType(), $"Invalid Argument type {token.Value.GetType().Name} for function {function}");

            }
        }
        public static bool NullCheck(Stack<Token> x, Token token, NullStrategy nullStrategy)
        {
            if (x == null)
            {
                throw new EmptyStackException();
            }
            if (token.TokenType == TokenType.NULL)
            {
                switch (nullStrategy)
                {
                    case NullStrategy.Throw:
                        throw new NullTokenExecption(token);
                    case NullStrategy.Default:
                        x.Push(new Token(false, TokenType.Boolean));
                        break;
                    case NullStrategy.Propagate:
                        x.Push(token);
                        break;
                }
                return true;
            }
            return false;
        }
        public static Token NullCheck(Token token, NullStrategy nullStrategy)
        {
            if (nullStrategy == NullStrategy.Default)
            {
                return new Token(false, TokenType.Boolean);
            }
            else if (nullStrategy == NullStrategy.Propagate)
            {
                return new Token(null, TokenType.NULL);
            }
            else
            {
                throw new NullTokenExecption(token);
            }

        }
    }
}