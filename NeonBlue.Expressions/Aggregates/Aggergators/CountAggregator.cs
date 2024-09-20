namespace NeonBlue.Expressions.Aggregates.Aggergators
{
    /// <summary>
    /// Aggregates the count of values.
    /// </summary>
    public class CountAggregator : AggregatorBase
    {
        /// <summary>
        /// Stores the accumulated count of values.
        /// </summary>
        private int accumulated = 0;

        /// <summary>
        /// Increments the accumulated count for each non-null value.
        /// </summary>
        /// <param name="val">The value to be counted.</param>
        public override void Update(object? val)
        {
            base.Update(val);
            if (val != null)
            {
                accumulated++;
            }
        }

        /// <summary>
        /// Returns the accumulated count of values.
        /// </summary>
        /// <returns>The accumulated count.</returns>
        public override object? Return()
        {
            return accumulated;
        }

        /// <summary>
        /// Resets the accumulated count to 0.
        /// </summary>
        public override void Reset()
        {
            accumulated = 0;
        }
    }
}


