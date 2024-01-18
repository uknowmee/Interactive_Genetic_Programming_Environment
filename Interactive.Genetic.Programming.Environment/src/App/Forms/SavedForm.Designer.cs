using System.ComponentModel;

namespace App.Forms;

partial class SavedForm
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
        components = new Container();
        buttonQuit = new Button();
        buttonSaved = new Button();
        buttonTask = new Button();
        buttonFitness = new Button();
        buttonConfiguration = new Button();
        buttonHome = new Button();
        textBoxHistory = new TextBox();
        contextMenuStrip1 = new ContextMenuStrip(components);
        textBoxConfiguration = new TextBox();
        textBoxFitness = new TextBox();
        contextMenuStrip2 = new ContextMenuStrip(components);
        textBoxProgram = new TextBox();
        comboBoxSavedSolution = new ComboBox();
        labelConfiguration = new Label();
        labelFitness = new Label();
        labelSolutionName = new Label();
        labelProgram = new Label();
        labelHistory = new Label();
        buttonInspectSolution = new Button();
        buttonRemoveSolution = new Button();
        buttonInterpreter = new Button();
        comboBoxFitness = new ComboBox();
        buttonPlotFitness = new Button();
        SuspendLayout();
        // 
        // buttonQuit
        // 
        buttonQuit.Anchor = AnchorStyles.Top;
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
        buttonSaved.Anchor = AnchorStyles.Top;
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
        buttonTask.Anchor = AnchorStyles.Top;
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
        buttonFitness.Anchor = AnchorStyles.Top;
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
        buttonConfiguration.Anchor = AnchorStyles.Top;
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
        buttonHome.Anchor = AnchorStyles.Top;
        buttonHome.Location = new Point(501, 12);
        buttonHome.Name = "buttonHome";
        buttonHome.Size = new Size(122, 41);
        buttonHome.TabIndex = 25;
        buttonHome.Text = "Home";
        buttonHome.UseVisualStyleBackColor = true;
        buttonHome.Click += buttonHome_Click;
        // 
        // textBoxHistory
        // 
        textBoxHistory.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        textBoxHistory.Location = new Point(12, 690);
        textBoxHistory.Multiline = true;
        textBoxHistory.Name = "textBoxHistory";
        textBoxHistory.ReadOnly = true;
        textBoxHistory.ScrollBars = ScrollBars.Vertical;
        textBoxHistory.Size = new Size(995, 331);
        textBoxHistory.TabIndex = 26;
        // 
        // contextMenuStrip1
        // 
        contextMenuStrip1.ImageScalingSize = new Size(20, 20);
        contextMenuStrip1.Name = "contextMenuStrip1";
        contextMenuStrip1.Size = new Size(61, 4);
        // 
        // textBoxConfiguration
        // 
        textBoxConfiguration.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        textBoxConfiguration.Location = new Point(12, 139);
        textBoxConfiguration.Multiline = true;
        textBoxConfiguration.Name = "textBoxConfiguration";
        textBoxConfiguration.ReadOnly = true;
        textBoxConfiguration.ScrollBars = ScrollBars.Vertical;
        textBoxConfiguration.Size = new Size(469, 504);
        textBoxConfiguration.TabIndex = 62;
        // 
        // textBoxFitness
        // 
        textBoxFitness.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        textBoxFitness.Location = new Point(505, 139);
        textBoxFitness.Multiline = true;
        textBoxFitness.Name = "textBoxFitness";
        textBoxFitness.ReadOnly = true;
        textBoxFitness.ScrollBars = ScrollBars.Vertical;
        textBoxFitness.Size = new Size(502, 504);
        textBoxFitness.TabIndex = 63;
        // 
        // contextMenuStrip2
        // 
        contextMenuStrip2.ImageScalingSize = new Size(20, 20);
        contextMenuStrip2.Name = "contextMenuStrip2";
        contextMenuStrip2.Size = new Size(61, 4);
        // 
        // textBoxProgram
        // 
        textBoxProgram.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        textBoxProgram.Location = new Point(1028, 351);
        textBoxProgram.Multiline = true;
        textBoxProgram.Name = "textBoxProgram";
        textBoxProgram.ReadOnly = true;
        textBoxProgram.ScrollBars = ScrollBars.Vertical;
        textBoxProgram.Size = new Size(871, 670);
        textBoxProgram.TabIndex = 65;
        // 
        // comboBoxSavedSolution
        // 
        comboBoxSavedSolution.Anchor = AnchorStyles.Left;
        comboBoxSavedSolution.DropDownStyle = ComboBoxStyle.DropDownList;
        comboBoxSavedSolution.FormattingEnabled = true;
        comboBoxSavedSolution.Location = new Point(1316, 139);
        comboBoxSavedSolution.Name = "comboBoxSavedSolution";
        comboBoxSavedSolution.Size = new Size(306, 28);
        comboBoxSavedSolution.TabIndex = 68;
        comboBoxSavedSolution.SelectedIndexChanged += comboBoxSavedSolution_SelectedIndexChanged;
        // 
        // labelConfiguration
        // 
        labelConfiguration.Anchor = AnchorStyles.Left;
        labelConfiguration.BackColor = SystemColors.Control;
        labelConfiguration.Location = new Point(12, 105);
        labelConfiguration.Name = "labelConfiguration";
        labelConfiguration.Size = new Size(183, 31);
        labelConfiguration.TabIndex = 69;
        labelConfiguration.Text = "Configuration";
        labelConfiguration.TextAlign = ContentAlignment.BottomLeft;
        // 
        // labelFitness
        // 
        labelFitness.Anchor = AnchorStyles.Left;
        labelFitness.BackColor = SystemColors.Control;
        labelFitness.Location = new Point(505, 71);
        labelFitness.Name = "labelFitness";
        labelFitness.Size = new Size(183, 31);
        labelFitness.TabIndex = 70;
        labelFitness.Text = "Fitness";
        labelFitness.TextAlign = ContentAlignment.BottomLeft;
        // 
        // labelSolutionName
        // 
        labelSolutionName.Anchor = AnchorStyles.Left;
        labelSolutionName.BackColor = SystemColors.Control;
        labelSolutionName.Location = new Point(1127, 125);
        labelSolutionName.Name = "labelSolutionName";
        labelSolutionName.Size = new Size(183, 54);
        labelSolutionName.TabIndex = 71;
        labelSolutionName.Text = "Solution";
        labelSolutionName.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // labelProgram
        // 
        labelProgram.Anchor = AnchorStyles.None;
        labelProgram.BackColor = SystemColors.Control;
        labelProgram.Location = new Point(1028, 294);
        labelProgram.Name = "labelProgram";
        labelProgram.Size = new Size(183, 54);
        labelProgram.TabIndex = 72;
        labelProgram.Text = "Program";
        labelProgram.TextAlign = ContentAlignment.BottomLeft;
        // 
        // labelHistory
        // 
        labelHistory.Anchor = AnchorStyles.Left;
        labelHistory.BackColor = SystemColors.Control;
        labelHistory.Location = new Point(12, 658);
        labelHistory.Name = "labelHistory";
        labelHistory.Size = new Size(183, 29);
        labelHistory.TabIndex = 73;
        labelHistory.Text = "History";
        labelHistory.TextAlign = ContentAlignment.BottomLeft;
        // 
        // buttonInspectSolution
        // 
        buttonInspectSolution.Anchor = AnchorStyles.Left;
        buttonInspectSolution.Location = new Point(1473, 186);
        buttonInspectSolution.Name = "buttonInspectSolution";
        buttonInspectSolution.Size = new Size(151, 41);
        buttonInspectSolution.TabIndex = 74;
        buttonInspectSolution.Text = "Inspect Solution";
        buttonInspectSolution.UseVisualStyleBackColor = true;
        buttonInspectSolution.Click += buttonInspectSolution_Click;
        // 
        // buttonRemoveSolution
        // 
        buttonRemoveSolution.Anchor = AnchorStyles.Left;
        buttonRemoveSolution.Location = new Point(1645, 132);
        buttonRemoveSolution.Name = "buttonRemoveSolution";
        buttonRemoveSolution.Size = new Size(151, 41);
        buttonRemoveSolution.TabIndex = 75;
        buttonRemoveSolution.Text = "Remove Solution";
        buttonRemoveSolution.UseVisualStyleBackColor = true;
        buttonRemoveSolution.Click += buttonRemoveSolution_Click;
        // 
        // buttonInterpreter
        // 
        buttonInterpreter.Anchor = AnchorStyles.Top;
        buttonInterpreter.Location = new Point(1141, 12);
        buttonInterpreter.Name = "buttonInterpreter";
        buttonInterpreter.Size = new Size(122, 41);
        buttonInterpreter.TabIndex = 79;
        buttonInterpreter.Text = "Interpreter";
        buttonInterpreter.UseVisualStyleBackColor = true;
        buttonInterpreter.Click += buttonInterpreter_Click;
        // 
        // comboBoxFitness
        // 
        comboBoxFitness.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        comboBoxFitness.DropDownStyle = ComboBoxStyle.DropDownList;
        comboBoxFitness.FormattingEnabled = true;
        comboBoxFitness.Location = new Point(505, 105);
        comboBoxFitness.Name = "comboBoxFitness";
        comboBoxFitness.Size = new Size(502, 28);
        comboBoxFitness.TabIndex = 80;
        comboBoxFitness.SelectedIndexChanged += comboBoxFitness_SelectedIndexChanged;
        // 
        // buttonPlotFitness
        // 
        buttonPlotFitness.Anchor = AnchorStyles.Left;
        buttonPlotFitness.Location = new Point(1316, 186);
        buttonPlotFitness.Name = "buttonPlotFitness";
        buttonPlotFitness.Size = new Size(151, 41);
        buttonPlotFitness.TabIndex = 81;
        buttonPlotFitness.Text = "Plot Fitness";
        buttonPlotFitness.UseVisualStyleBackColor = true;
        buttonPlotFitness.Click += buttonPlot_Click;
        // 
        // SavedForm
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1902, 1033);
        Controls.Add(buttonPlotFitness);
        Controls.Add(comboBoxFitness);
        Controls.Add(buttonInterpreter);
        Controls.Add(buttonRemoveSolution);
        Controls.Add(buttonInspectSolution);
        Controls.Add(labelHistory);
        Controls.Add(labelProgram);
        Controls.Add(labelSolutionName);
        Controls.Add(labelFitness);
        Controls.Add(labelConfiguration);
        Controls.Add(comboBoxSavedSolution);
        Controls.Add(textBoxProgram);
        Controls.Add(textBoxFitness);
        Controls.Add(textBoxConfiguration);
        Controls.Add(textBoxHistory);
        Controls.Add(buttonHome);
        Controls.Add(buttonQuit);
        Controls.Add(buttonSaved);
        Controls.Add(buttonTask);
        Controls.Add(buttonFitness);
        Controls.Add(buttonConfiguration);
        MaximumSize = new Size(1920, 1080);
        Name = "SavedForm";
        Text = "Saved";
        Load += Saved_Load;
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
    private TextBox textBoxHistory;
    private ContextMenuStrip contextMenuStrip1;
    private TextBox textBoxConfiguration;
    private TextBox textBoxFitness;
    private ContextMenuStrip contextMenuStrip2;
    private TextBox textBoxProgram;
    private ComboBox comboBoxSavedSolution;
    private Label labelConfiguration;
    private Label labelFitness;
    private Label labelSolutionName;
    private Label labelProgram;
    private Label labelHistory;
    private Button buttonInspectSolution;
    private Button buttonRemoveSolution;
    private Button buttonInterpreter;
    private ComboBox comboBoxFitness;
    private Button buttonPlotFitness;
}