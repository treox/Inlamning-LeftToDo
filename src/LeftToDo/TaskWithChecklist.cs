using System.Collections.Generic;

namespace LeftToDo
{
    public class TaskWithChecklist : Task
    {
        // public string activityNameTC { get; private set; }
        List<string> checklist = new List<string>();
        // public bool doneTC { get; set;}

        public TaskWithChecklist(string activityName, string activtyDueDate, bool done)
        {
            this.activityName = activityName;
            this.done = done;
        }

    }
}