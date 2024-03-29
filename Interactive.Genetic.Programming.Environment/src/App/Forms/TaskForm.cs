﻿using App.Forms.Scaling;
using App.Services.Interfaces;
using Configuration.App;
using Database.Entities;
using Shared.Exceptions;
using Solvers;
using Solvers.Interfaces;
using Tasks.Interfaces;

namespace App.Forms;

public partial class TaskForm :
    Form,
    IFormPropertiesProvider<TaskForm>,
    IAvailableTasksSubscriber,
    ISolverStatusSubscriber
{
    public FormProperties<TaskForm> FormProperties { get; set; }

    private SolverStatus _status = SolverStatus.Idle;

    private readonly IWindowSwitcherService _windowSwitcher;
    private readonly ITasksService _tasksService;
    private readonly IAvailableTasksService _availableTasksService;
    private readonly IAppConfiguration _appConfiguration;
    private readonly ISolverService _solverService;

    public TaskForm(
        IWindowSwitcherService windowSwitcher,
        ITasksService tasksService,
        IAvailableTasksService availableTasksService,
        IAppConfiguration appConfiguration,
        ISolverService solverService
    )
    {
        _windowSwitcher = windowSwitcher;
        _tasksService = tasksService;
        _availableTasksService = availableTasksService;
        _appConfiguration = appConfiguration;
        _solverService = solverService;

        InitializeComponent();
        FormProperties = new FormProperties<TaskForm>(this);

        _availableTasksService.Subscribe(this);
        _solverService.Subscribe(this);
    }

    private void Task_Load(object sender, EventArgs e)
    {
        WindowState = FormWindowState.Maximized;
        _availableTasksService.FetchAllSubscribed();
    }

    public new void Show()
    {
        Task_Load(this, EventArgs.Empty);
        base.Show();
    }

    private void TaskForm_Resize(object sender, EventArgs e)
    {
        if (this.CanResize() is false) return;
        FormProperties.MinimizeMaximizeChange = this.ResizeDecision();
    }

    private void buttonHome_Click(object sender, EventArgs e)
    {
        _windowSwitcher.Switch<HomeForm>(this);
    }

    private void buttonConfiguration_Click(object sender, EventArgs e)
    {
        _windowSwitcher.Switch<ConfigurationForm>(this);
    }

    private void buttonFitness_Click(object sender, EventArgs e)
    {
        _windowSwitcher.Switch<FitnessForm>(this);
    }

    private void buttonTask_Click(object sender, EventArgs e)
    {
        _windowSwitcher.Switch<TaskForm>(this);
    }

    private void buttonSaved_Click(object sender, EventArgs e)
    {
        _windowSwitcher.Switch<SavedForm>(this);
    }

    private void buttonInterpreter_Click(object sender, EventArgs e)
    {
        _windowSwitcher.Switch<InterpreterForm>(this);
    }

    private void buttonQuit_Click(object sender, EventArgs e)
    {
        _windowSwitcher.Quit(this);
    }

    private void buttonUploadTask_Click(object sender, EventArgs e)
    {
        var openFileDialog = new OpenFileDialog
        {
            Title = @"Select task file",
            Filter = _appConfiguration.ReadTaskFromJson
                ? "JSON files (*.json)|*.json"
                : "CSV files (*.csv)|*.csv",
            FilterIndex = 2,
            RestoreDirectory = true
        };

        openFileDialog.ShowDialog();
        if (string.IsNullOrWhiteSpace(openFileDialog.FileName)) return;

        textBoxTaskPath.Text = openFileDialog.FileName;
    }

    private void buttonSaveTask_Click(object sender, EventArgs e)
    {
        var taskName = textBoxTaskName.Text;
        var taskPath = textBoxTaskPath.Text;

        if (string.IsNullOrWhiteSpace(taskName)) throw new CustomException("Task name cannot be empty");
        if (string.IsNullOrWhiteSpace(taskPath)) throw new CustomException("Task path cannot be empty");

        _tasksService.SaveTask(taskName, taskPath);

        textBoxTaskName.Text = "";
        textBoxTaskPath.Text = "";
        
        MessageBox.Show(@"Task saved successfully", @"Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    private void buttonRemoveTask_Click(object sender, EventArgs e)
    {
        if (comboBoxSavedTask.SelectedItem is not TaskEntity task) return;

        _tasksService.RemoveTask(task);
    }

    private void buttonInspectTask_Click(object sender, EventArgs e)
    {
        if (comboBoxSavedTask.SelectedItem is not TaskEntity task) return;
        _tasksService.InspectTask(task);
    }

    private void comboBoxSavedTask_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (comboBoxSavedTask.InvokeRequired)
        {
            comboBoxSavedTask.BeginInvoke(SelectedTaskChange);
        }
        else
        {
            SelectedTaskChange();
        }
    }

    private void SelectedTaskChange()
    {
        if (comboBoxSavedTask.SelectedItem is not TaskEntity task) return;
        _tasksService.ActivateTask(task);
    }

    public void AvailableTasksUpdate(IEnumerable<TaskEntity> tasks)
    {
        if (comboBoxSavedTask.InvokeRequired)
        {
            comboBoxSavedTask.BeginInvoke(() => UpdateComboBox(tasks));
        }
        else
        {
            UpdateComboBox(tasks);
        }
    }

    private void UpdateComboBox(IEnumerable<TaskEntity> tasks)
    {
        var tasksArray = tasks.ToArray();

        var selected = comboBoxSavedTask.SelectedItem as TaskEntity;
        comboBoxSavedTask.Items.Clear();
        comboBoxSavedTask.Items.AddRange(tasksArray.Cast<object>().ToArray());

        if (selected == null) return;
        if (tasksArray.FirstOrDefault(t => t.Id == selected.Id) is not { } newSelected) return;

        comboBoxSavedTask.SelectedItem = newSelected;
    }

    public void OnTaskReset()
    {
        if (comboBoxSavedTask.InvokeRequired)
        {
            comboBoxSavedTask.BeginInvoke(() => comboBoxSavedTask.SelectedIndex = -1);
        }
        else
        {
            comboBoxSavedTask.SelectedIndex = -1;
        }
    }

    public void OnSolverStatusUpdate(SolverStatus status)
    {
        _status = status;
        if (comboBoxSavedTask.InvokeRequired)
        {
            comboBoxSavedTask.BeginInvoke(() => comboBoxSavedTask.Enabled = _status == SolverStatus.Idle);
        }
        else
        {
            comboBoxSavedTask.Enabled = _status == SolverStatus.Idle;
        }

        if (buttonRemoveTask.InvokeRequired)
        {
            buttonRemoveTask.BeginInvoke(() => buttonRemoveTask.Enabled = _status == SolverStatus.Idle);
        }
        else
        {
            buttonRemoveTask.Enabled = _status == SolverStatus.Idle;
        }
    }

    private void TaskForm_FormClosed(object sender, FormClosedEventArgs e)
    {
        _windowSwitcher.Quit(this);
    }
}