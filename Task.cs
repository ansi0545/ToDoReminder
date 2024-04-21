namespace ToDoReminder
{
    internal class Task
    {
        private string description;
        private DateTime dateAndTime;
        private PriorityType priority;

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public DateTime DateAndTime
        {
            get { return dateAndTime; }
            set { dateAndTime = value; }
        }

        public PriorityType Priority
        {
            get { return priority; }
            set { priority = value; }
        }

        public Task(string description, DateTime dateAndTime, PriorityType priority)
        {
            Description = description;
            DateAndTime = dateAndTime;
            Priority = priority;
        }
    }
}