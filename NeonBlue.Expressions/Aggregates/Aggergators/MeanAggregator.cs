namespace NeonBlue.Expressions.Aggregates.Aggergators
{
    /// <summary>
    /// Aggregates the mean (average) of numerical values.
    /// </summary>
    public class MeanAggregator : AggregatorBase
    {
        /// <summary>
        /// Stores the number of values processed.
        /// </summary>
        private int count;

        /// <summary>
        /// Stores the calculated mean.
        /// </summary>
        private double mean;

        /// <summary>
        /// Updates the mean using the online mean algorithm.
        /// </summary>
        /// <param name="val">The value to be added to the mean.</param>
        public override void Update(object? val)
        {
            base.Update(val);

            if (val is null)
            {
                return;
            }

            if (val is not double &&
                (val is not int) &&
                (val is not byte) &&
                (val is not long) &&
                (val is not float) &&
                (val is not decimal))
            {
                throw new InvalidArgumentTypeException("Mean", val.GetType(), $"Invalid Argument type {val.GetType().Name} for aggregate function Mean");
            }

            var newValue = Convert.ToDouble(val);
            count++;
            double delta = newValue - mean;
            mean += delta / count;
        }

        /// <summary>
        /// Returns the calculated mean.
        /// </summary>
        /// <returns>The calculated mean, or double.NaN if there are fewer than two values.</returns>
        public override object? Return()
        {
            if (count < 2)
            {
                return double.NaN;
            }

            return mean;
        }

        /// <summary>
        /// Resets the count and mean to their initial values.
        /// </summary>
        public override void Reset()
        {
            count = 0;
            mean = 0;
        }
    }



}


