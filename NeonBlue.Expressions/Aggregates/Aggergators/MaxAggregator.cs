namespace NeonBlue.Expressions.Aggregates.Aggergators
{
    public class MaxAggregator : AggregatorBase
    {
        object? accumelated;

        public override void Update(object? val)
        {
            base.Update(val);
            if (val == null) return;
            if (accumelated is null)
            {
                accumelated = val;
                return;
            }

            if (val is null)
            {
                return;
            }

            if (val.GetType() == typeof(int))
            {

                accumelated = Math.Max((int)accumelated, (int)val);
            }
            else
            if (val.GetType() == typeof(float))
            {

                accumelated = Math.Max((float)accumelated, (float)val);
            }
            else
            if (val.GetType() == typeof(decimal))
            {

                accumelated = Math.Max(Convert.ToDecimal(accumelated), (decimal)val);
            }
            else
            if (val.GetType() == typeof(double))
            {

                accumelated = Math.Max((double)accumelated, (double)val);
            }
            else
            if (val.GetType() == typeof(long))
            {

                accumelated = Math.Max((long)accumelated, (long)val);
            }
            else
            if (val.GetType() == typeof(byte))
            {

                accumelated = Math.Max((int)accumelated, (byte)val);
            }
            else
            if (val.GetType() == typeof(string))
            {
                if (accumelated is null)
                {
                    accumelated = val;
                    return;
                }
            }
            else
            if (val.GetType() == typeof(bool))
            {
                if (accumelated is null)
                {
                    accumelated = val;
                    return;
                }
            }
            else
            if (val.GetType() == typeof(DateTime))
            {
                accumelated = Convert.ToDateTime(accumelated) < Convert.ToDateTime(val) ? val : accumelated;
            }
            else
            {
                throw new InvalidArgumentTypeException("Max", val.GetType(), $"Invalid Argument type {val.GetType().Name} for aggregate function Max");
            }
        }
        public override object? Return()
        {
            return accumelated;
        }
        public override void Reset()
        {
            accumelated = null;
        }
    }
}


