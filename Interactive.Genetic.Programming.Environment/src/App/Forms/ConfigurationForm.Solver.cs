using System.Globalization;

namespace App.Forms;

public partial class ConfigurationForm
{
    private void LoadSolverConfiguration()
    {
        textBoxNumOfTestCases.Text = _solverConfiguration.NumOfTestCases.ToString();
        textBoxInputLength.Text = _solverConfiguration.InputLength.ToString();
        textBoxExecutionTime.Text = _solverConfiguration.ExecutionTime.ToString();
        textBoxError.Text = _solverConfiguration.Error.ToString(CultureInfo.InvariantCulture);
        textBoxPopulationSize.Text = _solverConfiguration.PopulationSize.ToString();
        textBoxMaxGenerations.Text = _solverConfiguration.MaxGenerations.ToString();
        textBoxTournamentSize.Text = _solverConfiguration.TournamentSize.ToString();
        textBoxCrossoverProbability.Text = _solverConfiguration.CrossoverProbability.ToString(CultureInfo.InvariantCulture);
        textBoxMutationProbability.Text = _solverConfiguration.MutationProbability.ToString(CultureInfo.InvariantCulture);
        textBoxPointMutationProbability.Text = _solverConfiguration.PointMutationProbability.ToString(CultureInfo.InvariantCulture);
        textBoxSubtreeMutationProbability.Text = _solverConfiguration.SubtreeMutationProbability.ToString(CultureInfo.InvariantCulture);
        textBoxHorizontalModificationProbability.Text = _solverConfiguration.HorizontalModificationProbability.ToString(CultureInfo.InvariantCulture);
        textBoxNewLineProbability.Text = _solverConfiguration.NewLineProbability.ToString(CultureInfo.InvariantCulture);
        textBoxDeleteLineProbability.Text = _solverConfiguration.DeleteLineProbability.ToString(CultureInfo.InvariantCulture);
        textBoxSwapLinesProbability.Text = _solverConfiguration.SwapLinesProbability.ToString(CultureInfo.InvariantCulture);
    }
    
    private void textBoxNumOfTestCases_KeyPress(object sender, KeyPressEventArgs e)
    {
        EnsureInt(sender, e);
        if (e.KeyChar == (char)Keys.Enter && int.TryParse(textBoxNumOfTestCases.Text, out var numOfTestCases))
        {
            _solverConfiguration.NumOfTestCases = numOfTestCases;
        }
    }

    private void textBoxInputLength_KeyPress(object sender, KeyPressEventArgs e)
    {
        EnsureInt(sender, e);
        if (e.KeyChar == (char)Keys.Enter && int.TryParse(textBoxInputLength.Text, out var inputLength))
        {
            _solverConfiguration.InputLength = inputLength;
        }
    }

    private void textBoxExecutionTime_KeyPress(object sender, KeyPressEventArgs e)
    {
        EnsureInt(sender, e);
        if (e.KeyChar == (char)Keys.Enter && int.TryParse(textBoxExecutionTime.Text, out var executionTime))
        {
            _solverConfiguration.ExecutionTime = executionTime;
        }
    }

    private void textBoxError_KeyPress(object sender, KeyPressEventArgs e)
    {
        EnsureDouble(sender, e);
        if (e.KeyChar == (char)Keys.Enter && double.TryParse(textBoxError.Text, out var error))
        {
            _solverConfiguration.Error = error;
        }
    }

    private void textBoxPopulationSize_KeyPress(object sender, KeyPressEventArgs e)
    {
        EnsureInt(sender, e);
        if (e.KeyChar == (char)Keys.Enter && int.TryParse(textBoxPopulationSize.Text, out var populationSize))
        {
            _solverConfiguration.PopulationSize = populationSize;
        }
    }

    private void textBoxMaxGenerations_KeyPress(object sender, KeyPressEventArgs e)
    {
        EnsureInt(sender, e);
        if (e.KeyChar == (char)Keys.Enter && int.TryParse(textBoxMaxGenerations.Text, out var maxGenerations))
        {
            _solverConfiguration.MaxGenerations = maxGenerations;
        }
    }

    private void textBoxTournamentSize_KeyPress(object sender, KeyPressEventArgs e)
    {
        EnsureInt(sender, e);
        if (e.KeyChar == (char)Keys.Enter && int.TryParse(textBoxTournamentSize.Text, out var tournamentSize))
        {
            _solverConfiguration.TournamentSize = tournamentSize;
        }
    }

    private void textBoxCrossoverProbability_KeyPress(object sender, KeyPressEventArgs e)
    {
        EnsureDouble(sender, e);
        if (e.KeyChar == (char)Keys.Enter && double.TryParse(textBoxCrossoverProbability.Text, out var crossoverProbability))
        {
            _solverConfiguration.CrossoverProbability = crossoverProbability;
        }
    }

    private void textBoxMutationProbability_KeyPress(object sender, KeyPressEventArgs e)
    {
        EnsureDouble(sender, e);
        if (e.KeyChar == (char)Keys.Enter && double.TryParse(textBoxMutationProbability.Text, out var mutationProbability))
        {
            _solverConfiguration.MutationProbability = mutationProbability;
        }
    }

    private void textBoxPointMutationProbability_KeyPress(object sender, KeyPressEventArgs e)
    {
        EnsureDouble(sender, e);
        if (e.KeyChar == (char)Keys.Enter && double.TryParse(textBoxPointMutationProbability.Text, out var pointMutationProbability))
        {
            _solverConfiguration.PointMutationProbability = pointMutationProbability;
        }
    }

    private void textBoxSubtreeMutationProbability_KeyPress(object sender, KeyPressEventArgs e)
    {
        EnsureDouble(sender, e);
        if (e.KeyChar == (char)Keys.Enter && double.TryParse(textBoxSubtreeMutationProbability.Text, out var subtreeMutationProbability))
        {
            _solverConfiguration.SubtreeMutationProbability = subtreeMutationProbability;
        }
    }
    
    private void textBoxHorizontalModificationProbability_KeyPress(object sender, KeyPressEventArgs e)
    {
        EnsureDouble(sender, e);
        if (e.KeyChar == (char)Keys.Enter && double.TryParse(textBoxHorizontalModificationProbability.Text, out var horizontalModificationProbability))
        {
            _solverConfiguration.HorizontalModificationProbability = horizontalModificationProbability;
        }
    }
    
    private void textBoxNewLineProbability_KeyPress(object sender, KeyPressEventArgs e)
    {
        EnsureDouble(sender, e);
        if (e.KeyChar == (char)Keys.Enter && double.TryParse(textBoxNewLineProbability.Text, out var newLineProbability))
        {
            _solverConfiguration.NewLineProbability = newLineProbability;
        }
    }
    
    private void textBoxDeleteLineProbability_KeyPress(object sender, KeyPressEventArgs e)
    {
        EnsureDouble(sender, e);
        if (e.KeyChar == (char)Keys.Enter && double.TryParse(textBoxDeleteLineProbability.Text, out var deleteLineProbability))
        {
            _solverConfiguration.DeleteLineProbability = deleteLineProbability;
        }
    }
    
    private void textBoxSwapLinesProbability_KeyPress(object sender, KeyPressEventArgs e)
    {
        EnsureDouble(sender, e);
        if (e.KeyChar == (char)Keys.Enter && double.TryParse(textBoxSwapLinesProbability.Text, out var swapLinesProbability))
        {
            _solverConfiguration.SwapLinesProbability = swapLinesProbability;
        }
    }
}