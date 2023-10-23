using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppProjectS7.src.Vue
{
    class MenuView
    {
        private static string sep = "--------------------------------------------\n";
        private static bool display = true;

        /// <summary>
        /// Displays a tabular representation of elements.
        /// </summary>
        /// <param name="elements">The array of elements to be displayed in a tabular format. note that the first element is the table title</param>
        public static void DisplayTab(string[] elements)
        {
            if (display)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(sep + elements[0] + "\n" + sep);
                for (int i = 1; i < elements.Length; i++)
                {
                    Console.WriteLine((i) + "- " + elements[i]);
                }
                Console.Write(sep);
            }
        }
        public static void setDisplay(bool state) { display = state; }
        /// <summary>
        /// Displays text.
        /// </summary>
        /// <param name="text">text to be displayed.</param>
        public static void DisplayText(string text)
        {
            if (display)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(sep + text);
            }
        }
        /// <summary>
        /// Displays text in green.
        /// </summary>
        /// <param name="text">text to be displayed.</param>
        public static void DisplayTextG(string text)
        {
            if (display)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(sep + text);
            }
        }
        /// <summary>
        /// Displays text in Yellow.
        /// </summary>
        /// <param name="text">text to be displayed.</param>
        public static void DisplayTextY(string text)
        {
            if (display)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine(sep + text);
            }
        }
        /// <summary>
        /// Displays an error message.
        /// </summary>
        /// <param name="error">the error message.</param>
        public static void DisplayError(string error)
        {
            if (display)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(sep + error);
            }
        }
        /// <summary>
        /// Ask the user a question.
        /// </summary>
        /// <param name="question">the question to ask.</param>
        public static T AskUser<T>(string question)
        {
            while (display)
            {
                Console.Write(sep + question + " ");
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
            return (T)Convert.ChangeType(null, typeof(T));
        }
        public static T AskUser<T>(string question,string[] elements)
        {
            question += "\n";
            for(int i=0;i<elements.Length;i++)
            {
                question += i + "- " + elements[i] + "\n";
            }
            return AskUser<T>(question);
        }
    }
}