using App.Services.Interfaces;
using Database.Entities;
using Fitness.Interfaces;

namespace App.Forms;

public partial class FitnessForm : Form, IAvailableFitnessFunctionsSubscriber
{
    private readonly IWindowSwitcherService _windowSwitcher;
    private readonly IFitnessService _fitnessService;
    private readonly IAvailableFitnessFunctionsService _availableFitnessFunctionsService;

    public FitnessForm(
        IWindowSwitcherService windowSwitcher,
        IFitnessService fitnessService,
        IAvailableFitnessFunctionsService availableFitnessFunctionsService
    )
    {
        _windowSwitcher = windowSwitcher;
        _fitnessService = fitnessService;
        _availableFitnessFunctionsService = availableFitnessFunctionsService;

        InitializeComponent();

        _availableFitnessFunctionsService.Subscribe(this);
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

    private void buttonSaveFitness_Click(object sender, EventArgs e)
    {
        var code = textBoxFitnessCode.Text;
        var name = textBoxFitnessName.Text;

        _fitnessService.SaveFitness(code, name);

        textBoxFitnessCode.Text = "";
        textBoxFitnessName.Text = "";
    }

    private void buttonRemoveFitness_Click(object sender, EventArgs e)
    {
        if (comboBoxSavedFitness.SelectedItem is not FitnessFunctionEntity fitnessFunction) return;
        
        _fitnessService.RemoveFitness(fitnessFunction);
    }
    
    private void comboBoxSavedFitness_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (comboBoxSavedFitness.SelectedItem is not FitnessFunctionEntity fitnessFunction) return;

        _fitnessService.ActivateFitness(fitnessFunction);

        textBoxActiveFitness.Text = fitnessFunction.Code;
    }

    public void AvailableFunctionsUpdate(IEnumerable<FitnessFunctionEntity> functions)
    {
        var functionArray = functions.ToArray();

        var selected = comboBoxSavedFitness.SelectedItem as FitnessFunctionEntity;
        comboBoxSavedFitness.Items.Clear();
        comboBoxSavedFitness.Items.Add("None");
        comboBoxSavedFitness.Items.AddRange(functionArray.Cast<object>().ToArray());

        if (selected == null) return;
        if (functionArray.FirstOrDefault(f => f.Id == selected.Id) is not { } newSelected) return;

        comboBoxSavedFitness.SelectedItem = newSelected;
    }

    public void OnFitnessFunctionReset()
    {
        comboBoxSavedFitness.SelectedIndex = -1;
        textBoxActiveFitness.Text = "";
    }
}