using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CarGoatWebServices.Game;
using CarGoatWebServices.Models;

namespace CarGoatWebServices.Controllers
{
    public class GameController : Controller
    {
        // GET: Game
        public ActionResult Index()
        {
            Stats stats = new Stats();

            stats.SameDoorTable = new List<SameDoorStats>();
            stats.ChangeDoorTable = new List<ChangeDoorStats>();
            stats.RandomChoiseTheDoorTable = new List<RandomChoiseTheDoorStats>();

            Random random = new Random();
            
            for (int i = 1; i <= 100; i++)
            {
                random.Next();
                stats.SameDoorTable.Add(new SameDoorStats(){Number = i,Prize = new Game.Game(PlayerChoise.sameDoor,random).Play()});
                stats.ChangeDoorTable.Add(new ChangeDoorStats() { Number = i, Prize = new Game.Game(PlayerChoise.sameDoor, random).Play()});
                stats.RandomChoiseTheDoorTable.Add(new RandomChoiseTheDoorStats() { Number = i, Prize = new Game.Game(PlayerChoise.sameDoor, random).Play()});
            }

            stats.SameDoorProb = new List<ITables>(stats.SameDoorTable).Probability();
            stats.ChangeDoorProb = new List<ITables>(stats.ChangeDoorTable).Probability();
            stats.RandomChoiseTheDoorProb = new List<ITables>(stats.RandomChoiseTheDoorTable).Probability();

            return View(stats);
        }
    }
}