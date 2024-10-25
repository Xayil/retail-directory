using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Console.WriteLine("Dame la cantidad de productos que piensas tener inicialmente");
        Console.WriteLine("NOTA: Los descuentos serán agregados posteriormente");

        int Y = int.Parse(Console.ReadLine());

        List<string> productos = new List<string>();
        List<double> precios = new List<double>();
        List<double> ahorros = new List<double>();

        agregarProductoPrecio(productos, precios, ahorros, Y);

        int opcion = 0;
        while (opcion != 4)
        {
            Console.WriteLine("\nElije la opción que deseas realizar por medio del número:");
            Console.WriteLine("1. Añadir más productos");
            Console.WriteLine("2. Visualizar lista de productos registrados");
            Console.WriteLine("3. Añadir descuentos a productos ya existentes"); 
            Console.WriteLine("4. Salir del programa");
            opcion = int.Parse(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    Console.WriteLine("Ha elegido agregar productos");
                    Console.WriteLine("Digite la cantidad de productos que desea agregar:");
                    int P = int.Parse(Console.ReadLine());
                    agregarProductoPrecio(productos, precios, ahorros, P);
                    Console.WriteLine("Productos añadidos.");
                    break;
                case 2:
                    Console.WriteLine("Visualización de los productos:");
                    Console.WriteLine("\nProductos y sus precios:");
                    for (int i = 0; i < productos.Count; i++)
                    {
                        Console.WriteLine($"{productos[i]}, Precio: {precios[i]:C}, Descuentos: {ahorros[i]}%");
                    }
                    break;
                case 3:
                    Console.WriteLine("\nProductos en existencia:");
                    for (int i = 0; i < productos.Count; i++)
                    {
                        Console.WriteLine($"{productos[i]}, Precio: {precios[i]:C}, Descuentos: {ahorros[i]}");
                    }
                    Console.WriteLine("Dime el producto al que deseas añadir un descuento");
                    string pbusca = Console.ReadLine();
                    buscarProductoDescuento(productos, precios, ahorros, pbusca);
                    break;
                case 4:
                    for (int i = 0; i < productos.Count; i++)
                    {
                        Console.WriteLine($"{productos[i]}, Precio: {precios[i]:C}, Descuentos: {ahorros[i]}%");
                    }
                    Console.WriteLine("Saliendo del programa...");
                    break;
                default:
                    Console.WriteLine("Opción no válida, por favor elija otra.");
                    break;
            }
        }
    }

    static void agregarProductoPrecio(List<string> productos, List<double> precios, List<double> ahorros, int S)
    {
        for (int i = 0; i < S; i++)
        {
            double descuento = 0;

            Console.WriteLine($"Dame el nombre del producto {i + 1}: ");
            string nombre = Console.ReadLine();

            Console.WriteLine($"Dame el precio del producto que me acabas de dar {i + 1}: ");
            double precio = double.Parse(Console.ReadLine());

            productos.Add(nombre);
            precios.Add(precio);
            ahorros.Add(descuento);
        }
    }

    static void buscarProductoDescuento(List<string> productos, List<double> precios, List <double> ahorros, string pbusca)
    {
        int indice = productos.IndexOf(pbusca);

        if (indice != -1)
        {
            Console.WriteLine($"Producto encontrado: {productos[indice]}, Precio: {precios[indice]:C}");
            Console.WriteLine("Cuánto descuento deseas aplicar? (Porcentaje entre 0 y 100)");

            int porcentaje = int.Parse(Console.ReadLine());

            if (porcentaje < 0 || porcentaje > 100)
            {
                Console.WriteLine("Porcentaje inválido, debe estar entre 0 y 100.");
            }
            else
            {
                double descuento = precios[indice] * (porcentaje / 100.0);
                precios[indice] -= descuento;
                ahorros[indice] += porcentaje;

                Console.WriteLine($"Nuevo precio para {productos[indice]}: {precios[indice]:C} (descuento aplicado: {porcentaje}%)");
            }
        }
        else
        {
            Console.WriteLine("Producto no encontrado");
        }
    }
}

