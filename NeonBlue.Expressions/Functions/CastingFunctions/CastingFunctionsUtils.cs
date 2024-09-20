namespace NeonBlue.Expressions.Functions.CastingFunctions
{
    public static class CastingFunctionsUtils
    {
        public static bool NullCheck(Stack<Token> x, Token token, Token defaultToken, IExecutionOptions executionOptions)
        {
            if (token.TokenType == TokenType.NULL)
            {
                switch (executionOptions.NullStrategy)
                {
                    case NullStrategy.Throw:
                        throw new NullTokenException(token);
                    case NullStrategy.Default:
                        x.Push(defaultToken);
                        break;
                    case NullStrategy.Propagate:
                        x.Push(token);
                        break;
                }
                return true;
            }
            return false;
        }
    }
}