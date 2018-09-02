using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace dotnet_code_challenge
{
    public static class WolferHamptoncs
    {
        public static Dictionary<string, decimal> GetWolferHamptonFData(string path)
        {
            try
            {
                //Read the JSON from the json file
                using (StreamReader r = new StreamReader(path))
                {
                    var json = r.ReadToEnd();

                    JObject rss = JObject.Parse(json);

                    Dictionary<string, decimal> Racedictionary = new Dictionary<string, decimal>();
                    Dictionary<string, decimal> FinalRacedictionary = new Dictionary<string, decimal>();

                    var HorseNames = from h in rss["RawData"]["Participants"] select (string)h["Name"];
                    var Prices = from p in rss["RawData"]["Markets"][0]["Selections"] select (decimal)p["Price"];

                    int i = 0;
                    //Get first list of horses with price and put it in a dictionary as key value pair.
                    if (HorseNames != null)
                    {
                        foreach (var names in HorseNames)
                        {
                            Racedictionary.Add(names, Prices.ToList()[i]);

                            i++;
                        }
                        //sort the dictionary
                        var sortedRaceDict = from entry in Racedictionary orderby entry.Value ascending select entry;

                        foreach (var x in sortedRaceDict)
                        {
                            FinalRacedictionary.Add(x.Key, x.Value);
                        }

                        //output the horse and price list
                        Console.WriteLine("List of JSON");
                        Console.WriteLine("---------------");

                        sortedRaceDict.ToList().ForEach(x => Console.WriteLine(x.Key + "  " + x.Value));
                    }
                    Console.WriteLine("");
                    Console.WriteLine("");
                    Console.WriteLine("");
                    return FinalRacedictionary;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}