using System;
namespace Proyecto7_Musica
{
    public class ListaCircular
    {
        private Nodo actual;

        private class Nodo
        {
            public Cancion Datos;
            public Nodo Siguiente;

            public Nodo(Cancion cancion)
            {
                Datos = cancion;
            }
        }
        public void Agregar(Cancion cancion)
        {
            Nodo nuevo = new Nodo(cancion);
            if(actual == null)
            {
                actual = nuevo;
                nuevo.Siguiente = nuevo;
                return;
            } 
            Nodo auxiliar = actual;
            while(auxiliar.Siguiente != actual)
            auxiliar = auxiliar.Siguiente;

            auxiliar.Siguiente = nuevo;
            nuevo.Siguiente = actual;
        }
        public void Siguiente()
        {
            if(actual != null)
            {
                actual = actual.Siguiente;
                Console.WriteLine($"Reproduciendo: {actual.Datos}");
            }
        }
        public void Mostrar()
        {
            if(actual == null)
            return;
            Nodo auxiliar = actual;

            do
            {
                Console.WriteLine(auxiliar.Datos);
                auxiliar = auxiliar.Siguiente;
            }
            while(auxiliar != actual);
        }
    }
}