﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace dotnet_code_challenge
{
    public static class CaulfieldRace
    {
        public static Dictionary<string, string> GetCaulfieldRace(string path)
        {
            try
            {
                List<string> iListhorses = new List<string>();
                List<string> iListprice = new List<string>();

                XDocument doc = XDocument.Load(path);
                List<XElement> horses = doc.Descendants("horse").Where(x => x.Elements().Where(y => y.Attribute("name") != null).Any()).ToList();
                var prices = doc.Descendants("horses").LastOrDefault();
                var finalprices = prices.Descendants("horse");

                if (horses.Count > 0)
                {
                    //Get first list of horses
                    foreach (XElement x in horses)
                    {
                        iListhorses.Add((x.Attribute("name").Value));
                    }
                }
                if (finalprices != null)
                {
                    //Get Price for each horse
                    foreach (var z in finalprices)
                    {
                        iListprice.Add(z.Attribute("Price").Value);
                    }
                }
                int i = 0;
                //Output the list
                Console.WriteLine("List of XML");
                Console.WriteLine("---------------");
                Dictionary<string, string> Racedictionary = new Dictionary<string, string>();
                if (iListhorses.Count > 0 && iListprice.Count > 0)
                {
                    foreach (var RaceList in iListhorses)
                    {
                        Racedictionary.Add(RaceList.ToString(), iListprice[i].ToString());
                        i++;
                    }

                    Racedictionary.ToList().ForEach(x => Console.WriteLine(x.Key + "  " + x.Value));
                }
                return Racedictionary;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}