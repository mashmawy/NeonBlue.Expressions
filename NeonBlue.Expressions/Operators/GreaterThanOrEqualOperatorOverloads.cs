using NeonBlue.Expressions.Operators.ByteValue;
using NeonBlue.Expressions.Operators.DatetimeValue;
using NeonBlue.Expressions.Operators.DeicmalValue;
using NeonBlue.Expressions.Operators.DoubleValue;
using NeonBlue.Expressions.Operators.FloatValue;
using NeonBlue.Expressions.Operators.IntegerValue;
using NeonBlue.Expressions.Operators.LongValue;
using NeonBlue.Expressions.Operators.NullValue;

namespace NeonBlue.Expressions.Operators
{
    /// <summary>
    /// Represents the operator overloads for greater than or equal to comparisons.
    /// </summary>
    public class GreaterThanOrEqualOperatorOverloads : IOperator
    {
        /// <summary>
        /// Gets the operator type.
        /// </summary>
        public TokenType OperatorType { get; } = TokenType.GreaterThanOrEqual;

        /// <summary>
        /// A dictionary of operator overloads for different data types.
        /// </summary>
        private readonly Dictionary<TokenType, OperatorsOverload> typesOverloads = new();

        /// <summary>
        /// Initializes a new instance of the GreaterThanOrEqualOperatorOverloads class.
        /// </summary>
        public GreaterThanOrEqualOperatorOverloads()
        {
            AddIntegerOps();
            AddByteOps();
            AddLongOps();
            AddDecimalOps();
            AddFloatOps();
            AddDoubleOps();
            AddDateTimeOps();
            AddNullOps();
        }

        /// <summary>
        /// Adds operator overloads for integer values.
        /// </summary>
        private void AddIntegerOps()
        {
            IntegerValueGreaterThanOrEqualOperatorOverloads overloads = new();
            typesOverloads.Add(TokenType.Integer, overloads);
        }

        /// <summary>
        /// Adds operator overloads for byte values.
        /// </summary>
        private void AddByteOps()
        {
            ByteValueGreaterThanOrEqualOperatorOverloads overloads = new();
            typesOverloads.Add(TokenType.Byte, overloads);
        }

        /// <summary>
        /// Adds operator overloads for long values.
        /// </summary>
        private void AddLongOps()
        {
            LongValueGreaterThanOrEqualOperatorOverloads overloads = new();
            typesOverloads.Add(TokenType.Long, overloads);
        }

        /// <summary>
        /// Adds operator overloads for decimal values.
        /// </summary>
        private void AddDecimalOps()
        {
            DecimalValueGreaterThanOrEqualOperatorOverloads overloads = new();
            typesOverloads.Add(TokenType.Decimal, overloads);
        }

        /// <summary>
        /// Adds operator overloads for float values.
        /// </summary>
        private void AddFloatOps()
        {
            FloatValueGreaterThanOrEqualOperatorOverloads overloads = new();
            typesOverloads.Add(TokenType.Float, overloads);
        }

        /// <summary>
        /// Adds operator overloads for double values.
        /// </summary>
        private void AddDoubleOps()
        {
            DoubleValueGreaterThanOrEqualOperatorOverloads overloads = new();
            typesOverloads.Add(TokenType.Double, overloads);
        }

        /// <summary>
        /// Adds operator overloads for datetime values.
        /// </summary>
        private void AddDateTimeOps()
        {
            DatetimeValueGreaterThanOrEqualOperatorOverloads overloads = new();
            typesOverloads.Add(TokenType.Datetime, overloads);
        }

        /// <summary>
        /// Adds operator overloads for null values.
        /// </summary>
        private void AddNullOps()
        {
            NullValueCompareOperatorsOverloads overloads = new();
            typesOverloads.Add(TokenType.NULL, overloads);
        }

        /// <summary>
        /// Executes the greater than or equal to operation based on the operand types.
        /// </summary>
        /// <param name="operand1">The first operand.</param>
        /// <param name="operand2">The second operand.</param>
        /// <param name="executionOptions">The execution options.</param>
        /// <returns>The result of the greater than or equal to operation.</returns>
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