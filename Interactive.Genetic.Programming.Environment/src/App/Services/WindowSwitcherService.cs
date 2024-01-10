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
        if (typeof(T) == typeof(HomeForm) && current is not App.Forms.HomeForm)
        {
            HomeForm.Show();
            current.Hide();
        }
        else if (typeof(T) == typeof(ConfigurationForm) && current is not App.Forms.ConfigurationForm)
        {
            ConfigurationForm.Show();
            current.Hide();
        }
        else if (typeof(T) == typeof(FitnessForm) && current is not App.Forms.FitnessForm)
        {
            FitnessForm.Show();
            current.Hide();
        }
        else if (typeof(T) == typeof(TaskForm) && current is not App.Forms.TaskForm)
        {
            TaskForm.Show();
            current.Hide();
        }
        else if (typeof(T) == typeof(SavedForm) && current is not App.Forms.SavedForm)
        {
            SavedForm.Show();
            current.Hide();
        }
    }

    public void Quit(Form current)
    {
        Application.Exit();
    }
}