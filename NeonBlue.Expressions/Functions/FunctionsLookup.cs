using NeonBlue.Expressions.Functions;
using NeonBlue.Expressions.Functions.BooleanFunctions;
using NeonBlue.Expressions.Functions.CastingFunctions;
using NeonBlue.Expressions.Functions.DateFunctions;
using NeonBlue.Expressions.Functions.MathFunctions;
using NeonBlue.Expressions.Functions.StringFunctions;

namespace NeonBlue.Expressions
{
    public class FunctionsLookup
    {
        private readonly List<IStackUpdateFunction> functions = [];

        private readonly Dictionary<string, Action<Stack<Token>, IExecutionOptions>> Implementation = [];

        public FunctionsLookup()
        {
            functions.AddRange(
                [
                    new IsnullFunction(),
                    new NotFunction(),
                    new IifFunction(),
                    new AndFunction(),
                    new OrFunction(),
                    new AbsFunction(),
                    new AcosFunction(),
                    new AcoshFunction(),
                    new CStringFunction(),
                    new AsinFunction(),
                    new AsinhFunction(),
                    new AtanFunction(),
                    new CByteFunction(),
                    new CDateTimeFunction(),
                    new CBoolFunction(),
                    new CLongFunction(),
                    new CDecimalFunction(),
                    new CIntFunction(),
                    new CFloatFunction(),
                    new CDoubleFunction(),
                    new MinutesDiffFunction(),
                    new HourDiffFunction(),
                    new DayDiffFunction(),
                    new AddMinutesFunction(),
                    new AddHoursFunction(),
                    new CbrtFunction(),
                    new CeilingFunction(),
                    new ClampFunction(),
                    new CosFunction(),
                    new CoshFunction(),
                    new ExpFunction(),
                    new FloorFunction(),
                    new LogFunction(),
                    new Log10Function(),
                    new Log2Function(),
                    new SinFunction(),
                    new SinhFunction(),
                    new SqrtFunction(),
                    new TanFunction(),
                    new TanhFunction(),
                    new TruncateFunction(),
                    new PowFunction(),
                    new RoundFunction(),
                    new SubstringFunction(),
                    new LeftFunction(),
                    new RightFunction(),
                    new UpperFunction(),
                    new LowerFunction(),
                    new CapFunction(),
                    new ContainFunction(),
                    new StartWithFunction(),
                    new EndWithFunction(),
                    new ReplaceFunction(),
                    new ConcatFunction(),
                    new TrimFunction(),
                    new LTrimFunction(),
                    new RTrimFunction(),
                    new PadLeftFunction(),
                    new PadRightFunction(),
                    new YearFunction(),
                    new MonthFunction(),
                    new DayFunction(),
                    new HourFunction(),
                    new MinutesFunction(),
                    new SecondsFunction(),
                    new QuarterFunction(),
                    new MonthNameFunction(),
                    new QuarterNameFunction(),
                    new DayNameFunction(),
                    new AddDaysFunction(),
                    new AddMonthsFunction(),
                    new AtanhFunction(),
                    new AddYearsFunction(),
                ]);
            foreach (var func in functions)
            {
                Implementation.Add(func.FunctionName, func.Update);
            }
        }
        /// <summary>
        /// Executes the specified function on the given stack with the provided execution options.
        /// </summary>
        /// <param name="function">The name of the function to execute.</param>
        /// <param name="stack">The stack of tokens.</param>
        /// <param name="executionOptions">The execution options.</param>
        public void Exec(string function, Stack<Token> stack, IExecutionOptions executionOptions)
        {
            Implementation[function](stack, executionOptions);
        }

        /// <summary>
        /// Adds a custom function delegate to the registry.
        /// </summary>
        /// <param name="functionName">The name of the custom function.</param>
        /// <param name="customFunctionDelegate">The delegate representing the custom function.</param>
        internal void AddCustomFunctionDelegate(string functionName, Delegate customFunctionDelegate)
        {
            var func = new CustomStackUpdateFunction(functionName, customFunctionDelegate);
            functions.Add(func);
            Implementation.Add(func.FunctionName, func.Update);
        }

        /// <summary>
        /// Checks if the specified function name is registered.
        /// </summary>
        /// <param name="functionName">The name of the function to check.</param>
        /// <returns>True if the function is registered, false otherwise.</returns> 
        public bool IsFunction(string functionName)
        {
            return Implementation.ContainsKey(functionName);
        }
    }


}