namespace App;

public partial class Home : Form
{
    private readonly Service1 _service1;

    public Home(Service1 service1)
    {
        _service1 = service1;
        InitializeComponent();
    }

    private void Home_Load(object sender, EventArgs e)
    {
        WindowState = FormWindowState.Maximized;
    }
}