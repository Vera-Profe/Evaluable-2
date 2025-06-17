
using System.Data;
using System.Linq;

namespace VideoGame.Inventory {

    public partial class NPCInventory : BaseInventory {

        /// <summary>
        /// NPC que contiene al inventario
        /// </summary>
        public NPC parent { get; }



        /// <summary>
        /// Crea el inventario asociado a un jugador
        /// </summary>
        /// <param name="character">Dueño del inventario</param>
        /// <param name="size">Capacidad máxima del inventario</param>
        public NPCInventory(NPC character, int size = 10) : base(size) {
            this.parent = character;
        }

        /// <summary>
        /// Oye no que esto no rula, el NPC no puede hacer drop
        /// </summary>
        public override bool Drop(IItem item) {
            return false;
        }

        /// <summary>
        /// Oye no que esto no rula, el NPC no puede hacer drop
        /// </summary>
        public override bool Drop(int index) {
            
            return false;
        }


        public override bool Transfer(IItem item, IInventory target) {
            int index = content.IndexOf(item);
            if (index == -1)
                return false;
            if (!base.Drop(index))
                return false; //No puede hacer drop
            if (target.Store(item))
                return true; // Ha salido bien todo

            ForceStore(item, index);
            return false;
        }
    }
}