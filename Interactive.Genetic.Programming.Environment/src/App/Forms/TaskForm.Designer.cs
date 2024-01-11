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
        SuspendLayout();
        // 
        // buttonQuit
        // 
        buttonQuit.Anchor = AnchorStyles.Top;
        buttonQuit.Location = new Point(1208, 12);
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
        buttonSaved.Location = new Point(1080, 12);
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
        buttonTask.Location = new Point(952, 12);
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
        buttonFitness.Location = new Point(824, 12);
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
        buttonConfiguration.Location = new Point(696, 12);
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
        buttonHome.Location = new Point(568, 12);
        buttonHome.Name = "buttonHome";
        buttonHome.Size = new Size(122, 41);
        buttonHome.TabIndex = 25;
        buttonHome.Text = "Home";
        buttonHome.UseVisualStyleBackColor = true;
        buttonHome.Click += buttonHome_Click;
        // 
        // buttonInspectTask
        // 
        buttonInspectTask.Anchor = AnchorStyles.Left;
        buttonInspectTask.Location = new Point(603, 403);
        buttonInspectTask.Name = "buttonInspectTask";
        buttonInspectTask.Size = new Size(151, 41);
        buttonInspectTask.TabIndex = 69;
        buttonInspectTask.Text = "Inspect Task";
        buttonInspectTask.UseVisualStyleBackColor = true;
        buttonInspectTask.Click += buttonInspectTask_Click;
        // 
        // labelActiveTask
        // 
        labelActiveTask.Anchor = AnchorStyles.Left;
        labelActiveTask.Location = new Point(75, 417);
        labelActiveTask.Name = "labelActiveTask";
        labelActiveTask.Size = new Size(183, 54);
        labelActiveTask.TabIndex = 68;
        labelActiveTask.Text = "Active Task";
        labelActiveTask.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // comboBoxSavedTask
        // 
        comboBoxSavedTask.Anchor = AnchorStyles.Left;
        comboBoxSavedTask.DropDownStyle = ComboBoxStyle.DropDownList;
        comboBoxSavedTask.FormattingEnabled = true;
        comboBoxSavedTask.Location = new Point(278, 431);
        comboBoxSavedTask.Name = "comboBoxSavedTask";
        comboBoxSavedTask.Size = new Size(306, 28);
        comboBoxSavedTask.TabIndex = 67;
        comboBoxSavedTask.SelectedIndexChanged += comboBoxSavedTask_SelectedIndexChanged;
        // 
        // labelTaskName
        // 
        labelTaskName.Anchor = AnchorStyles.Left;
        labelTaskName.BackColor = SystemColors.Control;
        labelTaskName.Location = new Point(75, 214);
        labelTaskName.Name = "labelTaskName";
        labelTaskName.Size = new Size(183, 54);
        labelTaskName.TabIndex = 66;
        labelTaskName.Text = "Task Name";
        labelTaskName.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // textBoxTaskName
        // 
        textBoxTaskName.Anchor = AnchorStyles.Left;
        textBoxTaskName.Location = new Point(278, 228);
        textBoxTaskName.Name = "textBoxTaskName";
        textBoxTaskName.Size = new Size(476, 27);
        textBoxTaskName.TabIndex = 65;
        // 
        // textBoxTaskPath
        // 
        textBoxTaskPath.Anchor = AnchorStyles.Left;
        textBoxTaskPath.Location = new Point(278, 296);
        textBoxTaskPath.Name = "textBoxTaskPath";
        textBoxTaskPath.ReadOnly = true;
        textBoxTaskPath.Size = new Size(476, 27);
        textBoxTaskPath.TabIndex = 70;
        // 
        // buttonUploadTask
        // 
        buttonUploadTask.Anchor = AnchorStyles.Left;
        buttonUploadTask.Location = new Point(104, 289);
        buttonUploadTask.Name = "buttonUploadTask";
        buttonUploadTask.Size = new Size(122, 41);
        buttonUploadTask.TabIndex = 71;
        buttonUploadTask.Text = "Upload Task";
        buttonUploadTask.UseVisualStyleBackColor = true;
        buttonUploadTask.Click += buttonUploadTask_Click;
        // 
        // buttonSaveTask
        // 
        buttonSaveTask.Anchor = AnchorStyles.Left;
        buttonSaveTask.Location = new Point(104, 350);
        buttonSaveTask.Name = "buttonSaveTask";
        buttonSaveTask.Size = new Size(122, 41);
        buttonSaveTask.TabIndex = 72;
        buttonSaveTask.Text = "Save";
        buttonSaveTask.UseVisualStyleBackColor = true;
        buttonSaveTask.Click += buttonSaveTask_Click;
        // 
        // buttonRemoveTask
        // 
        buttonRemoveTask.Anchor = AnchorStyles.Left;
        buttonRemoveTask.Location = new Point(603, 450);
        buttonRemoveTask.Name = "buttonRemoveTask";
        buttonRemoveTask.Size = new Size(151, 41);
        buttonRemoveTask.TabIndex = 73;
        buttonRemoveTask.Text = "Remove Task";
        buttonRemoveTask.UseVisualStyleBackColor = true;
        buttonRemoveTask.Click += buttonRemoveTask_Click;
        // 
        // TaskForm
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1902, 1033);
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
}