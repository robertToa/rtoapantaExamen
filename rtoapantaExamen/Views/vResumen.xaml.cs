namespace rtoapantaExamen.Views;

public partial class vResumen : ContentPage
{
	public vResumen()
	{
		InitializeComponent();
	}

    public vResumen(string usuarioconectado, string nombre, string apellido, int edad, DateTime? fechaInicio, string plan, decimal montoInicial, bool tieneCasillero, decimal pagoMensual, decimal pagoTotal)
    {
        InitializeComponent();
        txtUsuarioConectado.Text = usuarioconectado;
        txtNombre.Text = nombre;
        txtApellido.Text = apellido;
        txtEdad.Text = edad.ToString();
        if(fechaInicio.HasValue)
        {
            txtFechaInicio.Text = fechaInicio.Value.ToString("dd/MM/yyyy");
        }
        txtPlanSeleccionado.Text = plan;
        txtMontoInicial.Text = montoInicial.ToString("F2");
        txtCasillero.Text = tieneCasillero ? "Sí" : "No";
        txtPagoMensual.Text = pagoMensual.ToString("F2");
        txtPagoTotal.Text = pagoTotal.ToString("F2");

    }

    private void btnNuevoRegistro_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new Views.vRegistro(txtUsuarioConectado.Text));
    }

    private void btnCerrarSesion_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new Views.vLogin());
    }

    private void btnExportarTxt_Clicked(object sender, EventArgs e)
    {
        exportarArchivotexto();
    }

    private void exportarArchivotexto()
    {
        string contenido = $"Usuario Conectado: {txtUsuarioConectado.Text}\n" +
            $"Nombre: {txtNombre.Text}\n" +
            $"Apellido: {txtApellido.Text}\n" +
            $"Edad: {txtEdad.Text}\n" +
            $"Fecha de Inicio: {txtFechaInicio.Text}\n" +
            $"Plan Seleccionado: {txtPlanSeleccionado.Text}\n" +
            $"Monto Inicial: {txtMontoInicial.Text}\n" +
            $"Casillero: {txtCasillero.Text}\n" +
            $"Pago Mensual: {txtPagoMensual.Text}\n" +
            $"Pago Total: {txtPagoTotal.Text}";
        string rutaProyecto = AppDomain.CurrentDomain.BaseDirectory;
        string carpeta = Path.Combine(rutaProyecto, "Archivos");
        string rutaArchivo = Path.Combine(carpeta, "examen.txt");
        if (!Directory.Exists(carpeta))
        {
            Directory.CreateDirectory(carpeta);
        }
        if (!File.Exists(rutaArchivo))
        {
            File.Create(rutaArchivo).Dispose();
        }
        using (StreamWriter writer = new StreamWriter(rutaArchivo, true))
        {
            writer.WriteLine(contenido);
        }
        DisplayAlert("Exportación exitosa", $"El archivo {rutaArchivo} se ha exportado correctamente.", "OK");
    }
}