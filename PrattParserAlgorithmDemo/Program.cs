namespace PrattParserAlgorithmDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = "1 * 2 + 5";
            var tokenizer = new Tokenizer(input);
            var tokens = tokenizer.Tokenize();

            var parser = new PrattParser(tokens);
            double result = parser.Parse();

            Console.WriteLine($"Result: {result}");
        }
    }
}
