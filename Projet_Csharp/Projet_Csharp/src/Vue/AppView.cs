using System;

public class AppView
{
    private static string sep = "--------------------------------------------\n";
    /// <summary>
    /// Displays a tabular representation of elements.
    /// </summary>
    /// <param name="elements">The array of elements to be displayed in a tabular format. note that the first element is the table title</param>
    public static void DisplayTab(string[] elements)
    {
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write(sep+elements[0]+"\n"+sep);
        for (int i = 1; i < elements.Length; i++)
        {
            Console.WriteLine((i) + "- " + elements[i]);
        }
        Console.Write(sep);
    }

    /// <summary>
    /// Displays text.
    /// </summary>
    /// <param name="text">text to be displayed.</param>
    public static void DisplayText(string text)
    {
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine(sep+text);
    }

    /// <summary>
    /// Displays an error message.
    /// </summary>
    /// <param name="error">the error message.</param>
    public static void DisplayError(string error)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(sep+error);
    }
    /// <summary>
    /// Ask the user a question.
    /// </summary>
    /// <param name="question">the question to ask.</param>
    public static T AskUser<T>(string question)
    {
        while (true)
        {
            Console.Write(question + " ");
            string input = Console.ReadLine();
            try
            {
                return (T)Convert.ChangeType(input, typeof(T));
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input. Please enter a valid value.");
            }
            catch (InvalidCastException)
            {
                Console.WriteLine("Invalid input. Please enter a valid value.");
            }
        }
    }
}