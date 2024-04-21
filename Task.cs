

namespace ToDoReminder
{
    internal class Task
    {
        public string Description { get; set; }
        public DateTime DateAndTime { get; set; }
        public PriorityType Priority { get; set; }

        public Task(string description, DateTime dateAndTime, PriorityType priority)
        {
            Description = description;
            DateAndTime = dateAndTime;
            Priority = priority;
        }
    }
}
