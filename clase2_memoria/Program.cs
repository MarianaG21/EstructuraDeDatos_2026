// 1. Declaración de variables iniciales
int numero = 5;                           // Variable de tipo valor (Value Type -> Vive en el Stack)
int[] miArreglo = { 1, 2, 3 };            // Variable de tipo referencia (Reference Type -> El objeto vive en el Heap)

// 2. Impresión de valores ANTES de llamar a las funciones
Console.WriteLine("========== ANTES DE LAS FUNCIONES ==========");
Console.WriteLine($"Valor del entero 'numero': {numero}");
Console.WriteLine($"Primer elemento de 'miArreglo': {miArreglo[0]}");
Console.WriteLine("============================================\n");

// 3. Llamada a las funciones del reto
CambiarValor(numero);
CambiarReferencia(miArreglo);

// 4. Impresión de valores DESPUÉS de llamar a las funciones
Console.WriteLine("========== DESPUÉS DE LAS FUNCIONES =========");
Console.WriteLine($"Valor del entero 'numero': {numero}");
Console.WriteLine($"Primer elemento de 'miArreglo': {miArreglo[0]}");
Console.WriteLine("=============================================");


// --- DEFINICIÓN DE LAS FUNCIONES (RETO DE PROGRAMACIÓN) ---

// Función 1: Intenta cambiar el valor de un entero a 100
static void CambiarValor(int x)
{
    x = 100; 
    // Aquí solo se modifica una COPIA de la variable original en otra parte del Stack
}

// Función 2: Intenta cambiar el primer elemento de un arreglo a 100
static void CambiarReferencia(int[] arr)
{
    if (arr.Length > 0)
    {
        arr[0] = 100; 
        // Aquí accedemos directamente a la dirección del Heap usando el puntero original
    }
}