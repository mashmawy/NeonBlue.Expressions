﻿namespace NeonBlue.Expressions.Aggregates.Aggergators
{
    /// <summary>
    /// Aggregates the standard deviation of numerical values.
    /// </summary>
    public class StdAggregator : AggregatorBase
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
        /// Stores the second moment of the data.
        /// </summary>
        private double M2;

        /// <summary>
        /// Updates the mean and M2 using the online algorithm for calculating standard deviation.
        /// </summary>
        /// <param name="val">The value to be added to the standard deviation calculation.</param>
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
                throw new InvalidArgumentTypeException("Std", val.GetType(), $"Invalid Argument type {val.GetType().Name} for aggregate function Std");
            }

            double newValue = Convert.ToDouble(val);
            count++;
            double delta = newValue - mean;
            mean += delta / count;
            double delta2 = newValue - mean;
            M2 += delta * delta2;
        }

        /// <summary>
        /// Returns the calculated standard deviation.
        /// </summary>
        /// <returns>The calculated standard deviation, or double.NaN if there are fewer than two values.</returns>
        public override object? Return()
        {
            if (count < 2)
            {
                return double.NaN;
            }

            double variance = M2 / count;
            return Math.Sqrt(variance);
        }

        /// <summary>
        /// Resets the count, mean, and M2 to their initial values.
        /// </summary>
        public override void Reset()
        {
            count = 0;
            mean = 0;
            M2 = 0;
        }
    }
}


