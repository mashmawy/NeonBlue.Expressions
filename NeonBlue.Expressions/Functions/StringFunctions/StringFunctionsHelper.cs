using NeonBlue.Expressions;

public static class StringFunctionsHelper
{
    public static bool NullCheck(Stack<Token> x, Token token,IExecutionOptions  executionOptions)
    {
        if (token.TokenType == TokenType.NULL)
        {
            if (executionOptions.NullStrategy == NullStrategy.Throw)
            {
                throw new NullTokenException(token);

            }
            else
            {
                x.Push(new(null, TokenType.NULL));
            }
            return true;
        }
        return false;
    }
}