using System;
using System.Collections.Generic;

namespace Lab2
{
    public class Program
    {
        static void Main(string[] args)
        {

            //IsBalanced("{ int a = new int[ ] ( ( ) ) }");

            Console.WriteLine(Evaluate("10 2 8 * + 3 -"));

        }



        public static bool IsBalanced(string s)
        {
            Stack<char> stack = new Stack<char>();

            foreach( char c in s)
            {
                // If opening symbol, then push onto stack
                if ( c == '{' || c=='<' || c=='[' || c=='(' )
                {
                    stack.Push(c);
                }

                // If closing symbol, then see if it matches the top
                else if (c == '}' || c == '>' || c == ']' || c == ')')
                {
                    if (stack.Count == 0)
                    {
                        return false;
                    }
                    else if(Matches(stack.Peek(), c) )
                    {
                        stack.Pop();
                    }
                    else
                    {
                        return false;
                    }
                }

                // If any other character, then continue/ignore it.
                else
                {
                    //continue;
                }
            }

            // If stack is empty, return true
            // else return false

            if( stack.Count == 0)
            {
                return true;
            }

            return false;
        }

        private static bool Matches(char open, char close)
        {
            switch (open)
            {
                case '[':
                    if (close == ']')
                    {
                        return true;
                    }
                    break;
                case '{':
                    if (close == '}')
                    {
                        return true;
                    }
                    break;
                case '(':
                    if (close == ')')
                    {
                        return true;
                    }
                    break;
                case '<':
                    if (close == '>')
                    {
                        return true;
                    }
                    break;
                default:
                    return false;
            }

            return false;
        }

        // Evaluate("5 3 11 + -")	// returns -9
        // 2.4 3.8 / 2.321 +
        
        public static double? Evaluate(string s)
        {
            // parse into tokens (strings)

            string[] tokens = s.Split();

            Stack<double> stack = new Stack<double>();

            // foreach token
                // If token is an integer
                // Push on stack

                // If token is an operator
                    // Pop twice and save both values
                    // (if you can't pop twice, then return null)
                    // Perform operation on 2 values (in the correct order)
                    // Push the result on to stack


            
            foreach (string t in tokens)
            {
                if (t.Contains("0") || t.Contains("1") || t.Contains("2") || t.Contains("3") || t.Contains("4") || t.Contains("5") || t.Contains("6") || t.Contains("7") || t.Contains("8") || t.Contains("9"))
                {
                    int intT = int.Parse(t.ToString());
                    stack.Push(intT);
                }

                else if (t == "+" || t == "-" || t == "*" || t == "/")
                {
                    if (stack.Count > 1)
                    {
                        double int2 = stack.Pop();
                        double int1 = stack.Pop();
                        if (t == "+")
                        {
                            stack.Push(int1 + int2);
                        }
                        else if (t == "-")
                        {
                            stack.Push(int1 - int2);
                        }
                        else if (t == "*")
                        {
                            stack.Push(int1 * int2);
                        }
                        else if (t == "/")
                        {
                            stack.Push(int1 / int2);
                        }
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            if (stack.Count != 1)
            {
                return null;
            }
            return stack.Pop();
        }



    }
}
