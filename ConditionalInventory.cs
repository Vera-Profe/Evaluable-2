
using System.Collections;
using System.Data;
using System.Linq;

namespace VideoGame.Inventory {

    public partial class ConditionalInventory : BaseInventory {


        public Func<IItem, bool> condition;


        /// <summary>
        /// Crea el inventario asociado a un jugador
        /// </summary>

        /// <param name="size">Capacidad máxima del inventario</param>
        public ConditionalInventory(Func<IItem, bool> condition) : base(0) {
            Size = int.MaxValue;
            content = new List<IItem?>();
            this.condition = condition;
        }



        public override bool Store(IItem item) {
            if (condition(item)) {
                base.Store(item);
            }
                
            return false;
        }


        public override bool StoreAt(IItem item, int index) {
            if (condition(item)) {
                return base.StoreAt(item, index);
            }
            return false;
        }


  

        // public override bool Transfer(IItem item, PlayerInventory target) {

        // }
    }
}