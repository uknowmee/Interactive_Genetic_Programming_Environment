using App.Forms.Scaling;
using App.Services.Interfaces;
using Configuration;
using Configuration.App;
using Configuration.Solver;

namespace App.Forms;

public partial class ConfigurationForm : Form, IFormPropertiesProvider<ConfigurationForm>
{
    public FormProperties<ConfigurationForm> FormProperties { get; set; }

    private readonly IWindowSwitcherService _windowSwitcher;
    private readonly IModelConfiguration _modelConfiguration;
    private readonly ISolverConfiguration _solverConfiguration;
    private readonly IAppConfiguration _appConfiguration;

    public ConfigurationForm(
        IWindowSwitcherService windowSwitcher,
        IModelConfiguration modelConfiguration,
        ISolverConfiguration solverConfiguration,
        IAppConfiguration appConfiguration
    )
    {
        _windowSwitcher = windowSwitcher;
        _modelConfiguration = modelConfiguration;
        _solverConfiguration = solverConfiguration;
        _appConfiguration = appConfiguration;

        InitializeComponent();

        FormProperties = new FormProperties<ConfigurationForm>(this);
    }

    private void Configuration_Load(object sender, EventArgs e)
    {
        WindowState = FormWindowState.Maximized;
        LoadModelConfiguration();
        LoadSolverConfiguration();

        buttonTaskFormatSwitcher.Text = _appConfiguration.ReadTaskFromJson ? "JSON" : "CSV";
    }

    public new void Show()
    {
        Configuration_Load(this, EventArgs.Empty);
        base.Show();
    }

    private void ConfigurationForm_Resize(object sender, EventArgs e)
    {
        if (this.CanResize() is false) return;
        FormProperties.MinimizeMaximizeChange = this.ResizeDecision();
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

    private void buttonInterpreter_Click(object sender, EventArgs e)
    {
        _windowSwitcher.Switch<InterpreterForm>(this);
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

    private void buttonTaskFormatSwitcher_Click(object sender, EventArgs e)
    {
        _appConfiguration.ReadTaskFromJson = !_appConfiguration.ReadTaskFromJson;
        buttonTaskFormatSwitcher.Text = _appConfiguration.ReadTaskFromJson ? "JSON" : "CSV";
    }

    private void ConfigurationForm_FormClosed(object sender, FormClosedEventArgs e)
    {
        _windowSwitcher.Quit(this);
    }
}