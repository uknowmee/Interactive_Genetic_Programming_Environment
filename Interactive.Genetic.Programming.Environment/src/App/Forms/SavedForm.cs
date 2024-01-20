using App.Forms.Scaling;
using App.Services.Interfaces;
using Database.Entities;
using Solution.Interfaces;

namespace App.Forms;

public partial class SavedForm :
    Form,
    IFormPropertiesProvider<SavedForm>,
    IAvailableSolutionsSubscriber
{
    public FormProperties<SavedForm> FormProperties { get; set; }

    private readonly IWindowSwitcherService _windowSwitcher;
    private readonly IAvailableSolutionsService _solutionService;

    public SavedForm(
        IWindowSwitcherService windowSwitcher,
        IAvailableSolutionsService solutionService
    )
    {
        _windowSwitcher = windowSwitcher;
        _solutionService = solutionService;

        InitializeComponent();
        FormProperties = new FormProperties<SavedForm>(this);

        _solutionService.Subscribe(this);
    }

    private void Saved_Load(object sender, EventArgs e)
    {
        WindowState = FormWindowState.Maximized;
        _solutionService.FetchAllSubscribed();
    }

    public new void Show()
    {
        Saved_Load(this, EventArgs.Empty);
        base.Show();
    }

    private void SavedForm_Resize(object sender, EventArgs e)
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

    private void buttonInspectSolution_Click(object sender, EventArgs e)
    {
        if (comboBoxSavedSolution.SelectedItem is not SolutionEntity solution) return;
        _solutionService.InspectSolution(solution);
    }

    private void buttonRemoveSolution_Click(object sender, EventArgs e)
    {
        if (comboBoxSavedSolution.SelectedItem is not SolutionEntity solution) return;
        _solutionService.RemoveSolution(solution);
    }

    private void comboBoxSavedSolution_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (comboBoxSavedSolution.InvokeRequired)
        {
            comboBoxSavedSolution.BeginInvoke(SelectedSolutionChange);
        }
        else
        {
            SelectedSolutionChange();
        }
    }

    public void AvailableSolutionsUpdate(IEnumerable<SolutionEntity> solutions)
    {
        if (comboBoxSavedSolution.InvokeRequired)
        {
            comboBoxSavedSolution.BeginInvoke(() => UpdateAvailableSolutions(solutions));
        }
        else
        {
            UpdateAvailableSolutions(solutions);
        }
    }

    private void UpdateAvailableSolutions(IEnumerable<SolutionEntity> solutions)
    {
        var solutionsArray = solutions.ToArray();

        var selected = comboBoxSavedSolution.SelectedItem as SolutionEntity;
        comboBoxSavedSolution.Items.Clear();
        comboBoxSavedSolution.Items.AddRange(solutionsArray.Cast<object>().ToArray());

        if (selected == null) return;
        if (solutionsArray.FirstOrDefault(t => t.Id == selected.Id) is not { } newSelected)
        {
            UnLoadSolution();
            return;
        }

        comboBoxSavedSolution.SelectedItem = newSelected;
    }

    private void SelectedSolutionChange()
    {
        if (comboBoxSavedSolution.SelectedItem is not SolutionEntity solution)
        {
            UnLoadSolution();
            return;
        }

        LoadSolution(solution);
    }

    private void LoadSolution(SolutionEntity solution)
    {
        textBoxConfiguration.Text = $@"{solution.InitialModelConfiguration}" +
                                    $@"{Environment.NewLine}{Environment.NewLine}" +
                                    $@"{solution.InitialSolverConfiguration}";
        textBoxHistory.Text = solution.History;
        textBoxProgram.Text = solution.BestIndividual;

        comboBoxFitness.Items.Clear();
        comboBoxFitness.Items.AddRange(solution.FitnessFunctions.Cast<object>().ToArray());
        comboBoxFitness.SelectedItem = solution.FitnessFunctions.First();
    }

    private void UnLoadSolution()
    {
        textBoxConfiguration.Text = string.Empty;
        textBoxHistory.Text = string.Empty;
        textBoxProgram.Text = string.Empty;

        textBoxFitness.Text = string.Empty;
        comboBoxFitness.Items.Clear();
    }

    private void comboBoxFitness_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (comboBoxFitness.SelectedItem is not SolutionFitnessFunction fitness) return;
        textBoxFitness.Text = fitness.Code;
    }

    private void buttonPlot_Click(object sender, EventArgs e)
    {
        if (comboBoxSavedSolution.SelectedItem is not SolutionEntity solution) return;

        PrintPlot(solution);
    }

    private void SavedForm_FormClosed(object sender, FormClosedEventArgs e)
    {
        _windowSwitcher.Quit(this);
    }
}