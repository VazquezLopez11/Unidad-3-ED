using System;

namespace Proyecto_8_AtencionBanco
{
    internal class Program
    {
        static void Main()
        {
            ColaPrioridad cola = new ColaPrioridad();
            int siguienteTurno = 1;
            bool salir = false;

            while (!salir)
            {
                Console.WriteLine("\n=== SISTEMA DE ATENCIÓN AL BANCO ===");
                Console.WriteLine("1. Registrar cliente (Insertar)");
                Console.WriteLine("2. Atender siguiente cliente");
                Console.WriteLine("3. Mostrar cola en espera");
                Console.WriteLine("4. Salir");
                Console.Write("Selecciona una opción: ");

                string? opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        Console.Write("Nombre del cliente: ");
                        string? nombre = Console.ReadLine();
                        if (string.IsNullOrWhiteSpace(nombre))
                        {
                            nombre = "Sin nombre";
                        }

                        Console.Write("Prioridad (ej. 1 = Alta, 2 = Media, 3 = Baja): ");
                        if (int.TryParse(Console.ReadLine(), out int prioridad))
                        {
                            Cliente nuevoCliente = new Cliente(siguienteTurno++, nombre.Trim(), prioridad);
                            cola.Insertar(nuevoCliente);
                            Console.WriteLine($"Registrado: {nuevoCliente}");
                        }
                        else
                        {
                            Console.WriteLine("Prioridad inválida. Ingresa un número entero.");
                        }
                        break;

                    case "2":
                        Cliente? atendido = cola.Atender();
                        if (atendido != null)
                        {
                            Console.WriteLine($"Atendiendo a -> {atendido}");
                        }
                        else
                        {
                            Console.WriteLine("No hay clientes en espera.");
                        }
                        break;

                    case "3":
                        Console.WriteLine("\n--- Clientes en espera ---");
                        cola.Mostrar();
                        break;

                    case "4":
                        salir = true;
                        break;

                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }
            }
        }
    }
}