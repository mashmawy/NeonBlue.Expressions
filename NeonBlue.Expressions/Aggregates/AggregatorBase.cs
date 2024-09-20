namespace NeonBlue.Expressions.Aggregates
{
    /// <summary>
    /// Base class for aggregators that perform calculations on a set of values.
    /// </summary>
    public abstract class AggregatorBase : IAggregator
    {
        /// <summary>
        /// Gets the data type of the values being aggregated.
        /// </summary>
        public Type? ValueType { get; private set; }

        /// <summary>
        /// Updates the internal state of the aggregator with a new value.
        /// </summary>
        /// <param name="val">The value to be added to the aggregation.</param>
        /// <exception cref="AggregateFunctionException">Thrown if the data type of the value changes during aggregation.</exception>
        public virtual void Update(object? val)
        {
            if (val is not null)
            {
                if (ValueType is null)
                {
                    ValueType = val.GetType();
                }
                else if (ValueType != val.GetType())
                {
                    throw new AggregateFunctionException($"value data type changed from {ValueType.Name} to {val.GetType().Name}");
                }
            }
        }

        /// <summary>
        /// Returns the aggregated result.
        /// </summary>
        /// <returns>The aggregated result.</returns>
        public abstract object? Return();

        /// <summary>
        /// Resets the internal state of the aggregator to its initial values.
        /// </summary>
        public abstract void Reset();
    }
}


