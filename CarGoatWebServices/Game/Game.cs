using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CarGoatWebServices.Game.Heroes;

namespace CarGoatWebServices.Game
{
    public class Game
    {
        public Prize Prize { get;private set; }

        private Door[] Doors { get; set; }

        public PlayerChoise PlayerChoise { get; set; }

        private Random rand;
        private Player player;
        private Croupier croupier;

        public Game(PlayerChoise pc, Random r)
        {
            rand = r;
            Doors = InitDoors();
            PlayerChoise = pc;
            player = new Player();
            croupier = new Croupier();
        }

        private Door[] InitDoors()
        {
            int randomInt = rand.Next(0, 2);
            Door[] doors = {null,null,null};
            doors[randomInt] = new Door(Prize.Car);

            for (int i = 0; i < doors.Length; i++)
            {
                if (doors[i] == null)
                {
                    doors[i] = new Door(Prize.Goat);
                }
            }

            return doors;
        }

        private void PlayerFirstSelect()
        {
            int randomInt = rand.Next(0, 2);
            player.SelectedDoor = Doors[randomInt];
        }

        private void CroupierOpen()
        {
            int indexSelectedDoor = -1;
            Prize prizeSelectedDoor = player.SelectedDoor.Prize;
            
            for (int i = 0; i < Doors.Length; i++)
            {
                if (player.SelectedDoor == Doors[i])
                {
                    indexSelectedDoor = i;
                    break;
                }
            }

            if (prizeSelectedDoor == Prize.Goat)
            {
                for (int i = 0; i < Doors.Length; i++)
                {
                    if (i!=indexSelectedDoor && Doors[i].Prize!=Prize.Car)
                    {
                        croupier.OpenTheDoor(Doors[i]);
                    }
                }
            }
            else
            {
                for (int i = 0; i < Doors.Length; i++)
                {
                    if (i!=indexSelectedDoor)
                    {
                        croupier.OpenTheDoor(Doors[i]);
                        break;
                    }
                }
            }
        }


        private void PlayerSecondSelect()
        {
            int indexSelectedDoor = -1;
            for (int i = 0; i < Doors.Length; i++)
            {
                if (player.SelectedDoor == Doors[i])
                {
                    indexSelectedDoor = i;
                }
            }

            if (PlayerChoise == PlayerChoise.changeDoor)
            {
                for (int i = 0; i < Doors.Length; i++)
                {
                    if (indexSelectedDoor!=i && Doors[i].Open != true)
                    {
                        Prize = Doors[i].Prize;
                    }
                }
            }else if (PlayerChoise == PlayerChoise.sameDoor)
            {
                Prize = player.SelectedDoor.Prize;
            }else if (PlayerChoise == PlayerChoise.randomChoiseTheDoor)
            {
                int random = rand.Next(0, 1);
                if (random == 0)
                {
                    for (int i = 0; i < Doors.Length; i++)
                    {
                        if (indexSelectedDoor != i && Doors[i].Open != true)
                        {
                            Prize = Doors[i].Prize;
                        }
                    }
                }
                else
                {
                    Prize = player.SelectedDoor.Prize;
                }
            }
        }

        public Prize Play()
        {
            PlayerFirstSelect();
            CroupierOpen();
            PlayerSecondSelect();

            return this.Prize;
        }
    }

    public enum PlayerChoise
    {
        changeDoor,
        sameDoor,
        randomChoiseTheDoor
    }
}