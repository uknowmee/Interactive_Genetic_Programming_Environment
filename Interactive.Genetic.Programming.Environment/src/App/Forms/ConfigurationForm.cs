using App.Services.Interfaces;
using Configuration;
using Configuration.Solver;

namespace App.Forms;

public partial class ConfigurationForm : Form
{
    private readonly IWindowSwitcherService _windowSwitcher;
    private readonly IModelConfiguration _modelConfiguration;
    private readonly ISolverConfiguration _solverConfiguration;

    public ConfigurationForm(IWindowSwitcherService windowSwitcher, IModelConfiguration modelConfiguration,
        ISolverConfiguration solverConfiguration)
    {
        _windowSwitcher = windowSwitcher;
        _modelConfiguration = modelConfiguration;
        _solverConfiguration = solverConfiguration;

        InitializeComponent();
    }

    private void Configuration_Load(object sender, EventArgs e)
    {
        WindowState = FormWindowState.Maximized;
        LoadModelConfiguration();
        LoadSolverConfiguration();
    }

    public new void Show()
    {
        Configuration_Load(this, EventArgs.Empty);
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

    private static void EnsureInt(object sender, KeyPressEventArgs e)
    {
        _ = sender as TextBox ?? throw new InvalidOperationException("Sender is not a TextBox");
        if (e.KeyChar == (char)Keys.Enter
            || char.IsDigit(e.KeyChar)
            || e.KeyChar == (char)Keys.Back
            || e.KeyChar == (char)Keys.Delete
        )
        {
            return;
        }

        e.Handled = true;
    }

    private static void EnsureDouble(object sender, KeyPressEventArgs e)
    {
        var textBox = sender as TextBox ?? throw new InvalidOperationException("Sender is not a TextBox");
        if (e.KeyChar == (char)Keys.Enter
            || char.IsDigit(e.KeyChar)
            || (e.KeyChar == '.' && textBox.Text.Contains('.') is false)
            || e.KeyChar == (char)Keys.Back
            || e.KeyChar == (char)Keys.Delete
        )
        {
            return;
        }

        e.Handled = true;
    }
}