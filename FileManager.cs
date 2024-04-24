namespace ToDoReminder
{
    internal class FileManager
    {
        private const string Token = "ToDoReminderApp";
        private List<Task> tasks;
        private string filePath;

        /// <summary>
        /// Gets or sets the list of tasks.
        /// </summary>
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

        /// <summary>
        /// Saves the list of tasks to a file.
        /// </summary>
        /// <param name="tasks">The list of tasks to be saved.</param>
        private void SaveTasks(List<Task> tasks)
        {
            try
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
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while saving tasks: {ex.Message}");
            }
        }

        /// <summary>
        /// Sets the file path for saving and loading tasks.
        /// </summary>
        public string FilePath
        {
            set
            {
                filePath = value;
                tasks = null;
            }
        }

        /// <summary>
        /// Loads tasks from a file and returns a list of tasks.
        /// </summary>
        /// <returns>A list of tasks loaded from the file.</returns>
        private List<Task> LoadTasksFromFile()
        {
            var tasks = new List<Task>();

            if (string.IsNullOrEmpty(filePath))
            {
                return tasks;
            }

            try
            {
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
            }
            catch (IOException ex)
            {
                Console.WriteLine($"An I/O error occurred while loading tasks: {ex.Message}");
            }
            catch (FormatException ex)
            {
                Console.WriteLine($"A format error occurred while loading tasks: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while loading tasks: {ex.Message}");
            }

            return tasks;
        }
    }
}