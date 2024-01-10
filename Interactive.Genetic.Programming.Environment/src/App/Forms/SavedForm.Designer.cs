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
        textBoxLogs = new TextBox();
        contextMenuStrip1 = new ContextMenuStrip(components);
        textBox1 = new TextBox();
        textBox2 = new TextBox();
        contextMenuStrip2 = new ContextMenuStrip(components);
        textBox3 = new TextBox();
        comboBoxSavedTask = new ComboBox();
        labelTaskName = new Label();
        label1 = new Label();
        label2 = new Label();
        label3 = new Label();
        label4 = new Label();
        buttonInspectTask = new Button();
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
        // textBoxLogs
        // 
        textBoxLogs.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        textBoxLogs.Enabled = false;
        textBoxLogs.Location = new Point(12, 690);
        textBoxLogs.Multiline = true;
        textBoxLogs.Name = "textBoxLogs";
        textBoxLogs.ScrollBars = ScrollBars.Vertical;
        textBoxLogs.Size = new Size(995, 331);
        textBoxLogs.TabIndex = 26;
        // 
        // contextMenuStrip1
        // 
        contextMenuStrip1.ImageScalingSize = new Size(20, 20);
        contextMenuStrip1.Name = "contextMenuStrip1";
        contextMenuStrip1.Size = new Size(61, 4);
        // 
        // textBox1
        // 
        textBox1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        textBox1.Enabled = false;
        textBox1.Location = new Point(12, 139);
        textBox1.Multiline = true;
        textBox1.Name = "textBox1";
        textBox1.ScrollBars = ScrollBars.Vertical;
        textBox1.Size = new Size(469, 443);
        textBox1.TabIndex = 62;
        // 
        // textBox2
        // 
        textBox2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        textBox2.Enabled = false;
        textBox2.Location = new Point(505, 139);
        textBox2.Multiline = true;
        textBox2.Name = "textBox2";
        textBox2.ScrollBars = ScrollBars.Vertical;
        textBox2.Size = new Size(502, 443);
        textBox2.TabIndex = 63;
        // 
        // contextMenuStrip2
        // 
        contextMenuStrip2.ImageScalingSize = new Size(20, 20);
        contextMenuStrip2.Name = "contextMenuStrip2";
        contextMenuStrip2.Size = new Size(61, 4);
        // 
        // textBox3
        // 
        textBox3.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        textBox3.Enabled = false;
        textBox3.Location = new Point(1028, 351);
        textBox3.Multiline = true;
        textBox3.Name = "textBox3";
        textBox3.ScrollBars = ScrollBars.Vertical;
        textBox3.Size = new Size(871, 670);
        textBox3.TabIndex = 65;
        // 
        // comboBoxSavedTask
        // 
        comboBoxSavedTask.Anchor = AnchorStyles.Left;
        comboBoxSavedTask.DropDownStyle = ComboBoxStyle.DropDownList;
        comboBoxSavedTask.FormattingEnabled = true;
        comboBoxSavedTask.Location = new Point(1316, 139);
        comboBoxSavedTask.Name = "comboBoxSavedTask";
        comboBoxSavedTask.Size = new Size(306, 28);
        comboBoxSavedTask.TabIndex = 68;
        // 
        // labelTaskName
        // 
        labelTaskName.Anchor = AnchorStyles.Left;
        labelTaskName.BackColor = SystemColors.Control;
        labelTaskName.Location = new Point(12, 82);
        labelTaskName.Name = "labelTaskName";
        labelTaskName.Size = new Size(183, 54);
        labelTaskName.TabIndex = 69;
        labelTaskName.Text = "Configuration";
        labelTaskName.TextAlign = ContentAlignment.BottomLeft;
        // 
        // label1
        // 
        label1.Anchor = AnchorStyles.Left;
        label1.BackColor = SystemColors.Control;
        label1.Location = new Point(505, 82);
        label1.Name = "label1";
        label1.Size = new Size(183, 54);
        label1.TabIndex = 70;
        label1.Text = "Fitness";
        label1.TextAlign = ContentAlignment.BottomLeft;
        // 
        // label2
        // 
        label2.Anchor = AnchorStyles.Left;
        label2.BackColor = SystemColors.Control;
        label2.Location = new Point(1127, 125);
        label2.Name = "label2";
        label2.Size = new Size(183, 54);
        label2.TabIndex = 71;
        label2.Text = "Task Name";
        label2.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // label3
        // 
        label3.Anchor = AnchorStyles.None;
        label3.BackColor = SystemColors.Control;
        label3.Location = new Point(1028, 294);
        label3.Name = "label3";
        label3.Size = new Size(183, 54);
        label3.TabIndex = 72;
        label3.Text = "Program";
        label3.TextAlign = ContentAlignment.BottomLeft;
        // 
        // label4
        // 
        label4.Anchor = AnchorStyles.Left;
        label4.BackColor = SystemColors.Control;
        label4.Location = new Point(12, 633);
        label4.Name = "label4";
        label4.Size = new Size(183, 54);
        label4.TabIndex = 73;
        label4.Text = "History";
        label4.TextAlign = ContentAlignment.BottomLeft;
        // 
        // buttonInspectTask
        // 
        buttonInspectTask.Anchor = AnchorStyles.Left;
        buttonInspectTask.Location = new Point(1643, 132);
        buttonInspectTask.Name = "buttonInspectTask";
        buttonInspectTask.Size = new Size(151, 41);
        buttonInspectTask.TabIndex = 74;
        buttonInspectTask.Text = "Inspect Task";
        buttonInspectTask.UseVisualStyleBackColor = true;
        // 
        // SavedForm
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1902, 1033);
        Controls.Add(buttonInspectTask);
        Controls.Add(label4);
        Controls.Add(label3);
        Controls.Add(label2);
        Controls.Add(label1);
        Controls.Add(labelTaskName);
        Controls.Add(comboBoxSavedTask);
        Controls.Add(textBox3);
        Controls.Add(textBox2);
        Controls.Add(textBox1);
        Controls.Add(textBoxLogs);
        Controls.Add(buttonHome);
        Controls.Add(buttonQuit);
        Controls.Add(buttonSaved);
        Controls.Add(buttonTask);
        Controls.Add(buttonFitness);
        Controls.Add(buttonConfiguration);
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
    private TextBox textBoxLogs;
    private ContextMenuStrip contextMenuStrip1;
    private TextBox textBox1;
    private TextBox textBox2;
    private ContextMenuStrip contextMenuStrip2;
    private TextBox textBox3;
    private ComboBox comboBoxSavedTask;
    private Label labelTaskName;
    private Label label1;
    private Label label2;
    private Label label3;
    private Label label4;
    private Button buttonInspectTask;
}