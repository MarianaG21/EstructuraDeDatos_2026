using System;

namespace Practica4Recursividad
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== PRÁCTICA 4: RECURSIVIDAD (FACTORIAL Y FIBONACCI) ===");
            
            // --- PRUEBA DE FACTORIAL ---
            try
            {
                int numeroFactorial = 5;
                Console.WriteLine($"\n[Calculando Factorial de {numeroFactorial}]...");
                long resultadoFactorial = CalcularFactorial(numeroFactorial);
                Console.WriteLine($"Resultado: {numeroFactorial}! = {resultadoFactorial}");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Error en Factorial: {ex.Message}");
            }

            // --- PRUEBA DE FIBONACCI ---
            try
            {
                int posicionFibonacci = 6;
                Console.WriteLine($"\n[Calculando elemento {posicionFibonacci} de la serie Fibonacci]...");
                int resultadoFibonacci = GenerarFibonacci(posicionFibonacci);
                Console.WriteLine($"Resultado: El elemento en la posición {posicionFibonacci} es {resultadoFibonacci}");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Error en Fibonacci: {ex.Message}");
            }

            // --- PRUEBA DE CONTROL DE ERRORES ---
            try
            {
                Console.WriteLine("\n[Prueba de Validación]: Intentando calcular el factorial de un número negativo (-3)...");
                CalcularFactorial(-3);
            }
            catch (ArgumentException ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"[Excepción Atrapada Exitosamente]: {ex.Message}");
                Console.ResetColor();
            }
            
            Console.WriteLine("\n=======================================================");
        }

        static long CalcularFactorial(int n)
        {
            if (n < 0)
                throw new ArgumentException("El número no puede ser negativo.");

            if (n == 0 || n == 1)
                return 1;

            return n * CalcularFactorial(n - 1);
        }

        static int GenerarFibonacci(int n)
        {
            if (n < 0)
                throw new ArgumentException("La posición no puede ser negativa.");

            if (n == 0) return 0;
            if (n == 1) return 1;

            return GenerarFibonacci(n - 1) + GenerarFibonacci(n - 2);
        }
    }
}