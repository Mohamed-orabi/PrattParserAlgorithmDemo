namespace PrattParserAlgorithmDemo
{
    class PrattParser
    {
        private readonly List<Token> _tokens;
        private int _position;

        public PrattParser(List<Token> tokens)
        {
            _tokens = tokens;
            _position = 0;
        }

        public double Parse()
        {
            return ParseExpression(0);
        }

        private double ParseExpression(int precedence)
        {
            Token token = Consume();
            double left = ParseNud(token);

            while (precedence < GetPrecedence(Peek().Type))
            {
                token = Consume();
                left = ParseLed(token, left);
            }

            return left;
        }

        private double ParseNud(Token token)
        {
            switch (token.Type)
            {
                case TokenType.Number:
                    return double.Parse(token.Value);
                case TokenType.LeftParen:
                    double value = ParseExpression(0);
                    Expect(TokenType.RightParen);
                    return value;
                case TokenType.Minus:
                    return -ParseExpression(GetPrecedence(TokenType.Minus));
                default:
                    throw new Exception($"Unexpected token: {token.Type}");
            }
        }

        private double ParseLed(Token token, double left)
        {
            switch (token.Type)
            {
                case TokenType.Plus:
                    return left + ParseExpression(GetPrecedence(TokenType.Plus));
                case TokenType.Minus:
                    return left - ParseExpression(GetPrecedence(TokenType.Minus));
                case TokenType.Multiply:
                    return left * ParseExpression(GetPrecedence(TokenType.Multiply));
                case TokenType.Divide:
                    return left / ParseExpression(GetPrecedence(TokenType.Divide));
                default:
                    throw new Exception($"Unexpected token: {token.Type}");
            }
        }

        private int GetPrecedence(TokenType type)
        {
            return type switch
            {
                TokenType.Plus or TokenType.Minus => 1,
                TokenType.Multiply or TokenType.Divide => 2,
                _ => 0
            };
        }

        private Token Consume()
        {
            return _tokens[_position++];
        }

        private Token Peek()
        {
            return _tokens[_position];
        }

        private void Expect(TokenType type)
        {
            if (Peek().Type != type)
            {
                throw new Exception($"Expected token: {type}, but found {Peek().Type}");
            }
            Consume();
        }
    }
}
