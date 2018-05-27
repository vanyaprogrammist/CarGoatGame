using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarGoatWebServices.Game.Heroes
{
    public class Door
    {
        public Prize Prize { get; private set; }
        public bool Open { get; set; } = false;

        public Door(Prize prize)
        {
            Prize = prize;
        }
    }

    public enum Prize
    {
        Goat = 1,
        Car = 2
    }
}