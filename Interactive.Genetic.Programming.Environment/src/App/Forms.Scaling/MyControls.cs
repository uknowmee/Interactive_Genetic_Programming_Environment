namespace App.Forms.Scaling;

public class MyControl
{
    public readonly string Name;
    public readonly Rectangle Shape;

    public MyControl(Control control)
    {
        Name = control.Name;
        Shape = new Rectangle(control.Location.X, control.Location.Y, control.Width, control.Height);
    }
}

public class MyControls<T> where T : Form
{
    public List<MyControl> Controls { get; } = [];

    public MyControls(IFormPropertiesProvider<T> formPropertiesProvider)
    {
        var allControls = formPropertiesProvider.AllControls.Select(control => new MyControl(control));
        Controls.AddRange(allControls);
    }

    public Rectangle GetControlRectangle(Control control)
    {
        return Controls.Single(c => c.Name == control.Name).Shape;
    }
}