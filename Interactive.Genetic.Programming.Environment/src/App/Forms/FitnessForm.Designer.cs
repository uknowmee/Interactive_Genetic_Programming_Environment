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
        buttonQuit = new Button();
        buttonSaved = new Button();
        buttonTask = new Button();
        buttonFitness = new Button();
        buttonConfiguration = new Button();
        buttonHome = new Button();
        labelFitnessName = new Label();
        textBoxFitnessName = new TextBox();
        textBoxPreview = new TextBox();
        textBox1 = new TextBox();
        comboBoxSavedFitness = new ComboBox();
        labelActiveFitness = new Label();
        buttonSaveFitness = new Button();
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
        // labelFitnessName
        // 
        labelFitnessName.Anchor = AnchorStyles.Left;
        labelFitnessName.Location = new Point(49, 97);
        labelFitnessName.Name = "labelFitnessName";
        labelFitnessName.Size = new Size(183, 54);
        labelFitnessName.TabIndex = 59;
        labelFitnessName.Text = "Fitness Name";
        labelFitnessName.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // textBoxFitnessName
        // 
        textBoxFitnessName.Anchor = AnchorStyles.Left;
        textBoxFitnessName.Location = new Point(35, 170);
        textBoxFitnessName.Name = "textBoxFitnessName";
        textBoxFitnessName.Size = new Size(212, 27);
        textBoxFitnessName.TabIndex = 58;
        // 
        // textBoxPreview
        // 
        textBoxPreview.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
        textBoxPreview.Location = new Point(279, 97);
        textBoxPreview.Multiline = true;
        textBoxPreview.Name = "textBoxPreview";
        textBoxPreview.ScrollBars = ScrollBars.Vertical;
        textBoxPreview.Size = new Size(723, 435);
        textBoxPreview.TabIndex = 60;
        // 
        // textBox1
        // 
        textBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
        textBox1.Location = new Point(279, 558);
        textBox1.Multiline = true;
        textBox1.Name = "textBox1";
        textBox1.ReadOnly = true;
        textBox1.ScrollBars = ScrollBars.Vertical;
        textBox1.Size = new Size(723, 435);
        textBox1.TabIndex = 61;
        // 
        // comboBoxSavedFitness
        // 
        comboBoxSavedFitness.Anchor = AnchorStyles.Left;
        comboBoxSavedFitness.DropDownStyle = ComboBoxStyle.DropDownList;
        comboBoxSavedFitness.FormattingEnabled = true;
        comboBoxSavedFitness.Location = new Point(1039, 170);
        comboBoxSavedFitness.Name = "comboBoxSavedFitness";
        comboBoxSavedFitness.Size = new Size(311, 28);
        comboBoxSavedFitness.TabIndex = 62;
        // 
        // labelActiveFitness
        // 
        labelActiveFitness.Anchor = AnchorStyles.Left;
        labelActiveFitness.Location = new Point(1100, 97);
        labelActiveFitness.Name = "labelActiveFitness";
        labelActiveFitness.Size = new Size(183, 54);
        labelActiveFitness.TabIndex = 63;
        labelActiveFitness.Text = "Active Fitness";
        labelActiveFitness.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // buttonSaveFitness
        // 
        buttonSaveFitness.Anchor = AnchorStyles.Left;
        buttonSaveFitness.Location = new Point(79, 222);
        buttonSaveFitness.Name = "buttonSaveFitness";
        buttonSaveFitness.Size = new Size(122, 41);
        buttonSaveFitness.TabIndex = 64;
        buttonSaveFitness.Text = "Save";
        buttonSaveFitness.UseVisualStyleBackColor = true;
        // 
        // FitnessForm
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1902, 1033);
        Controls.Add(buttonSaveFitness);
        Controls.Add(labelActiveFitness);
        Controls.Add(comboBoxSavedFitness);
        Controls.Add(textBox1);
        Controls.Add(textBoxPreview);
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
    private TextBox textBoxPreview;
    private TextBox textBox1;
    private ComboBox comboBoxSavedFitness;
    private Label labelActiveFitness;
    private Button buttonSaveFitness;
}