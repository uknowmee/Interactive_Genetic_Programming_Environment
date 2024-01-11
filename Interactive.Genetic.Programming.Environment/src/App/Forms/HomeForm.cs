using System.Globalization;
using App.Services.Interfaces;
using Fitness.Interfaces;
using History.Interfaces;
using Solvers;
using Solvers.Interfaces;
using Tasks.Interfaces;

namespace App.Forms;

public partial class HomeForm : Form, ISolverSubscriber, IHistorySubscriber, IFitnessInformationSubscriber, ITaskInformationSubscriber
{
    private readonly IWindowSwitcherService _windowSwitcher;
    private readonly ISolverService _solver;
    private readonly IHistoryPublisher _historyPublisher;
    private readonly IFitnessInformationPublisher _fitnessInformationPublisher;
    private readonly ITaskInformationPublisher _taskInformationPublisher;

    public HomeForm(
        IWindowSwitcherService windowSwitcher,
        ISolverService solver,
        IHistoryPublisher historyPublisher,
        IFitnessInformationPublisher fitnessInformationPublisher,
        ITaskInformationPublisher taskInformationPublisher
    )
    {
        _windowSwitcher = windowSwitcher;
        _solver = solver;
        _historyPublisher = historyPublisher;
        _fitnessInformationPublisher = fitnessInformationPublisher;
        _taskInformationPublisher = taskInformationPublisher;

        InitializeComponent();

        _solver.Subscribe(this);
        _historyPublisher.Subscribe(this);
        _fitnessInformationPublisher.Subscribe(this);
        _taskInformationPublisher.Subscribe(this);
    }

    private void Home_Load(object sender, EventArgs e)
    {
        WindowState = FormWindowState.Maximized;
        _solver.FetchAllSubscribed();
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

    private void buttonStart_Click(object sender, EventArgs e)
    {
        _solver.Start();
    }

    private void buttonStop_Click(object sender, EventArgs e)
    {
        _solver.Stop();
    }

    private void buttonFinish_Click(object sender, EventArgs e)
    {
        _solver.Finish();
    }

    public void OnSolverStatusUpdate(SolverStatus status)
    {
        labelStatusValue.Text = status.ToString();
    }

    public void OnPopulationSizeUpdate(int size)
    {
        labelPopulationSizeValue.Text = size.ToString();
    }

    public void OnBestIndividualUpdate(string program)
    {
        textBoxBestIndividual.Text = program;
    }

    public void BestIndividualFitnessUpdate(double fitness)
    {
        labelBestIndividualValue.Text = fitness.ToString(CultureInfo.InvariantCulture);
    }

    public void OnAvgFitnessUpdate(double avgFitness)
    {
        labelAvgFitnessValue.Text = avgFitness.ToString(CultureInfo.InvariantCulture);
    }

    public void OnProceededUpdate(int percent)
    {
        labelProcedeedValue.Text = $@"{percent}%";
    }

    public void OnHistoryUpdate(string update)
    {
        textBoxHistory.Text += update;
    }

    public void OnHistoryClear()
    {
        textBoxHistory.Text = string.Empty;
    }

    public void OnFitnessFunctionChange(string functionName)
    {
        labelFitnessFunctionName.Text = functionName;
    }

    public void OnFitnessFunctionReset()
    {
        labelFitnessFunctionName.Text = @"None";
    }

    public void OnTaskChange(string taskName)
    {
        labelTaskName.Text = taskName;
    }

    public void OnTaskReset()
    {
        labelFitnessFunctionName.Text = @"None";
    }
}