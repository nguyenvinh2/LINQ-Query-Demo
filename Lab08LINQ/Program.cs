using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Lab08LINQ.Classes;
using System.IO;
using System.Linq;

namespace Lab08LINQ
{
  class Program
  {
    /// <summary>
    /// test the methods and answers the question
    /// </summary>
    /// <param name="args"></param>
    static void Main(string[] args)
    {
      Answers myAnswers = GetJSON();

      Console.WriteLine("Question #1: Output all Neighborhoods from the JSON File");
      Console.WriteLine();
      List<string> neighborhoods = Neighborhoods(myAnswers);
      Console.WriteLine();
      Console.WriteLine("Question #2: Remove all blanks in Neighborhoods");
      Console.WriteLine();
      List<string> noBlankNeighborhoods = RemoveNull(neighborhoods);
      Console.WriteLine();
      Console.WriteLine("Question #3: Remove all duplicates in Neighborhoods");
      Console.WriteLine();
      List<string> noDuplicateNeighborhoods= RemoveDuplicates(noBlankNeighborhoods);
      Console.WriteLine();
      Console.WriteLine("Question #4: Do #1-3 in one query");
      Console.WriteLine();
      List<string> allOneOperation = AllInOneQuery(myAnswers);
      Console.WriteLine();
      Console.WriteLine("Question #5: Do #3 without lambda expressions");
      Console.WriteLine();
      RedoNoDuplicates(noBlankNeighborhoods);
      Console.ReadKey();
    }
    /// <summary>
    /// parses through JSON file to return it in object form
    /// </summary>
    /// <returns>Answer object containing same data</returns>
    static Answers GetJSON()
    {
      string path = "../../../../data.json";
      string text = "";

      using (StreamReader sr = File.OpenText(path))
      {
        text = sr.ReadToEnd();
      }
      Answers myAnswers = JsonConvert.DeserializeObject<Answers>(text);
      return myAnswers;
    }
    /// <summary>
    /// outputs a list of all neighborhoods from JSON object data
    /// </summary>
    /// <param name="myAnswers">json source objects</param>
    /// <returns>list of raw neighborhood outputs</returns>
    static List<string> Neighborhoods(Answers myAnswers)
    {
      var neighborhoods = (from result in myAnswers.Features
                           select result.Properties.Neigborhood)
                           .ToList<string>();

      foreach (var item in neighborhoods)
      {
        Console.WriteLine(item);
      }
      return neighborhoods;
    }
    /// <summary>
    /// removes blanks entries from neighborhoods
    /// </summary>
    /// <param name="neighborhoods">list of raw neighborhoods</param>
    /// <returns>blanks removed from list</returns>
    static List<string> RemoveNull(List<string> neighborhoods)
    {
      var noBlanks = (from result in neighborhoods
                      where result != ""
                      select result).ToList<string>();

      foreach (var item in noBlanks)
      {
        Console.WriteLine(item);
      }

      return noBlanks;
    }
    /// <summary>
    /// from removing blank entries, this method takes it further and
    /// removes duplicate entries
    /// uses lambda expressions to filter
    /// </summary>
    /// <param name="noBlankNeighborhoods">list of neighborhoods without blanks</param>
    /// <returns>list of neighborhoods with duplicate removed</returns>
    static List<string> RemoveDuplicates(List<string> noBlankNeighborhoods)
    {
      var noDuplicates = noBlankNeighborhoods.GroupBy(x => x).Select(x => x.First()).ToList<string>();

      foreach (var item in noDuplicates)
      {
        Console.WriteLine(item);
      }

      return noDuplicates;
    }
    /// <summary>
    /// from json object, gets all neighborhoods without blanks or duplicates
    /// </summary>
    /// <param name="myAnswers">json data converted in objects</param>
    /// <returns>list of neighborhoods no duplicates no blanks</returns>
    static List<string> AllInOneQuery(Answers myAnswers)
    {
      var noBlanksOrDuplicates = (from result in myAnswers.Features
                                  where       result.Properties.Neigborhood != ""
                                  select result.Properties.Neigborhood)
                                  .GroupBy(x => x).Select(x => x.First()).ToList<string>();

      foreach (var item in noBlanksOrDuplicates)
      {
        Console.WriteLine(item);
      }

      return noBlanksOrDuplicates;
    }
    /// <summary>
    /// removes duplicates using linq expressions
    /// </summary>
    /// <param name="noBlanks">list of neighborhoods with no blanks</param>
    /// <returns>list of neighborhoods with duplicates removed</returns>
    static List<string> RedoNoDuplicates(List<string> noBlanks)
    {
      var noDuplicates = (from result in noBlanks
                          select result)
                          .Distinct().ToList<string>();

      foreach (var item in noDuplicates)
      {
        Console.WriteLine(item);
      }

      return noDuplicates;
    }

  }
}
