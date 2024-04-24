namespace ToDoReminder
{
    public partial class MainForm : Form
    {
        private TaskManager taskManager;
        private FileManager fileManager;
        string fileName = Application.StartupPath + "\\Tasks.txt";
        public MainForm()
        {
            InitializeComponent();
            this.Text = "ToDo Reminder by Ann-Sofie";
            fileManager = new FileManager();
            taskManager = new TaskManager(fileManager); // Pass the FileManager object to the TaskManager
            PopulatePriorityComboBox();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToString("HH:mm:ss");
        }


        private void PopulatePriorityComboBox()
        {
            foreach (var priority in Enum.GetValues(typeof(PriorityType)))
            {
                comboBoxPriority.Items.Add(priority);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs())
            {
                return;
            }

            var task = CreateTaskFromInputs();
            taskManager.NewTask = task;

            ClearInputs();
            RefreshListView();
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            if (listViewToDo.SelectedItems.Count > 0)
            {
                if (!ValidateInputs())
                {
                    return;
                }

                var selectedTask = listViewToDo.SelectedItems[0].Tag as Task;
                var newTask = CreateTaskFromInputs();

                taskManager.UpdateTask = (selectedTask, newTask);
                RefreshListView();
            }
        }

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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (listViewToDo.SelectedItems.Count > 0)
            {
                // Get the selected task
                var selectedTask = (Task)listViewToDo.SelectedItems[0].Tag;

                // Confirm deletion
                var result = MessageBox.Show("Are you sure you want to delete this task?", "Delete Task", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    // Delete the task
                    taskManager.DeleteTask = selectedTask;

                    // Refresh the list view to remove the task
                    RefreshListView();
                }
            }
        }

        private void listViewToDo_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Enable or disable the Change and Delete buttons based on the selection in the ListView
            btnChange.Enabled = btnDelete.Enabled = listViewToDo.SelectedItems.Count > 0;

            if (listViewToDo.SelectedItems.Count > 0)
            {
                // Get the selected task
                var selectedTask = listViewToDo.SelectedItems[0].Tag as Task;

                if (selectedTask != null)
                {
                    // Populate the textbox and comboBoxPriority with the selected task's details
                    txtBoxEnterToDo.Text = selectedTask.Description;
                    comboBoxPriority.SelectedItem = selectedTask.Priority;
                    dateTimePicker.Value = selectedTask.DateAndTime;
                }
            }
        }

        private void toolStripMenuNew_Click(object sender, EventArgs e)
        {
            // Reset the program
            taskManager = new TaskManager();
            RefreshListView();
        }

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

        private void toolStripSaveDataFile_Click(object sender, EventArgs e)
        {
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

        private void toolStripExit_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to exit?", "Exit", MessageBoxButtons.OKCancel);
            if (result == DialogResult.OK)
            {
                Application.Exit();
            }
        }

        private void toolStripAbout_Click(object sender, EventArgs e)
        {
            AboutBox aboutBox = new AboutBox();
            aboutBox.ShowDialog();
        }

        private void RefreshListView()
        {
            listViewToDo.Items.Clear();

            foreach (var task in taskManager.Tasks)
            {
                var item = new ListViewItem(new[] { task.DateAndTime.ToString(), task.Description, task.Priority.ToString() });
                item.Tag = task; // Store the task object in the ListViewItem's Tag property
                listViewToDo.Items.Add(item);
            }

            // Resize the columns to fit the content
            for (int i = 0; i < listViewToDo.Columns.Count; i++)
            {
                listViewToDo.AutoResizeColumn(i, ColumnHeaderAutoResizeStyle.ColumnContent);
            }

            // Enable or disable the Change and Delete buttons based on the selection in the ListView
            btnChange.Enabled = btnDelete.Enabled = listViewToDo.SelectedItems.Count > 0;
        }

        private void dateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            // You can add validation for the date and time here
        }

        private void comboBoxPriority_SelectedIndexChanged(object sender, EventArgs e)
        {
            // You can add validation for the priority here
        }

        private void txtBoxEnterToDo_TextChanged(object sender, EventArgs e)
        {
            // You can add validation for the task description here
        }
    }
}