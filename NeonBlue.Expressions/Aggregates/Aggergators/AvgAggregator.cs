namespace NeonBlue.Expressions.Aggregates.Aggergators
{
    /// <summary>
    /// Aggregator for calculating the average of numerical values.
    /// </summary>
    public class AvgAggregator : AggregatorBase
    {
        // Stores the running sum of the values.
        private object? accumulated;

        // Keeps track of the number of values processed.
        private int count = 0;

        /// <summary>
        /// Updates the accumulated sum and increments the count.
        /// </summary>
        /// <param name="val">The value to be added to the average.</param> 
        public override void Update(object? val)
        {
            base.Update(val);
            count++;

            if (val is null)
            {
                return;
            }

            // Handle different numerical types using type guards and conversions.
            if (val is int intVal)
            {
                accumulated = Convert.ToInt32(accumulated) + intVal;
            }
            else if (val is float floatVal)
            {
                accumulated = Convert.ToSingle(accumulated) + floatVal;
            }
            else if (val is decimal decimalVal)
            {
                accumulated = Convert.ToDecimal(accumulated) + decimalVal;
            }
            else if (val is double doubleVal)
            {
                accumulated = Convert.ToDouble(accumulated) + doubleVal;
            }
            else if (val is long longVal)
            {
                accumulated = Convert.ToInt64(accumulated) + longVal;
            }
            else if (val is byte byteVal)
            {
                accumulated = Convert.ToInt32(accumulated) + byteVal;
            }
            else
            {
                // Throw an exception for invalid argument types.
                throw new InvalidArgumentTypeException("Avg", val.GetType(), $"Invalid Argument type {val.GetType().Name} for aggregate function Avg");
            }
        }

        /// <summary>
        /// Calculates the average and returns it as a double.
        /// </summary>
        /// <returns>The calculated average.</returns>
        public override object? Return()
        {
            // Calculate the average and return it as a double.
            return Convert.ToDouble(accumulated) / count;
        }

        /// <summary>
        /// Resets the accumulated sum to 0.
        /// </summary>
        public override void Reset()
        {
            // Reset the accumulated sum to 0.
            accumulated = 0;
        }
    }
}


