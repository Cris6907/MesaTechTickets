namespace MesaTechTickets
{
    partial class FormPrincipal
    {
        /// <summary>
        /// Requerido por el diseñador de Visual Studio. Sin este campo (y el
        /// Dispose de abajo) el diseñador WinForms para proyectos .NET moderno
        /// no reconoce la clase como un formulario "de diseñador".
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>Limpia los recursos usados.</summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        // ---------- Controles (todos como campos: el disenador de VS solo puede
        // parsear InitializeComponent si cada control es un campo de la clase,
        // instanciado con tipo explicito y sin inicializadores de objeto {}) ----------
        private GroupBox grpRegistro;
        private Label lblCodigo;
        private TextBox txtCodigo;
        private Label lblDescripcion;
        private TextBox txtDescripcion;
        private Label lblPrioridad;
        private ComboBox cmbPrioridad;
        private Button btnRegistrar;
        private Button btnListar;

        private GroupBox grpBuscar;
        private Label lblCodigoBuscar;
        private TextBox txtCodigoBuscar;
        private Button btnBuscar;

        private GroupBox grpEliminar;
        private Label lblCodigoEliminar;
        private TextBox txtCodigoEliminar;
        private Button btnEliminar;

        private GroupBox grpPruebas;
        private Button btnContar;
        private Button btnPruebas;

        private GroupBox grpResultado;
        private ListBox lstResultado;

        private GroupBox grpLog;
        private TextBox txtLog;

        /// <summary>
        /// Metodo que el diseñador de Visual Studio ejecuta para dibujar la vista
        /// previa del formulario. Sigue el patron estricto que el diseñador puede
        /// parsear: cada control es un campo, se instancia sin inicializador de
        /// objeto y sus propiedades se asignan una por linea.
        /// </summary>
        private void InitializeComponent()
        {
            grpRegistro = new GroupBox();
            lblCodigo = new Label();
            txtCodigo = new TextBox();
            lblDescripcion = new Label();
            txtDescripcion = new TextBox();
            lblPrioridad = new Label();
            cmbPrioridad = new ComboBox();
            btnRegistrar = new Button();
            btnListar = new Button();

            grpBuscar = new GroupBox();
            lblCodigoBuscar = new Label();
            txtCodigoBuscar = new TextBox();
            btnBuscar = new Button();

            grpEliminar = new GroupBox();
            lblCodigoEliminar = new Label();
            txtCodigoEliminar = new TextBox();
            btnEliminar = new Button();

            grpPruebas = new GroupBox();
            btnContar = new Button();
            btnPruebas = new Button();

            grpResultado = new GroupBox();
            lstResultado = new ListBox();

            grpLog = new GroupBox();
            txtLog = new TextBox();

            grpRegistro.SuspendLayout();
            grpBuscar.SuspendLayout();
            grpEliminar.SuspendLayout();
            grpPruebas.SuspendLayout();
            grpResultado.SuspendLayout();
            grpLog.SuspendLayout();
            SuspendLayout();

            // --- Panel de registro ---
            grpRegistro.Text = "1) Registrar ticket (Lista Enlazada Simple)";
            grpRegistro.Left = 10;
            grpRegistro.Top = 10;
            grpRegistro.Width = 460;
            grpRegistro.Height = 210;

            lblCodigo.Text = "Codigo:";
            lblCodigo.Left = 10;
            lblCodigo.Top = 25;
            lblCodigo.Width = 80;

            txtCodigo.Left = 100;
            txtCodigo.Top = 22;
            txtCodigo.Width = 150;

            lblDescripcion.Text = "Descripcion:";
            lblDescripcion.Left = 10;
            lblDescripcion.Top = 55;
            lblDescripcion.Width = 80;

            txtDescripcion.Left = 100;
            txtDescripcion.Top = 52;
            txtDescripcion.Width = 340;

            lblPrioridad.Text = "Prioridad:";
            lblPrioridad.Left = 10;
            lblPrioridad.Top = 85;
            lblPrioridad.Width = 80;

            cmbPrioridad.Left = 100;
            cmbPrioridad.Top = 82;
            cmbPrioridad.Width = 150;
            cmbPrioridad.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPrioridad.Items.AddRange(new object[] { "Alta", "Media", "Baja" });
            cmbPrioridad.SelectedIndex = 1;

            btnRegistrar.Text = "Registrar ticket";
            btnRegistrar.Left = 10;
            btnRegistrar.Top = 120;
            btnRegistrar.Width = 150;
            btnRegistrar.Click += btnRegistrar_Click;

            btnListar.Text = "Listar todos";
            btnListar.Left = 170;
            btnListar.Top = 120;
            btnListar.Width = 130;
            btnListar.Click += btnListar_Click;

            grpRegistro.Controls.Add(lblCodigo);
            grpRegistro.Controls.Add(txtCodigo);
            grpRegistro.Controls.Add(lblDescripcion);
            grpRegistro.Controls.Add(txtDescripcion);
            grpRegistro.Controls.Add(lblPrioridad);
            grpRegistro.Controls.Add(cmbPrioridad);
            grpRegistro.Controls.Add(btnRegistrar);
            grpRegistro.Controls.Add(btnListar);

            // --- Panel de busqueda ---
            grpBuscar.Text = "2) Buscar ticket por codigo";
            grpBuscar.Left = 480;
            grpBuscar.Top = 10;
            grpBuscar.Width = 460;
            grpBuscar.Height = 90;

            lblCodigoBuscar.Text = "Codigo:";
            lblCodigoBuscar.Left = 10;
            lblCodigoBuscar.Top = 30;
            lblCodigoBuscar.Width = 80;

            txtCodigoBuscar.Left = 100;
            txtCodigoBuscar.Top = 27;
            txtCodigoBuscar.Width = 150;

            btnBuscar.Text = "Buscar";
            btnBuscar.Left = 270;
            btnBuscar.Top = 25;
            btnBuscar.Width = 120;
            btnBuscar.Click += btnBuscar_Click;

            grpBuscar.Controls.Add(lblCodigoBuscar);
            grpBuscar.Controls.Add(txtCodigoBuscar);
            grpBuscar.Controls.Add(btnBuscar);

            // --- Panel de eliminacion ---
            grpEliminar.Text = "3) Eliminar ticket por codigo";
            grpEliminar.Left = 480;
            grpEliminar.Top = 110;
            grpEliminar.Width = 460;
            grpEliminar.Height = 90;

            lblCodigoEliminar.Text = "Codigo:";
            lblCodigoEliminar.Left = 10;
            lblCodigoEliminar.Top = 30;
            lblCodigoEliminar.Width = 80;

            txtCodigoEliminar.Left = 100;
            txtCodigoEliminar.Top = 27;
            txtCodigoEliminar.Width = 150;

            btnEliminar.Text = "Eliminar";
            btnEliminar.Left = 270;
            btnEliminar.Top = 25;
            btnEliminar.Width = 120;
            btnEliminar.Click += btnEliminar_Click;

            grpEliminar.Controls.Add(lblCodigoEliminar);
            grpEliminar.Controls.Add(txtCodigoEliminar);
            grpEliminar.Controls.Add(btnEliminar);

            // --- Panel de pruebas / contador ---
            grpPruebas.Text = "4) Contador y casos de prueba";
            grpPruebas.Left = 480;
            grpPruebas.Top = 210;
            grpPruebas.Width = 460;
            grpPruebas.Height = 90;

            btnContar.Text = "Contar tickets activos";
            btnContar.Left = 10;
            btnContar.Top = 30;
            btnContar.Width = 190;
            btnContar.Click += btnContar_Click;

            btnPruebas.Text = "Ejecutar casos de prueba automaticos";
            btnPruebas.Left = 210;
            btnPruebas.Top = 30;
            btnPruebas.Width = 230;
            btnPruebas.Click += btnPruebas_Click;

            grpPruebas.Controls.Add(btnContar);
            grpPruebas.Controls.Add(btnPruebas);

            // --- Resultado ---
            grpResultado.Text = "Resultado";
            grpResultado.Left = 10;
            grpResultado.Top = 230;
            grpResultado.Width = 460;
            grpResultado.Height = 300;

            lstResultado.Left = 10;
            lstResultado.Top = 20;
            lstResultado.Width = 435;
            lstResultado.Height = 265;
            lstResultado.HorizontalScrollbar = true;

            grpResultado.Controls.Add(lstResultado);

            // --- Bitacora ---
            grpLog.Text = "Bitacora de ejecucion";
            grpLog.Left = 480;
            grpLog.Top = 310;
            grpLog.Width = 460;
            grpLog.Height = 220;

            txtLog.Left = 10;
            txtLog.Top = 20;
            txtLog.Width = 435;
            txtLog.Height = 185;
            txtLog.Multiline = true;
            txtLog.ScrollBars = ScrollBars.Vertical;
            txtLog.ReadOnly = true;

            grpLog.Controls.Add(txtLog);

            // --- Formulario ---
            // AutoScaleMode.Font (el valor por defecto) reescala las coordenadas
            // absolutas de cada control segun el DPI/fuente del monitor donde se
            // ejecute. Con AutoScaleMode.Dpi las coordenadas se mantienen estables.
            AutoScaleMode = AutoScaleMode.Dpi;
            Font = new Font("Segoe UI", 9F);
            Text = "MesaTech - Gestor de Tickets de Soporte Academico";
            // ClientSize define el area interior real (sin contar borde ni barra de
            // titulo). El contenido llega hasta 950 x 540, asi que se deja margen.
            ClientSize = new Size(970, 570);
            AutoScroll = true;
            StartPosition = FormStartPosition.CenterScreen;

            Controls.Add(grpRegistro);
            Controls.Add(grpBuscar);
            Controls.Add(grpEliminar);
            Controls.Add(grpPruebas);
            Controls.Add(grpResultado);
            Controls.Add(grpLog);

            grpRegistro.ResumeLayout(false);
            grpBuscar.ResumeLayout(false);
            grpEliminar.ResumeLayout(false);
            grpPruebas.ResumeLayout(false);
            grpResultado.ResumeLayout(false);
            grpLog.ResumeLayout(false);
            ResumeLayout(false);
        }
    }
}
