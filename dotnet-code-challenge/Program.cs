using System;

namespace dotnet_code_challenge
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            try
            {
                string wolfpath = ".\\FeedData\\Wolferhampton_Race1.json";
                string Caulfiepath = @".\\FeedData\\Caulfield_Race1.xml";
                WolferHamptoncs.GetWolferHamptonFData(wolfpath);
                CaulfieldRace.GetCaulfieldRace(Caulfiepath);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            Console.ReadLine();
        }
    }
}