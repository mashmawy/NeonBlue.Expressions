using System.Data;
using System.Text;
using NeonBlue.Expressions.Aggregates;
using NeonBlue.Expressions.Operators;

namespace NeonBlue.Expressions
{
    public static class ExpressionAnalyzer
    {
        internal static readonly string[] specialTokens
            = ["=", "==", "&&", "||", "!=", ">", "<", "<=", ">=", "-", "+", "%", "/", "*", "!", "'", ",", "(", ")"];


        /// <summary>
        ///  Parses an expression string, identifying and extracting aggregated expressions 
        /// </summary>
        /// <param name="expression">The input expression string to be parsed.</param>
        /// <param name="functionsLookup">A lookup table containing information about defined functions.</param>
        /// <returns>An AggregatedExpression object containing the updated expression and a list of extracted aggregated expressions.</returns>
        /// <exception cref="UnclosedParenthesesException">Represents an exception that occurs when there are unclosed parentheses in the expression.</exception>
        public static AggregatedExpression GetAggregatedExpressions(string expression, FunctionsLookup functionsLookup)
        {
            // Create a tokenizer to break down the expression into tokens
            Tokenizer tokenizer = new(expression);

            // Tokenize the expression
            var tokens = tokenizer.Tokenize(functionsLookup);

            // Track if we're inside an aggregated function
            bool inFunction = false;

            // Count opened parentheses
            int opened = 0;

            // Store extracted aggregated expressions and their temporary identifiers
            Dictionary<string, string> results = [];
            List<AggregatedExpressionPart> expressions = [];

            // StringBuilder to build the aggregated expression string
            StringBuilder inFunctionExpression = new();

            // List of variables within the current aggregated function
            List<string> variables = [];

            // Current function being processed
            string currentFunction = string.Empty;

            // Updated expression with replaced aggregated expressions
            StringBuilder updatedExpression = new();

            // Iterate through each token
            foreach (var token in tokens)
            {
                // Check if it's the start of an aggregated function
                if (token.Value is not null && AggregatedExpressionPart.IsAggregate(token.Value.Trim()))
                {
                    // Set current function and indicate we're inside a function
                    currentFunction = token.Value.Trim();
                    inFunction = true;
                    continue;
                }

                // Check for opening parentheses within the function
                if (token.Value is not null && token.Value.Trim() == "(" && inFunction)
                {
                    // Increment opened parentheses count
                    opened++;

                    // If this is the first opening parenthesis, continue
                    if (opened == 1)
                    {
                        continue;
                    }
                }

                // Check for closing parentheses within the function
                if (token.Value is not null && token.Value.Trim() == ")" && inFunction)
                {
                    // Decrement opened parentheses count
                    opened--;

                    // If all parentheses are closed
                    if (opened == 0)
                    {
                        // Generate a temporary identifier
                        var id = "V" + Guid.NewGuid().ToString().Replace("-", "");

                        // Store the extracted expression and its identifier
                        var currentString = inFunctionExpression.ToString();
                        results.Add(id, currentString);
                        expressions.Add(new AggregatedExpressionPart(currentString, id, currentFunction, variables));

                        // Replace the original expression with the identifier
                        expression = expression.Replace(currentString, id);

                        // Clear the in-function expression and variables
                        inFunctionExpression.Clear();
                        updatedExpression.Append(id);
                        variables.Clear();

                        // Indicate that we're no longer inside a function
                        inFunction = false;
                        continue;
                    }
                }

                // If we're inside a function, append the token to the in-function expression
                if (inFunction)
                {
                    inFunctionExpression.Append(token.Value);
                }
                else
                {
                    // Otherwise, append the token to the updated expression
                    updatedExpression.Append(token.Value);
                }

                // If the token is a variable, add it to the current function's variables
                if (token.Value is not null && token.TokenType == IntermediateTokenType.Variable)
                {
                    variables.Add(token.Value.Trim());
                }
            }

            // Check for unclosed parentheses
            if (opened > 0)
            {
                throw new UnclosedParenthesesException();
            }

            // Return the updated expression and extracted aggregated expressions
            return new AggregatedExpression(updatedExpression.ToString(), expressions);
        }


        /// <summary>
        /// Parses an expression string into a list of tokens, handling variables, functions, operators, and parentheses.
        /// </summary>
        /// <param name="expression">The input expression string to be parsed.</param>
        /// <param name="table">An IExpressionContext object that provides information about variables and their types.</param>
        /// <param name="functionsLookup">A lookup table containing information about defined functions.</param>
        /// <returns>List contains the final tokens that represent the parsed expression</returns>
        /// <exception cref="SyntaxErrorException">Thrown if an unknown token is encountered during parsing.</exception>
        internal static List<Token> Parse(string expression, IExpressionContext table, FunctionsLookup functionsLookup)
        {
            // Create a tokenizer to break down the expression into intermediate tokens
            Tokenizer tokenizer = new(expression);

            // Tokenize the expression
            var intermediaTokens = tokenizer.Tokenize(functionsLookup);

            // Stack to store operators and parentheses
            Stack<IntermediateToken> expressionStack = new();

            // List to store the final tokens
            List<Token> expressionList = [];

            // Iterate through each intermediate token
            foreach (var token in intermediaTokens)
            {
                // Handle string literals
                if (token.TokenType == IntermediateTokenType.String)
                {
                    // Create a new Token with the string value
                    var varToken = new Token(token.Value, TokenType.String, token.Pos, true);
                    expressionList.Add(varToken);
                    continue;
                }

                // Handle variables
                if (token.Value is not null && table.HasVariable(token.Value))
                {
                    // Create a new Token with the variable value and type
                    var varToken = new Token(token.Value, table.GetVariableType(token.Value), token.Pos, false, true);
                    expressionList.Add(varToken);
                    continue;
                }

                // Handle operators and functions
                if (!specialTokens.Contains(token.Value) && !(token.Value is not null && TokensUtils.IsFunction(token.Value, functionsLookup)))
                {
                    // Create a new Token for numerical values
                    var numericalToken = new Token(token.Value, token.Pos);

                    // Check if the token is a valid numerical type
                    if (!OperatorHelper.IsNumerical(numericalToken.TokenType))
                    {
                        // Throw an exception for unknown tokens
                        throw new SyntaxErrorException($"Unknown token at '{token.Value}' at position {token.Pos}");
                    }

                    // Add the numerical token to the expression list
                    expressionList.Add(numericalToken);
                }
                else if (token.Value == "(")
                {
                    // Push opening parentheses onto the stack
                    expressionStack.Push(token);
                }
                else if (token.Value == ")")
                {
                    // Pop items from the stack until matching opening parenthesis is found
                    while (expressionStack.TryPop(out IntermediateToken? res) && res.Value != "(")
                    {
                        // Create a new Token and add it to the expression list
                        expressionList.Add(new Token(res.Value, res.Pos, functionsLookup));
                    }
                }
                else
                {
                    // Handle operators and functions based on precedence
                    while (expressionStack.Count > 0 &&
                           Priority(expressionStack.Peek().Value, specialTokens, functionsLookup) >= Priority(token.Value, specialTokens, functionsLookup))
                    {
                        // Pop operators from the stack and add them to the expression list
                        var res = expressionStack.Pop();
                        expressionList.Add(new Token(res.Value, res.Pos, functionsLookup));
                    }

                    // Push the current token onto the stack if it's not a comma
                    if (token.Value != ",")
                    {
                        expressionStack.Push(token);
                    }
                }
            }

            // Pop any remaining operators from the stack
            while (expressionStack.TryPop(out IntermediateToken? res))
            {
                expressionList.Add(new Token(res.Value, res.Pos, functionsLookup));
            }

            // Return the final list of tokens
            return expressionList;
        }

         
       
        
        private static int Priority(string? x, string[] separatingStrings, FunctionsLookup functionsLookup)
        {
            switch (x)
            {
                case "(":
                    return 0;
                case "&&" or "||":
                    return 2;
                case "=" or "!=" or "==" or ">=" or "<=" or ">" or "<":
                    return 3;
                case "+" or "-":
                    return 4;
                case "*" or "/" or "%":
                    return 5;
                case "!":
                    return 6;
                default:
                    {
                        if (separatingStrings.Contains(x)) return 1;
                        if (x is not null && TokensUtils.IsFunction(x, functionsLookup))
                        {
                            return 7;
                        }

                        break;
                    }
            }
            return 8;
        }

    }


}


