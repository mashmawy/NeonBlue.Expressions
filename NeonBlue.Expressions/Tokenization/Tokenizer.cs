using System.Text;

namespace NeonBlue.Expressions
{
    /// <summary>
    /// A tokenizer that breaks down an expression into a list of tokens.
    /// </summary>
    public class Tokenizer
    {
        /// <summary>
        /// The input expression to be tokenized.
        /// </summary>
        private readonly string _expression;

        /// <summary>
        /// The current position within the input expression.
        /// </summary>
        private int _currentPosition = 0;

        private FunctionsLookup? _functionsLookup;
        /// <summary>
        /// The list of tokens generated during the tokenization process.
        /// </summary>
        private readonly List<IntermediateToken> _tokens = [];

        /// <summary>
        /// Initializes a new instance of the <see cref="Tokenizer"/> class.
        /// </summary>
        /// <param name="expression">The input expression to be tokenized.</param>
        public Tokenizer(string expression)
        {
            ArgumentNullException.ThrowIfNull(expression);
            _expression = expression;

        }

        /// <summary>
        /// Tokenizes the input expression into a list of <see cref="IntermediateToken"/> objects.
        /// </summary>
        /// <param name="functionsLookup">The function lookup used in current context.</param>
        /// <returns>A list of tokens representing the input expression.</returns>
        public List<IntermediateToken> Tokenize(FunctionsLookup functionsLookup)
        {
            _functionsLookup = functionsLookup;
            while (_currentPosition < _expression.Length)
            {
                var currentChar = _expression[_currentPosition];
                if (char.IsWhiteSpace(currentChar))
                {
                    // Skip whitespace
                    _currentPosition++;
                }
                else if (char.IsNumber(currentChar) || currentChar == '.')
                {
                    var token = ReadNumber();
                    _tokens.Add(token);
                }
                else if (char.IsLetter(currentChar))
                {
                    var token = ReadVariable();
                    _tokens.Add(token);
                }
                else if (currentChar == '\'')
                {
                    var token = ReadString();
                    _tokens.Add(token);
                }
                else if (IsCompositOperator(currentChar))
                {
                    var startPos = _currentPosition;
                    // Handle comparison operators
                    var compositOperatorToken = currentChar.ToString();

                    _currentPosition++;
                    currentChar = _expression[_currentPosition];
                    if (IsCompositOperator(currentChar))
                    {
                        // Handle comparison operators
                        compositOperatorToken += currentChar.ToString();
                        _currentPosition++;
                    }

                    _tokens.Add(new IntermediateToken(IntermediateTokenType.Operator, compositOperatorToken, startPos));
                }
                else
                {
                    if (currentChar == '-')
                    {
                        var previousToken = _tokens.LastOrDefault();
                        if (previousToken is null || (!previousToken.IsNumber() && previousToken.Value != ")"))
                        {
                            _tokens.Add(new IntermediateToken(IntermediateTokenType.Double, "0", -1));
                        } 
                    }
                    // Single-character operators or delimiters 
                    var tokenType = IntermediateTokenType.Operator;
                    _tokens.Add(new IntermediateToken(tokenType, currentChar.ToString(), _currentPosition));
                    _currentPosition++;
                }
            }
            return _tokens;
        }

        private IntermediateToken ReadNumber()
        {
            var startPos = _currentPosition;
            var numberBuilder = new StringBuilder();
            bool hasDecimal = false;

            while (_currentPosition < _expression.Length)
            {
                var currentChar = _expression[_currentPosition];
                if (char.IsNumber(currentChar))
                {
                    numberBuilder.Append(currentChar);
                }
                else if (currentChar == '.' && !hasDecimal)
                {
                    numberBuilder.Append(currentChar);
                    hasDecimal = true;
                }
                else
                {
                    break;
                }

                _currentPosition++;
            }

            return new IntermediateToken(hasDecimal ? IntermediateTokenType.Double : IntermediateTokenType.Integer,
                numberBuilder.ToString(), startPos);
        }

        private static bool IsCompositOperator(char ch)
        {
            return ch == '&' || ch == '|' || ch == '=' || ch == '!' || ch == '>' || ch == '<';
        }

        private IntermediateToken ReadVariable()
        {
            var startPos = _currentPosition;
            var variableBuilder = new StringBuilder();

            while (_currentPosition < _expression.Length)
            {
                var currentChar = _expression[_currentPosition];
                if (char.IsLetterOrDigit(currentChar) || currentChar == '_')
                {
                    variableBuilder.Append(currentChar);
                }
                else
                {
                    break;
                }

                _currentPosition++;
            }
            var word = variableBuilder.ToString();
            if (TokensUtils.IsFunction(word, _functionsLookup!))
            {
                return new IntermediateToken(IntermediateTokenType.Function, variableBuilder.ToString(), startPos);
            }
            else
            {
                return new IntermediateToken(IntermediateTokenType.Variable, variableBuilder.ToString(), startPos);

            }
        }

        private IntermediateToken ReadString()
        {
            var startPos = _currentPosition;
            _currentPosition++; // Skip the opening quote

            var stringBuilder = new StringBuilder();
            while (_currentPosition < _expression.Length)
            {
                var currentChar = _expression[_currentPosition];
                if (currentChar == '\'')
                {
                    break;
                }
                else
                {
                    stringBuilder.Append(currentChar);
                }

                _currentPosition++;
            }

            if (_currentPosition < _expression.Length && _expression[_currentPosition] == '\'')
            {
                _currentPosition++; // Skip the closing quote
            }
            else
            {
                // Throw an error or handle missing closing quote
                throw new ArgumentException("Unterminated string literal");
            }

            return new IntermediateToken(IntermediateTokenType.String, stringBuilder.ToString(), startPos);
        }
    }
}