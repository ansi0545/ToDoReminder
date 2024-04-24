using System;
using System.Windows.Forms;

namespace ToDoReminder
{
    /// <summary>
    /// Represents the main form of the ToDo Reminder application.
    /// </summary>
    public partial class MainForm : Form
    {
        private TaskManager taskManager;
        private FileManager fileManager;
        string fileName = Application.StartupPath + "\\Tasks.txt";

        /// <summary>
        /// Initializes a new instance of the MainForm class.
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
            this.Text = "ToDo Reminder by Ann-Sofie";
            fileManager = new FileManager();
            taskManager = new TaskManager(fileManager);
            PopulatePriorityComboBox();
        }

        /// <summary>
        /// Event handler for the Timer's Tick event.
        /// Updates the label text with the current time.
        /// </summary>
        /// <param name="sender">The object that raised the event.</param>
        /// <param name="e">The event arguments.</param>
        private void Timer_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        /// <summary>
        /// Populates the priority combo box with values from the PriorityType enum.
        /// </summary>
        private void PopulatePriorityComboBox()
        {
            foreach (var priority in Enum.GetValues(typeof(PriorityType)))
            {
                comboBoxPriority.Items.Add(priority);
            }
        }

        /// <summary>
        /// Event handler for the click event of the btnAdd button.
        /// </summary>
        /// <param name="sender">The object that raised the event.</param>
        /// <param name="e">The event arguments.</param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            HandleTask();
        }

        /// <summary>
        /// Event handler for the click event of the btnChange button.
        /// </summary>
        /// <param name="sender">The object that raised the event.</param>
        /// <param name="e">The event arguments.</param>
        private void btnChange_Click(object sender, EventArgs e)
        {
            if (listViewToDo.SelectedItems.Count > 0)
            {
                HandleTask();
            }
        }

        /// <summary>
        /// Handles the task by validating inputs, creating a task from inputs, and updating the task manager.
        /// </summary>
        private void HandleTask()
        {
            if (!ValidateInputs())
            {
                return;
            }

            var task = CreateTaskFromInputs();

            if (listViewToDo.SelectedItems.Count > 0)
            {
                var selectedTask = listViewToDo.SelectedItems[0].Tag as Task;
                taskManager.UpdateTask = (selectedTask, task);
            }
            else
            {
                taskManager.NewTask = task;
            }

            ClearInputs();
            RefreshListView();
        }

        /// <summary>
        /// Validates the user inputs for the task description and priority selection.
        /// </summary>
        /// <returns>True if the inputs are valid; otherwise, false.</returns>
        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(txtBoxEnterToDo.Text))
            {
                MessageBox.Show("Please enter a task description.");
                return false;
            }

            if (comboBoxPriority.SelectedItem == null)
            {
                MessageBox.Show("Please select a priority.");
                return false;
            }

            return true;
        }

        /// <summary>
        /// Represents a task with a description, due date, and priority.
        /// </summary>
        private Task CreateTaskFromInputs()
        {
            return new Task(txtBoxEnterToDo.Text, dateTimePicker.Value, (PriorityType)comboBoxPriority.SelectedItem);
        }

        private void ClearInputs()
        {
            txtBoxEnterToDo.Clear();
            comboBoxPriority.SelectedIndex = -1;
            dateTimePicker.Value = DateTime.Now;
        }

        /// <summary>
        /// Event handler for the delete button click event.
        /// Deletes the selected task from the list view and updates the display.
        /// </summary>
        /// <param name="sender">The object that raised the event.</param>
        /// <param name="e">The event arguments.</param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (listViewToDo.SelectedItems.Count > 0)
            {
                var selectedTask = (Task)listViewToDo.SelectedItems[0].Tag;
                var result = MessageBox.Show("Are you sure you want to delete this task?", "Delete Task", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    taskManager.DeleteTask = selectedTask;
                    RefreshListView();
                }
            }
        }

        /// <summary>
        /// Event handler for the SelectedIndexChanged event of the listViewToDo control.
        /// Updates the state of the btnChange and btnDelete buttons based on the selected item in the listViewToDo control.
        /// If a task is selected, it populates the text box, combo box, and date time picker with the details of the selected task.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An EventArgs that contains the event data.</param>
        private void listViewToDo_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnChange.Enabled = btnDelete.Enabled = listViewToDo.SelectedItems.Count > 0;

            if (listViewToDo.SelectedItems.Count > 0)
            {
                var selectedTask = listViewToDo.SelectedItems[0].Tag as Task;
                if (selectedTask != null)
                {
                    txtBoxEnterToDo.Text = selectedTask.Description;
                    comboBoxPriority.SelectedItem = selectedTask.Priority;
                    dateTimePicker.Value = selectedTask.DateAndTime;
                }
            }
        }

        /// <summary>
        /// Event handler for the "New" menu item click event.
        /// Creates a new instance of the TaskManager class, clears the input fields, and refreshes the list view.
        /// </summary>
        /// <param name="sender">The object that raised the event.</param>
        /// <param name="e">The event arguments.</param>
        private void toolStripMenuNew_Click(object sender, EventArgs e)
        {
            taskManager = new TaskManager();
            ClearInputs();
            RefreshListView();
        }

        /// <summary>
        /// Event handler for the "Open Datafile" tool strip button click event.
        /// </summary>
        /// <param name="sender">The object that raised the event.</param>
        /// <param name="e">The event arguments.</param>
        private void toolStripOpenDatafile_Click(object sender, EventArgs e)
        {
            try
            {
                fileManager.FilePath = fileName;
                taskManager.ReplaceTasks(fileManager.Tasks);
                RefreshListView();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to open file: {ex.Message}");
            }
        }

        /// <summary>
        /// Event handler for the "Save Data File" button click event.
        /// Saves the tasks to a file.
        /// </summary>
        /// <param name="sender">The object that raised the event.</param>
        /// <param name="e">The event arguments.</param>
        private void toolStripSaveDataFile_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs())
            {
                return;
            }
            try
            {
                fileManager.FilePath = fileName;
                fileManager.Tasks = taskManager.Tasks;
                MessageBox.Show("Tasks saved successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to save file: {ex.Message}");
            }
        }

        /// <summary>
        /// Event handler for the "Exit" button click event.
        /// Displays a confirmation message box and exits the application if the user confirms.
        /// </summary>
        /// <param name="sender">The object that raised the event.</param>
        /// <param name="e">The event arguments.</param>
        private void toolStripExit_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to exit?", "Exit", MessageBoxButtons.OKCancel);
            if (result == DialogResult.OK)
            {
                Application.Exit();
            }
        }

        /// <summary>
        /// Event handler for the "About" tool strip menu item click event.
        /// Displays the AboutBox form.
        /// </summary>
        /// <param name="sender">The object that raised the event.</param>
        /// <param name="e">The event arguments.</param>
        private void toolStripAbout_Click(object sender, EventArgs e)
        {
            AboutBox aboutBox = new AboutBox();
            aboutBox.ShowDialog();
        }

        /// <summary>
        /// Refreshes the ListView control with the latest tasks from the task manager.
        /// </summary>
        private void RefreshListView()
        {
            listViewToDo.Items.Clear();
            foreach (var task in taskManager.Tasks)
            {
                var item = new ListViewItem(new[] { task.DateAndTime.ToString(), task.Description, task.Priority.ToString() });
                item.Tag = task;
                listViewToDo.Items.Add(item);
            }

            for (int i = 0; i < listViewToDo.Columns.Count; i++)
            {
                listViewToDo.AutoResizeColumn(i, ColumnHeaderAutoResizeStyle.ColumnContent);
            }
            btnChange.Enabled = btnDelete.Enabled = listViewToDo.SelectedItems.Count > 0;
        }
    }
}