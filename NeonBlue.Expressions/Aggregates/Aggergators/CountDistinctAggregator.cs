namespace NeonBlue.Expressions.Aggregates.Aggergators
{
    public class CountDistinctAggregator : AggregatorBase
    {
        readonly HashSet<object?> HashSet = [];
        int accumelated = 0;

        public override void Update(object? val)
        {
            base.Update(val);
            if (val == null) return;
            if (HashSet.Add(val))
            {
                accumelated += 1;
            }
        }
        public override object? Return()
        {
            return accumelated;
        }
        public override void Reset()
        {
            HashSet.Clear();
            accumelated = 0;
        }
    }
}


