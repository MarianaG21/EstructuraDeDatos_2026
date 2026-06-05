// 1. AQUÍ INICIA TU PROGRAMA (Instrucciones principales)
Console.WriteLine("=== CALCULADORA DE POLÍGONOS REGULARES ===");

// Creamos la "caja" para guardar los datos de nuestro polígono
PoligonoRegular miPoligono = new PoligonoRegular();

// Paso 1: Seleccionar el polígono
miPoligono.NumeroLados = SeleccionarPoligono();
Console.WriteLine($"\n[Sistema]: Has elegido un polígono de {miPoligono.NumeroLados} lados.");

// Paso 2: Pedir los datos (Le pasamos nuestro polígono para que lo llene y nos lo devuelva)
miPoligono = PedirDatos(miPoligono);


// 2. TUS FUNCIONES INDEPENDIENTES

// Función 1: El Menú
int SeleccionarPoligono()
{
    Console.WriteLine("\nSelecciona el polígono que deseas calcular:");
    Console.WriteLine("1. Pentágono (5 lados)");
    Console.WriteLine("2. Hexágono (6 lados)");
    Console.Write("Digita el número de tu opción: ");

    string opcion = Console.ReadLine();

    if (opcion == "1") return 5;
    if (opcion == "2") return 6;

    Console.WriteLine("Opción no válida. Se seleccionará un Triángulo por defecto.");
    return 3;
}

// Función 2: Pedir y Validar Datos (Cumple el Diferenciador Profesional)
PoligonoRegular PedirDatos(PoligonoRegular poligono)
{
    Console.WriteLine("\n--- REGISTRO DE MEDIDAS ---");

    // Validar la medida del lado
    while (true)
    {
        Console.Write("Ingresa la medida del lado (Debe ser mayor a 0): ");
        // TryParse intenta convertir el texto a número. Si puede y es mayor a 0, avanza.
        if (double.TryParse(Console.ReadLine(), out double lado) && lado > 0)
        {
            poligono.MedidaLado = lado;
            break; // Rompe el ciclo porque el dato es correcto
        }
        Console.WriteLine("[Error]: Por favor introduce un número válido y positivo.");
    }

    // Validar la apotema
    while (true)
    {
        Console.Write("Ingresa la medida de la apotema (Debe ser mayor a 0): ");
        if (double.TryParse(Console.ReadLine(), out double apotema) && apotema > 0)
        {
            poligono.Apotema = apotema;
            break; // Rompe el ciclo
        }
        Console.WriteLine("[Error]: Por favor introduce un número válido y positivo.");
    }

    return poligono; // Devolvemos el polígono ya con sus datos guardados
}


// 3. TU CONTENEDOR DE DATOS
struct PoligonoRegular
{
    public int NumeroLados;
    public double MedidaLado;
    public double Apotema;
}