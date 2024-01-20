namespace App.Forms.Scaling;

public interface IFormPropertiesProvider<T> where T : Form
{
    public Form Form => this as Form ?? throw new Exception("Form is null");

    public FormProperties<T> FormProperties { get; set; }

    public List<Control> AllControls 
        => GroupBoxes.Concat(Controls).Concat(GroupBoxesControls).ToList();
    
    private IEnumerable<GroupBox> GroupBoxes
        => Form.Controls.Cast<Control>().Where(c => c is GroupBox).Cast<GroupBox>().ToList();
    
    private IEnumerable<Control> Controls 
        => Form.Controls.Cast<Control>().Where(c => c is not GroupBox).ToList();
    
    private IEnumerable<Control> GroupBoxesControls
        => GroupBoxes.SelectMany(gb => gb.Controls.Cast<Control>()).ToList();
}