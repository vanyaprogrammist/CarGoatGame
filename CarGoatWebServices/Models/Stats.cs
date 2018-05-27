using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CarGoatWebServices.Game.Heroes;

namespace CarGoatWebServices.Models
{
    public class Stats
    {
        public List<ChangeDoorStats> ChangeDoorTable { get; set; }
        public List<SameDoorStats> SameDoorTable { get; set; }
        public List<RandomChoiseTheDoorStats> RandomChoiseTheDoorTable { get; set; }

        public int ChangeDoorProb { get; set; }
        public int SameDoorProb { get; set; }
        public int RandomChoiseTheDoorProb { get; set; }
    }

    public class ChangeDoorStats : ITables
    {
        public int Number { get; set; }
        public Prize Prize { get; set; }
    }

    public class SameDoorStats : ITables
    {
        public int Number { get; set; }
        public Prize Prize { get; set; }
    }

    public class RandomChoiseTheDoorStats : ITables
    {
        public int Number { get; set; }
        public Prize Prize { get; set; }
    }

    public interface ITables
    {
        int Number { get; set; }
        Prize Prize { get; set; }
    }
}