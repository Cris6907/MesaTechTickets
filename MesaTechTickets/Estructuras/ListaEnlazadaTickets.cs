using System;
using System.Collections.Generic;

namespace MesaTechTickets.Estructuras
{
    public class ListaEnlazadaTickets
    {
        private Nodo? head;

        public bool EstaVacia => head == null;

        public bool Registrar(string? codigo, string? descripcion, string? prioridad, out string mensaje)
        {
            if (string.IsNullOrWhiteSpace(codigo))
            {
                mensaje = "Error: el codigo del ticket no puede estar vacio.";
                return false;
            }

            codigo = codigo.Trim();

            if (BuscarPorCodigo(codigo) != null)
            {
                mensaje = $"Error: ya existe un ticket registrado con el codigo '{codigo}'.";
                return false;
            }

            var nuevo = new Nodo(codigo, (descripcion ?? "").Trim(), string.IsNullOrWhiteSpace(prioridad) ? "Media" : prioridad.Trim());

            if (head == null)
            {
                head = nuevo;
            }
            else
            {
                var actual = head;
                while (actual.Siguiente != null)
                    actual = actual.Siguiente;
                actual.Siguiente = nuevo;
            }

            mensaje = $"Ticket '{codigo}' registrado correctamente.";
            return true;
        }

        public List<Nodo> Listar()
        {
            var resultado = new List<Nodo>();
            var actual = head;
            while (actual != null)
            {
                resultado.Add(actual);
                actual = actual.Siguiente;
            }
            return resultado;
        }

        public Nodo? BuscarPorCodigo(string? codigo)
        {
            if (string.IsNullOrWhiteSpace(codigo)) return null;
            codigo = codigo.Trim();

            var actual = head;
            while (actual != null)
            {
                if (actual.Codigo.Equals(codigo, StringComparison.OrdinalIgnoreCase))
                    return actual;
                actual = actual.Siguiente;
            }
            return null;
        }

        public bool Eliminar(string? codigo, out string mensaje)
        {
            if (string.IsNullOrWhiteSpace(codigo))
            {
                mensaje = "Error: ingrese un codigo para eliminar.";
                return false;
            }
            codigo = codigo.Trim();

            if (head == null)
            {
                mensaje = "La lista de tickets esta vacia: no hay nada que eliminar.";
                return false;
            }

            if (head.Codigo.Equals(codigo, StringComparison.OrdinalIgnoreCase))
            {
                head = head.Siguiente;
                mensaje = $"Ticket '{codigo}' eliminado (estaba al inicio de la lista).";
                return true;
            }

            var anterior = head;
            var actual = head.Siguiente;
            while (actual != null)
            {
                if (actual.Codigo.Equals(codigo, StringComparison.OrdinalIgnoreCase))
                {
                    anterior.Siguiente = actual.Siguiente;
                    mensaje = $"Ticket '{codigo}' eliminado correctamente.";
                    return true;
                }
                anterior = actual;
                actual = actual.Siguiente;
            }

            mensaje = $"No se encontro ningun ticket con el codigo '{codigo}'.";
            return false;
        }

        public int ContarActivos()
        {
            int contador = 0;
            var actual = head;
            while (actual != null)
            {
                contador++;
                actual = actual.Siguiente;
            }
            return contador;
        }
    }
}
