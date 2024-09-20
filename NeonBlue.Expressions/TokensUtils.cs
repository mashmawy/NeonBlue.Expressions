namespace NeonBlue.Expressions
{
    internal static class TokensUtils
    {

        internal static readonly Dictionary<string, TokenType> SpecialTokenMap = new() {
            { "+", TokenType.Plus },
            { "-", TokenType.Minuse },
            { "/", TokenType.Divide },
            { "*", TokenType.Multiply },
            { "%", TokenType.Percentage },
            { "&&", TokenType.LogicalAnd },
            { "||", TokenType.LogicalOr },
            { "=", TokenType.Equal },
            { "==", TokenType.Equal },
            { "!=", TokenType.NotEqual },
            { "<", TokenType.LessThan },
            { ">", TokenType.GreaterThan },
            { "<=", TokenType.LessThanOrEqual },
            { ">=", TokenType.GreaterThanOrEqual },
            { "!", TokenType.LogicalNot },

        };
        internal static readonly Dictionary<Type, TokenType> TypeTokenMap = new() {
            { typeof(decimal), TokenType.Decimal },
            { typeof(byte), TokenType.Byte },
            { typeof(int), TokenType.Integer },
            { typeof(long), TokenType.Long },
            { typeof(float), TokenType.Float  },
            { typeof(double), TokenType.Double },
            { typeof(bool), TokenType.Boolean },
            { typeof(string), TokenType.String },
            { typeof(DateTime), TokenType.Datetime },
            { typeof(DateOnly), TokenType.Datetime },
            { typeof(TimeOnly), TokenType.Datetime },

        };

        static (TokenType, object?) PredictDataType(object data)
        {
            if (data is null)
            {
                return new(TokenType.NULL, null);
            }
            else
            if (data is string)
            {
                string datastr = data.ToString()!;
                if (datastr.Trim().StartsWith('\'') && datastr.Trim().EndsWith('\''))
                {
                    return (TokenType.String, datastr.Replace("'", ""));
                }
                else
                if (double.TryParse(datastr, out double db))
                {
                    if (datastr.Contains('.'))
                        return (TokenType.Double, db);
                    else
                        return (TokenType.Integer, Convert.ToInt32(data));
                }
                else if (DateTime.TryParse(data.ToString(), out DateTime date))
                {
                    return (TokenType.Datetime, date);
                }
                else
                {
                    return (TokenType.String, data.ToString());
                }
            }
            else
                return (GetDataType(data), data);
        }

        static TokenType GetDataType(object data)
        {
            if (TypeTokenMap.TryGetValue(data.GetType(), out var type))
            {
                return type;
            }
            else
                return TokenType.String;
        }

        internal static (TokenType, object?, bool, bool) GetTokenType(object? data, FunctionsLookup functionsLookup)
        {
            if (data is null)
            {
                return (TokenType.NULL, null, false, false);
            }
            else
            if (SpecialTokenMap.TryGetValue(data.ToString()!, out TokenType specialType))
            {
                return (specialType, data, true, false);
            }
            else if (IsFunction(data.ToString()!, functionsLookup))
            {
                return (TokenType.Function, data, false, true);
            }
            else
            {
                var res = PredictDataType(data);
                return (res.Item1, res.Item2, false, false);
            }
        }

        internal static bool IsNumeric(TokenType tokenType)
        {
            return tokenType switch
            {
                TokenType.Decimal or TokenType.Double or TokenType.Float or TokenType.Long or TokenType.Byte or TokenType.Integer => true,
                _ => false,
            };
        }
        internal static bool IsFunction(string name, FunctionsLookup functionsLookup)
        {
            return functionsLookup.IsFunction(name);
        }
    }
}