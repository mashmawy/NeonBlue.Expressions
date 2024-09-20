namespace NeonBlue.Expressions.Aggregates.Aggergators
{
    public class MeanAggregator : AggregatorBase
    {
        private int count;
        private double mean;

        public override void Update(object? val)
        {
            base.Update(val);
            if (val is null) return;

            if (val is not double &&
                (val is not int) &&
                (val is not byte) &&
                (val is not long) &&
                (val is not float) &&
                (val is not decimal))
            {
                throw new InvalidArgumentTypeException
                       ("Mean", val.GetType(), $"Invalid Argument type {val.GetType().Name} for aggregate function Mean");

            }
            var new_value = Convert.ToDouble(val); count++;
            double delta = new_value - mean;
            mean += delta / count;

        }
        public override object? Return()
        {

            if (count < 2)
            {
                return double.NaN;
            }

            return mean;

        }
        public override void Reset()
        {
            count = 0;
            mean = 0;

        }
    }



}


