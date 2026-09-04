using MesaTechTickets.Estructuras;

namespace MesaTechTickets
{
    public partial class FormPrincipal : Form
    {
        private readonly ListaEnlazadaTickets tickets = new();

        public FormPrincipal()
        {
            InitializeComponent();
        }

        //  MANEJADORES DE EVENTOS
        private void btnRegistrar_Click(object? sender, EventArgs e) => RegistrarTicket();
        private void btnListar_Click(object? sender, EventArgs e) => ListarTickets();
        private void btnBuscar_Click(object? sender, EventArgs e) => BuscarTicket();
        private void btnEliminar_Click(object? sender, EventArgs e) => EliminarTicket();
        private void btnContar_Click(object? sender, EventArgs e) => ContarActivos();
        private void btnPruebas_Click(object? sender, EventArgs e) => EjecutarCasosDePrueba();

        private void Log(string mensaje) => txtLog.AppendText($"{DateTime.Now:HH:mm:ss} - {mensaje}{Environment.NewLine}");

        //  ACCIONES SOBRE LA LISTA ENLAZADA
        private void RegistrarTicket()
        {
            bool exito = tickets.Registrar(txtCodigo.Text, txtDescripcion.Text, cmbPrioridad.Text, out string mensaje);
            Log(exito ? $"OK: {mensaje}" : $"ERROR: {mensaje}");
            if (!exito)
                MessageBox.Show(mensaje, "Dato invalido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                txtCodigo.Clear();
                txtDescripcion.Clear();
            }
            ListarTickets();
        }

        private void ListarTickets()
        {
            lstResultado.Items.Clear();
            var todos = tickets.Listar();
            if (todos.Count == 0)
            {
                lstResultado.Items.Add("(la lista de tickets esta vacia)");
                return;
            }

            lstResultado.Items.Add($"--- Tickets registrados ({todos.Count}), en orden de ingreso ---");
            foreach (var t in todos)
                lstResultado.Items.Add(t.ToString());
        }

        private void BuscarTicket()
        {
            lstResultado.Items.Clear();
            var codigo = txtCodigoBuscar.Text.Trim();
            var resultado = tickets.BuscarPorCodigo(codigo);

            if (resultado == null)
            {
                lstResultado.Items.Add($"No se encontro ningun ticket con el codigo '{codigo}'.");
                Log($"[Buscar] '{codigo}': no encontrado.");
            }
            else
            {
                lstResultado.Items.Add($"Ticket encontrado: {resultado}");
                Log($"[Buscar] '{codigo}': encontrado.");
            }
        }

        private void EliminarTicket()
        {
            var codigo = txtCodigoEliminar.Text.Trim();
            bool exito = tickets.Eliminar(codigo, out string mensaje);
            Log(exito ? $"OK: {mensaje}" : $"ERROR: {mensaje}");
            if (exito)
                txtCodigoEliminar.Clear();
            ListarTickets();
        }

        private void ContarActivos()
        {
            int total = tickets.ContarActivos();
            lstResultado.Items.Clear();
            lstResultado.Items.Add($"Cantidad total de tickets activos: {total}");
            Log($"[Contar] Tickets activos: {total}.");
        }

        private void EjecutarCasosDePrueba()
        {
            lstResultado.Items.Clear();
            Log("=== EJECUTANDO CASOS DE PRUEBA AUTOMATICOS ===");
            var lista = new ListaEnlazadaTickets();
            int caso = 1;

            void Caso(string nombre, Action accion)
            {
                lstResultado.Items.Add($"[Caso {caso}] {nombre}");
                Log($"[Caso {caso}] {nombre}");
                caso++;
                accion();
            }

            void Resultado(bool ok, string detalle)
            {
                string linea = (ok ? "  OK: " : "  FALLO: ") + detalle;
                lstResultado.Items.Add(linea);
                Log(linea);
            }

            Caso("Listar sobre lista vacia", () =>
            {
                var l = lista.Listar();
                Resultado(l.Count == 0, "la lista esta vacia, como se esperaba.");
            });

            Caso("Buscar sobre lista vacia", () =>
            {
                var r = lista.BuscarPorCodigo("TCK001");
                Resultado(r == null, "no se encontro nada, como se esperaba.");
            });

            Caso("Eliminar sobre lista vacia", () =>
            {
                bool ok = lista.Eliminar("TCK001", out string msg);
                Resultado(!ok, msg);
            });

            Caso("Registrar un ticket valido (primer nodo, cabeza de la lista)", () =>
            {
                bool ok = lista.Registrar("TCK001", "Teclado no responde en Lab 3", "Alta", out string msg);
                Resultado(ok, msg);
            });

            Caso("Registrar varios tickets mas (deben quedar en orden de ingreso)", () =>
            {
                lista.Registrar("TCK002", "Sin acceso a Office 365", "Media", out _);
                lista.Registrar("TCK003", "Prestamo de audifonos", "Baja", out _);
                var l = lista.Listar();
                bool ordenOk = l.Count == 3 && l[0].Codigo == "TCK001" && l[1].Codigo == "TCK002" && l[2].Codigo == "TCK003";
                Resultado(ordenOk, "los tickets quedaron en orden de ingreso.");
            });

            Caso("Registrar con codigo vacio (dato invalido)", () =>
            {
                bool ok = lista.Registrar("", "Descripcion cualquiera", "Alta", out string msg);
                Resultado(!ok, msg);
            });

            Caso("Registrar con codigo repetido (dato invalido)", () =>
            {
                bool ok = lista.Registrar("TCK002", "Duplicado del ticket anterior", "Alta", out string msg);
                Resultado(!ok, msg);
            });

            Caso("Buscar un ticket existente", () =>
            {
                var r = lista.BuscarPorCodigo("TCK002");
                Resultado(r != null, $"encontrado -> {r}");
            });

            Caso("Buscar un ticket inexistente", () =>
            {
                var r = lista.BuscarPorCodigo("TCK999");
                Resultado(r == null, "no encontrado, como se esperaba.");
            });

            Caso("Eliminar el ticket del inicio (cabeza)", () =>
            {
                bool ok = lista.Eliminar("TCK001", out string msg);
                bool cabezaOk = lista.Listar().Count > 0 && lista.Listar()[0].Codigo == "TCK002";
                Resultado(ok && cabezaOk, msg);
            });

            Caso("Eliminar un ticket del medio/final", () =>
            {
                bool ok = lista.Eliminar("TCK003", out string msg);
                Resultado(ok, msg);
            });

            Caso("Eliminar un ticket que no existe", () =>
            {
                bool ok = lista.Eliminar("TCK999", out string msg);
                Resultado(!ok, msg);
            });

            Caso("Contar tickets activos al final del recorrido", () =>
            {
                int total = lista.ContarActivos();
                Resultado(total == 1, $"quedan {total} ticket(s) activo(s).");
            });

            Log("=== FIN DE LOS CASOS DE PRUEBA (12 casos ejecutados) ===");
        }
    }
}
