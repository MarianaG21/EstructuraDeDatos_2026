using System;

namespace Practica6ReferenciasYMemoria
{
    // Clase de prueba para el Módulo 3: Demostración del Heap
    public class Estudiante
    {
        public string Nombre { get; set; }
        public Estudiante(string nombre)
        {
            Nombre = nombre;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== UNITEC: PRÁCTICA 6 - MANEJO DE MEMORIA, REF Y OUT ===\n");

            // =================================================================
            // MÓDULO 1: Demostración del modificador 'ref' (Paso por Referencia)
            // =================================================================
            Console.WriteLine("--- MÓDULO 1: Intercambio de Valores con 'ref' ---");
            int a = 10;
            int b = 99;
            Console.WriteLine($"[Antes] Valores originales en el Stack: a = {a}, b = {b}");
            
            // Llamamos al método pasando las direcciones de memoria
            Intercambiar(ref a, ref b);
            Console.WriteLine($"[Después] Valores modificados directamente: a = {a}, b = {b}\n");


            // =================================================================
            // MÓDULO 2: Demostración del modificador 'out' (Múltiples Retornos)
            // =================================================================
            Console.WriteLine("--- MÓDULO 2: División Segura con 'out' ---");
            int dividendo = 25;
            int divisor = 4;
            
            // Las variables out no necesitan inicializarse antes de pasarse
            if (CalcularYValidar(dividendo, divisor, out int cociente, out int residuo))
            {
                Console.WriteLine($"División exitosa de {dividendo} / {divisor}:");
                Console.WriteLine($" -> Cociente (Resultado): {cociente}");
                Console.WriteLine($" -> Residuo (Sobrante): {residuo}\n");
            }

            // Prueba de validación de error (División entre cero)
            Console.WriteLine("Probando caso de error (División entre cero)...");
            if (!CalcularYValidar(10, 0, out _, out _))
            {
                Console.WriteLine("[Alerta de Sistema]: No se puede dividir entre cero. Operación rechazada de forma segura.\n");
            }


            // =================================================================
            // MÓDULO 3: Demostración de Referencias de Objetos (Memoria Heap)
            // =================================================================
            Console.WriteLine("--- MÓDULO 3: Comportamiento del Heap frente al Stack ---");
            
            // Creamos un objeto en el Heap. 'estudiante1' solo guarda su dirección (puntero).
            Estudiante estudiante1 = new Estudiante("Manuel");
            // Copiamos la referencia (dirección de memoria), NO el objeto real
            Estudiante estudiante2 = estudiante1;

            Console.WriteLine($"[Original] Nombre del Estudiante 1: {estudiante1.Nombre}");
            Console.WriteLine($"[Copia Ref] Nombre del Estudiante 2: {estudiante2.Nombre}");

            // Modificamos al estudiante 2
            Console.WriteLine("\nCambiando el nombre a través de la variable 'estudiante2'...");
            estudiante2.Nombre = "Manuel - Alumno UNITEC";

            // Comprobamos que AMBOS cambiaron porque apuntan al mismo bloque en el Heap
            Console.WriteLine($"[Resultado] Nombre del Estudiante 1: {estudiante1.Nombre}");
            Console.WriteLine($"[Resultado] Nombre del Estudiante 2: {estudiante2.Nombre}");
            Console.WriteLine("[Análisis]: Se comprueba que ambas variables comparten la misma dirección en el Heap.");
            
            Console.WriteLine("\n========================================================");
            Console.WriteLine("Presiona cualquier tecla para finalizar...");
            Console.ReadKey();
        }

        // Método del Módulo 1: Usa 'ref' para alterar las variables originales en el Stack
        public static void Intercambiar(ref int num1, ref int num2)
        {
            int temporal = num1;
            num1 = num2;
            num2 = temporal;
        }

        // Método del Módulo 2: Usa 'out' para garantizar la asignación de múltiples salidas
        public static bool CalcularYValidar(int dividendo, int divisor, out int cociente, out int residuo)
        {
            // Validación obligatoria: si dividimos entre cero, el programa fallaría
            if (divisor == 0)
            {
                cociente = 0; // 'out' exige asignar un valor antes de salir, pase lo que pase
                residuo = 0;
                return false; // Retornamos false indicando que falló la operación
            }

            // Operaciones matemáticas normales
            cociente = dividendo / divisor;
            residuo = dividendo % divisor;
            return true; // Retornamos true indicando éxito
        }
    }
}