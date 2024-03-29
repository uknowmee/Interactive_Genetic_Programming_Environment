﻿using System.ComponentModel;

namespace App.Forms;
partial class ConfigurationForm
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
        groupBoxModel = new GroupBox();
        textBoxNewVarExpressionChance = new TextBox();
        labelMaxInt = new Label();
        textBoxNewDeepNodeGenerationFall = new TextBox();
        textBoxNewChildOfForNodeChance = new TextBox();
        textBoxNewDeepNodeGenerationChance = new TextBox();
        labelNewChildOfProgramNodeChance = new Label();
        textBoxNewChildOfProgramNodeChance = new TextBox();
        textBoxNewExpressionInForComparisonChance = new TextBox();
        labelNewVarExpressionChance = new Label();
        textBoxMaxInt = new TextBox();
        labelNextTwoArgExpressionChance = new Label();
        labelNewDeepNodeGenerationChance = new Label();
        textBoxNewChildOfIfNodeChance = new TextBox();
        labelNewLogicExpressionChance = new Label();
        labelNewDeepNodeGenerationFall = new Label();
        labelNewChildOfIfNodeChance = new Label();
        textBoxNewLogicExpressionChance = new TextBox();
        textBoxNextTwoArgExpressionChance = new TextBox();
        labelNewExpressionInForComparisonChance = new Label();
        labelNewChildOfForNodeChance = new Label();
        groupBoxSolver = new GroupBox();
        textBoxSwapLinesProbability = new TextBox();
        labelSubtreeMutationProbability = new Label();
        labelSwapLinesProbability = new Label();
        textBoxDeleteLineProbability = new TextBox();
        labelDeleteLineProbability = new Label();
        labelNewLineProbability = new Label();
        textBoxNewLineProbability = new TextBox();
        labelHorizontalModificationProbability = new Label();
        textBoxPointMutationProbability = new TextBox();
        textBoxSubtreeMutationProbability = new TextBox();
        labelPointMutationProbability = new Label();
        textBoxHorizontalModificationProbability = new TextBox();
        textBoxMutationProbability = new TextBox();
        labelPopulationSize = new Label();
        labelMutationProbability = new Label();
        labelNumOfTestCases = new Label();
        textBoxNumOfTestCases = new TextBox();
        textBoxCrossoverProbability = new TextBox();
        labelCrossoverProbability = new Label();
        textBoxInputLength = new TextBox();
        labelInputLength = new Label();
        labelTournamentSize = new Label();
        textBoxExecutionTime = new TextBox();
        textBoxTournamentSize = new TextBox();
        labelMaxGenerations = new Label();
        textBoxError = new TextBox();
        labelExecutionTime = new Label();
        textBoxPopulationSize = new TextBox();
        labelError = new Label();
        textBoxMaxGenerations = new TextBox();
        buttonInterpreter = new Button();
        groupBoxApp = new GroupBox();
        buttonTaskFormatSwitcher = new Button();
        labelTaskFormat = new Label();
        groupBoxModel.SuspendLayout();
        groupBoxSolver.SuspendLayout();
        groupBoxApp.SuspendLayout();
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
        // groupBoxModel
        // 
        groupBoxModel.Anchor = AnchorStyles.None;
        groupBoxModel.Controls.Add(textBoxNewVarExpressionChance);
        groupBoxModel.Controls.Add(labelMaxInt);
        groupBoxModel.Controls.Add(textBoxNewDeepNodeGenerationFall);
        groupBoxModel.Controls.Add(textBoxNewChildOfForNodeChance);
        groupBoxModel.Controls.Add(textBoxNewDeepNodeGenerationChance);
        groupBoxModel.Controls.Add(labelNewChildOfProgramNodeChance);
        groupBoxModel.Controls.Add(textBoxNewChildOfProgramNodeChance);
        groupBoxModel.Controls.Add(textBoxNewExpressionInForComparisonChance);
        groupBoxModel.Controls.Add(labelNewVarExpressionChance);
        groupBoxModel.Controls.Add(textBoxMaxInt);
        groupBoxModel.Controls.Add(labelNextTwoArgExpressionChance);
        groupBoxModel.Controls.Add(labelNewDeepNodeGenerationChance);
        groupBoxModel.Controls.Add(textBoxNewChildOfIfNodeChance);
        groupBoxModel.Controls.Add(labelNewLogicExpressionChance);
        groupBoxModel.Controls.Add(labelNewDeepNodeGenerationFall);
        groupBoxModel.Controls.Add(labelNewChildOfIfNodeChance);
        groupBoxModel.Controls.Add(textBoxNewLogicExpressionChance);
        groupBoxModel.Controls.Add(textBoxNextTwoArgExpressionChance);
        groupBoxModel.Controls.Add(labelNewExpressionInForComparisonChance);
        groupBoxModel.Controls.Add(labelNewChildOfForNodeChance);
        groupBoxModel.Location = new Point(67, 117);
        groupBoxModel.Name = "groupBoxModel";
        groupBoxModel.Size = new Size(828, 616);
        groupBoxModel.TabIndex = 26;
        groupBoxModel.TabStop = false;
        groupBoxModel.Text = "Model Configuration";
        // 
        // textBoxNewVarExpressionChance
        // 
        textBoxNewVarExpressionChance.Anchor = AnchorStyles.None;
        textBoxNewVarExpressionChance.Location = new Point(335, 535);
        textBoxNewVarExpressionChance.Name = "textBoxNewVarExpressionChance";
        textBoxNewVarExpressionChance.Size = new Size(170, 27);
        textBoxNewVarExpressionChance.TabIndex = 47;
        textBoxNewVarExpressionChance.KeyPress += textBoxNewVarExpressionChance_KeyPress;
        // 
        // labelMaxInt
        // 
        labelMaxInt.Anchor = AnchorStyles.None;
        labelMaxInt.Location = new Point(19, 35);
        labelMaxInt.Name = "labelMaxInt";
        labelMaxInt.Size = new Size(310, 54);
        labelMaxInt.TabIndex = 28;
        labelMaxInt.Text = "MaxInt";
        labelMaxInt.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // textBoxNewDeepNodeGenerationFall
        // 
        textBoxNewDeepNodeGenerationFall.Anchor = AnchorStyles.None;
        textBoxNewDeepNodeGenerationFall.Location = new Point(335, 211);
        textBoxNewDeepNodeGenerationFall.Name = "textBoxNewDeepNodeGenerationFall";
        textBoxNewDeepNodeGenerationFall.Size = new Size(170, 27);
        textBoxNewDeepNodeGenerationFall.TabIndex = 40;
        textBoxNewDeepNodeGenerationFall.KeyPress += textBoxNewDeepNodeGenerationFall_KeyPress;
        // 
        // textBoxNewChildOfForNodeChance
        // 
        textBoxNewChildOfForNodeChance.Anchor = AnchorStyles.None;
        textBoxNewChildOfForNodeChance.Location = new Point(335, 265);
        textBoxNewChildOfForNodeChance.Name = "textBoxNewChildOfForNodeChance";
        textBoxNewChildOfForNodeChance.Size = new Size(170, 27);
        textBoxNewChildOfForNodeChance.TabIndex = 41;
        textBoxNewChildOfForNodeChance.KeyPress += textBoxNewChildOfForNodeChance_KeyPress;
        // 
        // textBoxNewDeepNodeGenerationChance
        // 
        textBoxNewDeepNodeGenerationChance.Anchor = AnchorStyles.None;
        textBoxNewDeepNodeGenerationChance.Location = new Point(335, 157);
        textBoxNewDeepNodeGenerationChance.Name = "textBoxNewDeepNodeGenerationChance";
        textBoxNewDeepNodeGenerationChance.Size = new Size(170, 27);
        textBoxNewDeepNodeGenerationChance.TabIndex = 39;
        textBoxNewDeepNodeGenerationChance.KeyPress += textBoxNewDeepNodeGenerationChance_KeyPress;
        // 
        // labelNewChildOfProgramNodeChance
        // 
        labelNewChildOfProgramNodeChance.Anchor = AnchorStyles.None;
        labelNewChildOfProgramNodeChance.Location = new Point(19, 89);
        labelNewChildOfProgramNodeChance.Name = "labelNewChildOfProgramNodeChance";
        labelNewChildOfProgramNodeChance.Size = new Size(310, 54);
        labelNewChildOfProgramNodeChance.TabIndex = 29;
        labelNewChildOfProgramNodeChance.Text = "NewChildOfProgramNodeChance";
        labelNewChildOfProgramNodeChance.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // textBoxNewChildOfProgramNodeChance
        // 
        textBoxNewChildOfProgramNodeChance.Anchor = AnchorStyles.None;
        textBoxNewChildOfProgramNodeChance.Location = new Point(335, 103);
        textBoxNewChildOfProgramNodeChance.Name = "textBoxNewChildOfProgramNodeChance";
        textBoxNewChildOfProgramNodeChance.Size = new Size(170, 27);
        textBoxNewChildOfProgramNodeChance.TabIndex = 38;
        textBoxNewChildOfProgramNodeChance.KeyPress += textBoxNewChildOfProgramNodeChance_KeyPress;
        // 
        // textBoxNewExpressionInForComparisonChance
        // 
        textBoxNewExpressionInForComparisonChance.Anchor = AnchorStyles.None;
        textBoxNewExpressionInForComparisonChance.Location = new Point(335, 319);
        textBoxNewExpressionInForComparisonChance.Name = "textBoxNewExpressionInForComparisonChance";
        textBoxNewExpressionInForComparisonChance.Size = new Size(170, 27);
        textBoxNewExpressionInForComparisonChance.TabIndex = 42;
        textBoxNewExpressionInForComparisonChance.KeyPress += textBoxNewExpressionInForComparisonChance_KeyPress;
        // 
        // labelNewVarExpressionChance
        // 
        labelNewVarExpressionChance.Anchor = AnchorStyles.None;
        labelNewVarExpressionChance.Location = new Point(19, 521);
        labelNewVarExpressionChance.Name = "labelNewVarExpressionChance";
        labelNewVarExpressionChance.Size = new Size(310, 54);
        labelNewVarExpressionChance.TabIndex = 46;
        labelNewVarExpressionChance.Text = "NewVarExpressionChance";
        labelNewVarExpressionChance.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // textBoxMaxInt
        // 
        textBoxMaxInt.Anchor = AnchorStyles.None;
        textBoxMaxInt.Location = new Point(335, 49);
        textBoxMaxInt.Name = "textBoxMaxInt";
        textBoxMaxInt.Size = new Size(170, 27);
        textBoxMaxInt.TabIndex = 37;
        textBoxMaxInt.KeyPress += textBoxMaxInt_KeyPress;
        // 
        // labelNextTwoArgExpressionChance
        // 
        labelNextTwoArgExpressionChance.Anchor = AnchorStyles.None;
        labelNextTwoArgExpressionChance.Location = new Point(19, 467);
        labelNextTwoArgExpressionChance.Name = "labelNextTwoArgExpressionChance";
        labelNextTwoArgExpressionChance.Size = new Size(310, 54);
        labelNextTwoArgExpressionChance.TabIndex = 36;
        labelNextTwoArgExpressionChance.Text = "NextTwoArgExpressionChance";
        labelNextTwoArgExpressionChance.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // labelNewDeepNodeGenerationChance
        // 
        labelNewDeepNodeGenerationChance.Anchor = AnchorStyles.None;
        labelNewDeepNodeGenerationChance.Location = new Point(19, 143);
        labelNewDeepNodeGenerationChance.Name = "labelNewDeepNodeGenerationChance";
        labelNewDeepNodeGenerationChance.Size = new Size(310, 54);
        labelNewDeepNodeGenerationChance.TabIndex = 30;
        labelNewDeepNodeGenerationChance.Text = "NewDeepNodeGenerationChance";
        labelNewDeepNodeGenerationChance.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // textBoxNewChildOfIfNodeChance
        // 
        textBoxNewChildOfIfNodeChance.Anchor = AnchorStyles.None;
        textBoxNewChildOfIfNodeChance.Location = new Point(335, 373);
        textBoxNewChildOfIfNodeChance.Name = "textBoxNewChildOfIfNodeChance";
        textBoxNewChildOfIfNodeChance.Size = new Size(170, 27);
        textBoxNewChildOfIfNodeChance.TabIndex = 43;
        textBoxNewChildOfIfNodeChance.KeyPress += textBoxNewChildOfIfNodeChance_KeyPress;
        // 
        // labelNewLogicExpressionChance
        // 
        labelNewLogicExpressionChance.Anchor = AnchorStyles.None;
        labelNewLogicExpressionChance.Location = new Point(19, 413);
        labelNewLogicExpressionChance.Name = "labelNewLogicExpressionChance";
        labelNewLogicExpressionChance.Size = new Size(310, 54);
        labelNewLogicExpressionChance.TabIndex = 35;
        labelNewLogicExpressionChance.Text = "NewLogicExpressionChance";
        labelNewLogicExpressionChance.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // labelNewDeepNodeGenerationFall
        // 
        labelNewDeepNodeGenerationFall.Anchor = AnchorStyles.None;
        labelNewDeepNodeGenerationFall.Location = new Point(19, 197);
        labelNewDeepNodeGenerationFall.Name = "labelNewDeepNodeGenerationFall";
        labelNewDeepNodeGenerationFall.Size = new Size(310, 54);
        labelNewDeepNodeGenerationFall.TabIndex = 31;
        labelNewDeepNodeGenerationFall.Text = "NewDeepNodeGenerationFall";
        labelNewDeepNodeGenerationFall.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // labelNewChildOfIfNodeChance
        // 
        labelNewChildOfIfNodeChance.Anchor = AnchorStyles.None;
        labelNewChildOfIfNodeChance.Location = new Point(19, 359);
        labelNewChildOfIfNodeChance.Name = "labelNewChildOfIfNodeChance";
        labelNewChildOfIfNodeChance.Size = new Size(310, 54);
        labelNewChildOfIfNodeChance.TabIndex = 34;
        labelNewChildOfIfNodeChance.Text = "NewChildOfIfNodeChance";
        labelNewChildOfIfNodeChance.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // textBoxNewLogicExpressionChance
        // 
        textBoxNewLogicExpressionChance.Anchor = AnchorStyles.None;
        textBoxNewLogicExpressionChance.Location = new Point(335, 427);
        textBoxNewLogicExpressionChance.Name = "textBoxNewLogicExpressionChance";
        textBoxNewLogicExpressionChance.Size = new Size(170, 27);
        textBoxNewLogicExpressionChance.TabIndex = 44;
        textBoxNewLogicExpressionChance.KeyPress += textBoxNewLogicExpressionChance_KeyPress;
        // 
        // textBoxNextTwoArgExpressionChance
        // 
        textBoxNextTwoArgExpressionChance.Anchor = AnchorStyles.None;
        textBoxNextTwoArgExpressionChance.Location = new Point(335, 481);
        textBoxNextTwoArgExpressionChance.Name = "textBoxNextTwoArgExpressionChance";
        textBoxNextTwoArgExpressionChance.Size = new Size(170, 27);
        textBoxNextTwoArgExpressionChance.TabIndex = 45;
        textBoxNextTwoArgExpressionChance.KeyPress += textBoxNextTwoArgExpressionChance_KeyPress;
        // 
        // labelNewExpressionInForComparisonChance
        // 
        labelNewExpressionInForComparisonChance.Anchor = AnchorStyles.None;
        labelNewExpressionInForComparisonChance.Location = new Point(19, 305);
        labelNewExpressionInForComparisonChance.Name = "labelNewExpressionInForComparisonChance";
        labelNewExpressionInForComparisonChance.Size = new Size(310, 54);
        labelNewExpressionInForComparisonChance.TabIndex = 33;
        labelNewExpressionInForComparisonChance.Text = "NewExpressionInForComparisonChance";
        labelNewExpressionInForComparisonChance.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // labelNewChildOfForNodeChance
        // 
        labelNewChildOfForNodeChance.Anchor = AnchorStyles.None;
        labelNewChildOfForNodeChance.Location = new Point(19, 251);
        labelNewChildOfForNodeChance.Name = "labelNewChildOfForNodeChance";
        labelNewChildOfForNodeChance.Size = new Size(310, 54);
        labelNewChildOfForNodeChance.TabIndex = 32;
        labelNewChildOfForNodeChance.Text = "NewChildOfForNodeChance";
        labelNewChildOfForNodeChance.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // groupBoxSolver
        // 
        groupBoxSolver.Anchor = AnchorStyles.None;
        groupBoxSolver.Controls.Add(textBoxSwapLinesProbability);
        groupBoxSolver.Controls.Add(labelSubtreeMutationProbability);
        groupBoxSolver.Controls.Add(labelSwapLinesProbability);
        groupBoxSolver.Controls.Add(textBoxDeleteLineProbability);
        groupBoxSolver.Controls.Add(labelDeleteLineProbability);
        groupBoxSolver.Controls.Add(labelNewLineProbability);
        groupBoxSolver.Controls.Add(textBoxNewLineProbability);
        groupBoxSolver.Controls.Add(labelHorizontalModificationProbability);
        groupBoxSolver.Controls.Add(textBoxPointMutationProbability);
        groupBoxSolver.Controls.Add(textBoxSubtreeMutationProbability);
        groupBoxSolver.Controls.Add(labelPointMutationProbability);
        groupBoxSolver.Controls.Add(textBoxHorizontalModificationProbability);
        groupBoxSolver.Controls.Add(textBoxMutationProbability);
        groupBoxSolver.Controls.Add(labelPopulationSize);
        groupBoxSolver.Controls.Add(labelMutationProbability);
        groupBoxSolver.Controls.Add(labelNumOfTestCases);
        groupBoxSolver.Controls.Add(textBoxNumOfTestCases);
        groupBoxSolver.Controls.Add(textBoxCrossoverProbability);
        groupBoxSolver.Controls.Add(labelCrossoverProbability);
        groupBoxSolver.Controls.Add(textBoxInputLength);
        groupBoxSolver.Controls.Add(labelInputLength);
        groupBoxSolver.Controls.Add(labelTournamentSize);
        groupBoxSolver.Controls.Add(textBoxExecutionTime);
        groupBoxSolver.Controls.Add(textBoxTournamentSize);
        groupBoxSolver.Controls.Add(labelMaxGenerations);
        groupBoxSolver.Controls.Add(textBoxError);
        groupBoxSolver.Controls.Add(labelExecutionTime);
        groupBoxSolver.Controls.Add(textBoxPopulationSize);
        groupBoxSolver.Controls.Add(labelError);
        groupBoxSolver.Controls.Add(textBoxMaxGenerations);
        groupBoxSolver.Location = new Point(1019, 117);
        groupBoxSolver.Name = "groupBoxSolver";
        groupBoxSolver.Size = new Size(828, 904);
        groupBoxSolver.TabIndex = 27;
        groupBoxSolver.TabStop = false;
        groupBoxSolver.Text = "Solver Configuration";
        // 
        // textBoxSwapLinesProbability
        // 
        textBoxSwapLinesProbability.Anchor = AnchorStyles.None;
        textBoxSwapLinesProbability.Location = new Point(335, 805);
        textBoxSwapLinesProbability.Name = "textBoxSwapLinesProbability";
        textBoxSwapLinesProbability.Size = new Size(170, 27);
        textBoxSwapLinesProbability.TabIndex = 75;
        textBoxSwapLinesProbability.KeyPress += textBoxSwapLinesProbability_KeyPress;
        // 
        // labelSubtreeMutationProbability
        // 
        labelSubtreeMutationProbability.Anchor = AnchorStyles.None;
        labelSubtreeMutationProbability.Location = new Point(19, 575);
        labelSubtreeMutationProbability.Name = "labelSubtreeMutationProbability";
        labelSubtreeMutationProbability.Size = new Size(310, 54);
        labelSubtreeMutationProbability.TabIndex = 65;
        labelSubtreeMutationProbability.Text = "SubtreeMutationProbability";
        labelSubtreeMutationProbability.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // labelSwapLinesProbability
        // 
        labelSwapLinesProbability.Anchor = AnchorStyles.None;
        labelSwapLinesProbability.Location = new Point(19, 791);
        labelSwapLinesProbability.Name = "labelSwapLinesProbability";
        labelSwapLinesProbability.Size = new Size(310, 54);
        labelSwapLinesProbability.TabIndex = 69;
        labelSwapLinesProbability.Text = "SwapLinesProbability";
        labelSwapLinesProbability.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // textBoxDeleteLineProbability
        // 
        textBoxDeleteLineProbability.Anchor = AnchorStyles.None;
        textBoxDeleteLineProbability.Location = new Point(335, 751);
        textBoxDeleteLineProbability.Name = "textBoxDeleteLineProbability";
        textBoxDeleteLineProbability.Size = new Size(170, 27);
        textBoxDeleteLineProbability.TabIndex = 74;
        textBoxDeleteLineProbability.KeyPress += textBoxDeleteLineProbability_KeyPress;
        // 
        // labelDeleteLineProbability
        // 
        labelDeleteLineProbability.Anchor = AnchorStyles.None;
        labelDeleteLineProbability.Location = new Point(19, 737);
        labelDeleteLineProbability.Name = "labelDeleteLineProbability";
        labelDeleteLineProbability.Size = new Size(310, 54);
        labelDeleteLineProbability.TabIndex = 68;
        labelDeleteLineProbability.Text = "DeleteLineProbability";
        labelDeleteLineProbability.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // labelNewLineProbability
        // 
        labelNewLineProbability.Anchor = AnchorStyles.None;
        labelNewLineProbability.Location = new Point(19, 683);
        labelNewLineProbability.Name = "labelNewLineProbability";
        labelNewLineProbability.Size = new Size(310, 54);
        labelNewLineProbability.TabIndex = 67;
        labelNewLineProbability.Text = "NewLineProbability";
        labelNewLineProbability.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // textBoxNewLineProbability
        // 
        textBoxNewLineProbability.Anchor = AnchorStyles.None;
        textBoxNewLineProbability.Location = new Point(335, 697);
        textBoxNewLineProbability.Name = "textBoxNewLineProbability";
        textBoxNewLineProbability.Size = new Size(170, 27);
        textBoxNewLineProbability.TabIndex = 73;
        textBoxNewLineProbability.KeyPress += textBoxNewLineProbability_KeyPress;
        // 
        // labelHorizontalModificationProbability
        // 
        labelHorizontalModificationProbability.Anchor = AnchorStyles.None;
        labelHorizontalModificationProbability.Location = new Point(19, 629);
        labelHorizontalModificationProbability.Name = "labelHorizontalModificationProbability";
        labelHorizontalModificationProbability.Size = new Size(310, 54);
        labelHorizontalModificationProbability.TabIndex = 66;
        labelHorizontalModificationProbability.Text = "HorizontalModificationProbability";
        labelHorizontalModificationProbability.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // textBoxPointMutationProbability
        // 
        textBoxPointMutationProbability.Anchor = AnchorStyles.None;
        textBoxPointMutationProbability.Location = new Point(335, 535);
        textBoxPointMutationProbability.Name = "textBoxPointMutationProbability";
        textBoxPointMutationProbability.Size = new Size(170, 27);
        textBoxPointMutationProbability.TabIndex = 70;
        textBoxPointMutationProbability.KeyPress += textBoxPointMutationProbability_KeyPress;
        // 
        // textBoxSubtreeMutationProbability
        // 
        textBoxSubtreeMutationProbability.Anchor = AnchorStyles.None;
        textBoxSubtreeMutationProbability.Location = new Point(335, 589);
        textBoxSubtreeMutationProbability.Name = "textBoxSubtreeMutationProbability";
        textBoxSubtreeMutationProbability.Size = new Size(170, 27);
        textBoxSubtreeMutationProbability.TabIndex = 71;
        textBoxSubtreeMutationProbability.KeyPress += textBoxSubtreeMutationProbability_KeyPress;
        // 
        // labelPointMutationProbability
        // 
        labelPointMutationProbability.Anchor = AnchorStyles.None;
        labelPointMutationProbability.Location = new Point(19, 521);
        labelPointMutationProbability.Name = "labelPointMutationProbability";
        labelPointMutationProbability.Size = new Size(310, 54);
        labelPointMutationProbability.TabIndex = 64;
        labelPointMutationProbability.Text = "PointMutationProbability";
        labelPointMutationProbability.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // textBoxHorizontalModificationProbability
        // 
        textBoxHorizontalModificationProbability.Anchor = AnchorStyles.None;
        textBoxHorizontalModificationProbability.Location = new Point(335, 643);
        textBoxHorizontalModificationProbability.Name = "textBoxHorizontalModificationProbability";
        textBoxHorizontalModificationProbability.Size = new Size(170, 27);
        textBoxHorizontalModificationProbability.TabIndex = 72;
        textBoxHorizontalModificationProbability.KeyPress += textBoxHorizontalModificationProbability_KeyPress;
        // 
        // textBoxMutationProbability
        // 
        textBoxMutationProbability.Anchor = AnchorStyles.None;
        textBoxMutationProbability.Location = new Point(335, 481);
        textBoxMutationProbability.Name = "textBoxMutationProbability";
        textBoxMutationProbability.Size = new Size(170, 27);
        textBoxMutationProbability.TabIndex = 63;
        textBoxMutationProbability.KeyPress += textBoxMutationProbability_KeyPress;
        // 
        // labelPopulationSize
        // 
        labelPopulationSize.Anchor = AnchorStyles.None;
        labelPopulationSize.Location = new Point(19, 251);
        labelPopulationSize.Name = "labelPopulationSize";
        labelPopulationSize.Size = new Size(310, 54);
        labelPopulationSize.TabIndex = 50;
        labelPopulationSize.Text = "PopulationSize";
        labelPopulationSize.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // labelMutationProbability
        // 
        labelMutationProbability.Anchor = AnchorStyles.None;
        labelMutationProbability.Location = new Point(19, 467);
        labelMutationProbability.Name = "labelMutationProbability";
        labelMutationProbability.Size = new Size(310, 54);
        labelMutationProbability.TabIndex = 54;
        labelMutationProbability.Text = "MutationProbability";
        labelMutationProbability.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // labelNumOfTestCases
        // 
        labelNumOfTestCases.Anchor = AnchorStyles.None;
        labelNumOfTestCases.Location = new Point(19, 35);
        labelNumOfTestCases.Name = "labelNumOfTestCases";
        labelNumOfTestCases.Size = new Size(310, 54);
        labelNumOfTestCases.TabIndex = 46;
        labelNumOfTestCases.Text = "NumOfTestCases";
        labelNumOfTestCases.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // textBoxNumOfTestCases
        // 
        textBoxNumOfTestCases.Anchor = AnchorStyles.None;
        textBoxNumOfTestCases.Location = new Point(335, 49);
        textBoxNumOfTestCases.Name = "textBoxNumOfTestCases";
        textBoxNumOfTestCases.Size = new Size(170, 27);
        textBoxNumOfTestCases.TabIndex = 55;
        textBoxNumOfTestCases.KeyPress += textBoxNumOfTestCases_KeyPress;
        // 
        // textBoxCrossoverProbability
        // 
        textBoxCrossoverProbability.Anchor = AnchorStyles.None;
        textBoxCrossoverProbability.Location = new Point(335, 427);
        textBoxCrossoverProbability.Name = "textBoxCrossoverProbability";
        textBoxCrossoverProbability.Size = new Size(170, 27);
        textBoxCrossoverProbability.TabIndex = 62;
        textBoxCrossoverProbability.KeyPress += textBoxCrossoverProbability_KeyPress;
        // 
        // labelCrossoverProbability
        // 
        labelCrossoverProbability.Anchor = AnchorStyles.None;
        labelCrossoverProbability.Location = new Point(19, 413);
        labelCrossoverProbability.Name = "labelCrossoverProbability";
        labelCrossoverProbability.Size = new Size(310, 54);
        labelCrossoverProbability.TabIndex = 53;
        labelCrossoverProbability.Text = "CrossoverProbability";
        labelCrossoverProbability.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // textBoxInputLength
        // 
        textBoxInputLength.Anchor = AnchorStyles.None;
        textBoxInputLength.Location = new Point(335, 103);
        textBoxInputLength.Name = "textBoxInputLength";
        textBoxInputLength.Size = new Size(170, 27);
        textBoxInputLength.TabIndex = 56;
        textBoxInputLength.KeyPress += textBoxInputLength_KeyPress;
        // 
        // labelInputLength
        // 
        labelInputLength.Anchor = AnchorStyles.None;
        labelInputLength.Location = new Point(19, 89);
        labelInputLength.Name = "labelInputLength";
        labelInputLength.Size = new Size(310, 54);
        labelInputLength.TabIndex = 47;
        labelInputLength.Text = "InputLength";
        labelInputLength.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // labelTournamentSize
        // 
        labelTournamentSize.Anchor = AnchorStyles.None;
        labelTournamentSize.Location = new Point(19, 359);
        labelTournamentSize.Name = "labelTournamentSize";
        labelTournamentSize.Size = new Size(310, 54);
        labelTournamentSize.TabIndex = 52;
        labelTournamentSize.Text = "TournamentSize";
        labelTournamentSize.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // textBoxExecutionTime
        // 
        textBoxExecutionTime.Anchor = AnchorStyles.None;
        textBoxExecutionTime.Location = new Point(335, 157);
        textBoxExecutionTime.Name = "textBoxExecutionTime";
        textBoxExecutionTime.Size = new Size(170, 27);
        textBoxExecutionTime.TabIndex = 57;
        textBoxExecutionTime.KeyPress += textBoxExecutionTime_KeyPress;
        // 
        // textBoxTournamentSize
        // 
        textBoxTournamentSize.Anchor = AnchorStyles.None;
        textBoxTournamentSize.Location = new Point(335, 373);
        textBoxTournamentSize.Name = "textBoxTournamentSize";
        textBoxTournamentSize.Size = new Size(170, 27);
        textBoxTournamentSize.TabIndex = 61;
        textBoxTournamentSize.KeyPress += textBoxTournamentSize_KeyPress;
        // 
        // labelMaxGenerations
        // 
        labelMaxGenerations.Anchor = AnchorStyles.None;
        labelMaxGenerations.Location = new Point(19, 305);
        labelMaxGenerations.Name = "labelMaxGenerations";
        labelMaxGenerations.Size = new Size(310, 54);
        labelMaxGenerations.TabIndex = 51;
        labelMaxGenerations.Text = "MaxGenerations";
        labelMaxGenerations.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // textBoxError
        // 
        textBoxError.Anchor = AnchorStyles.None;
        textBoxError.Location = new Point(335, 211);
        textBoxError.Name = "textBoxError";
        textBoxError.Size = new Size(170, 27);
        textBoxError.TabIndex = 58;
        textBoxError.KeyPress += textBoxError_KeyPress;
        // 
        // labelExecutionTime
        // 
        labelExecutionTime.Anchor = AnchorStyles.None;
        labelExecutionTime.Location = new Point(19, 143);
        labelExecutionTime.Name = "labelExecutionTime";
        labelExecutionTime.Size = new Size(310, 54);
        labelExecutionTime.TabIndex = 48;
        labelExecutionTime.Text = "ExecutionTime [ms]";
        labelExecutionTime.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // textBoxPopulationSize
        // 
        textBoxPopulationSize.Anchor = AnchorStyles.None;
        textBoxPopulationSize.Location = new Point(335, 265);
        textBoxPopulationSize.Name = "textBoxPopulationSize";
        textBoxPopulationSize.Size = new Size(170, 27);
        textBoxPopulationSize.TabIndex = 59;
        textBoxPopulationSize.KeyPress += textBoxPopulationSize_KeyPress;
        // 
        // labelError
        // 
        labelError.Anchor = AnchorStyles.None;
        labelError.Location = new Point(19, 197);
        labelError.Name = "labelError";
        labelError.Size = new Size(310, 54);
        labelError.TabIndex = 49;
        labelError.Text = "Error";
        labelError.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // textBoxMaxGenerations
        // 
        textBoxMaxGenerations.Anchor = AnchorStyles.None;
        textBoxMaxGenerations.Location = new Point(335, 319);
        textBoxMaxGenerations.Name = "textBoxMaxGenerations";
        textBoxMaxGenerations.Size = new Size(170, 27);
        textBoxMaxGenerations.TabIndex = 60;
        textBoxMaxGenerations.KeyPress += textBoxMaxGenerations_KeyPress;
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
        // groupBoxApp
        // 
        groupBoxApp.Anchor = AnchorStyles.None;
        groupBoxApp.Controls.Add(buttonTaskFormatSwitcher);
        groupBoxApp.Controls.Add(labelTaskFormat);
        groupBoxApp.Location = new Point(67, 746);
        groupBoxApp.Name = "groupBoxApp";
        groupBoxApp.Size = new Size(828, 275);
        groupBoxApp.TabIndex = 80;
        groupBoxApp.TabStop = false;
        groupBoxApp.Text = "App Configuration";
        // 
        // buttonTaskFormatSwitcher
        // 
        buttonTaskFormatSwitcher.Anchor = AnchorStyles.None;
        buttonTaskFormatSwitcher.Location = new Point(355, 30);
        buttonTaskFormatSwitcher.Name = "buttonTaskFormatSwitcher";
        buttonTaskFormatSwitcher.Size = new Size(122, 41);
        buttonTaskFormatSwitcher.TabIndex = 81;
        buttonTaskFormatSwitcher.UseVisualStyleBackColor = true;
        buttonTaskFormatSwitcher.Click += buttonTaskFormatSwitcher_Click;
        // 
        // labelTaskFormat
        // 
        labelTaskFormat.Anchor = AnchorStyles.None;
        labelTaskFormat.Location = new Point(19, 23);
        labelTaskFormat.Name = "labelTaskFormat";
        labelTaskFormat.Size = new Size(310, 54);
        labelTaskFormat.TabIndex = 81;
        labelTaskFormat.Text = "Task Format";
        labelTaskFormat.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // ConfigurationForm
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1902, 1033);
        Controls.Add(groupBoxApp);
        Controls.Add(buttonInterpreter);
        Controls.Add(groupBoxSolver);
        Controls.Add(groupBoxModel);
        Controls.Add(buttonHome);
        Controls.Add(buttonQuit);
        Controls.Add(buttonSaved);
        Controls.Add(buttonTask);
        Controls.Add(buttonFitness);
        Controls.Add(buttonConfiguration);
        Name = "ConfigurationForm";
        Text = "Configuration";
        FormClosed += ConfigurationForm_FormClosed;
        Load += Configuration_Load;
        Resize += ConfigurationForm_Resize;
        groupBoxModel.ResumeLayout(false);
        groupBoxModel.PerformLayout();
        groupBoxSolver.ResumeLayout(false);
        groupBoxSolver.PerformLayout();
        groupBoxApp.ResumeLayout(false);
        ResumeLayout(false);
    }

    #endregion

    private Button buttonQuit;
    private Button buttonSaved;
    private Button buttonTask;
    private Button buttonFitness;
    private Button buttonConfiguration;
    private Button buttonHome;
    private GroupBox groupBoxModel;
    private GroupBox groupBoxSolver;
    private Label labelMaxInt;
    private TextBox textBoxMaxInt;
    private Label labelNextTwoArgExpressionChance;
    private Label labelNewLogicExpressionChance;
    private Label labelNewChildOfIfNodeChance;
    private Label labelNewExpressionInForComparisonChance;
    private Label labelNewChildOfForNodeChance;
    private Label labelNewDeepNodeGenerationFall;
    private Label labelNewDeepNodeGenerationChance;
    private Label labelNewChildOfProgramNodeChance;
    private TextBox textBoxNextTwoArgExpressionChance;
    private TextBox textBoxNewLogicExpressionChance;
    private TextBox textBoxNewChildOfIfNodeChance;
    private TextBox textBoxNewExpressionInForComparisonChance;
    private TextBox textBoxNewChildOfForNodeChance;
    private TextBox textBoxNewDeepNodeGenerationFall;
    private TextBox textBoxNewDeepNodeGenerationChance;
    private TextBox textBoxNewChildOfProgramNodeChance;
    private TextBox textBoxMutationProbability;
    private Label labelNumOfTestCases;
    private TextBox textBoxCrossoverProbability;
    private Label labelInputLength;
    private TextBox textBoxTournamentSize;
    private Label labelExecutionTime;
    private TextBox textBoxMaxGenerations;
    private Label labelError;
    private TextBox textBoxPopulationSize;
    private Label labelPopulationSize;
    private TextBox textBoxError;
    private Label labelMaxGenerations;
    private TextBox textBoxExecutionTime;
    private Label labelTournamentSize;
    private TextBox textBoxInputLength;
    private Label labelCrossoverProbability;
    private TextBox textBoxNumOfTestCases;
    private Label labelMutationProbability;
    private TextBox textBoxNewVarExpressionChance;
    private Label labelNewVarExpressionChance;
    private TextBox textBoxSwapLinesProbability;
    private Label labelSubtreeMutationProbability;
    private Label labelSwapLinesProbability;
    private TextBox textBoxDeleteLineProbability;
    private Label labelDeleteLineProbability;
    private Label labelNewLineProbability;
    private TextBox textBoxNewLineProbability;
    private Label labelHorizontalModificationProbability;
    private TextBox textBoxPointMutationProbability;
    private TextBox textBoxSubtreeMutationProbability;
    private Label labelPointMutationProbability;
    private TextBox textBoxHorizontalModificationProbability;
    private Button buttonInterpreter;
    private GroupBox groupBoxApp;
    private Label labelTaskFormat;
    private Button buttonTaskFormatSwitcher;
}