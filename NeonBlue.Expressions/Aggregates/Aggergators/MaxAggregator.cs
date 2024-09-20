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
            }
            else if (val is int intVal)
            { 
                accumelated = Math.Max((int)accumelated, intVal);
            }
            else if (val is float floatVal)
            { 
                accumelated = Math.Max((float)accumelated, floatVal);
            }
            else if (val is decimal decimalVal)
            {

                accumelated = Math.Max(Convert.ToDecimal(accumelated), decimalVal);
            }
            else if (val is double doubleVal)
            {

                accumelated = Math.Max((double)accumelated, doubleVal);
            }
            else if (val is long longVal)
            { 
                accumelated = Math.Max((long)accumelated, longVal);
            }
            else if (val is byte byteVal)
            {

                accumelated = Math.Max((int)accumelated, byteVal);
            }
            else if (val is string)
            {
                accumelated = val;
            }
            else if (val is bool)
            {
                accumelated = val; 
            }
            else if (val is DateTime)
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


