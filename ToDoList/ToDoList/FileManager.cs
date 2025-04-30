using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

/// <summary>
/// Třída pro správu ukládání a načítání úkolů do/z souboru
/// </summary>
public class FileManager
{
    /// <summary>
    /// Uloží seznam úkolů do souboru
    /// </summary>
    /// <param name="tasks">Seznam úkolů</param>
    /// <param name="path">Cesta k souboru</param>
    public void SaveToFile(List<Task> tasks, string path)
    {
        var lines = tasks.Select(t =>
            $"{t.Title};{t.Description};{t.IsCompleted};{t.Deadline};{t.Priority};{t.Category};{t.CustomCategory}");
        File.WriteAllLines(path, lines);
    }

    /// <summary>
    /// Načte seznam úkolů ze souboru
    /// </summary>
    /// <param name="path">Cesta k souboru</param>
    /// <returns>Seznam načtených úkolů</returns>
    public List<Task> LoadFromFile(string path)
    {
        var tasks = new List<Task>();
        if (!File.Exists(path)) return tasks;

        foreach (var line in File.ReadAllLines(path))
        {
            var parts = line.Split(';');
            if (parts.Length == 7)
            {
                var task = new Task(parts[0], parts[1])
                {
                    IsCompleted = bool.Parse(parts[2]),
                    Deadline = DateTime.Parse(parts[3]),
                    Priority = Enum.Parse<Priority>(parts[4]),
                    Category = Enum.Parse<Category>(parts[5]),
                    CustomCategory = parts[6]
                };
                tasks.Add(task);
            }
        }
        return tasks;
    }
}