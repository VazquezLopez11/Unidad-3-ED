using System;
namespace Calculadora
{
    internal class Program
    {
        static int Prioridad(char operador)
        {
            if(operador == '+' || operador == '-')
                return 1;
            else if(operador == '*' || operador == '/')
                return 2;
            else if(operador == '^')
                return 3;
            else
                return 0;
        }
        static string infijaAPostfija(string expresion)
        {
            Pila pila = new Pila();
            string salida = "";

            foreach(char character in expresion)
            {
                if(char.IsDigit(character))
                {
                    salida += character;
                }
                else if(character == '(')
                {
                    pila.Apilar(character);
                }
                else if(character == ')')
                {
                    while(!pila.Vacia() && pila.Tope() != '(')
                    {
                        salida += pila.Desapilar();
                    }
                    pila.Desapilar(); // Desapilar el '('
                }
                else if ("+-*/^".Contains(character))
                {
                    while(!pila.Vacia() && Prioridad(pila.Tope()) >= Prioridad(character))
                    {
                        salida += pila.Desapilar();
                    }
                    pila.Apilar(character);
                }
            }
            while(!pila.Vacia())
            {
                salida += pila.Desapilar();
            }
            return salida;
        }
        static void Main()
        {
            Console.WriteLine("===CALCULADORA DE EXPRESIONES MATEMÁTICAS===");
            Console.Write("Expresion: ");
            string expresion = Console.ReadLine();

            string postfija = infijaAPostfija(expresion);
            Console.WriteLine($"Postfija: {postfija}");

            Console.WriteLine("Presione cualquier tecla para salir...");
            Console.ReadKey();
        }
    }
}