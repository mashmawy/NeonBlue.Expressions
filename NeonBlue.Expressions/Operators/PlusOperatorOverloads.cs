using NeonBlue.Expressions.Operators.ByteValue;
using NeonBlue.Expressions.Operators.DeicmalValue;
using NeonBlue.Expressions.Operators.DoubleValue;
using NeonBlue.Expressions.Operators.FloatValue;
using NeonBlue.Expressions.Operators.IntegerValue;
using NeonBlue.Expressions.Operators.LongValue;
using NeonBlue.Expressions.Operators.NullValue;
using NeonBlue.Expressions.Operators.StringValue;

namespace NeonBlue.Expressions.Operators
{

    /// <summary>
    /// Represents the operator overloads for addition operations.
    /// </summary>
    public class PlusOperatorOverloads : IOperator
    {
        /// <summary>
        /// Gets the operator type.
        /// </summary>
        public TokenType OperatorType { get; } = TokenType.Plus;

        /// <summary>
        /// A dictionary of operator overloads for different data types.
        /// </summary>
        private readonly Dictionary<TokenType, OperatorsOverload> typesOverloads = [];

        /// <summary>
        /// Initializes a new instance of the PlusOperatorOverloads class.
        /// </summary>
        public PlusOperatorOverloads()
        {
            AddIntegerAdditionOverloads();
            AddByteAdditionOverloads();
            AddLongAdditionOverloads();
            AddDecimalAdditionOverloads();
            AddFloatAdditionOverloads();
            AddDoubleAdditionOverloads();
            AddStringAdditionOverloads();
            AddNullAdditionOverloads();
        }

        /// <summary>
        /// Adds operator overloads for integer values.
        /// </summary>
        private void AddIntegerAdditionOverloads()
        {
            IntegerValuePlusOperatorOverloads overloads = new();
            typesOverloads.Add(TokenType.Integer, overloads);
        }

        /// <summary>
        /// Adds operator overloads for byte values.
        /// </summary>
        private void AddByteAdditionOverloads()
        {
            ByteValuePlusOperatorOverloads overloads = new();
            typesOverloads.Add(TokenType.Byte, overloads);
        }

        /// <summary>
        /// Adds operator overloads for long values.
        /// </summary>
        private void AddLongAdditionOverloads()
        {
            LongValuePlusOperatorOverloads overloads = new();
            typesOverloads.Add(TokenType.Long, overloads);
        }

        /// <summary>
        /// Adds operator overloads for decimal values.
        /// </summary>
        private void AddDecimalAdditionOverloads()
        {
            DecimalValuePlusOperatorOverloads overloads = new();
            typesOverloads.Add(TokenType.Decimal, overloads);
        }

        /// <summary>
        /// Adds operator overloads for float values.
        /// </summary>
        private void AddFloatAdditionOverloads()
        {
            FloatValuePlusOperatorOverloads overloads = new();
            typesOverloads.Add(TokenType.Float, overloads);
        }

        /// <summary>
        /// Adds operator overloads for double values.
        /// </summary>
        private void AddDoubleAdditionOverloads()
        {
            DoubleValuePlusOperatorOverloads overloads = new();
            typesOverloads.Add(TokenType.Double, overloads);
        }

        /// <summary>
        /// Adds operator overloads for string values (concatenation).
        /// </summary>
        private void AddStringAdditionOverloads()
        {
            StringValuePlusOperatorOverloads overloads = new();
            typesOverloads.Add(TokenType.String, overloads);
        }

        /// <summary>
        /// Adds operator overloads for null values.
        /// </summary>
        private void AddNullAdditionOverloads()
        {
            NullValueMathOperatorsOverloads overloads = new();
            typesOverloads.Add(TokenType.NULL, overloads);
        }

        /// <summary>
        /// Executes the addition operation based on the operand types.
        /// </summary>
        /// <param name="operand1">The first operand.</param>
        /// <param name="operand2">The second operand.</param>
        /// <param name="executionOptions">The execution options.</param>
        /// <returns>The result of the addition operation.</returns>
        public Token Run(Token operand1, Token operand2, IExecutionOptions executionOptions)
        {
            if (typesOverloads.TryGetValue(operand1.TokenType, out OperatorsOverload? overloads))
            {
                return overloads.Evaluate(operand1, operand2, executionOptions);
            }

            throw new InvalidOperationException();
        }
    }
}