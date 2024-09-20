namespace NeonBlue.Expressions.Aggregates
{
    /// <summary>
    /// Defines the interface for aggregators that perform calculations on a set of values.
    /// </summary>
    public interface IAggregator
    {
        /// <summary>
        /// Updates the internal state of the aggregator with a new value.
        /// </summary>
        /// <param name="val">The value to be added to the aggregation.</param>
        void Update(object? val);

        /// <summary>
        /// Returns the aggregated result.
        /// </summary>
        /// <returns>The aggregated result.</returns>
        object? Return();

        /// <summary>
        /// Resets the internal state of the aggregator to its initial values.
        /// </summary>
        void Reset();
    }
}


