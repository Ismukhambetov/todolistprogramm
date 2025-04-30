using System;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// Třída pro správu seznamu úkolů
/// </summary>
public class TaskManager
{
    private List<Task> _tasks = new List<Task>();

    /// <summary>
    /// Přidá nový úkol
    /// </summary>
    /// <param name="task">Úkol k přidání</param>
    public void AddTask(Task task) => _tasks.Add(task);

    /// <summary>
    /// Smaže úkol podle indexu
    /// </summary>
    /// <param name="index">Index úkolu</param>
    public void DeleteTask(int index)
    {
        if (index >= 0 && index < _tasks.Count)
            _tasks.RemoveAt(index);
    }

    /// <summary>
    /// Označí úkol jako dokončený
    /// </summary>
    /// <param name="index">Index úkolu</param>
    public void MarkAsCompleted(int index)
    {
        if (index >= 0 && index < _tasks.Count)
            _tasks[index].IsCompleted = true;
    }

    /// <summary>
    /// Vrátí všechny úkoly
    /// </summary>
    /// <returns>Seznam všech úkolů</returns>
    public List<Task> GetAllTasks() => _tasks;

    /// <summary>
    /// Vrátí dokončené úkoly
    /// </summary>
    /// <returns>Seznam dokončených úkolů</returns>
    public List<Task> GetCompletedTasks() =>
        _tasks.Where(t => t.IsCompleted).ToList();

    /// <summary>
    /// Vrátí aktivní úkoly
    /// </summary>
    /// <returns>Seznam aktivních úkolů</returns>
    public List<Task> GetActiveTasks() =>
        _tasks.Where(t => !t.IsCompleted).ToList();

    /// <summary>
    /// Vrátí úkoly na tento týden
    /// </summary>
    /// <returns>Seznam úkolů s termínem do konce týdne</returns>
    public List<Task> GetTasksDueThisWeek()
    {
        var endOfWeek = DateTime.Today.AddDays(7);
        return _tasks
            .Where(t => t.Deadline <= endOfWeek && !t.IsCompleted)
            .OrderBy(t => t.Deadline)
            .ToList();
    }
}