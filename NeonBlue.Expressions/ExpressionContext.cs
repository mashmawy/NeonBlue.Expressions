namespace NeonBlue.Expressions
{
    /// <summary>
    /// Represents the context for expression evaluation, managing variables and their types.
    /// </summary>
    public class ExpressionContext : IExpressionContext
    {
        /// <summary>
        /// A dictionary to store variable values.
        /// </summary>
        private readonly Dictionary<string, object?> variables = [];

        /// <summary>
        /// A dictionary to store variable types.
        /// </summary>
        private readonly Dictionary<string, TokenType> variablesTypes = [];

        /// <summary>
        /// Checks if a variable exists in the context.
        /// </summary>
        /// <param name="name">The name of the variable.</param>
        /// <returns>True if the variable exists, false otherwise.</returns>
        public bool HasVariable(string name)
        {
            return variablesTypes.ContainsKey(name);
        }

        /// <summary>
        /// Gets the value of a variable.
        /// </summary>
        /// <param name="name">The name of the variable.</param>
        /// <returns>The value of the variable, or null if not found.</returns>
        public object? GetVariableValue(string name)
        {
            if (variables.TryGetValue(name, out object? val))
            {
                return val;
            }

            throw new VariableNotFoundException($"Unknown Variable {name}");
        }

        /// <summary>
        /// Gets a Token representing the variable's value and type.
        /// </summary>
        /// <param name="name">The name of the variable.</param>
        /// <returns>A Token object with the variable's value and type.</returns>
        public Token GetValueToken(string name)
        {
            return new Token(GetVariableValue(name), GetVariableType(name));
        }

        /// <summary>
        /// Gets the type of a variable.
        /// </summary>
        /// <param name="name">The name of the variable.</param>
        /// <returns>The type of the variable.</returns>   

        public TokenType GetVariableType(string name)
        {
            if (variablesTypes.TryGetValue(name, out var type))
            {
                return type;
            }

            throw new VariableNotFoundException($"Unknown Variable {name}");
        }

        /// <summary>
        /// Sets the value and type of a variable.
        /// </summary>
        /// <param name="name">The name of the variable.</param>
        /// <param name="value">The new value of the variable.</param>
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
            }

            if (!variablesTypes.TryAdd(name, GetTokenType(value.GetType())))
            {
                variablesTypes[name] = GetTokenType(value.GetType());
            }
        }

        /// <summary>
        /// Gets the TokenType corresponding to a .NET type.
        /// </summary>
        /// <param name="dataType">The .NET type.</param>
        /// <returns>The corresponding TokenType.</returns>
        private static TokenType GetTokenType(Type dataType)
        {
            if (TokensUtils.TypeTokenMap.TryGetValue(dataType, out var type))
            {
                return type;
            }
            else
            {
                return TokenType.String;
            }
        }

        /// <summary>
        /// Initializes a new instance of the ExpressionContext class.
        /// </summary>
        public ExpressionContext()
        {
             
        }
    }

}


