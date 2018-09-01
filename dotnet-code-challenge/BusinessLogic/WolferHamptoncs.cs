using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace dotnet_code_challenge
{
    public static class WolferHamptoncs
    {
        public static void GetWolferHamptonRace(string path)
        {
            try
            {
                //Read the JSON from the json file
                using (StreamReader r = new StreamReader(path))
                {
                    var json = r.ReadToEnd();

                    JObject rss = JObject.Parse(json);

                    Dictionary<string, int> Racedictionary = new Dictionary<string, int>();

                    var HorseNames = from h in rss["RawData"]["Participants"] select (string)h["Name"];
                    var Prices = from p in rss["RawData"]["Markets"][0]["Selections"] select (Int32)p["Price"];

                    int i = 0;
                    //Get first list of horses
                    foreach (var names in HorseNames)
                    {
                        Racedictionary.Add(names, Prices.ToList()[i]);

                        i++;
                    }
                    //sort the dictionary
                    var sortedRaceDict = from entry in Racedictionary orderby entry.Value ascending select entry;
                    //output the horse and price list
                    Console.WriteLine("List of JSON");
                    Console.WriteLine("---------------");
                    foreach (var list in sortedRaceDict)
                    {
                        Console.WriteLine(list.ToString());
                    }

                    Console.WriteLine("");
                    Console.WriteLine("");
                    Console.WriteLine("");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

      
    }
}