using System;
using System.Collections.Generic;

namespace LeftToDo
{
    public class TaskList
    {
        public List<Task> listOfTasks = new List<Task>();
        string strNumberKey;
        // int index;

        public void CreateTaskWithDueDate()
        {                
            Console.Write("Skriv in namn på uppgift: ");
            string taskName = Console.ReadLine();
            Console.Write("Skriv in datum när uppgiften ska vara klar: ");
            string taskDueDate = Console.ReadLine();
            bool taskDone = false;

            listOfTasks.Add(new TaskWithDueDate(taskName, taskDueDate, taskDone));
        }

        public void CreateTaskWithChecklist()
        {                
            Console.Write("Skriv in namn på uppgift: ");
            string taskName = Console.ReadLine();
            string taskDueDate = null;
            
            bool taskDone = false;

            listOfTasks.Add(new TaskWithChecklist(taskName, taskDueDate, taskDone));
        }

        public void ChangeStateOfTask()
        {
            Console.Write("Vill du ändra uppgift till Utförd? Om ja välj [y]");
            
            ConsoleKeyInfo choice;
            choice = Console.ReadKey();

            if (choice.Key == ConsoleKey.Y)
            {
                try
                {
                Console.WriteLine("Välj vilken uppgift du vill ändra till Utförd. Välj uppgift [nr.]");
                
                    strNumberKey = Console.ReadLine();
                    Console.WriteLine(listOfTasks.Count);
                
                    int numberKey = Int32.Parse(strNumberKey);
                    listOfTasks[numberKey - 1].done = true;
                }
                catch(FormatException)
                {                    
                    Console.WriteLine("Otillåtet val. Välj uppgift [nr.]");
                }
                catch(ArgumentOutOfRangeException)
                {                    
                    Console.WriteLine("Otillåtet val. Välj uppgift [nr.]");
                }
            }
            else if (choice.Key != ConsoleKey.Y)
            {
                Console.WriteLine("Går tillbaka till menyn...");
            }
        }
    }
}