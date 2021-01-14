using System;
using System.Collections.Generic;
using System.Linq;

namespace usefulCS
{
    struct MathExpressionValidator
    {
        static internal HashSet<char> whiteList = new HashSet<char> {
            '+','-','*','/','^',
            '1','2','3','4','5','6','7','8','9','0',
            '(',')',
            '{','}',
            '[',']',
            'x','y',
            's','c','t','l',
            '\0'
        };
        //------------------------------------------------------------------
        static internal string DelSpaces(string s)
        {
            string sRes = "";
            foreach(char c in s)
            {
                if (' ' != c) sRes += c;
            }
            return sRes;
        }
        static internal void TestIt()
        {
            string[] test = new string[]
            {
            "11", "1-2", "x+1","+-",
            "sin(x)", "cos", "cos()","cos(x)",
            "1--1", "1", "-1-", "-1-=",
            "(cos(5x)+sin(x/3))*log(y)"
            };

            Console.WriteLine("{0, -10}{1, -10}{2, -10}{3, -10}{4, -10}", "Exp", "trash", "signs", "()", "res");
            foreach (string s in test)
            {
                Console.Write("{0, -10}", s);
                
                Console.Write("{0, -10}", IsCorrectFooAndNoTrash(s));
                Console.Write("{0, -10}", IsCorrectOperationSigns(s));
                Console.Write("{0, -10}", IsCorrectParentheses(s));

                Console.WriteLine("{0, -10}", StrIsMathExpr(s));
            }

            Console.ReadKey();
        }
        //-----------------------------------------------------------------
        static internal bool IsCorrectFooAndNoTrash(string s)
        {
            if (null == s) { return false; }
            if (s.Equals("")) { return false; }
            s += "\0\0\0\0\0";

            char ch;
            int leftBracket = 0;
            int rightBracket = 0;

            for (int i = 0; i < s.Length; i++)
            {
                ch = s.ElementAt(i);
                if (whiteList.Contains(ch))
                {
                    switch (ch)
                    {
                        case '(':
                        case '{':
                        case '[': leftBracket++; break;

                        case ')':
                        case '}':
                        case ']': rightBracket++; break;

                        case 'c':
                            {//cos, ctg
                                //string caseC = s.Substring(i + 1, i + 4);
                                string caseC = s.Substring(i + 1, 3);
                                if (!caseC.Equals("os(") && !caseC.Equals("tg(")) { return false; }
                                leftBracket++;
                                i += 3;
                            }
                            break;

                        case 's':
                            {//sin
                                //string caseS = s.Substring(i + 1, i + 4);
                                string caseS = s.Substring(i + 1, 3);
                                if (!caseS.Equals("in(")) { return false; }
                                leftBracket++;
                                i += 3;
                            }
                            break;

                        case 't':
                            {//tg
                                //String caseT = s.Substring(i + 1, i + 3);
                                string caseT = s.Substring(i + 1, 2);
                                if (!caseT.Equals("g(")) { return false; }
                                leftBracket++;
                                i += 2;
                            }
                            break;

                        case 'l'://log
                            {
                                string caseL = s.Substring(i + 1, 3);
                                if (!caseL.Equals("og(")) { return false; }
                                leftBracket++;
                                i += 3;
                            }
                            break;

                    }//sw
                }
                else return false;
            }

            if (leftBracket != rightBracket) return false;

            return true;
        }
        static internal bool IsCorrectOperationSigns(string s)
        {
            HashSet<char> operands = new HashSet<char> { '+', '*', '/', '-', '^' };

            //if ((operands.count(a[0]) != 0 && a[0] != '-') || operands.count(a[a.size() - 1]) != 0)
            if (  (operands.Contains(s.First()) && s.First() != '-') || operands.Contains(s.Last())  )
            {
                return false;
            }
            else
            {
                for (int i = 0; i < s.Length; i++)
                {
                    if (operands.Contains(s.ElementAt(i)) && operands.Contains(s.ElementAt(i + 1))) return false;                
                    if ((s.ElementAt(i) == '/') && (s.ElementAt(i + 1) == '0')) return false;
                }
            }
            return true;
        }
        static internal bool IsCorrectParentheses(string s)
        {
            Stack<char> st = new Stack<char>();

            HashSet<char> opening_parenthesis = new HashSet<char> { '(', '{', '[' };
            HashSet<char> closing_parenthesis = new HashSet<char> { ')', '}', ']' };

            for (int i = 0; i < s.Length; i++)
            {
                if (closing_parenthesis.Contains(s.ElementAt(i)))
                {
                    if (st.Count != 0)
                    {
                        if (
                            (s.ElementAt(i) == ')' && st.Peek() == ('(')) ||
                            (s.ElementAt(i) == '}' && st.Peek() == '{') ||
                            (s.ElementAt(i) == ']' && st.Peek() == '[')
                            )
                        {
                            st.Pop();
                        }
                        else return false;
                    }
                    else return false;
                }
                else if (opening_parenthesis.Contains(s.ElementAt(i)))
                {
                    st.Push(s.ElementAt(i));
                }
            }

            if (st.Count > 0) return false;

            return true;
        }
        //-----------------------------------------------------------------------------
        static internal bool StrIsMathExpr(string s)
        {
            return (IsCorrectFooAndNoTrash(s) && IsCorrectOperationSigns(s) && IsCorrectParentheses(s));
        }
        //-----------------------------------------------------------------------------
    }//s
}
