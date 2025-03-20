namespace PrattParserAlgorithmDemo
{
    class Tokenizer
    {
        private readonly string _input;
        private int _position;

        public Tokenizer(string input)
        {
            _input = input;
            _position = 0;
        }

        public List<Token> Tokenize()
        {
            var tokens = new List<Token>();

            while (_position < _input.Length)
            {
                char current = _input[_position];

                if (char.IsWhiteSpace(current))
                {
                    _position++;
                }
                else if (char.IsDigit(current))
                {
                    tokens.Add(ReadNumber());
                }
                else
                {
                    switch (current)
                    {
                        case '+': tokens.Add(new Token(TokenType.Plus)); break;
                        case '-': tokens.Add(new Token(TokenType.Minus)); break;
                        case '*': tokens.Add(new Token(TokenType.Multiply)); break;
                        case '/': tokens.Add(new Token(TokenType.Divide)); break;
                        case '(': tokens.Add(new Token(TokenType.LeftParen)); break;
                        case ')': tokens.Add(new Token(TokenType.RightParen)); break;
                        default: throw new Exception($"Unexpected character: {current}");
                    }
                    _position++;
                }
            }

            tokens.Add(new Token(TokenType.EndOfInput));
            return tokens;
        }

        private Token ReadNumber()
        {
            int start = _position;
            while (_position < _input.Length && char.IsDigit(_input[_position]))
            {
                _position++;
            }
            return new Token(TokenType.Number, _input.Substring(start, _position - start));
        }
    }
}
