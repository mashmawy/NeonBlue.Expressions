namespace NeonBlue.Expressions.Aggregates.Aggergators
{
    /// <summary>
    /// Aggregates the maximum value.
    /// </summary>
    public class MaxAggregator : AggregatorBase
    {
        /// <summary>
        /// Stores the current maximum value.
        /// </summary>
        private object? accumulated;

        /// <summary>
        /// Updates the accumulated value with the maximum of the current value and the input value.
        /// </summary>
        /// <param name="val">The value to be compared.</param>
        public override void Update(object? val)
        {
            base.Update(val);

            if (val == null)
            {
                return;
            }

            if (accumulated is null)
            {
                accumulated = val;
            }
            else if (val is int intVal)
            {
                accumulated = Math.Max((int)accumulated, intVal);
            }
            else if (val is float floatVal)
            {
                accumulated = Math.Max((float)accumulated, floatVal);
            }
            else if (val is decimal decimalVal)
            {
                accumulated = Math.Max(Convert.ToDecimal(accumulated), decimalVal);
            }
            else if (val is double doubleVal)
            {
                accumulated = Math.Max((double)accumulated, doubleVal);
            }
            else if (val is long longVal)
            {
                accumulated = Math.Max((long)accumulated, longVal);
            }
            else if (val is byte byteVal)
            {
                accumulated = Math.Max((int)accumulated, byteVal);
            }
            else if (val is string)
            {
                accumulated = val;
            }
            else if (val is bool)
            {
                accumulated = val;
            }
            else if (val is DateTime)
            {
                accumulated = Convert.ToDateTime(accumulated) < Convert.ToDateTime(val) ? val : accumulated;
            }
            else
            {
                throw new InvalidArgumentTypeException("Max", val.GetType(), $"Invalid Argument type {val.GetType().Name} for aggregate function Max");
            }
        }

        /// <summary>
        /// Returns the maximum value.
        /// </summary>
        /// <returns>The maximum value.</returns>
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


