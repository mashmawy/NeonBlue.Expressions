namespace NeonBlue.Expressions.Tokenization
{
    /// <summary>
    /// Represents the possible types of tokens in an intermediate representation.
    /// </summary>
    public enum IntermediateTokenType
    {
        /// <summary>
        /// An integer token.
        /// </summary>
        Integer,

        /// <summary>
        /// A double (floating-point) token.
        /// </summary>
        Double,

        /// <summary>
        /// A variable token.
        /// </summary>
        Variable,

        /// <summary>
        /// A function token.
        /// </summary>
        Function,

        /// <summary>
        /// An operator token.
        /// </summary>
        Operator,

        /// <summary>
        /// A string token.
        /// </summary>
        String,
    }
}