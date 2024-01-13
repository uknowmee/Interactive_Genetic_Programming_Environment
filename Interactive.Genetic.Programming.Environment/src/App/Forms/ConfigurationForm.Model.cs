using System.Globalization;

namespace App.Forms;

public partial class ConfigurationForm
{
    private void LoadModelConfiguration()
    {
        textBoxMaxInt.Text = _modelConfiguration.MaxInt.ToString();
        textBoxNewChildOfProgramNodeChance.Text = _modelConfiguration.NewChildOfProgramNodeChance.ToString(CultureInfo.InvariantCulture);
        textBoxNewDeepNodeGenerationChance.Text = _modelConfiguration.NewDeepNodeGenerationChance.ToString(CultureInfo.InvariantCulture);
        textBoxNewDeepNodeGenerationFall.Text = _modelConfiguration.NewDeepNodeGenerationFall.ToString(CultureInfo.InvariantCulture);
        textBoxNewChildOfForNodeChance.Text = _modelConfiguration.NewChildOfForNodeChance.ToString(CultureInfo.InvariantCulture);
        textBoxNewExpressionInForComparisonChance.Text = _modelConfiguration.NewExpressionInForComparisonChance.ToString(CultureInfo.InvariantCulture);
        textBoxNewChildOfIfNodeChance.Text = _modelConfiguration.NewChildOfIfNodeChance.ToString(CultureInfo.InvariantCulture);
        textBoxNewLogicExpressionChance.Text = _modelConfiguration.NewLogicExpressionChance.ToString(CultureInfo.InvariantCulture);
        textBoxNextTwoArgExpressionChance.Text = _modelConfiguration.NextTwoArgExpressionChance.ToString(CultureInfo.InvariantCulture);
        textBoxNewVarExpressionChance.Text = _modelConfiguration.NewVarExpressionChance.ToString(CultureInfo.InvariantCulture);
    }

    private void textBoxMaxInt_KeyPress(object sender, KeyPressEventArgs e)
    {
        EnsureInt(sender, e);
        if (e.KeyChar == (char)Keys.Enter && int.TryParse(textBoxMaxInt.Text, out var maxInt))
        {
            _modelConfiguration.MaxInt = maxInt;
        }
    }

    private void textBoxNewChildOfProgramNodeChance_KeyPress(object sender, KeyPressEventArgs e)
    {
        EnsureDouble(sender, e);
        if (e.KeyChar == (char)Keys.Enter && double.TryParse(textBoxNewChildOfProgramNodeChance.Text, out var chance))
        {
            _modelConfiguration.NewChildOfProgramNodeChance = chance;
        }
    }
    
    private void textBoxNewDeepNodeGenerationChance_KeyPress(object sender, KeyPressEventArgs e)
    {
        EnsureDouble(sender, e);
        if (e.KeyChar == (char)Keys.Enter && double.TryParse(textBoxNewDeepNodeGenerationChance.Text, out var chance))
        {
            _modelConfiguration.NewDeepNodeGenerationChance = chance;
        }
    }

    private void textBoxNewDeepNodeGenerationFall_KeyPress(object sender, KeyPressEventArgs e)
    {
        EnsureDouble(sender, e);
        if (e.KeyChar == (char)Keys.Enter && double.TryParse(textBoxNewDeepNodeGenerationFall.Text, out var fall))
        {
            _modelConfiguration.NewDeepNodeGenerationFall = fall;
        }
    }

    private void textBoxNewChildOfForNodeChance_KeyPress(object sender, KeyPressEventArgs e)
    {
        EnsureDouble(sender, e);
        if (e.KeyChar == (char)Keys.Enter && double.TryParse(textBoxNewChildOfForNodeChance.Text, out var chance))
        {
            _modelConfiguration.NewChildOfForNodeChance = chance;
        }
    }

    private void textBoxNewExpressionInForComparisonChance_KeyPress(object sender, KeyPressEventArgs e)
    {
        EnsureDouble(sender, e);
        if (e.KeyChar == (char)Keys.Enter && double.TryParse(textBoxNewExpressionInForComparisonChance.Text, out var chance))
        {
            _modelConfiguration.NewExpressionInForComparisonChance = chance;
        }
    }

    private void textBoxNewChildOfIfNodeChance_KeyPress(object sender, KeyPressEventArgs e)
    {
        EnsureDouble(sender, e);
        if (e.KeyChar == (char)Keys.Enter && double.TryParse(textBoxNewChildOfIfNodeChance.Text, out var chance))
        {
            _modelConfiguration.NewChildOfIfNodeChance = chance;
        }
    }

    private void textBoxNewLogicExpressionChance_KeyPress(object sender, KeyPressEventArgs e)
    {
        EnsureDouble(sender, e);
        if (e.KeyChar == (char)Keys.Enter && double.TryParse(textBoxNewLogicExpressionChance.Text, out var chance))
        {
            _modelConfiguration.NewLogicExpressionChance = chance;
        }
    }

    private void textBoxNextTwoArgExpressionChance_KeyPress(object sender, KeyPressEventArgs e)
    {
        EnsureDouble(sender, e);
        if (e.KeyChar == (char)Keys.Enter && double.TryParse(textBoxNextTwoArgExpressionChance.Text, out var chance))
        {
            _modelConfiguration.NextTwoArgExpressionChance = chance;
        }
    }

    private void textBoxNewVarExpressionChance_KeyPress(object sender, KeyPressEventArgs e)
    {
        EnsureDouble(sender, e);
        if (e.KeyChar == (char)Keys.Enter && double.TryParse(textBoxNewVarExpressionChance.Text, out var chance))
        {
            _modelConfiguration.NewVarExpressionChance = chance;
        }
    }
}