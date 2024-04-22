namespace ToDoReminder
{
    internal class TaskManager
    {
        private List<Task> tasks;
        private readonly FileManager fileManager;

        public List<Task> Tasks
        {
            get { return tasks; }
            private set { tasks = value; }
        }

        public TaskManager() : this(new FileManager())
        {
        }

        public TaskManager(FileManager fileManager)
        {
            this.fileManager = fileManager;
            tasks = new List<Task>();
        }

        public Task NewTask
        {
            set { AddTask(value); }
        }

        public Task DeleteTask
        {
            set { RemoveTask(value); }
        }

        public void ReplaceTasks(List<Task> newTasks)
        {
            tasks = newTasks;
        }


        public (Task oldTask, Task newTask) UpdateTask
        {
            set { UpdateExistingTask(value.oldTask, value.newTask); }
        }

        public void LoadTasks(string fileName)
        {
            if (!File.Exists(fileName))
            {
                throw new FileNotFoundException("File not found.", fileName);
            }
            fileManager.FilePath = fileName;
            Tasks = fileManager.Tasks;
        }

        private void AddTask(Task task)
        {
            if (task == null)
            {
                throw new ArgumentNullException(nameof(task), "Task cannot be null.");
            }
            tasks.Add(task);
        }

        private void RemoveTask(Task task)
        {
            if (task == null)
            {
                throw new ArgumentNullException(nameof(task), "Task cannot be null.");
            }
            if (!tasks.Contains(task))
            {
                throw new ArgumentException("Task not found in the list.");
            }
            tasks.Remove(task);
        }

        private void UpdateExistingTask(Task oldTask, Task newTask)
        {
            if (oldTask == null)
            {
                throw new ArgumentNullException(nameof(oldTask), "Old task cannot be null.");
            }
            if (newTask == null)
            {
                throw new ArgumentNullException(nameof(newTask), "New task cannot be null.");
            }
            int index = tasks.IndexOf(oldTask);
            if (index != -1)
            {
                tasks[index] = newTask;
            }
            else
            {
                throw new ArgumentException("Task not found in the list.");
            }
        }
    }
}