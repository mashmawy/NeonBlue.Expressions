namespace NeonBlue.Expressions.Aggregates
{
    public class AggregatedExpression
    {
        public List<AggregatedExpressionPart> Parts {get;}=[];
        public string FinalExpression{get;}
        public AggregatedExpression(string final, IEnumerable<AggregatedExpressionPart> parts)
        {
            Parts.AddRange(parts);
            FinalExpression = final;
        }
    } 
}


