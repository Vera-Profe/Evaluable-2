
using System.Collections;
using System.Data;
using System.Linq;

namespace VideoGame.Inventory {

    public abstract class PriorityInventory {

        /// <summary>
        /// Capacidad máxima del inventario
        /// </summary>
        public int Size { get; protected set; }

        protected SortedList<int,IItem?> content;


        /// <summary>
        /// Crea el inventario asociado a un jugador
        /// </summary>
        /// <param name="size">Capacidad máxima del inventario</param>
        public PriorityInventory( int size = 10) {
            this.Size = size;
            content = new SortedList<int,IItem?>();
        }
        

        /// <summary>
        /// Guarda un item en el inventario
        /// </summary>
        /// <param name="item">Item a insertar</param>
        public virtual bool Store(IItem item) {
            
            return false;
        }

        /// <summary>
        /// TODO: Implementar
        /// </summary>
        public virtual bool StoreAt(IItem item, int index) {
            
            return true;
        }

        protected virtual void ForceStore(IItem item, int index) {
            // ! (item as Item)?.MoveTo(this);
            // content.
            
        }

        protected virtual void ForceDrop( int index) {
            // ! (content[index] as Item)?.MoveTo(null);
            content[index] = null;
        }


        /// <summary>
        /// TODO: Implementar
        /// </summary>
        public virtual IItem? GetItemAt(int index) {
            if (isValidIndex(index))
                return null;
            return content[index];
        }

        /// <summary>
        /// TODO: Implementar
        /// </summary>
        public virtual bool Drop(IItem item) {

           
            return true;
        }

        /// <summary>
        /// TODO: Implementar
        /// </summary>
        public virtual bool Drop(int index) {
            
            return false;
        }

        public virtual bool isValidIndex(int index) {
            return index < 0 || index >= content.Count;
        }


        /// <summary>
        /// TODO: Implementar
        /// </summary>
        public virtual ICollection<IItem> ListItems() {
            return (ICollection<IItem>)content.Values.Where(v => v != null).ToArray();
        }

        /// <summary>
        /// Comprueba si el inventario contiene el item concreto
        /// </summary>
        /// <param name="item">item (no null) a comprobar</param>
        /// <returns>Si contiene el item (no null)</returns>
        public virtual bool Contains(IItem item) {
            return false;
        }


    }
}