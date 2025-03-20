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

---
# Walkthrough with an Example

Let’s walk through the algorithm step by step for the expression 1 + 2 * 3.

Step 1: Tokenization

The input 1 + 2 * 3 is tokenized into:
```
[Number(1), Plus, Number(2), Multiply, Number(3)]
```
Step 2: Initial Setup
 - The parser starts at the first token: Number(1).
 - The current precedence is 0 (lowest).

Step 3: Parse the First Token (Nud)
 - The first token is Number(1), which is handled by the nud function.
 - The nud function returns the value 1.

Step 4: Parse the Next Token (Led)
 - The next token is Plus.
 - The parser checks the binding power of Plus (which is 1).
 - Since 1 (current precedence) < 1 (binding power of Plus), the parser proceeds.
- The led function for Plus is called with the left operand 1.

Step 5: Recursive Parsing
- The led function for Plus calls ParseExpression with the binding power of Plus (1).
- Inside ParseExpression, the next token is Number(2).
- The nud function for Number(2) returns 2.

Step 6: Parse the Next Token (Led)
 - The next token is Multiply.
 - The parser checks the binding power of Multiply (which is 2).
 - Since 1 (current precedence) < 2 (binding power of Multiply), the parser proceeds.
 - The led function for Multiply is called with the left operand 2.

Step 7: Recursive Parsing
 - The led function for Multiply calls ParseExpression with the binding power of Multiply (2).
 - Inside ParseExpression, the next token is Number(3).
 - The nud function for Number(3) returns 3.

Step 8: Combine Results
 - The led function for Multiply combines 2 and 3 to compute 2 * 3 = 6.
 - The led function for Plus combines 1 and 6 to compute 1 + 6 = 7.

Final Result:
   The parsed result is 7.

---

# Pseudocode for the Algorithm

```
function ParseExpression(precedence):
    token = Consume()
    left = Nud(token)  // Handle prefix operators or numbers

    while precedence < GetPrecedence(Peek()):
        token = Consume()
        left = Led(token, left)  // Handle infix operators

    return left

function Nud(token):
    if token is a number:
        return token.value
    if token is a unary operator (e.g., '-'):
        return -ParseExpression(precedence of unary operator)
    if token is '(':
        result = ParseExpression(0)
        Expect(')')
        return result
    else:
        throw error

function Led(token, left):
    if token is a binary operator (e.g., '+', '-', '*', '/'):
        right = ParseExpression(precedence of token)
        return left + right  // Or perform the appropriate operation
    else:
        throw error
```


