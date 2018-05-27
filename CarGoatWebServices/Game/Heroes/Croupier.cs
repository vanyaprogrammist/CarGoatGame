using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarGoatWebServices.Game.Heroes
{
    public class Croupier
    {
        public Door OpenTheDoor(Door door)
        {
            door.Open = true;
            return door;
        }
    }
}