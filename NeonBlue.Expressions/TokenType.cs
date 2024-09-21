namespace NeonBlue.Expressions
{
    /// <summary>
    /// Represents different token types used in expression evaluation.
    /// </summary>
    public enum TokenType
    {
        /// <summary>
        /// Addition operator (+).
        /// </summary>
        Plus,

        /// <summary>
        /// Subtraction operator (-).
        /// </summary>
        Minus,

        /// <summary>
        /// Division operator (/).
        /// </summary>
        Divide,

        /// <summary>
        /// Multiplication operator (*).
        /// </summary>
        Multiply,

        /// <summary>
        /// Modulus operator (%).
        /// </summary>
        Percentage,

        /// <summary>
        /// Logical AND operator (&&).
        /// </summary>
        LogicalAnd,

        /// <summary>
        /// Logical OR operator (||).
        /// </summary>
        LogicalOr,

        /// <summary>
        /// Logical NOT operator (!).
        /// </summary>
        LogicalNot,

        /// <summary>
        /// Equality operator (==).
        /// </summary>
        Equal,

        /// <summary>
        /// Inequality operator (!=).
        /// </summary>
        NotEqual,

        /// <summary>
        /// Less than operator (<).
        /// </summary>
        LessThan,

        /// <summary>
        /// Greater than operator (>).
        /// </summary>
        GreaterThan,


        /// <summary>
        /// Greater than or equal to operator (>=).
        /// </summary>
        GreaterThanOrEqual,

        /// <summary>
        /// Less than or equal to operator (<=).
        /// </summary>
        LessThanOrEqual,

        /// <summary>
        /// Function call.
        /// </summary>
        Function,

        /// <summary>
        /// String data type.
        /// </summary>
        String,

        /// <summary>
        /// Byte data type.
        /// </summary>
        Byte,

        /// <summary>
        /// Integer data type.
        /// </summary>
        Integer,

        /// <summary>
        /// Long data type.
        /// </summary>
        Long,

        /// <summary>
        /// Boolean data type.
        /// </summary>
        Boolean,

        /// <summary>
        /// Datetime data type.
        /// </summary>
        Datetime,

        /// <summary>
        /// Double data type.
        /// </summary>
        Double,

        /// <summary>
        /// Float data type.
        /// </summary>
        Float,

        /// <summary>
        /// Decimal data type.
        /// </summary>
        Decimal,

        /// <summary>
        /// Null value.
        /// </summary>
        NULL
    }
}