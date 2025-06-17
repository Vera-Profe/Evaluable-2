using System.Reflection;
using VideoGame;
using VideoGame.Inventory;

internal class Program
{
    static void Main(string[] args) {
        Console.WriteLine("Hello World!");

        var player = new Player();
        var inventario = new PlayerInventory(player, 2);
        var espada = new Sword("Espada Prueba");
        var escudo = new Armor("Escudo Prueba");

        inventario.Find<Armor>(armor => armor.defense > 3);

        var inventarioNPC = new NPCInventory(null, 2);
        // var cofre = new ChestInventory([escudo, espada, escudo]);
        // cofre = new ChestInventory(escudo,espada,escudo);
        var cofre = ChestInventory.CreateWith(escudo, espada, escudo);


       
    }
}
