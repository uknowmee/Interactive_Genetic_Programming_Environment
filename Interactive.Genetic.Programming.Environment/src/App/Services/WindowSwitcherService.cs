using App.Forms;
using App.Services.Interfaces;

namespace App.Services;

public class WindowSwitcherService : IWindowSwitcherService
{
    private HomeForm HomeForm { get; }
    private ConfigurationForm ConfigurationForm { get; }
    private FitnessForm FitnessForm { get; }
    private TaskForm TaskForm { get; }
    private SavedForm SavedForm { get; }
    
    public Form InitialView => HomeForm;
    
    public WindowSwitcherService()
    {
        HomeForm = new HomeForm(this);
        ConfigurationForm = new ConfigurationForm(this);
        FitnessForm = new FitnessForm(this);
        TaskForm = new TaskForm(this);
        SavedForm = new SavedForm(this);
    }
    
    public void Switch<T>(Form current) where T : Form
    {
        if (typeof(T) == typeof(HomeForm))
            HomeForm.Show();
        else if (typeof(T) == typeof(ConfigurationForm))
            ConfigurationForm.Show();
        else if (typeof(T) == typeof(FitnessForm))
            FitnessForm.Show();
        else if (typeof(T) == typeof(TaskForm))
            TaskForm.Show();
        else if (typeof(T) == typeof(SavedForm))
            SavedForm.Show();
        else
            throw new ArgumentException(@"Invalid type", nameof(T));
        
        current.Hide();
    }

    public void Quit(Form current)
    {
        Application.Exit();
    }
}