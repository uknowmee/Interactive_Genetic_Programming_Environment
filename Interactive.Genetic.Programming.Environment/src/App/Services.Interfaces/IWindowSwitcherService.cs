namespace App.Services.Interfaces;

public interface IWindowSwitcherService
{
    public Form InitialView { get; }
    public void Switch<T>(Form current) where T : Form;
    public void Quit(Form current);
}