using System;
using Xunit;
using dotnet_code_challenge;
using System.Collections.Generic;
using System.Linq;

namespace dotnet_code_challenge.Test
{
    public class RaceTests
    {
        [Fact]
        public void WolferHamptoncsTest()
        {
            string wolfpath = "..\\..\\..\\FeedData\\Wolferhampton_Race1.json";

            Dictionary<string, decimal> In = new Dictionary<string,decimal>();
            In.Add("Fikhaar", 4.4m);
            In.Add("Toolatetodelegate", 10);
            

            Dictionary<string, decimal> Out = WolferHamptoncs.GetWolferHamptonFData(wolfpath);
            bool flag = In.All(e => Out.Contains(e));

            Assert.True(flag);
        }

        [Fact]
        public void CaulfieldRaceTest()
        {
            string Caulfiepath = @"..\\..\\..\\FeedData\\Caulfield_Race1.xml";

            Dictionary<string, string> In = new Dictionary<string, string>();

            In.Add("Advancing", "4.2");
            In.Add("Coronel", "12");

            Dictionary<string, string> Out = CaulfieldRace.GetCaulfieldRace(Caulfiepath);
            bool flag = In.All(e => Out.Contains(e));

            Assert.True(flag);
        }
    }
}
