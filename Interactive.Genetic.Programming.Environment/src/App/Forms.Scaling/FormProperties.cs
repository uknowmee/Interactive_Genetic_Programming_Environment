namespace App.Forms.Scaling;

public class FormProperties<T> where T : Form
{
    public MyControls<T> MyControls { get; set; }
    public Rectangle OriginalFormSize { get; set; }
    public bool MinimizeMaximizeChange { get; set; }
    public bool Loaded { get; set; }

    public FormProperties(IFormPropertiesProvider<T> formPropertiesProvider)
    {
        var form = formPropertiesProvider.Form;
        
        Loaded = true;
        OriginalFormSize = new Rectangle(form.Location.X, form.Location.Y, form.Size.Width, form.Size.Height);
        MyControls = new MyControls<T>(formPropertiesProvider);
    }
}