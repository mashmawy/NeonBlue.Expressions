namespace NeonBlue.Expressions.Aggregates.Aggergators
{
    /// <summary>
    /// Returns the first non-null value encountered.
    /// </summary>
    public class FirstAggregator : AggregatorBase
    {
        /// <summary>
        /// Stores the first non-null value encountered.
        /// </summary>
        private object? accumulated;

        /// <summary>
        /// Assigns the value to accumulated if it's the first non-null value.
        /// </summary>
        /// <param name="val">The value to be considered.</param>
        public override void Update(object? val)
        {
            base.Update(val);
            accumulated ??= val;
        }

        /// <summary>
        /// Returns the first non-null value encountered.
        /// </summary>
        /// <returns>The first non-null value.</returns>
        public override object? Return()
        {
            return accumulated;
        }

        /// <summary>
        /// Resets the accumulated value to null.
        /// </summary>
        public override void Reset()
        {
            accumulated = null;
        }
    }
}


