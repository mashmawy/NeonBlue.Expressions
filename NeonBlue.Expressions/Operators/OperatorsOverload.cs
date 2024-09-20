namespace NeonBlue.Expressions.Operators
{
    public abstract class OperatorsOverload
    {
        protected readonly Dictionary<TokenType, Func<Token, Token, IExecutionOptions, Token>> overloads = [];

        public virtual Dictionary<TokenType, Func<Token, Token, IExecutionOptions, Token>> GetOverloads()
        {
            return overloads;
        }
        public Token Evaluate(Token a1, Token a2, IExecutionOptions excutionOptions)
        {
            if (GetOverloads().TryGetValue(a2.TokenType, out var overload))
            {
                return overload.Invoke(a1, a2, excutionOptions);
            }
            else
            {
                throw new InvalidOperationException($" {a1.TokenType} has no overload for type {a2.TokenType}");
            }
        }
    }
}