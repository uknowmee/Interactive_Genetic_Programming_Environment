using App.Forms;

namespace App.Services.Interfaces;

public interface IWindowSwitcherService
{
    public Form InitialView { get; }
    public void Switch<T>(Form current) where T : Form;
    public void Quit(Form current);
    void InitializeWithWindows(
        HomeForm homeForm,
        ConfigurationForm configurationForm,
        FitnessForm fitnessForm,
        TaskForm taskForm,
        SavedForm savedForm,
        InterpreterForm interpreterForm
    );
}