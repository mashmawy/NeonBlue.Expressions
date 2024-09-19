namespace NeonBlue.Expressions
{
    public enum TokenType
    {
        Plus,
        Minuse,
        Divide,
        Multiply,
        Percentage,

        LogicalAnd,
        LogicalOr,
        LogicalNot,

        Equal,
        NotEqual,
        LessThan,
        GreaterThan,
        GreaterThanOrEqual,
        LessThanOrEqual,

        Function,

        String,
        Byte,
        Integer,
        Long,
        Boolean,
        Datetime,
        Double,
        Float,
        Decimal,

        NULL
    }
}