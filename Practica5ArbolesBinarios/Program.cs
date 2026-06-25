using System;

namespace Practica5ArbolesBinarios
{
    // El Modelo de Datos: Definición del Nodo (Página 7 del PDF)
    public class Nodo
    {
        // Identificador único para ordenar el árbol
        public int ID { get; set; }
        
        // Información que almacena el nodo
        public string Dato { get; set; } = string.Empty;
        
        // Referencias recursivas a los hijos (Son nullable ? porque las hojas apuntan a null)
        public Nodo? HijoIzquierdo { get; set; }
        public Nodo? HijoDerecho { get; set; }

        // Constructor para crear nodos fácilmente
        public Nodo(int id, string dato)
        {
            ID = id;
            Dato = dato;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== UNITEC: PRÁCTICA 5 - ÁRBOLES BINARIOS ===");
            
            // 1. Crear el nodo raíz inicial (ID 10)
            Nodo raiz = new Nodo(10, "Root - Servidor Principal");
            Console.WriteLine($"\n[Raíz Creada]: ID {raiz.ID} -> {raiz.Dato}");

            // 2. Inserción de nodos basada en el orden del entregable
            raiz = InsertarNodo(raiz, new Nodo(5, "Usuario Laptop"));
            raiz = InsertarNodo(raiz, new Nodo(15, "Base de Datos"));
            raiz = InsertarNodo(raiz, new Nodo(3, "Smartphone"));
            raiz = InsertarNodo(raiz, new Nodo(7, "Tablet"));
            raiz = InsertarNodo(raiz, new Nodo(12, "Impresora de Red"));
            raiz = InsertarNodo(raiz, new Nodo(20, "Cámara de Seguridad"));
            
            Console.WriteLine("\n[Sistema]: Todos los nodos se han insertado en el BST de forma jerárquica.");

            // 3. Simulación de búsquedas interactivas en la consola (Complejidad O(log n))
            Console.WriteLine("\n=== Simulador de Búsqueda Eficiente O(log n) ===");
            
            // Prueba de búsqueda de un elemento que SÍ existe
            int idBuscar1 = 12;
            Console.WriteLine($"\nBuscando elemento con ID {idBuscar1}...");
            string? resultado1 = BuscarNodo(raiz, idBuscar1);
            Console.WriteLine($"Resultado: {(resultado1 != null ? $"¡Encontrado! -> {resultado1}" : "No encontrado en el sistema")}");

            // Prueba de búsqueda de un elemento que NO existe
            int idBuscar2 = 99;
            Console.WriteLine($"\nBuscando elemento no existente con ID {idBuscar2}...");
            string? resultado2 = BuscarNodo(raiz, idBuscar2);
            Console.WriteLine($"Resultado: {(resultado2 != null ? $"¡Encontrado! -> {resultado2}" : "No encontrado (Búsqueda finalizada con éxito)")}");
            
            Console.WriteLine("\n==========================================");
            Console.WriteLine("Presiona cualquier tecla para finalizar...");
            Console.ReadKey();
        }

        // Algoritmo de Inserción Recursiva (Página 8 del PDF)
        public static Nodo InsertarNodo(Nodo? raiz, Nodo nuevoNodo)
        {
            // CASO BASE: posición vacía encontrada. Colocamos el nuevo nodo aquí.
            if (raiz == null)
            {
                return nuevoNodo;
            }

            // CASO RECURSIVO: decidir la dirección comparando IDs
            if (nuevoNodo.ID < raiz.ID)
            {
                // El nuevo nodo es menor -> va al subárbol izquierdo
                raiz.HijoIzquierdo = InsertarNodo(raiz.HijoIzquierdo, nuevoNodo);
            }
            else if (nuevoNodo.ID > raiz.ID)
            {
                // El nuevo nodo es mayor -> va al subárbol derecho
                raiz.HijoDerecho = InsertarNodo(raiz.HijoDerecho, nuevoNodo);
            }

            return raiz; // Devolvemos la raíz actualizada con sus ramas
        }

        // Algoritmo de Búsqueda Recursiva O(log n) (Página 9 del PDF)
        public static string? BuscarNodo(Nodo? raiz, int idTarget)
        {
            // CASO BASE 1: posición vacía (el nodo no existe en el árbol)
            if (raiz == null)
            {
                return null;
            }

            // CASO BASE 2: ¡Encontrado! El ID coincide exactamente
            if (idTarget == raiz.ID)
            {
                return raiz.Dato;
            }

            // CASO RECURSIVO: Decidir qué mitad del árbol descartar
            if (idTarget < raiz.ID)
            {
                // El target es menor, buscamos solo a la izquierda
                return BuscarNodo(raiz.HijoIzquierdo, idTarget);
            }
            else
            {
                // El target es mayor, buscamos solo a la derecha
                return BuscarNodo(raiz.HijoDerecho, idTarget);
            }
        }
    }
}
