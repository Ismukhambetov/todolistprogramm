using System;
using System.Collections.Generic;

/// <summary>
/// Hlavní třída programu pro správu úkolů
/// </summary>
class Program
{
    /// <summary>
    /// Hlavní vstupní bod aplikace
    /// </summary>
    static void Main()
    {
        var manager = new TaskManager();
        var fileManager = new FileManager();
        string path = "tasks.txt";

        while (true)
        {
            ConsoleHelper.PrintMenu();
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    manager.AddTask(ConsoleHelper.ReadTaskFromConsole());
                    break;
                case "2":
                    PrintTasks(manager.GetAllTasks());
                    break;
                case "3":
                    PrintTasks(manager.GetActiveTasks());
                    break;
                case "4":
                    PrintTasks(manager.GetCompletedTasks());
                    break;
                case "5":
                    PrintTasks(manager.GetTasksDueThisWeek());
                    break;
                case "6":
                    manager.MarkAsCompleted(ConsoleHelper.ReadTaskIndex());
                    break;
                case "7":
                    manager.DeleteTask(ConsoleHelper.ReadTaskIndex());
                    break;
                case "8":
                    fileManager.SaveToFile(manager.GetAllTasks(), path);
                    break;
                case "9":
                    manager = new TaskManager();
                    fileManager.LoadFromFile(path).ForEach(manager.AddTask);
                    break;
                case "0":
                    return;
                default:
                    Console.WriteLine("Neplatný vstup!");
                    break;
            }
        }
    }

    /// <summary>
    /// Vypíše seznam úkolů do konzole
    /// </summary>
    /// <param name="tasks">Seznam úkolů k zobrazení</param>
    static void PrintTasks(List<Task> tasks)
    {
        if (tasks.Count == 0)
        {
            Console.WriteLine("Seznam úkolů je prázdný.");
            return;
        }

        for (int i = 0; i < tasks.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {tasks[i]}");
            Console.WriteLine("----------------------");
        }
    }
}