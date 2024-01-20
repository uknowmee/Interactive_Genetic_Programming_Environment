namespace App.Forms.Scaling;

public static class FormScalingExtensions
{
    public static bool ResizeDecision<T>(this IFormPropertiesProvider<T> form) where T : Form
    {
        if (form.FormProperties.Loaded is false)
        {
            return form.Resize();
        }

        form.ResizeEnd();
        return form.FormProperties.MinimizeMaximizeChange;
    }

    private static bool Resize<T>(this IFormPropertiesProvider<T> form) where T : Form
    {
        if (form.Form.WindowState is FormWindowState.Maximized)
        {
            form.HideAll();
            form.ResizeControls();
            form.ShowAll();
            return true;
        }

        if (form.FormProperties.MinimizeMaximizeChange is false) return false;
        
        form.HideAll();
        form.ResizeControls();
        form.ShowAll();
        
        return false;
    }

    private static void ResizeEnd<T>(this IFormPropertiesProvider<T> form) where T : Form
    {
        form.HideAll();
        form.ResizeControls();
        form.ShowAll();
    }
    
    private static void HideAll<T>(this IFormPropertiesProvider<T> form) where T : Form
    {
        foreach (var control in form.AllControls)
        {
            control.Visible = false;
        }
    }
    
    private static void ShowAll<T>(this IFormPropertiesProvider<T> form) where T : Form
    {
        foreach (var control in form.AllControls)
        {
            control.Visible = true;
        }
    }
    
    private static void ResizeControls<T>(this IFormPropertiesProvider<T> form) where T : Form
    {
        if (form.FormProperties.MyControls.Controls.Count == 0) return;
        
        var xRatio = form.Form.Width / (float) form.FormProperties.OriginalFormSize.Width;
        var yRatio = form.Form.Height / (float) form.FormProperties.OriginalFormSize.Height;
        
        foreach (var control in form.AllControls)
        {
            var rectangle = form.FormProperties.MyControls.GetControlRectangle(control);

            var newX = (int) (rectangle.Location.X * xRatio);
            var newY = (int) (rectangle.Location.Y * yRatio);

            var newWidth = (int) (rectangle.Width * xRatio);
            var newHeight = (int) (rectangle.Height * yRatio);

            control.Location = new Point(newX, newY);
            control.Size = new Size(newWidth, newHeight);
        }
    }
}

