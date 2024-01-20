using App.Forms.Scaling;
using App.Services.Interfaces;
using Interpreter;
using Shared.Exceptions;

namespace App.Forms;

public partial class InterpreterForm : Form, IFormPropertiesProvider<InterpreterForm>
{
    public FormProperties<InterpreterForm> FormProperties { get; set; }

    private const int MinExecutionTime = 3;
    private const int MaxExecutionTime = 10000;
    private readonly IWindowSwitcherService _windowSwitcher;
    private readonly IInterpreterService _interpreterService;

    public InterpreterForm(IWindowSwitcherService windowSwitcher, IInterpreterService interpreterService)
    {
        _windowSwitcher = windowSwitcher;
        _interpreterService = interpreterService;

        InitializeComponent();
        FormProperties = new FormProperties<InterpreterForm>(this);
    }

    private void InterpreterForm_Load(object sender, EventArgs e)
    {
        WindowState = FormWindowState.Maximized;

        textBoxExecutionTime.Text = MaxExecutionTime.ToString();
        textBoxProgramCode.Text = string.Empty;
        textBoxProgramOutput.Text = string.Empty;
        textBoxProgramInput.Text = string.Empty;
    }

    public new void Show()
    {
        InterpreterForm_Load(this, EventArgs.Empty);
        base.Show();
    }

    private void InterpreterForm_Resize(object sender, EventArgs e)
    {
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

    private void buttonRunProgram_Click(object sender, EventArgs e)
    {
        if (int.TryParse(textBoxExecutionTime.Text, out var executionTime))
        {
            if (executionTime is >= MinExecutionTime and <= MaxExecutionTime)
            {
                RunProgram(executionTime);
            }
            else
            {
                throw new CustomException($"Execution time must be between {MinExecutionTime} and {MaxExecutionTime}!");
            }
        }
        else
        {
            throw new CustomException("Execution time must be a number!");
        }
    }

    private void RunProgram(int executionTime)
    {
        var programCode = textBoxProgramCode.Text;
        var programInput = GetInputs();

        textBoxProgramOutput.Text = string.Empty;

        try
        {
            _interpreterService.Feed(programCode);
            _interpreterService.Run(programInput, executionTime);
        }
        catch (Exception e)
        {
            throw new CustomException(e.Message);
        }

        textBoxProgramOutput.Text = string.Join(", ", _interpreterService.Outputs);
    }

    private List<double> GetInputs()
    {
        if (string.IsNullOrWhiteSpace(textBoxProgramInput.Text))
        {
            return [];
        }

        try
        {
            return textBoxProgramInput.Text.Split(" ").Select(double.Parse).ToList();
        }
        catch (Exception e)
        {
            throw new CustomException("Input must be a list of numbers separated by spaces!");
        }
    }
}