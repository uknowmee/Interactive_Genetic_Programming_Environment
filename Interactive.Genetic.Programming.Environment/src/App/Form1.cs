namespace App;

public partial class Form1 : Form
{
    private readonly Service1 _service1;
    
    public Form1(Service1 service1)
    {
        _service1 = service1;
        InitializeComponent();
    }
}