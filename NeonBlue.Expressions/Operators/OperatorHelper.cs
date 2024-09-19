using NeonBlue.Expressions;

namespace NeonBlue.Expressions.Operators
{
    public static class OperatorHelper
    {
        public static readonly List<TokenType> OperatorsTypes = [TokenType.Plus,
            TokenType.Minuse,
            TokenType.Multiply,
            TokenType.Divide,
            TokenType.GreaterThanOrEqual,
            TokenType.GreaterThan,
            TokenType.LessThan,
            TokenType.LessThanOrEqual,
            TokenType.LogicalAnd,
            TokenType.LogicalOr,
            TokenType.LogicalNot];

        public static readonly List<TokenType> NumericalDataTypes = [TokenType.Integer,
            TokenType.Byte,
            TokenType.Long,
            TokenType.Float,
            TokenType.Double,
            TokenType.Decimal];


        public static readonly List<TokenType> NoneNumericalDataTypes = [
            TokenType.String,
            TokenType.Boolean,
            TokenType.Datetime,
            TokenType.NULL,
        ];

        public static readonly List<TokenType> AllDataTypes = [.. NumericalDataTypes, .. NoneNumericalDataTypes];



        public static bool IsDataType(TokenType type)
        {
            return AllDataTypes.Contains(type);
        }
        public static bool IsNumerical(TokenType type)
        {
            return NumericalDataTypes.Contains(type);
        }


    }
}