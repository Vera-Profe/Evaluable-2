
using System.Data;
using System.Linq;

namespace VideoGame.Inventory {

    public partial class ChestInventory : BaseInventory {





        /// <summary>
        /// Crea el inventario asociado a un jugador
        /// </summary>
        /// <param name="character">Dueño del inventario</param>
        /// <param name="size">Capacidad máxima del inventario</param>
        protected ChestInventory(int size = 10) : base(size) {

        }

        public ChestInventory(params ICollection<IItem?> items) : base(0) {
            content = items.Distinct().ToArray();
            this.Size = content.Length;
        }




        /// <summary>
        /// Oye no que esto no rula, el Chest no puede hacer Store
        /// </summary>
        public override bool Store(IItem item) {
            return false;
        }

        /// <summary>
        /// Oye no que esto no rula, el Chest no puede hacer Store
        /// </summary>
        public override bool StoreAt(IItem item, int index) {
            return false;
        }


        public static ChestInventory CreateWith(params ICollection<IItem?> items) {
            var uniqueItems = items.Distinct().ToArray();
            var chest = new ChestInventory(uniqueItems.Length);
            chest.content = uniqueItems;
            return chest;
        }

        // public override bool Transfer(IItem item, PlayerInventory target) {

        // }
    }
}