using System;
using System.Collections.Generic;

class Program
{
    static bool EsFormulaBalanceada(string formula)
    {
        Stack<char> pila = new Stack<char>();
        foreach (char caracter in formula)
        {
            if (caracter == '(' || caracter == '{' || caracter == '[')
            {
                pila.Push(caracter);
            }
            else if (caracter == ')' || caracter == '}' || caracter == ']')
            {
                if (pila.Count == 0)
                    return false;

                char top = pila.Pop();
                if ((caracter == ')' && top != '(') ||
                    (caracter == '}' && top != '{') ||
                    (caracter == ']' && top != '['))
                    return false;
            }
        }
        return pila.Count == 0;
    }

    static void Main()
    {
        string formula = "{7+(8*5)-[(9-7)+(4+1)]}";
        bool resultado = EsFormulaBalanceada(formula);

        Console.WriteLine(resultado ? "Fórmula balanceada" : "Fórmula no balanceada");
    }
}
