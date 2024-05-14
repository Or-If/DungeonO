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

        private static void IntroductionToEncounter() // this will eventually change depending on room and encounter
        {
            Console.WriteLine("As you enter the room " + enemies.Length + " slimes ooze out a small barrel in the center of the otherwise blank empty room");
            Console.WriteLine(">");
            Console.ReadLine();
        }

        public void Combat(Player player)
        {
            Console.WriteLine("Combat Starts");
            do
            {
                DisplayEnemyInfo();
                PlayerTurn(player);
                EnemyTurn(player);
            } while (EnemiesLeft() > 0);
        }

        #region EnemyInfo
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

        private void DisplayEnemyInfo()
        {
            for (int i = 0; i < enemies.Length; i++)
            {
                Console.WriteLine((i + 1) + ") " + enemies[i].Name + ": Health " + enemies[i].Health + "/" + enemies[i].MaxHealth);
            }

        }

        private void EnemyTurn(Player player)
        {
            foreach (var enemy in enemies)
            {
                if (enemy.Health > 0)
                {
                    enemy.AttackOther(player);
                }  
            }
        }
        #endregion

        #region PlayerTurn
        private void PlayerTurn(Player player)
        {
            int indexOfAction = MenuChoice(player.Actions);
            switch (indexOfAction)
            {
                case 0:
                    AttackEnemy(player);
                    break;
                case 1:
                    BiteEnemy(player);
                    break;
                case 2:
                    CombatInfo(player);
                    break;
                case 3:
                    RunFromCombat();
                    break;
                default:
                    break;
            }
            Console.WriteLine("WE HAVE REACHED THE END");
        }

        private void AttackEnemy(player)
        {
            int enemyToAttack = MenuChoice(enemies);
            player.AttackOther(enemyToAttack);
        }

        private void BiteEnemy(player)
        {
            int enemyToBite = MenuChoice(enemies);
            player.Bite(enemyToBite);
        }

        private void CombatInfo(Player player)
        {
            Console.Clear();
            Console.WriteLine("Combat Information");
            Console.WriteLine("------------");
            Console.WriteLine("- Player Stats -");
            Console.WriteLine("HP:     " + player.Health + "/" + player.MaxHealth);
            Console.WriteLine("Damage: " + player.Damage);
            Console.WriteLine("------------");
            Console.WriteLine("- Enemies -");
            foreach (var enemy in enemies)
            {
                Console.WriteLine(enemy.Name + " the " + enemy.Type + ": HP: " + enemy.Health + "/" + enemy.MaxHealth);
            }
            Console.WriteLine("------------");
        }

        private void RunFromCombat()
        {
            Console.WriteLine("You have run from this fight, and live to never fight another...");
        }

        private int MenuChoice(String[] menuItems)
        {
            int previousLineIndex = -1;
            int selectedLineIndex = 0;
            ConsoleKey pressedKey;
            do
            {
                if(previousLineIndex != selectedLineIndex)
                {
                    UpdateMenu(selectedLineIndex, menuItems);
                    previousLineIndex = selectedLineIndex;
                }
 
                pressedKey = Console.ReadKey().Key;

                
                if (pressedKey == ConsoleKey.DownArrow && selectedLineIndex + 1 < player.Actions.Length)
                    selectedLineIndex++;
                else if (pressedKey == ConsoleKey.UpArrow && selectedLineIndex - 1 >= 0)
                    selectedLineIndex--;
                
            } while (pressedKey != ConsoleKey.Enter);

            Console.WriteLine($"{menuItems[selectedLineIndex]} was chosen");  // change this so that different outputs will happen based on what the player chooses
            return selectedLineIndex;
        }

        private void UpdateMenu(int index, String[] menuItems)
        {
            Console.Clear();
            DisplayEnemyInfo();

            foreach (var item in menuItems) // I can make this choose either if menuItems
            {
                bool isSelected = item == menuItems[index];
                if (isSelected)
                    DrawSelectedMenu(item);
                else 
                    Console.WriteLine($"  {item})
                

                Console.WriteLine($"{(isSelected ? ">  " : "   ")}{item})");
            }
        }

        private void DrawSelectedMenu(string itemToHighlight)
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine($"> {itemToHighlight}");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
        }


        #endregion
 
    }
}
