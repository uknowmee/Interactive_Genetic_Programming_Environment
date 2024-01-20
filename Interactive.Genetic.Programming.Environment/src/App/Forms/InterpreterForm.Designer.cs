using System.ComponentModel;

namespace App.Forms;

partial class InterpreterForm
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
        buttonHome = new Button();
        buttonQuit = new Button();
        buttonSaved = new Button();
        buttonTask = new Button();
        buttonFitness = new Button();
        buttonConfiguration = new Button();
        textBoxProgramCode = new TextBox();
        textBoxProgramInput = new TextBox();
        textBoxProgramOutput = new TextBox();
        buttonRunProgram = new Button();
        textBoxExecutionTime = new TextBox();
        labelExecutionTime = new Label();
        buttonInterpreter = new Button();
        SuspendLayout();
        // 
        // buttonHome
        // 
        buttonHome.Anchor = AnchorStyles.None;
        buttonHome.Location = new Point(501, 12);
        buttonHome.Name = "buttonHome";
        buttonHome.Size = new Size(122, 41);
        buttonHome.TabIndex = 31;
        buttonHome.Text = "Home";
        buttonHome.UseVisualStyleBackColor = true;
        buttonHome.Click += buttonHome_Click;
        // 
        // buttonQuit
        // 
        buttonQuit.Anchor = AnchorStyles.None;
        buttonQuit.Location = new Point(1269, 12);
        buttonQuit.Name = "buttonQuit";
        buttonQuit.Size = new Size(122, 41);
        buttonQuit.TabIndex = 30;
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
        buttonSaved.TabIndex = 29;
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
        buttonTask.TabIndex = 28;
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
        buttonFitness.TabIndex = 27;
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
        buttonConfiguration.TabIndex = 26;
        buttonConfiguration.Text = "Configuration";
        buttonConfiguration.UseVisualStyleBackColor = true;
        buttonConfiguration.Click += buttonConfiguration_Click;
        // 
        // textBoxProgramCode
        // 
        textBoxProgramCode.Anchor = AnchorStyles.None;
        textBoxProgramCode.Location = new Point(64, 137);
        textBoxProgramCode.Multiline = true;
        textBoxProgramCode.Name = "textBoxProgramCode";
        textBoxProgramCode.PlaceholderText = "Define Program";
        textBoxProgramCode.ScrollBars = ScrollBars.Vertical;
        textBoxProgramCode.Size = new Size(815, 806);
        textBoxProgramCode.TabIndex = 61;
        // 
        // textBoxProgramInput
        // 
        textBoxProgramInput.Anchor = AnchorStyles.None;
        textBoxProgramInput.Location = new Point(922, 215);
        textBoxProgramInput.Multiline = true;
        textBoxProgramInput.Name = "textBoxProgramInput";
        textBoxProgramInput.PlaceholderText = "Place program input values separated with space.";
        textBoxProgramInput.ScrollBars = ScrollBars.Vertical;
        textBoxProgramInput.Size = new Size(917, 201);
        textBoxProgramInput.TabIndex = 62;
        // 
        // textBoxProgramOutput
        // 
        textBoxProgramOutput.Anchor = AnchorStyles.None;
        textBoxProgramOutput.Location = new Point(922, 436);
        textBoxProgramOutput.Multiline = true;
        textBoxProgramOutput.Name = "textBoxProgramOutput";
        textBoxProgramOutput.ReadOnly = true;
        textBoxProgramOutput.ScrollBars = ScrollBars.Vertical;
        textBoxProgramOutput.Size = new Size(917, 507);
        textBoxProgramOutput.TabIndex = 63;
        // 
        // buttonRunProgram
        // 
        buttonRunProgram.Anchor = AnchorStyles.None;
        buttonRunProgram.Location = new Point(922, 137);
        buttonRunProgram.Name = "buttonRunProgram";
        buttonRunProgram.Size = new Size(151, 41);
        buttonRunProgram.TabIndex = 75;
        buttonRunProgram.Text = "Run Program";
        buttonRunProgram.UseVisualStyleBackColor = true;
        buttonRunProgram.Click += buttonRunProgram_Click;
        // 
        // textBoxExecutionTime
        // 
        textBoxExecutionTime.Anchor = AnchorStyles.None;
        textBoxExecutionTime.Location = new Point(1596, 144);
        textBoxExecutionTime.Name = "textBoxExecutionTime";
        textBoxExecutionTime.Size = new Size(170, 27);
        textBoxExecutionTime.TabIndex = 77;
        // 
        // labelExecutionTime
        // 
        labelExecutionTime.Anchor = AnchorStyles.None;
        labelExecutionTime.Location = new Point(1529, 94);
        labelExecutionTime.Name = "labelExecutionTime";
        labelExecutionTime.Size = new Size(310, 54);
        labelExecutionTime.TabIndex = 76;
        labelExecutionTime.Text = "Max Execution Time (3ms - 10s) [ms]";
        labelExecutionTime.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // buttonInterpreter
        // 
        buttonInterpreter.Anchor = AnchorStyles.None;
        buttonInterpreter.Location = new Point(1141, 12);
        buttonInterpreter.Name = "buttonInterpreter";
        buttonInterpreter.Size = new Size(122, 41);
        buttonInterpreter.TabIndex = 78;
        buttonInterpreter.Text = "Interpreter";
        buttonInterpreter.UseVisualStyleBackColor = true;
        buttonInterpreter.Click += buttonInterpreter_Click;
        // 
        // InterpreterForm
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1902, 1033);
        Controls.Add(buttonInterpreter);
        Controls.Add(textBoxExecutionTime);
        Controls.Add(labelExecutionTime);
        Controls.Add(buttonRunProgram);
        Controls.Add(textBoxProgramOutput);
        Controls.Add(textBoxProgramInput);
        Controls.Add(textBoxProgramCode);
        Controls.Add(buttonHome);
        Controls.Add(buttonQuit);
        Controls.Add(buttonSaved);
        Controls.Add(buttonTask);
        Controls.Add(buttonFitness);
        Controls.Add(buttonConfiguration);
        Name = "InterpreterForm";
        Text = "Interpreter";
        Load += InterpreterForm_Load;
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Button buttonHome;
    private Button buttonQuit;
    private Button buttonSaved;
    private Button buttonTask;
    private Button buttonFitness;
    private Button buttonConfiguration;
    private TextBox textBoxProgramCode;
    private TextBox textBoxProgramInput;
    private TextBox textBoxProgramOutput;
    private Button buttonRunProgram;
    private TextBox textBoxExecutionTime;
    private Label labelExecutionTime;
    private Button buttonInterpreter;
}