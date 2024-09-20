using NeonBlue.Expressions.Aggregates.Aggergators;

namespace NeonBlue.Expressions.Aggregates
{
    /// <summary>
    /// Represents a part of an aggregated expression.
    /// </summary>
    public class AggregatedExpressionPart
    {
        /// <summary>
        /// Gets a list of variables used in the expression.
        /// </summary>
        public readonly List<string> Variables = [];

        /// <summary>
        /// Gets or sets the expression string.
        /// </summary>
        public string Expression { get; set; }

        /// <summary>
        /// Gets or sets a unique identifier for the part.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the aggregation type.
        /// </summary>
        public string AggregateType { get; set; }

        /// <summary>
        /// Stores aggregators keyed by their variable names.
        /// </summary>
        private Dictionary<string, IAggregator?> Aggregators { get; set; } = new();

        /// <summary>
        /// Gets an aggregator for the specified variable.
        /// </summary>
        /// <param name="key">The variable name.</param>
        /// <returns>The aggregator for the variable, or null if not found.</returns>
        public IAggregator? GetAggregator(string key)
        {
            if (Aggregators.TryGetValue(key, out IAggregator? val))
            {
                return val;
            }

            val = CreateAggregator(AggregateType);
            Aggregators.Add(key, val);

            return val;
        }

        /// <summary>
        /// Creates an aggregator instance based on the specified aggregation type.
        /// </summary>
        /// <param name="aggregateType">The aggregation type.</param>
        /// <returns>The created aggregator, or null if the aggregation type is invalid.</returns>
        public static IAggregator? CreateAggregator(string aggregateType)
        {
            return aggregateType switch
            {
                "sum" => new SumAggregator(),
                "count" => new CountAggregator(),
                "countd" => new CountDistinctAggregator(),
                "max" => new MaxAggregator(),
                "min" => new MinAggregator(),
                "first" => new FirstAggregator(),
                "last" => new LastAggregator(),
                "avg" => new AvgAggregator(),
                "var" => new VarAggregator(),
                "std" => new StdAggregator(),
                "mean" => new MeanAggregator(),
                _ => null
            };
        }

        /// <summary>
        /// Checks if the specified aggregation type is valid.
        /// </summary>
        /// <param name="aggregateType">The aggregation type.</param>
        /// <returns>True if the aggregation type is valid, false otherwise.</returns>
        public static bool IsAggregate(string aggregateType)
        {
            return aggregateType switch
            {
                "sum" => true,
                "count" => true,
                "countd" => true,
                "max" => true,
                "min" => true,
                "first" => true,
                "last" => true,
                "avg" => true,
                "var" => true,
                "std" => true,
                "mean" => true,
                _ => false
            };
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AggregatedExpressionPart"/> class.
        /// </summary>
        /// <param name="expression">The expression string.</param>
        /// <param name="id">A unique identifier for the part.</param>
        /// <param name="aggregateType">The aggregation type.</param>
        /// <param name="variables">The variables used in the expression.</param>
        public AggregatedExpressionPart(string expression, string id, string aggregateType, IEnumerable<string> variables)
        {
            Expression = expression;
            Id = id;
            AggregateType = aggregateType;
            Variables.AddRange(variables);
        }
    }
}


