using System.Globalization;
using App.Services.Interfaces;
using Configuration;
using Configuration.Interfaces;
using Configuration.Solver;
using Fitness.Interfaces;
using History.Interfaces;
using Solvers;
using Solvers.Interfaces;
using Tasks.Interfaces;

namespace App.Forms;

public partial class HomeForm : Form, ISolverSubscriber, IHistorySubscriber, IFitnessInformationSubscriber, ITaskInformationSubscriber, IConfigurationChangeFullSubscriber
{
    private readonly IWindowSwitcherService _windowSwitcher;
    private readonly ISolverService _solver;
    private readonly IHistoryPublisher _historyPublisher;
    private readonly IFitnessInformationPublisher _fitnessInformationPublisher;
    private readonly ITaskInformationPublisher _taskInformationPublisher;
    private readonly ISolverConfigurationChangePublisher _solverConfigurationChangePublisher;

    public HomeForm(
        IWindowSwitcherService windowSwitcher,
        ISolverService solver,
        IHistoryPublisher historyPublisher,
        IFitnessInformationPublisher fitnessInformationPublisher,
        ITaskInformationPublisher taskInformationPublisher,
        ISolverConfigurationChangePublisher solverConfigurationChangePublisher
    )
    {
        _windowSwitcher = windowSwitcher;
        _solver = solver;
        _historyPublisher = historyPublisher;
        _fitnessInformationPublisher = fitnessInformationPublisher;
        _taskInformationPublisher = taskInformationPublisher;
        _solverConfigurationChangePublisher = solverConfigurationChangePublisher;

        InitializeComponent();

        _solver.Subscribe(this);
        _historyPublisher.Subscribe(this);
        _fitnessInformationPublisher.Subscribe(this);
        _taskInformationPublisher.Subscribe(this);
        _solverConfigurationChangePublisher.Subscribe(this);
    }

    private void Home_Load(object sender, EventArgs e)
    {
        WindowState = FormWindowState.Maximized;
        
        _solver.FetchAllSubscribed();
        _fitnessInformationPublisher.FetchAllSubscribed();
        _taskInformationPublisher.FetchAllSubscribed();
        _solverConfigurationChangePublisher.FetchAllSubscribed(this);
    }

    public new void Show()
    {
        Home_Load(this, EventArgs.Empty);
        base.Show();
        ScrollHistoryDown();
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
        if (labelStatusValue.InvokeRequired)
        {
            labelStatusValue.Invoke(new Action(() => labelStatusValue.Text = status.ToString()));
        }
        else
        {
            labelStatusValue.Text = status.ToString();
        }
    }

    public void OnPopulationSizeUpdate(int size)
    {
        if (labelPopulationSizeValue.InvokeRequired)
        {
            labelPopulationSizeValue.Invoke(new Action(() => labelPopulationSizeValue.Text = size.ToString()));
        }
        else
        {
            labelPopulationSizeValue.Text = size.ToString();
        }
    }

    public void OnBestIndividualUpdate(string program)
    {
        if (textBoxBestIndividual.InvokeRequired)
        {
            textBoxBestIndividual.Invoke(new Action(() => textBoxBestIndividual.Text = program));
        }
        else
        {
            textBoxBestIndividual.Text = program;
        }
    }

    public void BestIndividualFitnessUpdate(double fitness)
    {
        if (labelBestIndividualValue.InvokeRequired)
        {
            labelBestIndividualValue.Invoke(new Action(() => labelBestIndividualValue.Text = fitness.ToString(CultureInfo.InvariantCulture)));
        }
        else
        {
            labelBestIndividualValue.Text = fitness.ToString(CultureInfo.InvariantCulture);
        }
    }

    public void OnAvgFitnessUpdate(double avgFitness)
    {
        if (labelAvgFitnessValue.InvokeRequired)
        {
            labelAvgFitnessValue.Invoke(new Action(() => labelAvgFitnessValue.Text = avgFitness.ToString(CultureInfo.InvariantCulture)));
        }
        else
        {
            labelAvgFitnessValue.Text = avgFitness.ToString(CultureInfo.InvariantCulture);
        }
    }

    public void OnProceededUpdate(int percent)
    {
        if (labelProcedeedValue.InvokeRequired)
        {
            labelProcedeedValue.Invoke(new Action(() => labelProcedeedValue.Text = $@"{percent}%"));
        }
        else
        {
            labelProcedeedValue.Text = $@"{percent}%";
        }
    }

    public void OnHistoryUpdate(string update)
    {
        if (textBoxHistory.InvokeRequired)
        {
            textBoxHistory.Invoke(new Action(() => textBoxHistory.Text += update));
        }
        else
        {
            textBoxHistory.Text += update;
        }
    }

    public void OnHistoryClear()
    {
        if (textBoxHistory.InvokeRequired)
        {
            textBoxHistory.Invoke(new Action(() => textBoxHistory.Text = string.Empty));
        }
        else
        {
            textBoxHistory.Text = string.Empty;
        }
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
        labelTaskName.Text = @"None";
    }

    public void OnSolverConfigurationChanged(IModelConfiguration modelConfiguration, ISolverConfiguration solverConfiguration)
    {
        textBoxModelConfiguration.Text = modelConfiguration.ToString();
        textBoxSolverConfiguration.Text = solverConfiguration.ToString();
    }
    
    private void ScrollHistoryDown()
    {
        textBoxHistory.SelectionStart = textBoxHistory.Text.Length;
        textBoxHistory.ScrollToCaret();
        textBoxHistory.Refresh();
    }
}