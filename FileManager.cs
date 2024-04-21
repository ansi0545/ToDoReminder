namespace ToDoReminder
{
    internal class FileManager
    {
        private List<Task> tasks;
        private string filePath;

        public List<Task> Tasks
        {

            get
            {
                if (tasks == null)
                {
                    tasks = LoadTasksFromFile();
                }
                return tasks;
            }
            set
            {
                tasks = value;
                SaveTasks(tasks);
            }
        }

        private void SaveTasks(List<Task> tasks)
        {
            using (var writer = new StreamWriter(filePath))
            {
                foreach (var task in tasks)
                {
                    writer.WriteLine($"{task.DateAndTime},{task.Description},{task.Priority}");
                }
            }
        }

        public string FilePath
        {
             set
            {
                filePath = value;
                tasks = null; // Reset the tasks so they will be reloaded the next time the Tasks property is accessed
            }
        }

        private List<Task> LoadTasksFromFile()
        {
            var tasks = new List<Task>();
            using (var reader = new StreamReader(filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    var parts = line.Split(',');
                    var task = new Task(parts[1], DateTime.Parse(parts[0]), (PriorityType)Enum.Parse(typeof(PriorityType), parts[2]));
                    tasks.Add(task);
                }
            }
            return tasks;
        }
    }
}