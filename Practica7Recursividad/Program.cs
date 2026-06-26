using System;

namespace Practica7Recursividad
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== UNITEC: PRÁCTICA 7 - LÓGICA DE RECURSIVIDAD ===\n");

            // =================================================================
            // MÓDULO 1: Cuenta Regresiva Recursiva (Visual)
            // =================================================================
            Console.WriteLine("--- MÓDULO 1: Cuenta Regresiva ---");
            Console.WriteLine("Iniciando secuencia de sistema en:");
            
            // Llamamos a la función con el número inicial
            CuentaRegresiva(5);
            Console.WriteLine("¡Secuencia finalizada!\n");

            // =================================================================
            // MÓDULO 2: Factorial Recursivo (Matemático)
            // =================================================================
            Console.WriteLine("--- MÓDULO 2: Cálculo de Factorial ---");
            int numero = 5;
            int resultadoFactorial = CalcularFactorial(numero);
            
            Console.WriteLine($"Procesando el factorial de {numero}...");
            Console.WriteLine($"Resultado Final: {numero}! = {resultadoFactorial}\n");

            Console.WriteLine("========================================================");
            Console.WriteLine("Presiona cualquier tecla para finalizar...");
            Console.ReadKey();
        }

        // -----------------------------------------------------------------
        // MÉTODO RECURSIVO 1: Cuenta Regresiva
        // -----------------------------------------------------------------
        public static void CuentaRegresiva(int n)
        {
            // 1. CASO BASE (Condición de salida vital para evitar bucles infinitos)
            if (n <= 0)
            {
                return;
            }

            // 2. Acción del nivel actual
            Console.WriteLine($" -> {n}");

            // 3. LLAMADA RECURSIVA (La función se llama a sí misma restando 1)
            CuentaRegresiva(n - 1);
        }

        // -----------------------------------------------------------------
        // MÉTODO RECURSIVO 2: Factorial
        // -----------------------------------------------------------------
        public static int CalcularFactorial(int n)
        {
            // 1. CASO BASE: El factorial de 0 o 1 siempre es 1
            if (n <= 1)
            {
                return 1;
            }

            // 2. LLAMADA RECURSIVA: Multiplica el número actual por el factorial del anterior
            return n * CalcularFactorial(n - 1);
        }
    }
} 

