using NeonBlue.Expressions;

namespace NeonBlue.Expressions.Aggregates.Aggergators
{
    public class AvgAggregator : AggregatorBase
    {
        object? accumelated;
        int count = 0;

        public override void Update(object? val)
        {
            base.Update(val);
            count++;
            if (val is null)
            {
                return;
            }
            else
            if (val.GetType() == typeof(int))
            {

                accumelated = Convert.ToInt32(accumelated) + (int)val;
            }
            else
            if (val.GetType() == typeof(float))
            {

                accumelated = Convert.ToSingle(accumelated) + (float)val;
            }
            else
            if (val.GetType() == typeof(decimal))
            {

                accumelated = Convert.ToDecimal(accumelated) + (decimal)val;
            }
            else
            if (val.GetType() == typeof(double))
            {

                accumelated = Convert.ToDouble(accumelated) + (double)val;
            }
            else
            if (val.GetType() == typeof(long))
            {

                accumelated = Convert.ToInt64(accumelated) + (long)val;
            }
            else
            if (val.GetType() == typeof(byte))
            {

                accumelated = Convert.ToInt32(accumelated) + (byte)val;
            }
            else
            {
                throw new InvalidArgumentTypeExeception("Avg", val.GetType(), $"Invalid Argument type {val.GetType().Name} for aggregate function Avg");
            }
        }
        public override object? Return()
        {
            return Convert.ToDouble(accumelated) / count;

        }
        public override void Reset()
        {
            accumelated = 0;
        }
    }
}


