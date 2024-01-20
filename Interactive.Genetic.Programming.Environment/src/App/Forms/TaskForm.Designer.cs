using System.ComponentModel;

namespace App.Forms;

partial class TaskForm
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
        ComponentResourceManager resources = new ComponentResourceManager(typeof(TaskForm));
        buttonQuit = new Button();
        buttonSaved = new Button();
        buttonTask = new Button();
        buttonFitness = new Button();
        buttonConfiguration = new Button();
        buttonHome = new Button();
        buttonInspectTask = new Button();
        labelActiveTask = new Label();
        comboBoxSavedTask = new ComboBox();
        labelTaskName = new Label();
        textBoxTaskName = new TextBox();
        textBoxTaskPath = new TextBox();
        buttonUploadTask = new Button();
        buttonSaveTask = new Button();
        buttonRemoveTask = new Button();
        textBoxTaskReadme = new TextBox();
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
        // buttonInspectTask
        // 
        buttonInspectTask.Anchor = AnchorStyles.None;
        buttonInspectTask.Location = new Point(650, 510);
        buttonInspectTask.Name = "buttonInspectTask";
        buttonInspectTask.Size = new Size(151, 41);
        buttonInspectTask.TabIndex = 69;
        buttonInspectTask.Text = "Inspect Task";
        buttonInspectTask.UseVisualStyleBackColor = true;
        buttonInspectTask.Click += buttonInspectTask_Click;
        // 
        // labelActiveTask
        // 
        labelActiveTask.Anchor = AnchorStyles.None;
        labelActiveTask.Location = new Point(122, 524);
        labelActiveTask.Name = "labelActiveTask";
        labelActiveTask.Size = new Size(183, 54);
        labelActiveTask.TabIndex = 68;
        labelActiveTask.Text = "Active Task";
        labelActiveTask.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // comboBoxSavedTask
        // 
        comboBoxSavedTask.Anchor = AnchorStyles.None;
        comboBoxSavedTask.DropDownStyle = ComboBoxStyle.DropDownList;
        comboBoxSavedTask.FormattingEnabled = true;
        comboBoxSavedTask.Location = new Point(325, 538);
        comboBoxSavedTask.Name = "comboBoxSavedTask";
        comboBoxSavedTask.Size = new Size(306, 28);
        comboBoxSavedTask.TabIndex = 67;
        comboBoxSavedTask.SelectedIndexChanged += comboBoxSavedTask_SelectedIndexChanged;
        // 
        // labelTaskName
        // 
        labelTaskName.Anchor = AnchorStyles.None;
        labelTaskName.BackColor = SystemColors.Control;
        labelTaskName.Location = new Point(122, 321);
        labelTaskName.Name = "labelTaskName";
        labelTaskName.Size = new Size(183, 54);
        labelTaskName.TabIndex = 66;
        labelTaskName.Text = "Task Name";
        labelTaskName.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // textBoxTaskName
        // 
        textBoxTaskName.Anchor = AnchorStyles.None;
        textBoxTaskName.Location = new Point(325, 335);
        textBoxTaskName.Name = "textBoxTaskName";
        textBoxTaskName.Size = new Size(476, 27);
        textBoxTaskName.TabIndex = 65;
        // 
        // textBoxTaskPath
        // 
        textBoxTaskPath.Anchor = AnchorStyles.None;
        textBoxTaskPath.Location = new Point(325, 403);
        textBoxTaskPath.Name = "textBoxTaskPath";
        textBoxTaskPath.ReadOnly = true;
        textBoxTaskPath.Size = new Size(476, 27);
        textBoxTaskPath.TabIndex = 70;
        // 
        // buttonUploadTask
        // 
        buttonUploadTask.Anchor = AnchorStyles.None;
        buttonUploadTask.Location = new Point(151, 396);
        buttonUploadTask.Name = "buttonUploadTask";
        buttonUploadTask.Size = new Size(122, 41);
        buttonUploadTask.TabIndex = 71;
        buttonUploadTask.Text = "Upload Task";
        buttonUploadTask.UseVisualStyleBackColor = true;
        buttonUploadTask.Click += buttonUploadTask_Click;
        // 
        // buttonSaveTask
        // 
        buttonSaveTask.Anchor = AnchorStyles.None;
        buttonSaveTask.Location = new Point(151, 457);
        buttonSaveTask.Name = "buttonSaveTask";
        buttonSaveTask.Size = new Size(122, 41);
        buttonSaveTask.TabIndex = 72;
        buttonSaveTask.Text = "Save";
        buttonSaveTask.UseVisualStyleBackColor = true;
        buttonSaveTask.Click += buttonSaveTask_Click;
        // 
        // buttonRemoveTask
        // 
        buttonRemoveTask.Anchor = AnchorStyles.None;
        buttonRemoveTask.Location = new Point(650, 557);
        buttonRemoveTask.Name = "buttonRemoveTask";
        buttonRemoveTask.Size = new Size(151, 41);
        buttonRemoveTask.TabIndex = 73;
        buttonRemoveTask.Text = "Remove Task";
        buttonRemoveTask.UseVisualStyleBackColor = true;
        buttonRemoveTask.Click += buttonRemoveTask_Click;
        // 
        // textBoxTaskReadme
        // 
        textBoxTaskReadme.Anchor = AnchorStyles.None;
        textBoxTaskReadme.Location = new Point(1013, 178);
        textBoxTaskReadme.Multiline = true;
        textBoxTaskReadme.Name = "textBoxTaskReadme";
        textBoxTaskReadme.ReadOnly = true;
        textBoxTaskReadme.ScrollBars = ScrollBars.Vertical;
        textBoxTaskReadme.Size = new Size(795, 757);
        textBoxTaskReadme.TabIndex = 74;
        textBoxTaskReadme.Text = resources.GetString("textBoxTaskReadme.Text");
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
        // TaskForm
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1902, 1033);
        Controls.Add(buttonInterpreter);
        Controls.Add(textBoxTaskReadme);
        Controls.Add(buttonRemoveTask);
        Controls.Add(buttonSaveTask);
        Controls.Add(buttonUploadTask);
        Controls.Add(textBoxTaskPath);
        Controls.Add(buttonInspectTask);
        Controls.Add(labelActiveTask);
        Controls.Add(comboBoxSavedTask);
        Controls.Add(labelTaskName);
        Controls.Add(textBoxTaskName);
        Controls.Add(buttonHome);
        Controls.Add(buttonQuit);
        Controls.Add(buttonSaved);
        Controls.Add(buttonTask);
        Controls.Add(buttonFitness);
        Controls.Add(buttonConfiguration);
        MaximumSize = new Size(1920, 1080);
        Name = "TaskForm";
        Text = "Task";
        Load += Task_Load;
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
    private Button buttonInspectTask;
    private Label labelActiveTask;
    private ComboBox comboBoxSavedTask;
    private Label labelTaskName;
    private TextBox textBoxTaskName;
    private TextBox textBoxTaskPath;
    private Button buttonUploadTask;
    private Button buttonSaveTask;
    private Button buttonRemoveTask;
    private TextBox textBoxTaskReadme;
    private Button buttonInterpreter;
}