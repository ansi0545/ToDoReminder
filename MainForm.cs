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
            taskManager = new TaskManager();
            fileManager = new FileManager();

            PopulatePriorityComboBox();
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
            taskManager.AddTask(task);
            Console.WriteLine($"Added task: {task.Description}");

            // Clear the input fields after adding the task
            txtBoxEnterToDo.Clear();
            comboBoxPriority.SelectedIndex = -1;
            dateTimePicker.Value = DateTime.Now;

            // Refresh the list view to show the new task
            RefreshListView();
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
                taskManager.Tasks = fileManager.LoadTasks(openFileDialog.FileName);
                RefreshListView();
            }
        }

        private void toolStripSaveDataFile_Click(object sender, EventArgs e)
        {
            var saveFileDialog = new SaveFileDialog();
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                fileManager.SaveTasks(taskManager.Tasks, saveFileDialog.FileName);
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
                listViewToDo.Items.Add(item);
            }

            //Resize the columns to fit the content
            for (int i = 0; i < listViewToDo.Columns.Count; i++)
            {
                listViewToDo.AutoResizeColumn(i, ColumnHeaderAutoResizeStyle.ColumnContent);
            }
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

        private void listViewToDo_SelectedIndexChanged(object sender, EventArgs e)
        {
            // You can handle the selection of a task in the list view here
        }
    }
}