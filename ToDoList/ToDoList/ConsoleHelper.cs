using System;

/// <summary>
/// Pomocná třída pro práci s konzolovým rozhraním
/// </summary>
public static class ConsoleHelper
{
    private const string Value = "Termin nesmi byt za 1 rok!";

    /// <summary>
    /// Zobrazí hlavní menu aplikace
    /// </summary>
    public static void PrintMenu()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("\n=== Seznam úkolů ===");
        Console.ResetColor();
        Console.WriteLine("1. Přidat úkol");
        Console.WriteLine("2. Zobrazit všechny úkoly");
        Console.WriteLine("3. Zobrazit aktivní úkoly");
        Console.WriteLine("4. Zobrazit dokončené úkoly");
        Console.WriteLine("5. Zobrazit úkoly na tento týden");
        Console.WriteLine("6. Označit úkol jako dokončený");
        Console.WriteLine("7. Smazat úkol");
        Console.WriteLine("8. Uložit úkoly do souboru");
        Console.WriteLine("9. Načíst úkoly ze souboru");
        Console.WriteLine("0. Konec");
        Console.Write("> ");
    }
    /// <summary>
    /// Načte údaje o úkolu z konzole
    /// </summary>
    /// <returns>Nový objekt úkolu</returns>

    public static Task ReadTaskFromConsole()
    {
        Console.Write("Nazev: ");
        string title = Console.ReadLine();

        Console.Write("Popis: ");
        string desc = Console.ReadLine();

        DateTime deadline = ReadDeadline();
        Priority priority = ReadPriority();

        return new Task(title, desc)
        {
            Deadline = deadline,
            Priority = priority
        };
    }

    /// <summary>
    /// Načte datum splnění úkolu
    /// </summary>
    /// <returns>Datum splnění</returns>
    private static DateTime ReadDeadline()
    {
        DateTime deadline;
        while (true)
        {
            Console.Write("Termín splnění (dd.mm.rrrr): ");
            if (DateTime.TryParse(Console.ReadLine(), out deadline))
            {
                return deadline;
            }
            Console.WriteLine("Chybný formát data!");
        }
    }

    /// <summary>
    /// Načte prioritu úkolu
    /// </summary>
    /// <returns>Priorita úkolu</returns>
    private static Priority ReadPriority()
    {
        Priority priority;
        while (true)
        {
            Console.Write("Priorita (Low/Medium/High): ");
            if (Enum.TryParse(Console.ReadLine(), true, out priority))
            {
                return priority;
            }
            Console.WriteLine("Povolené hodnoty: Low, Medium, High");
        }
    }

    /// <summary>
    /// Načte index úkolu
    /// </summary>
    /// <returns>Index úkolu (o 1 menší než zadaná hodnota)</returns>
    public static int ReadTaskIndex()
    {
        int index;
        while (true)
        {
            Console.Write("Číslo úkolu: ");
            if (int.TryParse(Console.ReadLine(), out index))
            {
                return index - 1;
            }
            Console.WriteLine("Chyba: zadejte číslo!!");
        }
    }
}