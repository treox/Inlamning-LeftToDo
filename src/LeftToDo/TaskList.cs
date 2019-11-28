using System;
using System.Collections.Generic;

namespace LeftToDo
{
    public class TaskList
    {
        public List<Task> listOfTasks = new List<Task>();
        string strNumberKey;
        // int index;

        public void CreateTask()
        {                
            Console.Write("Skriv in namn på aktivitet: ");
            string taskName = Console.ReadLine();
            Console.Write("Skriv in datum när aktiviteten ska vara klar: ");
            string taskDueDate = Console.ReadLine();
            bool taskDone = false;

            listOfTasks.Add(new Task(taskName, taskDueDate, taskDone));
        }

        public void ChangeStateOfTask()
        {
            Console.Write("Vill du ändra till Done? [y]");
            
            ConsoleKeyInfo choice;
            choice = Console.ReadKey();

            if (choice.Key == ConsoleKey.Y)
            {
                Console.WriteLine("Välj vilken aktivitet du vill ändra [nr]");
                strNumberKey = Console.ReadLine();
                Console.WriteLine(listOfTasks.Count);
                int numberKey = Int32.Parse(strNumberKey);
            
                listOfTasks[numberKey].done = true;
            }
            else if (choice.Key != ConsoleKey.Y)
            {
                Console.WriteLine("Går tillbaka till menyn...");
            }
        }
    }
}