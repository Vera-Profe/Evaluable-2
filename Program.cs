using VideoGame;
using VideoGame.Inventory;

internal class Program
{
    static void Main(string[] args) {
        Console.WriteLine("Hello World!");

        var player = new Player();
        var inventario = new PlayerInventory(player, 2);
        var espada = new Sword("Espada Prueba");
        inventario.Store(espada);
        inventario.Drop(espada);
        inventario.StoreAt(espada, 1);
        var list = inventario.ListItems() as IItem?[];
        inventario.Find(item => true);
        inventario.Find(item => false);

        inventario.Find<Armor>(armor => armor.defense > 3);

    }
}
