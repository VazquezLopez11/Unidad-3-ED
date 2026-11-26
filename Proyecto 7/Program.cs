using System;
namespace Proyecto7_Musica
{
    internal class Program
    {
        static ListaCircular playlist = new ListaCircular();

        static void Main()
        {
            int opcion;
            do
            {
                Console.Clear();
                Console.WriteLine("===== REPRODUCTOR =====");
                Console.WriteLine("1. Agregar Canción.");
                Console.WriteLine("2. Siguiente.");
                Console.WriteLine("3. Mostrar Playlist.");
                Console.WriteLine("4. Salir.");

                opcion = int.Parse(Console.ReadLine());

                switch(opcion)
                {
                    case 1:
                    Console.Write("Canción: ");
                    string nombre = Console.ReadLine();

                    Console.Write("Artista: ");
                    string artista = Console.ReadLine();

                    playlist.Agregar(new Cancion(nombre, artista));
                    break;

                    case 2:
                    playlist.Siguiente();
                    Console.ReadKey();
                    break;

                    case 3:
                    playlist.Mostrar();
                    Console.ReadKey();
                    break;
                }
                
            }while(opcion !=0);
        }
    }
}