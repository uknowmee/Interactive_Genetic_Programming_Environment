namespace App.Forms;

partial class HomeForm
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
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
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        buttonConfiguration = new Button();
        buttonFitness = new Button();
        buttonSaved = new Button();
        buttonTask = new Button();
        buttonQuit = new Button();
        buttonRest = new Button();
        buttonStop = new Button();
        buttonStart = new Button();
        textBoxBestIndividual = new TextBox();
        textBoxHistory = new TextBox();
        labelStatus = new Label();
        labelPopulationSize = new Label();
        labelBestIndividual = new Label();
        labelAvgFitness = new Label();
        LabelProceeded = new Label();
        labelProcedeedValue = new Label();
        labelAvgFitnessValue = new Label();
        labelBestIndividualValue = new Label();
        labelPopulationSizeValue = new Label();
        labelStatusValue = new Label();
        labelTaskName = new Label();
        labelFitnessFunctionName = new Label();
        labelTask = new Label();
        labelFitnessFunction = new Label();
        buttonHome = new Button();
        textBoxModelConfiguration = new TextBox();
        textBoxSolverConfiguration = new TextBox();
        SuspendLayout();
        // 
        // buttonConfiguration
        // 
        buttonConfiguration.Anchor = AnchorStyles.Top;
        buttonConfiguration.Location = new Point(696, 12);
        buttonConfiguration.Name = "buttonConfiguration";
        buttonConfiguration.Size = new Size(122, 41);
        buttonConfiguration.TabIndex = 0;
        buttonConfiguration.Text = "Configuration";
        buttonConfiguration.UseVisualStyleBackColor = true;
        buttonConfiguration.Click += buttonConfiguration_Click;
        // 
        // buttonFitness
        // 
        buttonFitness.Anchor = AnchorStyles.Top;
        buttonFitness.Location = new Point(824, 12);
        buttonFitness.Name = "buttonFitness";
        buttonFitness.Size = new Size(122, 41);
        buttonFitness.TabIndex = 1;
        buttonFitness.Text = "Fitness";
        buttonFitness.UseVisualStyleBackColor = true;
        buttonFitness.Click += buttonFitness_Click;
        // 
        // buttonSaved
        // 
        buttonSaved.Anchor = AnchorStyles.Top;
        buttonSaved.Location = new Point(1080, 12);
        buttonSaved.Name = "buttonSaved";
        buttonSaved.Size = new Size(122, 41);
        buttonSaved.TabIndex = 3;
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
        buttonTask.TabIndex = 2;
        buttonTask.Text = "Task";
        buttonTask.UseVisualStyleBackColor = true;
        buttonTask.Click += buttonTask_Click;
        // 
        // buttonQuit
        // 
        buttonQuit.Anchor = AnchorStyles.Top;
        buttonQuit.Location = new Point(1208, 12);
        buttonQuit.Name = "buttonQuit";
        buttonQuit.Size = new Size(122, 41);
        buttonQuit.TabIndex = 4;
        buttonQuit.Text = "Quit";
        buttonQuit.UseVisualStyleBackColor = true;
        buttonQuit.Click += buttonQuit_Click;
        // 
        // buttonRest
        // 
        buttonRest.Anchor = AnchorStyles.Left;
        buttonRest.Location = new Point(11, 233);
        buttonRest.Name = "buttonRest";
        buttonRest.Size = new Size(122, 41);
        buttonRest.TabIndex = 7;
        buttonRest.Text = "Reset";
        buttonRest.UseVisualStyleBackColor = true;
        buttonRest.Click += buttonReset_Click;
        // 
        // buttonStop
        // 
        buttonStop.Anchor = AnchorStyles.Left;
        buttonStop.Location = new Point(11, 186);
        buttonStop.Name = "buttonStop";
        buttonStop.Size = new Size(122, 41);
        buttonStop.TabIndex = 6;
        buttonStop.Text = "Stop";
        buttonStop.UseVisualStyleBackColor = true;
        buttonStop.Click += buttonStop_Click;
        // 
        // buttonStart
        // 
        buttonStart.Anchor = AnchorStyles.Left;
        buttonStart.Location = new Point(12, 139);
        buttonStart.Name = "buttonStart";
        buttonStart.Size = new Size(122, 41);
        buttonStart.TabIndex = 5;
        buttonStart.Text = "Start";
        buttonStart.UseVisualStyleBackColor = true;
        buttonStart.Click += buttonStart_Click;
        // 
        // textBoxBestIndividual
        // 
        textBoxBestIndividual.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
        textBoxBestIndividual.Location = new Point(1013, 139);
        textBoxBestIndividual.Multiline = true;
        textBoxBestIndividual.Name = "textBoxBestIndividual";
        textBoxBestIndividual.ReadOnly = true;
        textBoxBestIndividual.ScrollBars = ScrollBars.Both;
        textBoxBestIndividual.Size = new Size(877, 882);
        textBoxBestIndividual.TabIndex = 8;
        // 
        // textBoxHistory
        // 
        textBoxHistory.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
        textBoxHistory.Location = new Point(12, 771);
        textBoxHistory.Multiline = true;
        textBoxHistory.Name = "textBoxHistory";
        textBoxHistory.ReadOnly = true;
        textBoxHistory.ScrollBars = ScrollBars.Vertical;
        textBoxHistory.Size = new Size(995, 250);
        textBoxHistory.TabIndex = 9;
        // 
        // labelStatus
        // 
        labelStatus.Anchor = AnchorStyles.Left;
        labelStatus.Location = new Point(11, 487);
        labelStatus.Name = "labelStatus";
        labelStatus.Size = new Size(183, 54);
        labelStatus.TabIndex = 10;
        labelStatus.Text = "Status";
        labelStatus.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // labelPopulationSize
        // 
        labelPopulationSize.Anchor = AnchorStyles.Left;
        labelPopulationSize.Location = new Point(11, 541);
        labelPopulationSize.Name = "labelPopulationSize";
        labelPopulationSize.Size = new Size(183, 54);
        labelPopulationSize.TabIndex = 11;
        labelPopulationSize.Text = "PopulationSize";
        labelPopulationSize.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // labelBestIndividual
        // 
        labelBestIndividual.Anchor = AnchorStyles.Left;
        labelBestIndividual.Location = new Point(10, 595);
        labelBestIndividual.Name = "labelBestIndividual";
        labelBestIndividual.Size = new Size(183, 54);
        labelBestIndividual.TabIndex = 12;
        labelBestIndividual.Text = "Best Individual Fitness";
        labelBestIndividual.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // labelAvgFitness
        // 
        labelAvgFitness.Anchor = AnchorStyles.Left;
        labelAvgFitness.Location = new Point(10, 649);
        labelAvgFitness.Name = "labelAvgFitness";
        labelAvgFitness.Size = new Size(183, 54);
        labelAvgFitness.TabIndex = 13;
        labelAvgFitness.Text = "Avg Fitness";
        labelAvgFitness.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // LabelProceeded
        // 
        LabelProceeded.Anchor = AnchorStyles.Left;
        LabelProceeded.Location = new Point(11, 703);
        LabelProceeded.Name = "LabelProceeded";
        LabelProceeded.Size = new Size(183, 54);
        LabelProceeded.TabIndex = 14;
        LabelProceeded.Text = "Proceeded";
        LabelProceeded.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // labelProcedeedValue
        // 
        labelProcedeedValue.Anchor = AnchorStyles.Left;
        labelProcedeedValue.Location = new Point(200, 703);
        labelProcedeedValue.Name = "labelProcedeedValue";
        labelProcedeedValue.Size = new Size(183, 54);
        labelProcedeedValue.TabIndex = 19;
        labelProcedeedValue.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // labelAvgFitnessValue
        // 
        labelAvgFitnessValue.Anchor = AnchorStyles.Left;
        labelAvgFitnessValue.Location = new Point(199, 649);
        labelAvgFitnessValue.Name = "labelAvgFitnessValue";
        labelAvgFitnessValue.Size = new Size(183, 54);
        labelAvgFitnessValue.TabIndex = 18;
        labelAvgFitnessValue.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // labelBestIndividualValue
        // 
        labelBestIndividualValue.Anchor = AnchorStyles.Left;
        labelBestIndividualValue.Location = new Point(199, 595);
        labelBestIndividualValue.Name = "labelBestIndividualValue";
        labelBestIndividualValue.Size = new Size(183, 54);
        labelBestIndividualValue.TabIndex = 17;
        labelBestIndividualValue.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // labelPopulationSizeValue
        // 
        labelPopulationSizeValue.Anchor = AnchorStyles.Left;
        labelPopulationSizeValue.Location = new Point(200, 541);
        labelPopulationSizeValue.Name = "labelPopulationSizeValue";
        labelPopulationSizeValue.Size = new Size(183, 54);
        labelPopulationSizeValue.TabIndex = 16;
        labelPopulationSizeValue.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // labelStatusValue
        // 
        labelStatusValue.Anchor = AnchorStyles.Left;
        labelStatusValue.Location = new Point(200, 487);
        labelStatusValue.Name = "labelStatusValue";
        labelStatusValue.Size = new Size(183, 54);
        labelStatusValue.TabIndex = 15;
        labelStatusValue.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // labelTaskName
        // 
        labelTaskName.Anchor = AnchorStyles.Left;
        labelTaskName.Location = new Point(822, 703);
        labelTaskName.Name = "labelTaskName";
        labelTaskName.Size = new Size(183, 54);
        labelTaskName.TabIndex = 23;
        labelTaskName.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // labelFitnessFunctionName
        // 
        labelFitnessFunctionName.Anchor = AnchorStyles.Left;
        labelFitnessFunctionName.Location = new Point(822, 649);
        labelFitnessFunctionName.Name = "labelFitnessFunctionName";
        labelFitnessFunctionName.Size = new Size(183, 54);
        labelFitnessFunctionName.TabIndex = 22;
        labelFitnessFunctionName.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // labelTask
        // 
        labelTask.Anchor = AnchorStyles.Left;
        labelTask.Location = new Point(633, 703);
        labelTask.Name = "labelTask";
        labelTask.Size = new Size(183, 54);
        labelTask.TabIndex = 21;
        labelTask.Text = "Task";
        labelTask.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // labelFitnessFunction
        // 
        labelFitnessFunction.Anchor = AnchorStyles.Left;
        labelFitnessFunction.Location = new Point(633, 649);
        labelFitnessFunction.Name = "labelFitnessFunction";
        labelFitnessFunction.Size = new Size(183, 54);
        labelFitnessFunction.TabIndex = 20;
        labelFitnessFunction.Text = "Fitness Function";
        labelFitnessFunction.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // buttonHome
        // 
        buttonHome.Anchor = AnchorStyles.Top;
        buttonHome.Location = new Point(568, 12);
        buttonHome.Name = "buttonHome";
        buttonHome.Size = new Size(122, 41);
        buttonHome.TabIndex = 24;
        buttonHome.Text = "Home";
        buttonHome.UseVisualStyleBackColor = true;
        buttonHome.Click += buttonHome_Click;
        // 
        // textBoxModelConfiguration
        // 
        textBoxModelConfiguration.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
        textBoxModelConfiguration.Location = new Point(295, 139);
        textBoxModelConfiguration.Multiline = true;
        textBoxModelConfiguration.Name = "textBoxModelConfiguration";
        textBoxModelConfiguration.ReadOnly = true;
        textBoxModelConfiguration.Size = new Size(352, 297);
        textBoxModelConfiguration.TabIndex = 25;
        // 
        // textBoxSolverConfiguration
        // 
        textBoxSolverConfiguration.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
        textBoxSolverConfiguration.Location = new Point(653, 139);
        textBoxSolverConfiguration.Multiline = true;
        textBoxSolverConfiguration.Name = "textBoxSolverConfiguration";
        textBoxSolverConfiguration.ReadOnly = true;
        textBoxSolverConfiguration.Size = new Size(352, 297);
        textBoxSolverConfiguration.TabIndex = 26;
        // 
        // HomeForm
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1902, 1033);
        Controls.Add(textBoxSolverConfiguration);
        Controls.Add(textBoxModelConfiguration);
        Controls.Add(buttonHome);
        Controls.Add(labelTaskName);
        Controls.Add(labelFitnessFunctionName);
        Controls.Add(labelTask);
        Controls.Add(labelFitnessFunction);
        Controls.Add(labelProcedeedValue);
        Controls.Add(labelAvgFitnessValue);
        Controls.Add(labelBestIndividualValue);
        Controls.Add(labelPopulationSizeValue);
        Controls.Add(labelStatusValue);
        Controls.Add(LabelProceeded);
        Controls.Add(labelAvgFitness);
        Controls.Add(labelBestIndividual);
        Controls.Add(labelPopulationSize);
        Controls.Add(labelStatus);
        Controls.Add(textBoxHistory);
        Controls.Add(textBoxBestIndividual);
        Controls.Add(buttonRest);
        Controls.Add(buttonStop);
        Controls.Add(buttonStart);
        Controls.Add(buttonQuit);
        Controls.Add(buttonSaved);
        Controls.Add(buttonTask);
        Controls.Add(buttonFitness);
        Controls.Add(buttonConfiguration);
        MaximumSize = new Size(1920, 1080);
        Name = "HomeForm";
        Text = "Home";
        Load += Home_Load;
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Button buttonConfiguration;
    private Button buttonFitness;
    private Button buttonSaved;
    private Button buttonTask;
    private Button buttonQuit;
    private Button buttonRest;
    private Button buttonStop;
    private Button buttonStart;
    private TextBox textBoxBestIndividual;
    private TextBox textBoxHistory;
    private Label labelStatus;
    private Label labelPopulationSize;
    private Label labelBestIndividual;
    private Label labelAvgFitness;
    private Label LabelProceeded;
    private Label labelProcedeedValue;
    private Label labelAvgFitnessValue;
    private Label labelBestIndividualValue;
    private Label labelPopulationSizeValue;
    private Label labelStatusValue;
    private Label labelTaskName;
    private Label labelFitnessFunctionName;
    private Label labelTask;
    private Label labelFitnessFunction;
    private Button buttonHome;
    private TextBox textBoxModelConfiguration;
    private TextBox textBoxSolverConfiguration;
}