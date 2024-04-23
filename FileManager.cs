namespace ToDoReminder
{
    internal class FileManager
    {
        private const string Token = "ToDoReminderApp";
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
            if (string.IsNullOrEmpty(filePath))
            {
                throw new InvalidOperationException("File path has not been set.");
            }

            using (var writer = new StreamWriter(filePath))
            {
                writer.WriteLine(Token);
                writer.WriteLine(tasks.Count);
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

            if (string.IsNullOrEmpty(filePath))
            {
                return tasks; // Return an empty list if filePath is null or empty
            }

            using (var reader = new StreamReader(filePath))
            {
                string line = reader.ReadLine();
                if (line != Token)
                {
                    throw new InvalidOperationException("File was not saved by this application.");
                }

                int taskCount = int.Parse(reader.ReadLine());

                for (int i = 0; i < taskCount; i++)
                {
                    line = reader.ReadLine();
                    var parts = line.Split(',');
                    var task = new Task(parts[1], DateTime.Parse(parts[0]), (PriorityType)Enum.Parse(typeof(PriorityType), parts[2]));
                    tasks.Add(task);
                }
            }

            return tasks;
        }
    }
}