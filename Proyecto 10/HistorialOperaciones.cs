using System;
using System.Collections.Generic;

namespace Proyecto_10_Tienda_en_Linea;

public class HistorialOperaciones
{
    private Stack<string> historial = new Stack<string>();

    public void Agregar(string operacion)
    {
        historial.Push(operacion);
    }

    public void Mostrar()
    {
        foreach (string op in historial)
        {
            System.Console.WriteLine(op);
        }
    }
}
