using System;
using System.Collections.Generic;
using System.Linq;

namespace Practica3Inventario
{
    public class Producto
    {
        public string Id { get; set; }
        public string Nombre { get; set; }
        public int Stock { get; set; }
        public double Precio { get; set; }

        public Producto(string id, string nombre, int stock, double precio)
        {
            Id = id;
            Nombre = nombre;
            Stock = stock;
            Precio = precio;
        }

        public override string ToString()
        {
            return $"ID: {Id} | {Nombre} | Stock: {Stock} | Precio: ${Precio:F2}";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== SISTEMA DE INVENTARIO (Práctica 3) ===\n");

            List<Producto> listaProductos = new List<Producto>
            {
                new Producto("P001", "Laptop Gamer", 15, 25000.00),
                new Producto("P002", "Teclado Mecánico", 0, 1200.50), 
                new Producto("P003", "Mouse Óptico", 45, 450.00),
                new Producto("P004", "Monitor 4K", 8, 8500.00),
                new Producto("P005", "Audífonos Inalámbricos", 0, 1800.00)
            };

            Dictionary<string, Producto> diccionarioProductos = new Dictionary<string, Producto>();
            foreach (var prod in listaProductos)
            {
                diccionarioProductos.Add(prod.Id, prod);
            }

            var productosOrdenados = listaProductos.OrderByDescending(p => p.Precio).ToList();
            Console.WriteLine("--- Productos ordenados por Precio (Mayor a Menor) ---");
            foreach (var p in productosOrdenados) { Console.WriteLine(p); }

            var productosAgotados = listaProductos.Where(p => p.Stock == 0).ToList();
            Console.WriteLine("\n--- Alertas de Inventario: Productos Agotados ---");
            foreach (var p in productosAgotados) { Console.WriteLine($"⚠️ ¡AGOTADO!: {p.Nombre}"); }

            string idBuscar = "P004";
            Console.WriteLine($"\n--> Buscando producto con ID '{idBuscar}' en el Diccionario...");
            if (diccionarioProductos.TryGetValue(idBuscar, out Producto encontrado))
            {
                Console.WriteLine($"✨ ¡Producto Encontrado!: {encontrado.Nombre} | Precio: ${encontrado.Precio}");
            }
        }
    }
}
