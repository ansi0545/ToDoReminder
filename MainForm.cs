namespace ToDoReminder
{
    public partial class MainForm : Form
    {
        private TaskManager taskManager;
        private FileManager fileManager;

        public MainForm()
        {
            InitializeComponent();
            InitializeListView();
            this.Text = "ToDo Reminder by Ann-Sofie";
            fileManager = new FileManager();
            taskManager = new TaskManager(fileManager); // Pass the FileManager object to the TaskManager
            PopulatePriorityComboBox();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            // Update the label with the current time
            lblTime.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        private void InitializeListView()
        {
            listViewToDo.Location = new Point(6, 37);
            listViewToDo.Name = "listViewToDo";
            listViewToDo.Size = new Size(1350, 315);
            listViewToDo.TabIndex = 0;
            listViewToDo.UseCompatibleStateImageBehavior = false;
            listViewToDo.View = View.Details;
            listViewToDo.SelectedIndexChanged += listViewToDo_SelectedIndexChanged;

            // Add these lines to create columns in the ListView control
            listViewToDo.Columns.Add("Date and Time", -2, HorizontalAlignment.Left);
            listViewToDo.Columns.Add("Description", -2, HorizontalAlignment.Left);
            listViewToDo.Columns.Add("Priority", -2, HorizontalAlignment.Left);
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
            if (string.IsNullOrWhiteSpace(txtBoxEnterToDo.Text))
            {
                MessageBox.Show("Please enter a task description.");
                return;
            }

            if (comboBoxPriority.SelectedItem == null)
            {
                MessageBox.Show("Please select a priority.");
                return;
            }

            var task = new Task(txtBoxEnterToDo.Text, dateTimePicker.Value, (PriorityType)comboBoxPriority.SelectedItem);
            taskManager.NewTask = task;

            // Clear the input fields after adding the task
            txtBoxEnterToDo.Clear();
            comboBoxPriority.SelectedIndex = -1;
            dateTimePicker.Value = DateTime.Now;

            // Refresh the list view to show the new task
            RefreshListView();
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            if (listViewToDo.SelectedItems.Count > 0)
            {
                // Get the selected task
                var selectedTask = listViewToDo.SelectedItems[0].Tag as Task;

                if (selectedTask == null)
                {
                    MessageBox.Show("The selected task is not valid.");
                    return;
                }

                if (comboBoxPriority.SelectedItem == null)
                {
                    MessageBox.Show("Please select a priority.");
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtBoxEnterToDo.Text))
                {
                    MessageBox.Show("Please enter a task description.");
                    return;
                }

                // Get the new task details from the input fields
                var newTask = new Task(txtBoxEnterToDo.Text, dateTimePicker.Value, (PriorityType)comboBoxPriority.SelectedItem);

                // Update the task
                taskManager.UpdateTask = (selectedTask, newTask);

                // Refresh the list view to show the updated task
                RefreshListView();
            }
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
        }

        private void toolStripMenuNew_Click(object sender, EventArgs e)
        {
            // Reset the program
            taskManager = new TaskManager();
            RefreshListView();
        }

        private void toolStripOpenDatafile_Click(object sender, EventArgs e)
        {
            var openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                fileManager.FilePath = openFileDialog.FileName;
                taskManager.ReplaceTasks(fileManager.Tasks);
                RefreshListView();
            }
        }

        private void toolStripSaveDataFile_Click(object sender, EventArgs e)
        {
            var saveFileDialog = new SaveFileDialog();
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {

                fileManager.FilePath = saveFileDialog.FileName;
                fileManager.Tasks = taskManager.Tasks;
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