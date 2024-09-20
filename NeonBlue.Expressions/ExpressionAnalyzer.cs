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

        public static AggregatedExpression GetAggregatedExpressions(string expression, FunctionsLookup functionsLookup)
        {
            Tokenizer tokenizer = new(expression);
            var tokens = tokenizer.Tokenize(functionsLookup);
            bool inFuntion = false;
            int opened = 0;
            Dictionary<string, string> results = [];
            List<AggregatedExpressionPart> expressions = [];
            StringBuilder inFunctionExpression = new();
            List<string> variables = [];
            string currentFunction = string.Empty;
            StringBuilder updatedExpression = new();
            foreach (var token in tokens)
            {

                if (token.Value is not null && AggregatedExpressionPart.IsAggregate(token.Value.Trim()))
                {
                    currentFunction = token.Value.Trim();
                    inFuntion = true;
                    continue;
                }
                if (token.Value is not null && token.Value.Trim() == "(" && inFuntion)
                {
                    opened++;
                    if (opened == 1)
                    {
                        continue;
                    }
                }
                if (token.Value is not null && token.Value.Trim() == ")" && inFuntion)
                {
                    opened--;
                    if (opened == 0)
                    {
                        var id = "V" + Guid.NewGuid().ToString().Replace("-", "");
                        var currentString = inFunctionExpression.ToString();
                        results.Add(id, currentString);
                        expressions.Add(new AggregatedExpressionPart(currentString, id, currentFunction, variables));
                        expression = expression.Replace(currentString, id);
                        inFunctionExpression.Clear();
                        updatedExpression.Append(id);
                        variables.Clear();
                        inFuntion = false;
                        continue;
                    }
                }
                if (inFuntion)
                {
                    inFunctionExpression.Append(token.Value);
                }
                else
                {
                    updatedExpression.Append(token.Value);
                }
                if (token.Value is not null && token.TokenType == IntermediateTokenType.Variable)
                    variables.Add(token.Value.Trim());
            }

            if (opened > 0)
            {
                throw new UnclosedParenthesesException();
            }
            return new AggregatedExpression(updatedExpression.ToString(), expressions);
        }
        internal static List<Token> Parse(string expression, IExpressionContext table, FunctionsLookup functionsLookup)
        {
            Tokenizer tokenizer = new(expression);
            var intermediaTokens = tokenizer.Tokenize(functionsLookup);

            Stack<IntermediateToken> expressionStack = new();

            List<Token> expressionList = [];

            foreach (var token in intermediaTokens)
            {

                if (token.TokenType == IntermediateTokenType.String)
                {
                    var varToken = new Token(token.Value, TokenType.String, token.Pos, true);
                    expressionList.Add(varToken);
                    continue;
                }
                if (token.Value is not null && table.HasVariable(token.Value))
                {
                    var varToken = new Token(token.Value, table.GetVariableType(token.Value), token.Pos, false, true);
                    expressionList.Add(varToken);
                    continue;
                }

                if (!specialTokens.Contains(token.Value) && !(token.Value is not null && TokensUtils.IsFunction(token.Value, functionsLookup)))
                {
                    var numericalToken = new Token(token.Value, token.Pos);
                    if (!OperatorHelper.IsNumerical(numericalToken.TokenType))
                    {
                        throw new SyntaxErrorException($"Unknown token at '{token.Value}' at position {token.Pos}");

                    }
                    expressionList.Add(numericalToken);
                }
                else if (token.Value == "(")
                {
                    expressionStack.Push(token);
                }
                else if (token.Value == ")")
                {

                    while (expressionStack.TryPop(out IntermediateToken? res) && res.Value != "(")
                    {
                        expressionList.Add(new Token(res.Value, res.Pos, functionsLookup));
                    }
                }
                else
                {
                    while (expressionStack.Count > 0 &&
                        Priority(expressionStack.Peek().Value, specialTokens, functionsLookup) >= Priority(token.Value, specialTokens, functionsLookup))
                    {
                        var res = expressionStack.Pop();
                        expressionList.Add(new Token(res.Value, res.Pos, functionsLookup));
                    }
                    if (token.Value != ",")
                    {
                        expressionStack
                        .Push(token);
                    }
                }
            }
            while (expressionStack.TryPop(out IntermediateToken? res))
            {
                expressionList.Add(new Token(res.Value, res.Pos, functionsLookup));
            }

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


