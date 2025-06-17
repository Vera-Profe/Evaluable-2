
using System.Data;
using System.Linq;

namespace VideoGame.Inventory {

    public partial class PlayerInventory:BaseInventory {

        /// <summary>
        /// Jugador que contiene al inventario
        /// </summary>
        public Player parent { get; }



        /// <summary>
        /// Crea el inventario asociado a un jugador
        /// </summary>
        /// <param name="player">Dueño del inventario</param>
        /// <param name="size">Capacidad máxima del inventario</param>
        public PlayerInventory(Player player, int size = 10):base(size) {
            this.parent = player;
        }

    }
}