namespace NeonBlue.Expressions.Aggregates.Aggergators
{
    public class CountAggregator : AggregatorBase
    {
        int accumelated = 0;
        public override void Update(object? val)
        {
            base.Update(val);
            accumelated += 1;
        }
        public override object? Return()
        {
            return accumelated;
        }
        public override void Reset()
        {
            accumelated = 0;
        }
    }
}


