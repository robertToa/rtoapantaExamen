namespace rtoapantaExamen.Views;

public partial class vLogin : ContentPage
{
	public vLogin()
	{
		InitializeComponent();
	}

    private string[,] usuarios = { { "recepcion", "gym2026" }, { "entrenador", "fit_01" }, { "uisrael", "2026" }, { "gerente", "admin123" } };

    private void btnIniciarSesión_Clicked(object sender, EventArgs e)
    {
        string usuario = txtUsuario.Text;
        string contraseña = txtContrasenia.Text;
        if(validarCampos())
        {
            validarUsuario(usuario, contraseña);
        }
    }

    private bool validarCampos()
    {
        if (string.IsNullOrEmpty(txtUsuario.Text) || string.IsNullOrEmpty(txtContrasenia.Text))
        {
            DisplayAlert("Error", "Por favor, complete todos los campos.", "OK");
            return false;
        }
        return true;
    }

    private void validarUsuario(string usuario, string contraseña)
    {
        bool usuarioValido = false;
        for (int i = 0; i < usuarios.GetLength(0); i++)
        {
            if (usuarios[i, 0] == usuario && usuarios[i, 1] == contraseña)
            {
                usuarioValido = true;
                break;
            }
        }
        if (usuarioValido)
        {
            DisplayAlert("Inicio de sesión exitoso", "¡Bienvenido!", "OK");
            Navigation.PushAsync(new vRegistro(usuario));
        }
        else
        {
            DisplayAlert("Error de inicio de sesión", "Usuario o contraseña incorrectos", "OK");
        }
    }

    private void btnAcercaDe_Clicked(object sender, EventArgs e)
    {
        string mensaje = "Examen Aplicaciones Moviles Parcial 1\n" +
            "Estudiante: Roberto Toapanta\n" +
            "Carrera: Ingeniería en Sistemas Informaticos\n" +
            "Paralelo: A\n" +
            "Año: 2026\n";
        DisplayAlert("Acerca de", mensaje, "OK");
    }
}