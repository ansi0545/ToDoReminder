namespace ToDoReminder
{
    internal class TaskManager
    {
        private List<Task> tasks;
        private FileManager fileManager;

        public List<Task> Tasks
        {
            get { return tasks; }
            private set { tasks = value; }
        }

        public TaskManager()
        {
            tasks = new List<Task>();
            fileManager = new FileManager();
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
            fileManager.FilePath = fileName;
            Tasks = fileManager.Tasks;
        }

        private void AddTask(Task task)
        {
            tasks.Add(task);
        }

        private void RemoveTask(Task task)
        {
            tasks.Remove(task);
        }

        private void UpdateExistingTask(Task oldTask, Task newTask)
        {
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