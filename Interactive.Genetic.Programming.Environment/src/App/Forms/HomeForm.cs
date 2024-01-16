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

    private void buttonInterpreter_Click(object sender, EventArgs e)
    {
        _windowSwitcher.Switch<InterpreterForm>(this);
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

    private void buttonReset_Click(object sender, EventArgs e)
    {
        _solver.Reset();
    }

    public void OnSolverStatusUpdate(SolverStatus status)
    {
        if (labelStatusValue.InvokeRequired)
        {
            labelStatusValue.BeginInvoke(() => labelStatusValue.Text = status.ToString());
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
            labelPopulationSizeValue.BeginInvoke(() => labelPopulationSizeValue.Text = size.ToString());
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
            textBoxBestIndividual.BeginInvoke(() => textBoxBestIndividual.Text = program);
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
            labelBestIndividualValue.BeginInvoke(() => labelBestIndividualValue.Text = fitness.ToString(CultureInfo.InvariantCulture));
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
            labelAvgFitnessValue.BeginInvoke(() => labelAvgFitnessValue.Text = avgFitness.ToString(CultureInfo.InvariantCulture));
        }
        else
        {
            labelAvgFitnessValue.Text = avgFitness.ToString(CultureInfo.InvariantCulture);
        }
    }

    public void OnProceededUpdate(double percent)
    {
        if (labelProcedeedValue.InvokeRequired)
        {
            labelProcedeedValue.BeginInvoke(() => labelProcedeedValue.Text = $@"{percent}%");
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
            textBoxHistory.BeginInvoke(() =>
            {
                textBoxHistory.Text += update;
                ScrollHistoryDown();
            });
        }
        else
        {
            textBoxHistory.Text += update;
            ScrollHistoryDown();
        }
    }

    public void OnHistoryClear()
    {
        if (textBoxHistory.InvokeRequired)
        {
            textBoxHistory.BeginInvoke(() => textBoxHistory.Text = string.Empty);
        }
        else
        {
            textBoxHistory.Text = string.Empty;
        }
    }

    public void OnFitnessFunctionChange(string functionName)
    {
        if (labelFitnessFunctionName.InvokeRequired)
        {
            labelFitnessFunctionName.BeginInvoke(() => labelFitnessFunctionName.Text = functionName);
        }
        else
        {
            labelFitnessFunctionName.Text = functionName;
        }
    }

    public void OnFitnessFunctionReset()
    {
        if (labelFitnessFunctionName.InvokeRequired)
        {
            labelFitnessFunctionName.BeginInvoke(() => labelFitnessFunctionName.Text = @"None");
        }
        else
        {
            labelFitnessFunctionName.Text = @"None";
        }
    }

    public void OnTaskChange(string taskName)
    {
        if (labelTaskName.InvokeRequired)
        {
            labelTaskName.BeginInvoke(() => labelTaskName.Text = taskName);
        }
        else
        {
            labelTaskName.Text = taskName;
        }
    }

    public void OnTaskReset()
    {
        if (labelTaskName.InvokeRequired)
        {
            labelTaskName.BeginInvoke(() => labelTaskName.Text = @"None");
        }
        else
        {
            labelTaskName.Text = @"None";
        }
    }

    public void OnSolverConfigurationChanged(IModelConfiguration modelConfiguration, ISolverConfiguration solverConfiguration)
    {
        if (textBoxModelConfiguration.InvokeRequired)
        {
            textBoxModelConfiguration.BeginInvoke(() => textBoxModelConfiguration.Text = modelConfiguration.ToString());
        }
        else
        {
            textBoxModelConfiguration.Text = modelConfiguration.ToString();
        }

        if (textBoxSolverConfiguration.InvokeRequired)
        {
            textBoxSolverConfiguration.BeginInvoke(() => textBoxSolverConfiguration.Text = solverConfiguration.ToString());
        }
        else
        {
            textBoxSolverConfiguration.Text = solverConfiguration.ToString();
        }
    }

    private void ScrollHistoryDown()
    {
        textBoxHistory.SelectionStart = textBoxHistory.Text.Length;
        textBoxHistory.ScrollToCaret();
        textBoxHistory.Refresh();
    }
}