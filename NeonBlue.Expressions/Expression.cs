using NeonBlue.Expressions.Aggregates; 

namespace NeonBlue.Expressions
{
    /// <summary>
    /// Initializes a new instance of the Expression class, representing a formula to be evaluated. This constructor performs basic syntax analysis and stores the formula's structure.
    /// </summary>
    /// <param name="formula">A string containing the formula to be evaluated.</param>
    /// <exception cref="NeonBlueExpressionException">Thrown if an error occurs during the analysis of the formula. The inner exception provides more details about the specific error.</exception>
    public class Expression(string formula)
    {
        public bool IsAggregate { get; private set; }
        public string Formula { get; private set; } = formula;
        internal string finalFormula="";
        internal AggregatedExpression? aggregateException;

        internal void Init(FunctionsLookup functionsLookup)
        {
            try
            {
                ArgumentNullException.ThrowIfNull(Formula);
                aggregateException = ExpressionAnalyzer.GetAggregatedExpressions(Formula, functionsLookup);

                this.finalFormula = aggregateException.FinalExpression;
                IsAggregate = aggregateException.Parts.Count != 0;
            }
            catch (Exception ex)
            {
                throw new NeonBlueExpressionException("Error creating Expression object, see inner exception for more details", ex);
            }
        }

        public static implicit operator Expression(string str)
        {
            return new Expression(str);
        }
    }


}
