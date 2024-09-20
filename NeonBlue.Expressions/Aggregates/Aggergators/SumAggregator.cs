namespace NeonBlue.Expressions.Aggregates.Aggergators
{
    /// <summary>
    /// Aggregates the sum of numerical values.
    /// </summary>
    public class SumAggregator : AggregatorBase
    {
        /// <summary>
        /// Stores the accumulated sum of values.
        /// </summary>
        private object? accumulated;

        /// <summary>
        /// Updates the accumulated sum by adding the input value.
        /// </summary>
        /// <param name="val">The value to be added to the sum.</param>
        public override void Update(object? val)
        {
            base.Update(val);

            if (accumulated == null)
            {
                accumulated = val;
                return;
            }

            if (val is int intVal)
            {
                accumulated = (int)accumulated + intVal;
            }
            else if (val is float floatVal)
            {
                accumulated = (float)accumulated + floatVal;
            }
            else if (val is decimal decimalVal)
            {
                accumulated = Convert.ToDecimal(accumulated) + decimalVal;
            }
            else if (val is double doubleVal)
            {
                accumulated = (double)accumulated + doubleVal;
            }
            else if (val is long longVal)
            {
                accumulated = (long)accumulated + longVal;
            }
            else if (val is byte byteVal)
            {
                accumulated = (int)accumulated + byteVal;
            }
            else if (val is not null)
            {
                throw new InvalidArgumentTypeException("Sum", val.GetType(), $"Invalid Argument type {val.GetType().Name} for aggregate function Sum");
            }
        }

        /// <summary>
        /// Returns the accumulated sum.
        /// </summary>
        /// <returns>The accumulated sum.</returns>
        public override object? Return()
        {
            return accumulated ?? 0;
        }

        /// <summary>
        /// Resets the accumulated sum to 0.
        /// </summary>
        public override void Reset()
        {
            accumulated = 0;
        }
    }
}


