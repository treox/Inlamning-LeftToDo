using System;
using System.Collections.Generic;

namespace LeftToDo
{
    public class TaskList : List
    {
        public List<Task> listOfTasks = new List<Task>();
        string strNumberKey;

        public override void AddTaskToList(Task typeOfTaskToAdd)
        {
            listOfTasks.Add(typeOfTaskToAdd);
        }

        public override void RemoveTaskFromList(int index)
        {
            listOfTasks.RemoveAt(index);
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