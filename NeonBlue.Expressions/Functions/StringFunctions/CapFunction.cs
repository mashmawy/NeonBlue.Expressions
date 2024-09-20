namespace NeonBlue.Expressions.Functions.StringFunctions
{
    /// <summary>
    /// Represents the Cap function for capitalizing the first character of a string.
    /// </summary>
    public class CapFunction : StackUpdateFunction
    {
        /// <summary>
        /// Gets the name of the function.
        /// </summary>
        public override string FunctionName => "cap";

        /// <summary>
        /// Updates the stack by capitalizing the first character of the top string value.
        /// </summary>
        /// <param name="tokensStack">The stack of tokens.</param>
        /// <param name="executionOptions">The execution options.</param>
        /// <exception cref="EmptyStackException">Thrown if the stack is empty.</exception>
        /// <exception cref="InvalidArgumentTypeException">Thrown if the token is not a string type.</exception>
        /// <exception cref="StringException">Thrown if the capitalization operation fails.</exception>
        public override void Update(Stack<Token> tokensStack, IExecutionOptions executionOptions)
        {
            if (tokensStack is null || tokensStack.Count < 1)
            {
                throw new EmptyStackException();
            }
            var token = tokensStack.Pop();

            if (StringFunctionsHelper.NullCheck(tokensStack, token, executionOptions)) return;
            try
            {

                var arg1 = token.Value!.ToString();
                tokensStack.Push(new Token(FirstCharToUpper(arg1!.ToLower())));
            }
            catch (Exception ex)
            {
                throw new StringException(FunctionName, $"String operation {FunctionName} can't be executed, see inner exception for more details", ex);
            }

        }
        /// <summary>
        /// Capitalizes the first character of a string.
        /// </summary>
        /// <param name="input">The input string.</param>
        /// <returns>The capitalized string.</returns>
        /// <exception cref="ArgumentNullException">Thrown if the input string is null.</exception>
        /// <exception cref="ArgumentException">Thrown if the input string is empty.</exception>
        static string FirstCharToUpper(string input) =>
                     input switch
                     {
                         null => throw new ArgumentNullException(nameof(input)),
                         "" => throw new ArgumentException($"{nameof(input)} cannot be empty", nameof(input)),
                         _ => string.Concat(input[0].ToString().ToUpper(), input.AsSpan(1))
                     };
    }
}