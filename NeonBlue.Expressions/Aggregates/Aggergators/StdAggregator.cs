namespace NeonBlue.Expressions.Aggregates.Aggergators
{

    public class StdAggregator : AggregatorBase
    {
        private int count;
        private double mean;
        private double M2;

        public override void Update(object? val)
        {

            base.Update(val);
            if (val is null) return;

            if ((val is not double) &&
            (val is not int) &&
            (val is not byte) &&
            (val is not long) &&
            (val is not float) &&
            (val is not decimal))
            {
                throw new InvalidArgumentTypeException
                       ("Std", val.GetType(), $"Invalid Argument type {val.GetType().Name} for aggregate function Std");

            }
            double new_value = Convert.ToDouble(val);

            count++;
            double delta = new_value - mean;
            mean += delta / count;
            double delta2 = new_value - mean;
            M2 += delta * delta2;

        }
        public override object? Return()
        {

            if (count < 2)
            {
                return double.NaN;
            }

            double variance = M2 / count;
            return Math.Sqrt(variance);

        }
        public override void Reset()
        {
            count = 0;
            mean = 0;
            M2 = 0;

        }
    }

}


