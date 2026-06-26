using System;
using System.Numerics; // Necesario para manejar BigInteger (números gigantes)

namespace Practica8
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== DIAGNÓSTICO DE DESBORDAMIENTO (INT 32-BITS) ===");
            
            // Ciclo de diagnóstico solicitado (n=1 a n=20)
            for (int i = 1; i <= 20; i++)
            {
                int rec = FactorialInt(i);
                int ite = FactorialIterativo(i);

                Console.WriteLine($"n={i:D2} | Recursivo: {rec,15} | Iterativo: {ite,15}");
            }

            /* 
             * PUNTO DE QUIEBRE (Documentación obligatoria):
             * El desbordamiento ocurre exactamente en n=13.
             * Valor esperado: 6,227,020,800
             * Valor obtenido: 1,932,053,504
             * Razón: El valor supera los 2,147,483,647 (Límite de Int32), 
             * provocando que los bits se desborden y den una vuelta (wraparound).
             */

            Console.WriteLine("\n=== SOLUCIÓN PROFESIONAL CON BIGINTEGER ===");
            
            // Prueba con n=100 (Esto daría error o 0 con tipos comunes)
            BigInteger n100 = 100;
            BigInteger resultadoGrande = FactorialProfesional(n100);
            
            Console.WriteLine($"100! = {resultadoGrande}");
            Console.WriteLine($"\nEl resultado anterior tiene 158 dígitos.");
        }

        // --- MÉTODOS SOLICITADOS ---

        // 1. Versión Recursiva (Tradicional)
        static int FactorialInt(int n)
        {
            if (n == 0 || n == 1) return 1;
            return n * FactorialInt(n - 1);
        }

        // 2. Versión Iterativa (Tradicional)
        static int FactorialIterativo(int n)
        {
            int resultado = 1;
            for (int i = 2; i <= n; i++)
            {
                resultado *= i;
            }
            return resultado;
        }

        // 3. Versión de Alta Precisión (BigInteger)
        static BigInteger FactorialProfesional(BigInteger n)
        {
            if (n == 0 || n == 1) return BigInteger.One;
            return n * FactorialProfesional(n - 1);
        }
    }
}
