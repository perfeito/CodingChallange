using System;

namespace CodingChallange
{
    class Program
    {
        const int a = 0;
        const int b = 1;
        const int c = 2;
        const int d = 3;
        const int e = 4;
        const int f = 5;
        const int g = 6;
        
        static void PrintNumber(char character, byte value, int size)
        {
            Console.Clear();
            var segments = BCDToSeven(value);

            if (segments[a]) Line(character, size);
                Columns(segments[f] ? character : (char)ConsoleKey.Spacebar, segments[b] ? character : (char)ConsoleKey.Spacebar, size);
            if (!segments[g] && !segments[d])
                return;
            if (segments[g])
                Line(segments[g] ? character : (char)ConsoleKey.Spacebar, size);
            Columns(segments[e] ? character : (char)ConsoleKey.Spacebar, segments[c] ? character : (char)ConsoleKey.Spacebar, size);
            if (segments[d])
                Line(character, size);
        }
                
        static void Line(char character, int size)
        {
            for (int i = 0; i < size; i++)
                Console.Write(character);

            Console.WriteLine();
        }

        static void Columns(char startChar, char endChar, int size)
        {
            for (int i = 0; i < size; i++)
            {
                Console.Write(startChar);

                for (int j = 0; j < size - 2; j++)
                    Console.Write((char)ConsoleKey.Spacebar);

                Console.WriteLine(endChar);
            }
        }

        static bool[] BCDToSeven(byte value)
        {
            var result = new bool[] 
            {
                false,
                false,
                false,
                false,
                false,
                false,
                false
            };

            if (value < 0 || value > 9)
                return result;

            bool A = (value & 0b00001000) != 0;
            bool B = (value & 0b00000100) != 0;
            bool C = (value & 0b00000010) != 0;
            bool D = (value & 0b00000001) != 0;

            result[a] = A || C || (B && D) || (!B && !D);
            result[b] = !B || (!C && !D) || (C && D);
            result[c] = B || !C || D;
            result[d] = (!B && !D) || (C && !D) || (B && !C && D) || (!B && C) || A;
            result[e] = (!B && !D) || (C && !D);
            result[f] = A || (!C && !D) || (B && !C) || (B && !D);
            result[g] = A || (B && !C) || (!B && C) || (C && !D);

            return result;
        }

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Informe um número entre 1 e 9. Informe 0 para sair.");
                var value = Console.ReadKey().KeyChar;
                Console.Write(Environment.NewLine);

                if (value == (char)ConsoleKey.D0)
                    break;

                if (value < (char)ConsoleKey.D1 || value > (char)ConsoleKey.D9)
                {
                    Console.WriteLine("Dado Inválido!");
                    Console.WriteLine();
                    Console.WriteLine("__________");
                    Console.WriteLine();
                    continue;
                }

                byte val = (byte)(value - (char)ConsoleKey.D0);
                Console.WriteLine();
                Console.WriteLine("__________");
                Console.WriteLine();
                PrintNumber(value, val, val);
                Console.WriteLine("__________");
                Console.WriteLine();
            }
        }
    }
}
