using DungeonO;

Player player = new Player(Introduction());
Encounter introFight = new Encounter(player);

Console.ReadLine(); // This is here to pause the page before it closes.

/* Encounter :
 *  - Introduction
 *  - Enemies to be generated
 *  - 
 * 
*/

static string Introduction()
{
    Console.WriteLine("Hello adventurer, today you will be participating in a simple test to see if you are ready to venture into the dungeon");
    Console.WriteLine("First off what is your name...");
    var userName = Console.ReadLine();
    Console.WriteLine("Huh, I don't think thats a very good adventuring name. Here this will fit you better...");
    Console.WriteLine(" ----------------------------------------------------------------------------- ");
    return "Tim";
}  