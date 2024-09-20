namespace NeonBlue.Expressions.Aggregates.Aggergators
{
    /// <summary>
    /// Aggregates the minimum value.
    /// </summary>
    public class MinAggregator : AggregatorBase
    {
        /// <summary>
        /// Stores the current minimum value.
        /// </summary>
        private object? accumulated;

        /// <summary>
        /// Updates the accumulated value with the minimum of the current value and the input value.
        /// </summary>
        /// <param name="val">The value to be compared.</param>
        public override void Update(object? val)
        {
            base.Update(val);

            if (accumulated is null)
            {
                accumulated = val;
                return;
            }

            if (val is null)
            {
                return;
            }

            if (val is int intVal)
            {
                accumulated = Math.Min((int)accumulated, intVal);
            }
            else if (val is float floatVal)
            {
                accumulated = Math.Min((float)accumulated, floatVal);
            }
            else if (val is decimal decimalVal)
            {
                accumulated = Math.Min(Convert.ToDecimal(accumulated), decimalVal);
            }
            else if (val is double doubleVal)
            {
                accumulated = Math.Min((double)accumulated, doubleVal);
            }
            else if (val is long longVal)
            {
                accumulated = Math.Min((long)accumulated, longVal);
            }
            else if (val is byte byteVal)
            {
                accumulated = Math.Min((int)accumulated, byteVal);
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
                accumulated = Convert.ToDateTime(accumulated) > Convert.ToDateTime(val) ? val : accumulated;
            }
            else
            {
                throw new InvalidArgumentTypeException("Min", val.GetType(), $"Invalid Argument type {val.GetType().Name} for aggregate function Min");
            }
        } 
        /// <summary>
        /// Returns the minimum value.
        /// </summary>
        /// <returns>The minimum value.</returns>
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


