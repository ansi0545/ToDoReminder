

namespace ToDoReminder
{
    internal class FileManager
    {
        public void SaveTasks(List<Task> tasks, string filePath)
        {
            using (var writer = new StreamWriter(filePath))
            {
                foreach (var task in tasks)
                {
                    writer.WriteLine($"{task.DateAndTime},{task.Description},{task.Priority}");
                    Console.WriteLine($"Saved task: {task.Description}"); // Debug line
                }
            }
        }

        public List<Task> LoadTasks(string filePath)
        {
            // Implement loading tasks from a file
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
