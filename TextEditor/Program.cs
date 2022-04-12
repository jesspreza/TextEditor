using System;
using System.IO;

namespace TextEditor
{
  class Program
  {
    static void Main(string[] args)
    {
      Menu();
    }
    
    static void Menu()
    {
      Console.Clear();
      Console.WriteLine("Select an option:");
      Console.WriteLine("1 - Create new file");
      Console.WriteLine("2 - Open file");
      Console.WriteLine("0 - Exit");

      short option = short.Parse(Console.ReadLine());

      switch (option)
      {
        case 0: System.Environment.Exit(0); break;
        case 1: Create(); break;
        case 2: Open(); break;
        default: Menu(); break;
      }
    }
    static void Create()
    {
      Console.Clear();
      Console.WriteLine("Write a text below (press ESC to exit)");
      Console.WriteLine();
      
      string text = "";

      do
      {
        text += Console.ReadLine();
        text += Environment.NewLine;
      }
      while (Console.ReadKey().Key != ConsoleKey.Escape);
      
      Save(text);
    }
    
    static void Open() 
    {
      Console.Clear();
      Console.WriteLine("Write a path to open a file");
      string path = Console.ReadLine();

      using (var file = new StreamReader(path))
      {
        string text = file.ReadToEnd();
        Console.WriteLine(text);
      }

      Console.WriteLine();
      Console.ReadKey();
      Menu();
    }
    static void Save(string text)
    {
      Console.Clear();
      Console.WriteLine("Write a path to save the new file");
      string path = Console.ReadLine();

      using (var file = new StreamWriter(path))
      {
        file.Write(text);
      }

      Console.WriteLine($"File {path} saved!");
      Console.ReadKey();
      Menu();
    }
  }
}
