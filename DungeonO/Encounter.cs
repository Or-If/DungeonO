using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace DungeonO
{
    internal class Encounter
    {
        // I will have this build the encounter, what kind of enemies and what stats.
        // the combat will also be hosted in this for each encounter
        // the choices of attack and such like that on a loop until something breaks it


        public Random gen = new Random(); // will be used for generatingslightly random room comps
        private int _enemyAmount;
        private static Unit[] enemies; // consists of an array of Enemy typed units that each is a object that has stats and such

        public Encounter(Player player)
        {
            EnemyGeneration();
            IntroductionToEncounter();
            Combat(player);
        }

        public void EnemyGeneration()
        {
            Unit pinky = new Slime("Pinky");
            Unit poppy = new Slime("Bluey");
            Unit icarus = new Slime("Icarus");
            enemies = new Unit[] { pinky, poppy, icarus};
            
        }

        public int EnemiesLeft()
        {
            foreach(Unit enemy in enemies)
            {
                if(enemy.Health <= 0)
                {
                    _enemyAmount -= 1;
                }
            }
            return _enemyAmount;
        }

        private static void IntroductionToEncounter() // this will eventually change depending on room and encounter
        {
            Console.WriteLine("As you enter the room*" + enemies.Length + " slimes ooze out a small barrel in the center of the otherwise blank empty room");
        }

        public void Combat(Player player)
        {
            do
            {
                PlayerTurn();
            } while (EnemiesLeft() > 0);
            
        }

        private void PlayerTurn()
        {
            
        }
    }
}
