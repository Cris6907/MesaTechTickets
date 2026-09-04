namespace MesaTechTickets.Estructuras
{
    public class Nodo
    {
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public string Prioridad { get; set; }
        public Nodo? Siguiente { get; set; }

        public Nodo(string codigo, string descripcion, string prioridad)
        {
            Codigo = codigo;
            Descripcion = descripcion;
            Prioridad = prioridad;
            Siguiente = null;
        }

        public override string ToString() => $"[{Codigo}] Prioridad: {Prioridad} - {Descripcion}";
    }
}
