
using System.Collections;
using System.Data;
using System.Linq;

namespace VideoGame.Inventory {

    public partial class ShopInventory : BaseInventory {





        /// <summary>
        /// Crea el inventario asociado a un jugador
        /// </summary>
    
        /// <param name="size">Capacidad máxima del inventario</param>
        public ShopInventory() : base(0) {
            Size = int.MaxValue;
            content = new List<IItem?>();
        }



        public override bool Store(IItem item) {
            if (item is Item actualItem && actualItem.Price.HasValue) {
                base.Store(item);
            }
                
            return false;
        }


        public override bool StoreAt(IItem item, int index) {
            if (item is Item actualItem && actualItem.Price.HasValue) {

                return base.StoreAt(item, index);
                
            }
            return false;
        }


  

        // public override bool Transfer(IItem item, PlayerInventory target) {

        // }
    }
}