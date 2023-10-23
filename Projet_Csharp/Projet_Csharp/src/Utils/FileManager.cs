using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;

public class FileManager
{

    public FileManager()
    {
    }

    /// <summary>
    /// Reads and processes an XML file located at the specified path.
    /// </summary>
    /// <param name="xmlFilePath">The file path of the XML file to be read.</param>
    public void ReadXml(string xmlFilePath)
    {
        try
        {
            // Check if the XML file exists
            if (File.Exists(xmlFilePath))
            {
                // Create an XML reader
                using (XmlReader reader = XmlReader.Create(xmlFilePath))
                {
                    while (reader.Read())
                    {
                        if (reader.NodeType == XmlNodeType.Element)
                        {
                            // Handle XML element
                            Console.WriteLine("Element: " + reader.Name);
                        }
                        else if (reader.NodeType == XmlNodeType.Text)
                        {
                            // Handle text within XML elements
                            Console.WriteLine("Text: " + reader.Value);
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("The XML file does not exist.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred while reading the XML file: " + ex.Message);
        }
    }

    /// <summary>
    /// Reads and processes a Command file located at the specified path.
    /// </summary>
    /// <param name="cmdFilePath">The file path of the Cmd file to be read.</param>
    public void ReadCmdFile(string cmdFilePath)
    {
        try
        {
            // Check if the Cmd file exists
            if (File.Exists(cmdFilePath))
            {
                // Read all lines from the Cmd file and display them
                string[] lines = File.ReadAllLines(cmdFilePath);
                foreach (string line in lines)
                {
                    // Handle each line in the Cmd file
                    Console.WriteLine("Cmd Line: " + line);
                }
            }
            else
            {
                Console.WriteLine("The Cmd file does not exist.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred while reading the Cmd file: " + ex.Message);
        }
    }
}