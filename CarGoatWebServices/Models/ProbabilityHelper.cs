using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CarGoatWebServices.Game.Heroes;

namespace CarGoatWebServices.Models
{
    public static class ProbabilityHelper
    {
        
        public static int Probability(this List<ITables> table)
        {
            int car = table.Count(t => t.Prize == Prize.Car);
            int length = table.Count;
            double r = (double)car / length;

            return (int) (r * 100);
        }
    }
}