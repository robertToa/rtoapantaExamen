using System.ComponentModel.DataAnnotations;

namespace rtoapantaExamen.Views;

public partial class vRegistro : ContentPage
{
    private string usuarioConectado;
    public vRegistro()
	{
		InitializeComponent();
	}

    public vRegistro(String usuario)
    {
        InitializeComponent();
        txtUsuarioConectado.Text = usuario;
        this.usuarioConectado = usuario;
    }

    private void btnCalcularPagoMensual_Clicked(object sender, EventArgs e)
    {
        if(validarCampos())
        {
            double costoMembresia = 1200;
            decimal montoInicial = decimal.Parse(txtMontoInicial.Text);
            bool tieneCasillero = switchCasillero.IsToggled;
            decimal montoRestante = (decimal)costoMembresia - montoInicial;
            decimal montoCouta = (montoRestante / 5 ) * 1.02m;
            if(tieneCasillero)
            {
                montoCouta += 10;
            }
            txtPagoMensual.Text = montoCouta.ToString("F2");
        }
    }

	private bool validarCampos()
    {

        if (string.IsNullOrWhiteSpace(txtNombre.Text) || string.IsNullOrWhiteSpace(txtApellido.Text) || string.IsNullOrWhiteSpace(txtEdad.Text))
        {
            DisplayAlert("Error", "Todos los campos del clente son obligatorios.", "OK");
            return false;
        }
        if (datePickerInicio.Date <= DateTime.MinValue)
        {
            DisplayAlert("Error", "Seleccione una fecha de inicio válida.", "OK");
            return false;
        }
        if (pickerPlan.SelectedItem == null)
        {
            DisplayAlert("Error", "Seleccione un plan válido.", "OK");
            return false;
        }
        if (string.IsNullOrWhiteSpace(txtMontoInicial.Text) || !decimal.TryParse(txtMontoInicial.Text, out _))
        {
            DisplayAlert("Error", "Ingrese un monto inicial válido.", "OK");
            return false;
        }
        if (!decimal.TryParse(txtMontoInicial.Text, out decimal montoInicial) || montoInicial < 120 || montoInicial > 600)
        {
            DisplayAlert("Error", "El monto inicial debe estar entre 120 y 600.", "OK");
            return false;
        }

        return true;
    }

    private void btnResumen_Clicked(object sender, EventArgs e)
    {
        if (validarCampos() && txtPagoMensual.Text != null)
        {
            decimal pagoTotal = decimal.Parse(txtPagoMensual.Text) * 5;
            Navigation.PushAsync(new Views.vResumen(usuarioConectado, txtNombre.Text, txtApellido.Text, int.Parse(txtEdad.Text), datePickerInicio.Date, pickerPlan.SelectedItem.ToString(), decimal.Parse(txtMontoInicial.Text), switchCasillero.IsToggled, decimal.Parse(txtPagoMensual.Text), pagoTotal));
        }
    }
}