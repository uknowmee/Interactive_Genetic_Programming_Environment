using App.Services.Interfaces;

namespace App.Forms;

public partial class HomeForm : Form
{
    private readonly IWindowSwitcherService _windowSwitcher;

    public HomeForm(IWindowSwitcherService windowSwitcher)
    {
        _windowSwitcher = windowSwitcher;
        InitializeComponent();
    }

    private void Home_Load(object sender, EventArgs e)
    {
        WindowState = FormWindowState.Maximized;
    }

    public new void Show()
    {
        Home_Load(this, EventArgs.Empty);
        base.Show();
    }

    private void buttonHome_Click(object sender, EventArgs e)
    {
        _windowSwitcher.Switch<HomeForm>(this);
    }

    private void buttonConfiguration_Click(object sender, EventArgs e)
    {
        _windowSwitcher.Switch<ConfigurationForm>(this);
    }

    private void buttonFitness_Click(object sender, EventArgs e)
    {
        _windowSwitcher.Switch<FitnessForm>(this);
    }

    private void buttonTask_Click(object sender, EventArgs e)
    {
        _windowSwitcher.Switch<TaskForm>(this);
    }

    private void buttonSaved_Click(object sender, EventArgs e)
    {
        _windowSwitcher.Switch<SavedForm>(this);
    }

    private void buttonQuit_Click(object sender, EventArgs e)
    {
        _windowSwitcher.Quit(this);
    }
}