﻿namespace NeonBlue.Expressions
{
    public class ExpressionContext : IExpressionContext
    {
        private readonly Dictionary<string, object?> variables = [];
        private readonly Dictionary<string, TokenType> variablesTypes = [];

        public bool HasVariable(string name)
        {
            return variablesTypes.ContainsKey(name);
        }

        public object? GetVariableValue(string name)
        {
            if (variables.TryGetValue(name, out object? val))
            {
                return val;
            }
            throw new Exception($"Unknown Variable {name}");
        }

        public Token GetValueToken(string name)
        {
            return new Token(GetVariableValue(name), GetVariableType(name)); ;
        }
        public TokenType GetVariableType(string name)
        {
            if (variablesTypes.TryGetValue(name, out var type)) return type;

            throw new Exception($"Unknown Variable {name}");
        }
        public void SetVariable(string name, object? value)
        {
            if (value == null)
            {
                variables[name] = null;
                variablesTypes[name] = TokenType.NULL;
                return;
            }
            if (!variables.TryAdd(name, value))
            {
                variables[name] = value;
                if (variablesTypes[name] == TokenType.NULL)
                {
                    variablesTypes[name] = GetTokenType(value.GetType());

                }
            }
            if (!variablesTypes.TryAdd(name, GetTokenType(value.GetType())))
            {
                variablesTypes[name] = GetTokenType(value.GetType());

            }
        }


        private static TokenType GetTokenType(Type dataType, bool arrayOnly = false)
        {
            if (dataType == typeof(string) && arrayOnly == false)
            {
                return TokenType.String;
            }

            if (dataType == typeof(byte) && arrayOnly == false)
            {
                return TokenType.Byte;
            }

            if (dataType == typeof(int) && arrayOnly == false)
            {
                return TokenType.Integer;
            }

            if (dataType == typeof(long) && arrayOnly == false)
            {
                return TokenType.Long;
            }

            if (dataType == typeof(decimal) && arrayOnly == false)
            {
                return TokenType.Decimal;
            }

            if (dataType == typeof(float) && arrayOnly == false)
            {
                return TokenType.Float;
            }

            if (dataType == typeof(double) && arrayOnly == false)
            {
                return TokenType.Double;
            }

            if (dataType == typeof(bool) && arrayOnly == false)
            {
                return TokenType.Boolean;
            }

            if (dataType == typeof(DateTime) && arrayOnly == false)
            {
                return TokenType.Datetime;
            }

            return TokenType.String;





        }

        public ExpressionContext()
        {
        }



    }
}

