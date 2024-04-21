

namespace ToDoReminder
{
    internal class TaskManager
     {
        private List<Task> tasks;

        public List<Task> Tasks
        {
            get { return tasks; }
            set { tasks = value; }
        }

        public TaskManager()
        {
            tasks = new List<Task>();
        }

        public void AddTask(Task task)
        {
            tasks.Add(task);
        }

        public void DeleteTask(Task task)
        {
            tasks.Remove(task);
        }

        public void UpdateTask(Task oldTask, Task newTask)
        {
            int index = tasks.IndexOf(oldTask);
            if (index != -1)
            {
                tasks[index] = newTask;
            }
        }
    }
}
