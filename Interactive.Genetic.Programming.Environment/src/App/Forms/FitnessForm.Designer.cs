using System.ComponentModel;

namespace App.Forms;

partial class FitnessForm
{
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }

        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        ComponentResourceManager resources = new ComponentResourceManager(typeof(FitnessForm));
        buttonQuit = new Button();
        buttonSaved = new Button();
        buttonTask = new Button();
        buttonFitness = new Button();
        buttonConfiguration = new Button();
        buttonHome = new Button();
        labelFitnessName = new Label();
        textBoxFitnessName = new TextBox();
        textBoxFitnessCode = new TextBox();
        textBoxActiveFitness = new TextBox();
        comboBoxSavedFitness = new ComboBox();
        labelActiveFitness = new Label();
        buttonSaveFitness = new Button();
        buttonRemoveFitness = new Button();
        textBoxFitnessReadme = new TextBox();
        buttonInterpreter = new Button();
        SuspendLayout();
        // 
        // buttonQuit
        // 
        buttonQuit.Anchor = AnchorStyles.None;
        buttonQuit.Location = new Point(1269, 12);
        buttonQuit.Name = "buttonQuit";
        buttonQuit.Size = new Size(122, 41);
        buttonQuit.TabIndex = 9;
        buttonQuit.Text = "Quit";
        buttonQuit.UseVisualStyleBackColor = true;
        buttonQuit.Click += buttonQuit_Click;
        // 
        // buttonSaved
        // 
        buttonSaved.Anchor = AnchorStyles.None;
        buttonSaved.Location = new Point(1013, 12);
        buttonSaved.Name = "buttonSaved";
        buttonSaved.Size = new Size(122, 41);
        buttonSaved.TabIndex = 8;
        buttonSaved.Text = "Saved";
        buttonSaved.UseVisualStyleBackColor = true;
        buttonSaved.Click += buttonSaved_Click;
        // 
        // buttonTask
        // 
        buttonTask.Anchor = AnchorStyles.None;
        buttonTask.Location = new Point(885, 12);
        buttonTask.Name = "buttonTask";
        buttonTask.Size = new Size(122, 41);
        buttonTask.TabIndex = 7;
        buttonTask.Text = "Task";
        buttonTask.UseVisualStyleBackColor = true;
        buttonTask.Click += buttonTask_Click;
        // 
        // buttonFitness
        // 
        buttonFitness.Anchor = AnchorStyles.None;
        buttonFitness.Location = new Point(757, 12);
        buttonFitness.Name = "buttonFitness";
        buttonFitness.Size = new Size(122, 41);
        buttonFitness.TabIndex = 6;
        buttonFitness.Text = "Fitness";
        buttonFitness.UseVisualStyleBackColor = true;
        buttonFitness.Click += buttonFitness_Click;
        // 
        // buttonConfiguration
        // 
        buttonConfiguration.Anchor = AnchorStyles.None;
        buttonConfiguration.Location = new Point(629, 12);
        buttonConfiguration.Name = "buttonConfiguration";
        buttonConfiguration.Size = new Size(122, 41);
        buttonConfiguration.TabIndex = 5;
        buttonConfiguration.Text = "Configuration";
        buttonConfiguration.UseVisualStyleBackColor = true;
        buttonConfiguration.Click += buttonConfiguration_Click;
        // 
        // buttonHome
        // 
        buttonHome.Anchor = AnchorStyles.None;
        buttonHome.Location = new Point(501, 12);
        buttonHome.Name = "buttonHome";
        buttonHome.Size = new Size(122, 41);
        buttonHome.TabIndex = 25;
        buttonHome.Text = "Home";
        buttonHome.UseVisualStyleBackColor = true;
        buttonHome.Click += buttonHome_Click;
        // 
        // labelFitnessName
        // 
        labelFitnessName.Anchor = AnchorStyles.None;
        labelFitnessName.Location = new Point(49, 97);
        labelFitnessName.Name = "labelFitnessName";
        labelFitnessName.Size = new Size(183, 54);
        labelFitnessName.TabIndex = 59;
        labelFitnessName.Text = "Fitness Name";
        labelFitnessName.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // textBoxFitnessName
        // 
        textBoxFitnessName.Anchor = AnchorStyles.None;
        textBoxFitnessName.Location = new Point(35, 170);
        textBoxFitnessName.Name = "textBoxFitnessName";
        textBoxFitnessName.Size = new Size(212, 27);
        textBoxFitnessName.TabIndex = 58;
        // 
        // textBoxFitnessCode
        // 
        textBoxFitnessCode.Anchor = AnchorStyles.None;
        textBoxFitnessCode.Location = new Point(279, 97);
        textBoxFitnessCode.Multiline = true;
        textBoxFitnessCode.Name = "textBoxFitnessCode";
        textBoxFitnessCode.ScrollBars = ScrollBars.Vertical;
        textBoxFitnessCode.Size = new Size(723, 435);
        textBoxFitnessCode.TabIndex = 60;
        // 
        // textBoxActiveFitness
        // 
        textBoxActiveFitness.Anchor = AnchorStyles.None;
        textBoxActiveFitness.Location = new Point(279, 558);
        textBoxActiveFitness.Multiline = true;
        textBoxActiveFitness.Name = "textBoxActiveFitness";
        textBoxActiveFitness.ReadOnly = true;
        textBoxActiveFitness.ScrollBars = ScrollBars.Vertical;
        textBoxActiveFitness.Size = new Size(723, 449);
        textBoxActiveFitness.TabIndex = 61;
        // 
        // comboBoxSavedFitness
        // 
        comboBoxSavedFitness.Anchor = AnchorStyles.None;
        comboBoxSavedFitness.DropDownStyle = ComboBoxStyle.DropDownList;
        comboBoxSavedFitness.FormattingEnabled = true;
        comboBoxSavedFitness.Location = new Point(1302, 169);
        comboBoxSavedFitness.Name = "comboBoxSavedFitness";
        comboBoxSavedFitness.Size = new Size(311, 28);
        comboBoxSavedFitness.TabIndex = 62;
        comboBoxSavedFitness.SelectedIndexChanged += comboBoxSavedFitness_SelectedIndexChanged;
        // 
        // labelActiveFitness
        // 
        labelActiveFitness.Anchor = AnchorStyles.None;
        labelActiveFitness.Location = new Point(1363, 96);
        labelActiveFitness.Name = "labelActiveFitness";
        labelActiveFitness.Size = new Size(183, 54);
        labelActiveFitness.TabIndex = 63;
        labelActiveFitness.Text = "Active Fitness";
        labelActiveFitness.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // buttonSaveFitness
        // 
        buttonSaveFitness.Anchor = AnchorStyles.None;
        buttonSaveFitness.Location = new Point(79, 222);
        buttonSaveFitness.Name = "buttonSaveFitness";
        buttonSaveFitness.Size = new Size(122, 41);
        buttonSaveFitness.TabIndex = 64;
        buttonSaveFitness.Text = "Save";
        buttonSaveFitness.UseVisualStyleBackColor = true;
        buttonSaveFitness.Click += buttonSaveFitness_Click;
        // 
        // buttonRemoveFitness
        // 
        buttonRemoveFitness.Anchor = AnchorStyles.None;
        buttonRemoveFitness.Location = new Point(1396, 221);
        buttonRemoveFitness.Name = "buttonRemoveFitness";
        buttonRemoveFitness.Size = new Size(122, 41);
        buttonRemoveFitness.TabIndex = 65;
        buttonRemoveFitness.Text = "Remove";
        buttonRemoveFitness.UseVisualStyleBackColor = true;
        buttonRemoveFitness.Click += buttonRemoveFitness_Click;
        // 
        // textBoxFitnessReadme
        // 
        textBoxFitnessReadme.Anchor = AnchorStyles.None;
        textBoxFitnessReadme.Location = new Point(1076, 281);
        textBoxFitnessReadme.Multiline = true;
        textBoxFitnessReadme.Name = "textBoxFitnessReadme";
        textBoxFitnessReadme.ReadOnly = true;
        textBoxFitnessReadme.ScrollBars = ScrollBars.Vertical;
        textBoxFitnessReadme.Size = new Size(777, 726);
        textBoxFitnessReadme.TabIndex = 66;
        textBoxFitnessReadme.Text = resources.GetString("textBoxFitnessReadme.Text");
        // 
        // buttonInterpreter
        // 
        buttonInterpreter.Anchor = AnchorStyles.None;
        buttonInterpreter.Location = new Point(1141, 12);
        buttonInterpreter.Name = "buttonInterpreter";
        buttonInterpreter.Size = new Size(122, 41);
        buttonInterpreter.TabIndex = 79;
        buttonInterpreter.Text = "Interpreter";
        buttonInterpreter.UseVisualStyleBackColor = true;
        buttonInterpreter.Click += buttonInterpreter_Click;
        // 
        // FitnessForm
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1902, 1033);
        Controls.Add(buttonInterpreter);
        Controls.Add(textBoxFitnessReadme);
        Controls.Add(buttonRemoveFitness);
        Controls.Add(buttonSaveFitness);
        Controls.Add(labelActiveFitness);
        Controls.Add(comboBoxSavedFitness);
        Controls.Add(textBoxActiveFitness);
        Controls.Add(textBoxFitnessCode);
        Controls.Add(labelFitnessName);
        Controls.Add(textBoxFitnessName);
        Controls.Add(buttonHome);
        Controls.Add(buttonQuit);
        Controls.Add(buttonSaved);
        Controls.Add(buttonTask);
        Controls.Add(buttonFitness);
        Controls.Add(buttonConfiguration);
        Name = "FitnessForm";
        Text = "Fitness";
        Load += Fitness_Load;
        Resize += FitnessForm_Resize;
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Button buttonQuit;
    private Button buttonSaved;
    private Button buttonTask;
    private Button buttonFitness;
    private Button buttonConfiguration;
    private Button buttonHome;
    private Label labelFitnessName;
    private TextBox textBoxFitnessName;
    private TextBox textBoxFitnessCode;
    private TextBox textBoxActiveFitness;
    private ComboBox comboBoxSavedFitness;
    private Label labelActiveFitness;
    private Button buttonSaveFitness;
    private Button buttonRemoveFitness;
    private TextBox textBoxFitnessReadme;
    private Button buttonInterpreter;
}