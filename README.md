# Pratt Paser Algorithm Steps
- Here’s how the algorithm works step by step:

1. Tokenization:
   - The input string is converted into a list of tokens (e.g., numbers, operators, parentheses).
   - Example: The input 1 + 2 * 3 is tokenized into [Number(1), Plus, Number(2), Multiply, Number(3)].

2. Parsing:

   - The parser reads tokens one by one.
   - For each token, it decides whether to parse it as a prefix (nud) or infix (led) operator based on its binding power.

3. Binding Power:
   - Each operator has a binding power (precedence). For example:
      - (+ and -) have low binding power (e.g., 1).
      - (* and /) have higher binding power (e.g., 2).
   - The parser uses the binding power to decide how to group expressions.

4. Recursive Parsing:
   - The parser recursively parses subexpressions based on the binding power of the tokens.
   - If the current token has higher binding power than the previous one, it groups the subexpression first.

5. Nud and Led Functions:
   - Nud: Handles tokens that appear at the beginning of an expression (e.g., numbers, unary operators).
   - Led: Handles tokens that appear in the middle of an expression (e.g., binary operators).

