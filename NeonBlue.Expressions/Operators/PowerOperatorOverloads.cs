using NeonBlue.Expressions.Functions.MathFunctions;
using NeonBlue.Expressions.Operators.ByteValue;
using NeonBlue.Expressions.Operators.DeicmalValue;
using NeonBlue.Expressions.Operators.DoubleValue;
using NeonBlue.Expressions.Operators.FloatValue;
using NeonBlue.Expressions.Operators.IntegerValue;
using NeonBlue.Expressions.Operators.LongValue;
using NeonBlue.Expressions.Operators.NullValue;

namespace NeonBlue.Expressions.Operators
{
    /// <summary>
    /// Represents the operator overloads for power operations.
    /// </summary>
    public class PowerOperatorOverloads : IOperator
    {
        /// <summary>
        /// Gets the operator type.
        /// </summary>
        public TokenType OperatorType { get; } = TokenType.Power;

        /// <summary>
        /// A dictionary of operator overloads for different data types.
        /// </summary>
        private readonly Dictionary<TokenType, OperatorsOverload> typesOverloads = [];

        /// <summary>
        /// Initializes a new instance of the PowerOperatorOverloads class.
        /// </summary>
        public PowerOperatorOverloads()
        {
            AddIntegerOps();
            AddByteOps();
            AddLongOps();
            AddDecimalOps();
            AddFloatOps();
            AddDoubleOps();
            AddNullOps();
        }

        /// <summary>
        /// Adds operator overloads for integer values.
        /// </summary>
        private void AddIntegerOps()
        {
            IntegerValuePowerOperatorOverloads overloads = new();
            typesOverloads.Add(TokenType.Integer, overloads);
        }

        /// <summary>
        /// Adds operator overloads for byte values.
        /// </summary>
        private void AddByteOps()
        {
            ByteValuePowerOperatorOverloads overloads = new();
            typesOverloads.Add(TokenType.Byte, overloads);
        }

        /// <summary>
        /// Adds operator overloads for long values.
        /// </summary>
        private void AddLongOps()
        {
            LongValuePowerOperatorOverloads overloads = new();
            typesOverloads.Add(TokenType.Long, overloads);
        }

        /// <summary>
        /// Adds operator overloads for decimal values.
        /// </summary>
        private void AddDecimalOps()
        {
            DecimalValuePowerOperatorOverloads overloads = new();
            typesOverloads.Add(TokenType.Decimal, overloads);
        }

        /// <summary>
        /// Adds operator overloads for float values.
        /// </summary>
        private void AddFloatOps()
        {
            FloatValuePowerOperatorOverloads overloads = new();
            typesOverloads.Add(TokenType.Float, overloads);
        }

        /// <summary>
        /// Adds operator overloads for double values.
        /// </summary>
        private void AddDoubleOps()
        {
            DoubleValuePowerOperatorOverloads overloads = new();
            typesOverloads.Add(TokenType.Double, overloads);
        }

        /// <summary>
        /// Adds operator overloads for null values.
        /// </summary>
        private void AddNullOps()
        {
            NullValueMathOperatorsOverloads overloads = new();
            typesOverloads.Add(TokenType.NULL, overloads);
        }

        /// <summary>
        /// Executes the power operation based on the operand types and the null strategy.
        /// </summary>
        /// <param name="operand1">The first operand.</param>
        /// <param name="operand2">The second operand.</param>
        /// <param name="executionOptions">The execution options.</param>
        /// <returns>The result of the power operation.</returns>
        public Token Run(Token operand1, Token operand2, IExecutionOptions executionOptions)
        {
            if (typesOverloads.TryGetValue(operand1.TokenType, out OperatorsOverload? overloads))
            {
                if (operand1.Value is null || operand2.Value is null)
                {
                    // Handle null operands according to the null strategy
                    return MathFunctionUtils.NullCheck(operand2, executionOptions.NullStrategy);
                } 

                // Delegate the operation to the appropriate overload
                return overloads.Evaluate(operand1, operand2, executionOptions);
            }

            // If no overload is found, throw an exception
            throw new InvalidOperationException();
        }
    }
}