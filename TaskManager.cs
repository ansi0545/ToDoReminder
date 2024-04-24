namespace ToDoReminder
{

    internal class TaskManager
    {
        private List<Task> tasks;
        private readonly FileManager fileManager;

        /// <summary>
        /// Gets the list of tasks.
        /// </summary>
        public List<Task> Tasks
        {
            get { return tasks; }
            private set { tasks = value; }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TaskManager"/> class.
        /// </summary>
        public TaskManager() : this(new FileManager())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TaskManager"/> class with the specified file manager.
        /// </summary>
        /// <param name="fileManager">The file manager to use.</param>
        public TaskManager(FileManager fileManager)
        {
            this.fileManager = fileManager;
            tasks = new List<Task>();
        }

        /// <summary>
        /// Sets a new task to be added to the task list.
        /// </summary>
        public Task NewTask
        {
            set { AddTask(value); }
        }

        /// <summary>
        /// Sets a task to be deleted from the task list.
        /// </summary>
        public Task DeleteTask
        {
            set { RemoveTask(value); }
        }

        /// <summary>
        /// Replaces the current list of tasks with the specified list of tasks.
        /// </summary>
        /// <param name="newTasks">The new list of tasks.</param>
        public void ReplaceTasks(List<Task> newTasks)
        {
            tasks = newTasks;
        }

        /// <summary>
        /// Sets the old and new tasks to update an existing task in the task list.
        /// </summary>
        public (Task oldTask, Task newTask) UpdateTask
        {
            set { UpdateExistingTask(value.oldTask, value.newTask); }
        }

        /// <summary>
        /// Loads tasks from the specified file.
        /// </summary>
        /// <param name="fileName">The name of the file to load tasks from.</param>
         public void LoadTasks(string fileName)
        {
            try
            {
                if (!File.Exists(fileName))
                {
                    throw new FileNotFoundException("File not found.", fileName);
                }
                fileManager.FilePath = fileName;
                Tasks = fileManager.Tasks;
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine($"File not found: {ex.FileName}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while loading tasks: {ex.Message}");
            }
        }

        /// <summary>
        /// Adds a task to the task manager.
        /// </summary>
        /// <param name="task">The task to be added.</param>
         private void AddTask(Task task)
        {
            if (task == null)
            {
                throw new ArgumentNullException(nameof(task), "Task cannot be null.");
            }
            tasks.Add(task);
        }

        private void ValidateTask(Task task)
        {
            if (task == null)
            {
                throw new ArgumentNullException(nameof(task), "Task cannot be null.");
            }
            if (!tasks.Contains(task))
            {
                throw new ArgumentException("Task not found in the list.");
            }
        }

        private void RemoveTask(Task task)
        {
            try
            {
                ValidateTask(task);
                tasks.Remove(task);
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine($"Task cannot be null: {ex.ParamName}");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Task not found in the list: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while removing task: {ex.Message}");
            }
        }

        
        private void UpdateExistingTask(Task oldTask, Task newTask)
        {
            try
            {
                ValidateTask(oldTask);
                if (newTask == null)
                {
                    throw new ArgumentNullException(nameof(newTask), "New task cannot be null.");
                }
                int index = tasks.IndexOf(oldTask);
                if (index != -1)
                {
                    tasks[index] = newTask;
                }
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine($"{ex.ParamName} cannot be null: {ex.Message}");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Task not found in the list: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while updating task: {ex.Message}");
            }
        }
    }
}