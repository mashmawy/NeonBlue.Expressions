namespace NeonBlue.Expressions.Operators
{
    /// <summary>
    /// Helper class for working with operators and data types.
    /// </summary>
    public static class OperatorHelper
    {
        /// <summary>
        /// Epsilon value for floating-point comparisons.
        /// </summary>
        public readonly static float fepsilon = 1E-6f;
        public readonly static double depsilon = 1E-6;


        /// <summary>
        /// List of all supported operator token types.
        /// </summary>
        public static readonly List<TokenType> OperatorsTypes = [TokenType.Plus,
            TokenType.Minus,
            TokenType.Multiply,
            TokenType.Divide,
            TokenType.GreaterThanOrEqual,
            TokenType.GreaterThan,
            TokenType.LessThan,
            TokenType.LessThanOrEqual,
            TokenType.LogicalAnd,
            TokenType.LogicalOr,
            TokenType.LogicalNot];

        /// <summary>
        /// List of token types representing numerical data types.
        /// </summary>
        public static readonly List<TokenType> NumericalDataTypes = [TokenType.Integer,
            TokenType.Byte,
            TokenType.Long,
            TokenType.Float,
            TokenType.Double,
            TokenType.Decimal];


        /// <summary>
        /// List of token types representing non-numerical data types.
        /// </summary>
        public static readonly List<TokenType> NoneNumericalDataTypes = [
            TokenType.String,
            TokenType.Boolean,
            TokenType.Datetime,
            TokenType.NULL,
        ];

        /// <summary>
        /// List of all possible data types (combines numerical and non-numerical).
        /// </summary>
        public static readonly List<TokenType> AllDataTypes = [.. NumericalDataTypes, .. NoneNumericalDataTypes];


        /// <summary>
        /// Checks if the token type represents any data type (numerical or non-numerical).
        /// </summary>
        /// <param name="type">The token type to check.</param>
        /// <returns>True if the token type is a data type, false otherwise.</returns>

        public static bool IsDataType(TokenType type)
        {
            return AllDataTypes.Contains(type);
        }
        /// <summary>
        /// Checks if the token type represents a numerical data type.
        /// </summary>
        /// <param name="type">The token type to check.</param>
        /// <returns>True if the token type is a numerical data type, false otherwise.</returns>
        public static bool IsNumerical(TokenType type)
        {
            return NumericalDataTypes.Contains(type);
        }


    }
}