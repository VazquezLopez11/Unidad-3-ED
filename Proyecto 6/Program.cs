using System;

namespace Proyecto_6_Tarea
{
    class Program
    {
        static void Main(string[] args)
        {
            ListaDoble lista = new ListaDoble();
            int opcion = 0;

            do
            {
                Console.WriteLine("\n=== ADMINISTRADOR DE TAREAS ===");
                Console.WriteLine("1. Agregar Tarea");
                Console.WriteLine("2. Mostrar Tareas");
                Console.WriteLine("3. Buscar Tarea por ID");
                Console.WriteLine("4. Salir");
                Console.Write("Seleccione una opción: ");

                if (int.TryParse(Console.ReadLine(), out opcion))
                {
                    switch (opcion)
                    {
                        case 1:
                            Console.Write("Ingrese ID de la tarea: ");
                            if (int.TryParse(Console.ReadLine(), out int id))
                            {
                                Console.Write("Ingrese descripción de la tarea: ");
                                string desc = Console.ReadLine() ?? "";
                                Tarea nuevaTarea = new Tarea(id, desc);
                                lista.Insertar(nuevaTarea);
                                Console.WriteLine("¡Tarea agregada exitosamente!");
                            }
                            else
                            {
                                Console.WriteLine("ID inválido.");
                            }
                            break;

                        case 2:
                            Console.WriteLine("\n--- LISTA DE TAREAS ---");
                            lista.Mostrar();
                            break;

                        case 3:
                            Console.Write("Ingrese ID a buscar: ");
                            if (int.TryParse(Console.ReadLine(), out int searchId))
                            {
                                Tarea encontrada = lista.Buscar(searchId);
                                if (encontrada != null)
                                {
                                    Console.WriteLine($"Tarea encontrada: {encontrada}");
                                }
                                else
                                {
                                    Console.WriteLine("Tarea no encontrada.");
                                }
                            }
                            break;

                        case 4:
                            Console.WriteLine("Saliendo del sistema...");
                            break;

                        default:
                            Console.WriteLine("Opción no válida.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Por favor, ingrese un número válido.");
                }

            } while (opcion != 4);
        }
    }
}