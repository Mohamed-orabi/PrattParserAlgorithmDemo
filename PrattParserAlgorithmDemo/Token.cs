namespace PrattParserAlgorithmDemo
{
    enum TokenType
    {
        Number,
        Plus,
        Minus,
        Multiply,
        Divide,
        LeftParen,
        RightParen,
        EndOfInput
    }
    class Token
    {
        public TokenType Type { get; }
        public string Value { get; }

        public Token(TokenType type, string value = "")
        {
            Type = type;
            Value = value;
        }
    }
}
