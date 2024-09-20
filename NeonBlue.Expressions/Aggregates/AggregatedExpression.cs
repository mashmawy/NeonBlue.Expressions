namespace NeonBlue.Expressions.Aggregates
{
    /// <summary>
    /// Represents an aggregated expression composed of multiple parts.
    /// </summary>
    public class AggregatedExpression
    {
        /// <summary>
        /// Gets a list of parts that make up the aggregated expression.
        /// </summary>
        public List<AggregatedExpressionPart> Parts { get; } = [];

        /// <summary>
        /// Gets the final expression string.
        /// </summary>
        public string FinalExpression { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="AggregatedExpression"/> class.
        /// </summary>
        /// <param name="final">The final expression string.</param>
        /// <param name="parts">The parts of the aggregated expression.</param>
        public AggregatedExpression(string final, IEnumerable<AggregatedExpressionPart> parts)
        {
            Parts.AddRange(parts);
            FinalExpression = final;
        }
    }
}


