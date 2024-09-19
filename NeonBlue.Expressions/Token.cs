using NeonBlue.Expressions.Functions;

namespace NeonBlue.Expressions
{
    public class Token
    {
        public object? Value { get; private set; }
        public TokenType TokenType { get; private set; }
        public bool IsSpecial { get; private set; }
        public bool IsFunction { get; private set; }
        public bool IsVariable { get; private set; }
        public bool IsConstant { get; private set; }

        public int Position { get; private set; }

        public Token(object? value, bool isConstant = false, bool isVariable = false)
        {
            if (value is null)
            {
                TokenType = TokenType.NULL;
                Value = value;
                IsSpecial = false;
                IsFunction = false;
            }
            (TokenType, Value, IsSpecial, IsFunction) = TokensUtils.GetTokenType(value, new FunctionsLookup());
            IsConstant = isConstant;
            IsVariable = isVariable;

        }
        public Token(object? value, FunctionsLookup functionsLookup, bool isConstant = false, bool isVariable = false)
        {
            if (value is null)
            {
                TokenType = TokenType.NULL;
                Value = value;
                IsSpecial = false;
                IsFunction = false;
            }
            (TokenType, Value, IsSpecial, IsFunction) = TokensUtils.GetTokenType(value, functionsLookup);
            IsConstant = isConstant;
            IsVariable = isVariable;

        }
        public Token(object? value, TokenType tokenType, bool isConstant = false, bool isVariable = false)
        {
            Value = value;
            TokenType = tokenType;
            IsConstant = isConstant;
            IsVariable = isVariable;
        }

        public Token(object? value, int pos, bool isConstant = false, bool isVariable = false) : this(value, isConstant, isVariable)
        {
            Position = pos;
        }

        public Token(object? value, int pos, FunctionsLookup functionsLookup, bool isConstant = false, bool isVariable = false) : this(value, functionsLookup, isConstant, isVariable)
        {
            Position = pos;
        }

        public Token(object? value, TokenType tokenType, int pos, bool isConstant = false, bool isVariable = false)
        : this(value, tokenType, isConstant, isVariable)
        {
            Position = pos;
        }





        public override string ToString()
        {
            if (Value == null) return "null";
            else return Value!.ToString()!;
        }

        internal bool IsNumber()
        {
            return TokensUtils.IsNumeric(TokenType);
        }
    }
}