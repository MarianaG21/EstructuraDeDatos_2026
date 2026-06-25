// 1. FLUJO PRINCIPAL DEL PROGRAMA
Console.WriteLine("=== CALCULADORA DE POLÍGONOS REGULARES ===");

// Creamos la estructura para guardar los datos
PoligonoRegular miPoligono = new PoligonoRegular();

// Paso 1: Selección del polígono (Función 1)
miPoligono.NumeroLados = SeleccionarPoligono();
Console.WriteLine($"\n[Sistema]: Has elegido un polígono de {miPoligono.NumeroLados} lados.");

// Paso 2: Validación y captura de datos (Función 2)
miPoligono = PedirDatos(miPoligono);

// Paso 3: Cálculo y despliegue del área (Función 3)
CalcularArea(miPoligono);


// 2. FUNCIONES INDEPENDIENTES

// Función 1: Menú de selección
int SeleccionarPoligono()
{
    Console.WriteLine("\nSelecciona el polígono que deseas calcular:");
    Console.WriteLine("1. Pentágono (5 lados)");
    Console.WriteLine("2. Hexágono (6 lados)");
    Console.Write("Digita el número de tu opción: ");

    string? opcion = Console.ReadLine();

    if (opcion == "1") return 5;
    if (opcion == "2") return 6;

    Console.WriteLine("Opción no válida. Se seleccionará un Triángulo por defecto.");
    return 3;
}

// Función 2: Captura y Validación (Diferenciador Profesional)
PoligonoRegular PedirDatos(PoligonoRegular pol)
{
    Console.WriteLine("\n--- REGISTRO DE MEDIDAS ---");

    // Validar el lado
    while (true)
    {
        Console.Write("Ingresa la medida del lado (Debe ser mayor a 0): ");
        if (double.TryParse(Console.ReadLine(), out double lado) && lado > 0)
        {
            pol.MedidaLado = lado;
            break;
        }
        Console.WriteLine("[Error]: Por favor introduce un número válido y positivo.");
    }

    // Validar la apotema
    while (true)
    {
        Console.Write("Ingresa la medida de la apotema (Debe ser mayor a 0): ");
        if (double.TryParse(Console.ReadLine(), out double apotema) && apotema > 0)
        {
            pol.Apotema = apotema;
            break;
        }
        Console.WriteLine("[Error]: Por favor introduce un número válido y positivo.");
    }

    return pol;
}

// Función 3: Cálculo matemático del Área (Paso Final)
void CalcularArea(PoligonoRegular pol)
{
    Console.WriteLine("\n--- RESULTADOS FINALES ---");
    
    // Fórmula: Perímetro = Lados * Medida del lado
    double perimetro = pol.NumeroLados * pol.MedidaLado;
    
    // Fórmula: Área = (Perímetro * Apotema) / 2
    double area = (perimetro * pol.Apotema) / 2;

    Console.WriteLine($"Polígono evaluado: {pol.NumeroLados} lados.");
    Console.WriteLine($"Medida de cada lado: {pol.MedidaLado}");
    Console.WriteLine($"Medida de la apotema: {pol.Apotema}");
    Console.WriteLine($"Perímetro total: {perimetro}");
    Console.WriteLine("-----------------------------------------");
    Console.WriteLine($"¡El ÁREA TOTAL es: {area} unidades cuadradas!");
    Console.WriteLine("-----------------------------------------");
}


// 3. CONTENEDOR DE DATOS (Estructura)
struct PoligonoRegular
{
    public int NumeroLados;
    public double MedidaLado;
    public double Apotema;
}