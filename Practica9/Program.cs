using System;
using System.Diagnostics; 

namespace Practica9
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== PRÁCTICA 9: OPTIMIZACIÓN CON MEMOIZATION ===");
            Console.Write("Ingresa un número para Fibonacci (Sugerido 35-43): ");
            string? input = Console.ReadLine();

            if (!int.TryParse(input, out int n) || n < 0)
            {
                Console.WriteLine("Error: ingresa un número entero positivo.");
                return;
            }

            Stopwatch sw = new Stopwatch();

            // --- MÉTODO A: INSEGURO (Fuerza Bruta) ---
            Console.WriteLine($"\nCalculando Fibonacci({n}) - Método Inseguro...");
            sw.Start();
            long r1 = FibonacciInseguro(n);
            sw.Stop();
            Console.WriteLine($"Resultado: {r1} | Tiempo: {sw.ElapsedMilliseconds} ms");

            // --- MÉTODO B: PRO (Memoization) ---
            Console.WriteLine($"\nCalculando Fibonacci({n}) - Método Pro (Caché)...");
            long[] cache = new long[n + 1];
            for (int i = 0; i <= n; i++) cache[i] = -1; // Inicializar caché

            sw.Restart();
            long r2 = FibonacciPro(n, cache);
            sw.Stop();
            Console.WriteLine($"Resultado: {r2} | Tiempo: {sw.ElapsedMilliseconds} ms");
            
            Console.WriteLine("\nAnálisis: El método Pro es instantáneo gracias a que no recalcula valores.");
        }

        // Recursividad Simple O(2^n)
        public static long FibonacciInseguro(int n)
        {
            if (n == 0) return 0;
            if (n == 1) return 1;
            return FibonacciInseguro(n - 1) + FibonacciInseguro(n - 2);
        }

        // Recursividad con Memoization O(n)
        public static long FibonacciPro(int n, long[] cache)
        {
            if (n == 0) return 0;
            if (n == 1) return 1;
            
            // Si ya existe en caché, lo devolvemos
            if (cache[n] != -1) return cache[n];

            // Si no, lo calculamos y lo guardamos
            cache[n] = FibonacciPro(n - 1, cache) + FibonacciPro(n - 2, cache);
            return cache[n];
        }
    }
}
