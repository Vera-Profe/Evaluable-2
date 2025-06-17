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

        inventario.Store(espada);
        inventario.Store(escudo);

        inventario.Find<Armor>(armor => armor.defense > 3);

        inventario.Store(new Armor("Fallo"));

        var inventarioNPC = new NPCInventory(null, 2);
        inventarioNPC.Store(espada);
        // var cofre = new ChestInventory([escudo, espada, escudo]);
        // cofre = new ChestInventory(escudo,espada,escudo);
        var cofre = ChestInventory.CreateWith(escudo, espada, escudo);


        var tienda = new ShopInventory();
        tienda.Store(new Armor("Gold Armor", 100));
        tienda.Store(new Armor("Paper Armor", 0));
        tienda.Store(new Sword("Master Sword (Quest Item)", null));
    }
}
