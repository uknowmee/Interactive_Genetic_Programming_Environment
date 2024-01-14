using App.Forms;
using App.Services.Interfaces;
using Microsoft.Extensions.Logging;

namespace App.Services;

public class WindowSwitcherService : IWindowSwitcherService
{
    private readonly ILogger<WindowSwitcherService> _logger;
    
    private bool _initialized;

    private HomeForm? _homeForm;
    private ConfigurationForm? _configurationForm;
    private FitnessForm? _fitnessForm;
    private TaskForm? _taskForm;
    private SavedForm? _savedForm;
    
    private HomeForm HomeForm => _homeForm ?? FailNotInitialized<HomeForm>();
    private ConfigurationForm ConfigurationForm => _configurationForm ?? FailNotInitialized<ConfigurationForm>();
    private FitnessForm FitnessForm => _fitnessForm ?? FailNotInitialized<FitnessForm>();
    private TaskForm TaskForm => _taskForm ?? FailNotInitialized<TaskForm>();
    private SavedForm SavedForm => _savedForm ?? FailNotInitialized<SavedForm>();

    public Form InitialView => HomeForm;

    public WindowSwitcherService(ILoggerFactory loggerFactory)
    {
        _logger = loggerFactory.CreateLogger<WindowSwitcherService>();
    }
    
    public void InitializeWithWindows(
        HomeForm homeForm,
        ConfigurationForm configurationForm,
        FitnessForm fitnessForm,
        TaskForm taskForm,
        SavedForm savedForm
    )
    {
        _logger.LogInformation("Initializing windows.");
        _initialized = true;
        
        _homeForm = homeForm;
        _configurationForm = configurationForm;
        _fitnessForm = fitnessForm;
        _taskForm = taskForm;
        _savedForm = savedForm;
    }

    public void Switch<T>(Form current) where T : Form
    {
        _logger.LogInformation("Trying to switch window to {Form} from {CurrentForm}.", typeof(T).Name, current.GetType().Name);
        EnsureInitialized();
        
        if (typeof(T) == typeof(HomeForm) && current is not Forms.HomeForm)
        {
            HomeForm.Show();
            HomeForm.Location = current.Location;
            current.Hide();
        }
        else if (typeof(T) == typeof(ConfigurationForm) && current is not Forms.ConfigurationForm)
        {
            ConfigurationForm.Show();
            ConfigurationForm.Location = current.Location;
            current.Hide();
        }
        else if (typeof(T) == typeof(FitnessForm) && current is not Forms.FitnessForm)
        {
            FitnessForm.Show();
            FitnessForm.Location = current.Location;
            current.Hide();
        }
        else if (typeof(T) == typeof(TaskForm) && current is not Forms.TaskForm)
        {
            TaskForm.Show();
            TaskForm.Location = current.Location;
            current.Hide();
        }
        else if (typeof(T) == typeof(SavedForm) && current is not Forms.SavedForm)
        {
            SavedForm.Show();
            SavedForm.Location = current.Location;
            current.Hide();
        }
    }

    public void Quit(Form current)
    {
        EnsureInitialized();
        _logger.LogInformation("Quitting application from {CurrentForm}.", current.GetType().Name);
        Application.Exit();
    }

    private void EnsureInitialized()
    {
        if (_initialized is false)
        {
            FailNotInitialized<WindowSwitcherService>();
        }
    }
    
    private static T FailNotInitialized<T>()
    {
        throw new InvalidOperationException("WindowSwitcherService has not been initialized with windows.");
    }
}