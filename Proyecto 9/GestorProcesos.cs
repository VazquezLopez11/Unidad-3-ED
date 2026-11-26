using System;
using System.Collections.Generic;
using System.Linq;

namespace SistemaControlProcesos
{
    public class GestorProcesos
    {
        private LinkedList<Proceso> listaProcesos;
        private Queue<Proceso> colaListos;
        private Queue<Proceso> colaCircular;

        private int siguientePID;
        private const int QUANTUM = 3;

        public GestorProcesos()
        {
            listaProcesos = new LinkedList<Proceso>();
            colaListos = new Queue<Proceso>();
            colaCircular = new Queue<Proceso>();

            siguientePID = 1;
        }

        public void CrearProceso()
        {
            Console.Write("Nombre: ");
            string nombre = Console.ReadLine();

            Console.Write("Prioridad: ");
            int prioridad = int.Parse(Console.ReadLine());

            Console.Write("Tiempo de ejecución: ");
            int tiempo = int.Parse(Console.ReadLine());

            Proceso nuevo = new Proceso(
                siguientePID,
                nombre,
                prioridad,
                tiempo
            );

            siguientePID++;

            nuevo.Estado = Estados.LISTO;

            listaProcesos.AddLast(nuevo);

            colaListos.Enqueue(nuevo);
            colaCircular.Enqueue(nuevo);

            Console.WriteLine("Proceso creado correctamente.");
        }

        public void EliminarProceso()
        {
            Console.Write("PID a eliminar: ");
            int pid = int.Parse(Console.ReadLine());

            Proceso proceso = BuscarPID(pid);

            if (proceso == null)
            {
                Console.WriteLine("Proceso no encontrado.");
                return;
            }

            listaProcesos.Remove(proceso);

            ActualizarColas();

            Console.WriteLine("Proceso eliminado.");
        }

        public void EjecutarProceso()
        {
            if (colaCircular.Count == 0)
            {
                Console.WriteLine("No hay procesos listos.");
                return;
            }

            Proceso actual = colaCircular.Dequeue();

            if (actual.Estado != Estados.LISTO)
            {
                return;
            }

            Console.WriteLine(
                "\nEjecutando proceso: " + actual.Nombre
            );

            if (actual.TiempoEjecucion <= QUANTUM)
            {
                actual.TiempoEjecucion = 0;
                actual.Estado = Estados.TERMINADO;

                Console.WriteLine("Proceso terminado.");
            }
            else
            {
                actual.TiempoEjecucion -= QUANTUM;

                Console.WriteLine(
                    "Tiempo restante: " +
                    actual.TiempoEjecucion
                );

                colaCircular.Enqueue(actual);
            }
        }

        public void BloquearProceso()
        {
            Console.Write("PID a bloquear: ");
            int pid = int.Parse(Console.ReadLine());

            Proceso proceso = BuscarPID(pid);

            if (proceso == null)
            {
                Console.WriteLine("Proceso no encontrado.");
                return;
            }

            proceso.Estado = Estados.BLOQUEADO;

            ActualizarColas();

            Console.WriteLine("Proceso bloqueado.");
        }

        public void DesbloquearProceso()
        {
            Console.Write("PID a desbloquear: ");
            int pid = int.Parse(Console.ReadLine());

            Proceso proceso = BuscarPID(pid);

            if (proceso == null)
            {
                Console.WriteLine("Proceso no encontrado.");
                return;
            }

            proceso.Estado = Estados.LISTO;

            colaListos.Enqueue(proceso);
            colaCircular.Enqueue(proceso);

            Console.WriteLine("Proceso desbloqueado.");
        }

        public void MostrarProcesos()
        {
            if (listaProcesos.Count == 0)
            {
                Console.WriteLine("No existen procesos.");
                return;
            }

            Console.WriteLine("\nLISTA DE PROCESOS\n");

            foreach (Proceso proceso in listaProcesos)
            {
                Console.WriteLine(proceso);
            }
        }

        public void BuscarProceso()
        {
            Console.Write("PID a buscar: ");
            int pid = int.Parse(Console.ReadLine());

            Proceso proceso = BuscarPID(pid);

            if (proceso == null)
            {
                Console.WriteLine("Proceso no encontrado.");
                return;
            }

            Console.WriteLine(proceso);
        }

        public void AdministrarCola()
        {
            Console.WriteLine("\nCOLA DE LISTOS");

            foreach (Proceso proceso in colaListos)
            {
                Console.WriteLine(
                    proceso.PID + " - " + proceso.Nombre
                );
            }
        }

        private Proceso BuscarPID(int pid)
        {
            return listaProcesos.FirstOrDefault(
                p => p.PID == pid
            );
        }

        private void ActualizarColas()
        {
            colaListos.Clear();
            colaCircular.Clear();

            foreach (Proceso proceso in listaProcesos)
            {
                if (proceso.Estado == Estados.LISTO)
                {
                    colaListos.Enqueue(proceso);
                    colaCircular.Enqueue(proceso);
                }
            }
        }
    }
}