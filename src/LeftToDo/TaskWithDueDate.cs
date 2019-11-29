namespace LeftToDo
{
    public class TaskWithDueDate : Task
    {
        public TaskWithDueDate(string activityName, string activityDueDate, bool done) : base(activityName, activityDueDate, done)
        {
            this.activityName = activityName;
            this.activityDueDate = activityDueDate;
            this.done = done;
        }
    }
}