namespace NeonBlue.Expressions.Aggregates.Aggergators
{
    /// <summary>
    /// Aggregates the count of distinct values.
    /// </summary>
    public class CountDistinctAggregator : AggregatorBase
    {
        /// <summary>
        /// Stores unique values encountered.
        /// </summary>
        private readonly HashSet<object?> HashSet = new();

        /// <summary>
        /// Stores the accumulated count of distinct values.
        /// </summary>
        private int accumulated = 0;

        /// <summary>
        /// Adds the value to the HashSet if it's not already present and increments the count.
        /// </summary>
        /// <param name="val">The value to be added.</param>
        public override void Update(object? val)
        {
            base.Update(val);
            if (val != null && HashSet.Add(val))
            {
                accumulated++;
            }
        } 
        /// <summary>
        /// Returns the accumulated count of distinct values.
        /// </summary>
        /// <returns>The accumulated count.</returns>
        public override object? Return()
        {
            return accumulated;
        } 
        /// <summary>
        /// Resets the HashSet and the accumulated count.
        /// </summary>
        public override void Reset()
        {
            HashSet.Clear();
            accumulated = 0;
        }
    }
}


