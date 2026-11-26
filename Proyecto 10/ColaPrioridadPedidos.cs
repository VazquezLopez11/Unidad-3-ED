using System;
using System.Collections.Generic;


namespace Proyecto_10_Tienda_en_Linea;

public class ColaPrioridadPedidos
    {
        private Queue<Pedido> urgentes = new Queue<Pedido>();
        private Queue<Pedido> normales = new Queue<Pedido>();

        public void Encolar(Pedido pedido)
        {
            if (pedido.Prioridad.ToUpper() == "URGENTE")
                urgentes.Enqueue(pedido);
            else
                normales.Enqueue(pedido);
        }

        public Pedido Procesar()
        {
            if (urgentes.Count > 0)
                return urgentes.Dequeue();

            if (normales.Count > 0)
                return normales.Dequeue();

            return null;
        }

        public bool Vacia()
        {
            return urgentes.Count == 0 && normales.Count == 0;
        }
    }
