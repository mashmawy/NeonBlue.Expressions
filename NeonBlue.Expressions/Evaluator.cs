using NeonBlue.Expressions;
using NeonBlue.Expressions.Functions;
using NeonBlue.Expressions.Operators;

namespace NeonBlue.Expressions
{
    public class Evaluator
    {
        readonly Stack<Token> evaluationStack = new();
        private readonly IExecutionOptions _executionOptions;
        private readonly Dictionary<string, List<Token>> compiledCache = [];

        private readonly IExpressionContext _context = new ExpressionContext();
        private readonly FunctionsLookup _functionsLookup = new();
        /// <summary>
        /// Initializes a new instance of the Evaluator class, providing the necessary context and execution options for evaluating expressions.
        /// </summary>
        /// <param name="context">An IExpressionContext object that represents the context in which expressions will be evaluated.</param>
        /// <param name="executionOptions">An IExecutionOptions object that specifies the execution options for expression evaluation.</param>
        /// <exception cref="NeonBlueExpressionException">Thrown if an error occurs during the creation of the Evaluator object. The inner exception provides more details about the specific error.</exception>
        public Evaluator(IExpressionContext context, IExecutionOptions executionOptions)
        {
            try
            {
                ArgumentNullException.ThrowIfNull(context, nameof(context));
                ArgumentNullException.ThrowIfNull(executionOptions, nameof(executionOptions));
                _executionOptions = executionOptions;
                _context = context;
            }
            catch (Exception ex)
            {
                throw new NeonBlueExpressionException("Error creating Evaluator object, see inner exception for more details", ex);
            }
        }
        /// <summary>
        /// Initializes a new instance of the Evaluator class, providing the necessary context and execution options for evaluating expressions.
        /// </summary>
        /// <param name="executionOptions">An IExecutionOptions object that specifies the execution options for expression evaluation.</param>
        /// <exception cref="NeonBlueExpressionException">Thrown if an error occurs during the creation of the Evaluator object. The inner exception provides more details about the specific error.</exception>
        public Evaluator(IExecutionOptions executionOptions)
        {
            try
            {
                ArgumentNullException.ThrowIfNull(executionOptions, nameof(executionOptions));
                _executionOptions = executionOptions;
            }
            catch (Exception ex)
            {
                throw new NeonBlueExpressionException("Error creating Evaluator object, see inner exception for more details", ex);
            }
        }
        /// <summary>
        /// Sets the value of a variable in the underlying expression context.
        /// </summary>
        /// <param name="name">A string representing the name of the variable to set.</param>
        /// <param name="value">An object representing the new value to assign to the variable.</param>
        private void SetVariable(string name, object? value)
        {
            _context.SetVariable(name, value);
        }


        /// <summary>
        /// Evaluates the given expression using a cached compilation approach. If the expression has been evaluated before, the cached result is used. Otherwise, the expression is parsed and compiled, and the result is cached for future use.
        /// </summary>
        /// <param name="expression">A string representing the expression to be evaluated.</param>
        /// <returns>An object? representing the result of the evaluation. The return type can be any data type supported by the expression language.</returns>
        /// <exception cref="NeonBlueExpressionException">Thrown if an error occurs during the evaluation process. The inner exception provides more details about the specific error.</exception>
        private object? Evaluate(string expression)
        {
            if (compiledCache.TryGetValue(expression, out List<Token>? value))
            {
                return Evaluate(value);
            }
            else
            {
                var exp = ExpressionAnalyzer.Parse(expression, _context, _functionsLookup);
                compiledCache.Add(expression, exp);
                return Evaluate(exp);
            }
        }

        /// <summary>
        /// Evaluates the provided Expression object using the supplied ExpressionParameters object as the data source.
        /// </summary>
        /// <param name="neonBlueExpression">An Expression object representing the formula to be evaluated.</param>
        /// <param name="dataSource">An ExpressionParameters object providing the data for variable substitution during evaluation.</param>
        /// <returns>An object? representing the result of the evaluation. The return type can be any data type supported by the expression language.</returns>
        /// <exception cref="NeonBlueExpressionException">Thrown if an error occurs during the evaluation process. The inner exception provides more details about the specific error.</exception>
        public object? Evaluate(Expression neonBlueExpression, ExpressionParameters dataSource)
        {
            try
            {
                neonBlueExpression.Init(_functionsLookup);
                foreach (var item in dataSource.GetParameters().Where(p => !p.IsArray))
                {
                    _context.SetVariable(item.Name, dataSource.GetValue(item.Name));
                }
                if (neonBlueExpression.IsAggregate)
                {
                    for (int i = 0; i < dataSource.MaxLength; i++)
                    {
                        var updated = dataSource.MoveNext();
                        var varNames = updated.Keys;
                        var parts = neonBlueExpression
                        .aggregateException!.Parts.Where(p => varNames.Intersect(p.Variables).Any());

                        foreach (var v in updated)
                        {
                            _context.SetVariable(v.Key, v.Value);
                        }
                        foreach (var var in parts)
                        {
                            var evalagg = Evaluate(var.Expression);
                            var.GetAggregator("x")?.Update(evalagg);
                        }

                    }
                }
                dataSource.Reset();
                return AggregateAndEvaluate(neonBlueExpression); ;
            }
            catch (Exception ex)
            {
                throw new NeonBlueExpressionException("Error evaluating the expression, please see the inner exception for details", ex);
            }
        }

        /// <summary>
        /// Evaluates the provided Expression object, converts the result to the specified type T, and returns it.
        /// </summary> 
        /// <param name="neonBlueExpression">An Expression object representing the formula to be evaluated.</param>
        /// <param name="dataSource">An ExpressionParameters object providing the data for variable substitution during evaluation.</param>
        /// <returns>A generic T? representing the result of the evaluation, converted to the specified type. The return type can be any data type supported by your expression language.</returns>
        /// <exception cref="NeonBlueExpressionException">Thrown if an error occurs during the evaluation process. The inner exception provides more details about the specific error.</exception>
        public T? Evaluate<T>(Expression neonBlueExpression, ExpressionParameters dataSource)
        {
            return ConvertTo<T>(Evaluate(neonBlueExpression, dataSource));
        }

        private static T? ConvertTo<T>(object? value)
        {
            T? returnValue;
            if (value is T)
            {
                returnValue = (T?)value;
            }
            else
            {
                try
                {
                    returnValue = (T?)Convert.ChangeType(value, typeof(T));
                }
                catch (InvalidCastException)
                {
                    returnValue = default;
                }
            }
            return returnValue;
        }

        private object? AggregateAndEvaluate(Expression neonBlueExpression)
        {
            foreach (var e in neonBlueExpression.aggregateException!.Parts)
            {
                var Aggergator = e.GetAggregator("x");
                if (Aggergator != null)
                    _context.SetVariable(e.Id, Aggergator.Return());
            }
            return Evaluate(neonBlueExpression.finalFormula);

        }
        private object? Evaluate(List<Token> expressionList)
        {
            foreach (var word in expressionList)
            {
                if (word.ToString() == ",")
                {
                    continue;
                }
                Scan(word, evaluationStack, _context, _executionOptions);
            }
            evaluationStack.TryPop(out Token? res2);
            return res2?.Value;
        }
        private void Scan(Token item, Stack<Token> evaluationStack, IExpressionContext table, IExecutionOptions executionOptions)
        {
            if (item is { IsFunction: false, IsSpecial: false })
            {
                if (item.IsVariable)
                {
                    if (item.Value is null)
                    {
                        throw new NullTokenExecption(item);
                    }
                    else
                    {
                        evaluationStack.Push(new Token(table.GetVariableValue(item.Value.ToString()!), table.GetVariableType(item.Value.ToString()!)));
                    }
                }
                else
                {
                    evaluationStack.Push(item);
                }
            }
            else
            {
                if (item.TokenType == TokenType.Function)
                {
                    if (item.Value is null)
                    {
                        throw new NullTokenExecption(item);
                    }
                    else
                    {
                        _functionsLookup.Exec(item.Value.ToString()!, evaluationStack, executionOptions);
                    }

                }
                else
                {
                    OperatorsManager.Exec(item.TokenType, evaluationStack, executionOptions);
                }
            }
        }

        public void AddCustomFunction(string functionName, Delegate customFunctionDelegate)
        {
            _functionsLookup.AddCustomFunctionDelegate(functionName, customFunctionDelegate);
        }
    }
}