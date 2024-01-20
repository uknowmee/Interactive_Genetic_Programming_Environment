using App.Forms.Scaling;
using App.Services.Interfaces;
using Database.Entities;
using Fitness.Interfaces;
using Shared.Exceptions;
using Solvers;
using Solvers.Interfaces;

namespace App.Forms;

public partial class FitnessForm :
    Form,
    IFormPropertiesProvider<FitnessForm>,
    IAvailableFitnessFunctionsSubscriber,
    ISolverStatusSubscriber
{
    public FormProperties<FitnessForm> FormProperties { get; set; }

    private SolverStatus _status = SolverStatus.Idle;

    private readonly IWindowSwitcherService _windowSwitcher;
    private readonly IFitnessService _fitnessService;
    private readonly IAvailableFitnessFunctionsService _availableFitnessFunctionsService;
    private readonly ISolverService _solverService;

    public FitnessForm(
        IWindowSwitcherService windowSwitcher,
        IFitnessService fitnessService,
        IAvailableFitnessFunctionsService availableFitnessFunctionsService,
        ISolverService solverService
    )
    {
        _windowSwitcher = windowSwitcher;
        _fitnessService = fitnessService;
        _availableFitnessFunctionsService = availableFitnessFunctionsService;
        _solverService = solverService;

        InitializeComponent();
        FormProperties = new FormProperties<FitnessForm>(this);

        _availableFitnessFunctionsService.Subscribe(this);
        _solverService.Subscribe(this);
    }

    private void Fitness_Load(object sender, EventArgs e)
    {
        WindowState = FormWindowState.Maximized;
        _availableFitnessFunctionsService.FetchAllSubscribed();
    }

    public new void Show()
    {
        Fitness_Load(this, EventArgs.Empty);
        base.Show();
    }

    private void FitnessForm_Resize(object sender, EventArgs e)
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

    private void buttonSaveFitness_Click(object sender, EventArgs e)
    {
        var code = textBoxFitnessCode.Text;
        var name = textBoxFitnessName.Text;

        if (string.IsNullOrWhiteSpace(code)) throw new CustomException("Fitness code cannot be empty");
        if (string.IsNullOrWhiteSpace(name)) throw new CustomException("Fitness name cannot be empty");

        _fitnessService.SaveFitness(name, code);

        textBoxFitnessCode.Text = "";
        textBoxFitnessName.Text = "";

        MessageBox.Show(@"Fitness function saved successfully", @"Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    private void buttonRemoveFitness_Click(object sender, EventArgs e)
    {
        if (comboBoxSavedFitness.SelectedItem is not FitnessFunctionEntity fitnessFunction) return;

        _fitnessService.RemoveFitness(fitnessFunction);
    }

    private void comboBoxSavedFitness_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (comboBoxSavedFitness.InvokeRequired)
        {
            comboBoxSavedFitness.BeginInvoke(SelectedFitnessChange);
        }
        else
        {
            SelectedFitnessChange();
        }
    }

    private void SelectedFitnessChange()
    {
        if (comboBoxSavedFitness.SelectedItem is not FitnessFunctionEntity fitnessFunction) return;
        _fitnessService.ActivateFitness(fitnessFunction);

        textBoxActiveFitness.BeginInvoke(() => textBoxActiveFitness.Text = fitnessFunction.Code);
    }

    public void AvailableFunctionsUpdate(IEnumerable<FitnessFunctionEntity> functions)
    {
        if (comboBoxSavedFitness.InvokeRequired)
        {
            comboBoxSavedFitness.BeginInvoke(() => UpdateAvailableFunctions(functions));
        }
        else
        {
            UpdateAvailableFunctions(functions);
        }
    }

    private void UpdateAvailableFunctions(IEnumerable<FitnessFunctionEntity> functions)
    {
        var functionArray = functions.ToArray();

        var selected = comboBoxSavedFitness.SelectedItem as FitnessFunctionEntity;
        comboBoxSavedFitness.Items.Clear();
        comboBoxSavedFitness.Items.AddRange(functionArray.Cast<object>().ToArray());

        if (selected == null) return;
        if (functionArray.FirstOrDefault(f => f.Id == selected.Id) is not { } newSelected) return;

        comboBoxSavedFitness.SelectedItem = newSelected;
    }

    public void OnFitnessFunctionReset()
    {
        if (comboBoxSavedFitness.InvokeRequired)
        {
            comboBoxSavedFitness.BeginInvoke(() => comboBoxSavedFitness.SelectedIndex = -1);
        }
        else
        {
            comboBoxSavedFitness.SelectedIndex = -1;
        }

        if (textBoxActiveFitness.InvokeRequired)
        {
            textBoxActiveFitness.BeginInvoke(() => textBoxActiveFitness.Text = "");
        }
        else
        {
            textBoxActiveFitness.Text = "";
        }
    }

    public void OnSolverStatusUpdate(SolverStatus status)
    {
        _status = status;

        if (buttonRemoveFitness.InvokeRequired)
        {
            buttonRemoveFitness.BeginInvoke(() => buttonRemoveFitness.Enabled = _status == SolverStatus.Idle);
        }
        else
        {
            buttonRemoveFitness.Enabled = _status == SolverStatus.Idle;
        }
    }

    private void FitnessForm_FormClosed(object sender, FormClosedEventArgs e)
    {
        _windowSwitcher.Quit(this);
    }
}