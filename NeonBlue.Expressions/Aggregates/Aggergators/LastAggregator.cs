namespace NeonBlue.Expressions.Aggregates.Aggergators
{
    /// <summary>
    /// Returns the last non-null value encountered.
    /// </summary>
    public class LastAggregator : AggregatorBase
    {
        /// <summary>
        /// Stores the last non-null value encountered.
        /// </summary>
        private object? accumulated;

        /// <summary>
        /// Assigns the value to accumulated if it's not null.
        /// </summary>
        /// <param name="val">The value to be considered.</param>
        public override void Update(object? val)
        {
            base.Update(val);
            if (val is not null)
            {
                accumulated = val;
            }
        }

        /// <summary>
        /// Returns the last non-null value encountered.
        /// </summary>
        /// <returns>The last non-null value.</returns>
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


