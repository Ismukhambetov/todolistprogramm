// Task.cs
/// <summary>
/// Výčet priorit úkolů
/// </summary>
public enum Priority { Low, Medium, High }

/// <summary>
/// Výčet kategorií úkolů
/// </summary>
public enum Category { Work, Study, Personal }

/// <summary>
/// Třída reprezentující úkol
/// </summary>
public class Task
{
    public string Title { get; set; }
    public string Description { get; set; }
    public bool IsCompleted { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime Deadline { get; set; }
    public Priority Priority { get; set; }
    public Category Category { get; set; }
    public string CustomCategory { get; set; }

    /// <summary>
    /// Vytvoří nový úkol
    /// </summary>
    /// <param name="title">Název úkolu</param>
    /// <param name="description">Popis úkolu</param>
    public Task(string title, string description)
    {
        Title = title;
        Description = description;
        IsCompleted = false;
        CreatedAt = DateTime.Now;
        Deadline = DateTime.Now.AddDays(7);
        Priority = Priority.Medium;
    }

    /// <summary>
    /// Vrátí textovou reprezentaci úkolu
    /// </summary>
    /// <returns>Formátovaný řetězec s informacemi o úkolu</returns>
    public override string ToString()
    {
        string status = IsCompleted ? "[✓]" : "[ ]";
        string category = string.IsNullOrEmpty(CustomCategory) ? Category.ToString() : CustomCategory;

        return $"{status} {Title} (Priorita: {Priority}, Kategorie: {category})\n" +
               $"   Popis: {Description}\n" +
               $"   Vytvoreno: {CreatedAt:dd.MM.yyyy}, Termin: {Deadline:dd.MM.yyyy}";
    }
}