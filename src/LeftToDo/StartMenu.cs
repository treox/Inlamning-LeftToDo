using System;

namespace LeftToDo
{

    class StartMenu
    {

        private ConsoleKeyInfo startMenuChoice;
        private ConsoleKeyInfo answer;

        TaskList taskList = new TaskList();
        ArchiveList archiveList = new ArchiveList();

        public void PresentStartMenu()
        {
            start:
            Console.WriteLine();
            Console.WriteLine("[1] Lägg till uppgift med deadline");
            Console.WriteLine("[2] Lägg till uppgift med checklista");
            Console.WriteLine("[3] Visa lista på uppgifter");
            Console.WriteLine("[4] Arkivera uppgifter");
            Console.WriteLine("[5] Visa arkiv");
            Console.WriteLine("[6] Avsluta");
            Console.WriteLine("Välj:");

            startMenuChoice = Console.ReadKey();

            switch(startMenuChoice.Key)
            {
                case ConsoleKey.D1:
                    Console.Write("Skriv in namn på uppgift: ");
                    string taskNameWD = Console.ReadLine();
                    Console.Write("Skriv in datum när uppgiften ska vara klar: ");
                    string taskDueDateWD = Console.ReadLine();
                    bool taskDoneWD = false;

                    TaskWithDueDate taskWD = new TaskWithDueDate(taskNameWD, taskDueDateWD, taskDoneWD);

                    taskList.AddTaskToList(taskWD);
                    goto start;

                case ConsoleKey.D2:
                    Console.Write("Skriv in namn på uppgift: ");
                    string taskNameWC = Console.ReadLine();
                    string taskDueDateWC = null;
                    bool taskDoneWC = false;

                    TaskWithChecklist taskWC = new TaskWithChecklist(taskNameWC, taskDueDateWC, taskDoneWC);

                    // TODO: Improve checklist functionality.
                    addTaskToChecklist:
                    Console.Write("Vill du lägga till en uppgift i checklistan. Om ja välj [y]?");
                    answer = Console.ReadKey();
                    if (answer.Key == ConsoleKey.Y)
                    {
                        Console.WriteLine("Skriv in en uppgift: ");
                        string subTask = Console.ReadLine();
                        taskWC.checklist.Add(subTask);
                        goto addTaskToChecklist;
                    }
                    else if (answer.Key != ConsoleKey.Y)
                    {
                        Console.WriteLine("Går tillbaka till menyn...");
                    }

                    taskList.AddTaskToList(taskWC);
                    goto start;

                case ConsoleKey.D3:
                    taskList.DisplayListContent();
                    taskList.ChangeStateOfTask();
                    goto start;

                case ConsoleKey.D4:
                    int index = 0;
                    foreach (Task task in taskList.listOfTasks)
                    {
                        index += 1;
                        if (task.done == true)
                        {
                            archiveList.AddTaskToList(new TaskWithDueDate(task.activityName, task.activityDueDate, task.done));
                        }
                        else if(task.done == false)
                        {
                            continue;
                        }
                    }

                    startLoop:
                    int atIndex = -1;
                    foreach (Task task in taskList.listOfTasks)
                    {
                        atIndex += 1;
                        if (task.done == true)
                        {
                                taskList.RemoveTaskFromList(atIndex);
                                goto startLoop;
                        }
                        else if (task.done == false)
                        {
                           continue;     
                        }
                    }                    
                    goto start;

                case ConsoleKey.D5:
                    archiveList.DisplayListContent();
                    goto start;

                case ConsoleKey.D6:
                    return;
                default:
                    goto start;
            }
        }
    }
}