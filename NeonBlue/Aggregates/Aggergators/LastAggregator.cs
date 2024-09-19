namespace NeonBlue.Expressions.Aggregates.Aggergators
{
    public class LastAggregator : AggregatorBase
    {
        object? accumelated ;

        public override void Update(object? val)
        { 
            base.Update(val);
            if (val is not null)
                accumelated = val;
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


