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
      Console.ReadKey();
    }

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

    static List<string> Neighborhoods(Answers myAnswers)
    {
      List<string> neighborhoods = new List<string>();
      foreach (Features feature in myAnswers.Features)
      {
        neighborhoods.Add(feature.Properties.Neigborhood);
        Console.WriteLine(feature.Properties.Neigborhood);
      }
      return neighborhoods;
    }

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

    static List<string> RemoveDuplicates(List<string> noBlankNeighborhoods)
    {
      var noDuplicates = noBlankNeighborhoods.GroupBy(x => x).Select(x => x.First()).ToList<string>();

      foreach (var item in noDuplicates)
      {
        Console.WriteLine(item);
      }

      return noDuplicates;
    }

    static List<string> AllInOneQuery(List<string> neighborhoods)
    {
      var noBlanksOrDuplicates = (from result in neighborhoods
                                  where result != ""
                                  select result).ToList<string>();

      foreach (var item in noDuplicates)
      {
        Console.WriteLine(item);
      }

      return noDuplicates;
    }

  }
}
