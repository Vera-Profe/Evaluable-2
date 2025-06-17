
using System.Collections;
using System.Data;
using System.Linq;

namespace VideoGame.Inventory {

    public abstract class BaseInventory:IInventory {

        /// <summary>
        /// Capacidad máxima del inventario
        /// </summary>
        public int Size { get; protected set; }

        protected IList<IItem?> content;


        /// <summary>
        /// Crea el inventario asociado a un jugador
        /// </summary>
        /// <param name="size">Capacidad máxima del inventario</param>
        public BaseInventory( int size = 10) {
            this.Size = size;
            content = new IItem[size];
        }
        

        /// <summary>
        /// Guarda un item en el inventario
        /// </summary>
        /// <param name="item">Item a insertar</param>
        public virtual bool Store(IItem item) {
            if (item == null)
                return false;

            int? freeIndex = null;

            foreach (int index in Enumerable.Range(0, content.Count)) {
                if (content is IItem?[] array && array[index] == item) {
                    return true; //Ya está guardado
                }
                if (freeIndex == null && content[index] == null) {
                    freeIndex = index;
                }
            }
            if (freeIndex != null) {
                ForceStore(item, (int)freeIndex);
                return true;
            }
            // Hueco libre no encontrado
            if ( content.Count < Size && content is List<IItem?>) {
                ForceAdd(item);
                return true;
            }
            return false;
        }

        /// <summary>
        /// TODO: Implementar
        /// </summary>
        public virtual bool StoreAt(IItem item, int index) {
            int foundAt = content.IndexOf(item);
            if (foundAt == index)//Lo contiene en el mismo sitio
                return true;
             if (foundAt != -1) //Lo contiene
                return false;
            if (!isValidSlot(index))
                return false;
            // Insertar    
            if (isValidIndex(index)) {
                if (content[index] != null)
                    return false;
                ForceStore(item, index);
                return true;
            }
            else if(content is List<IItem>){
                ForceAddAt(item, index);
                return true;
            }
            return false;
        }

        protected virtual void ForceStore(IItem item, int index) {
            (item as Item)?.MoveTo(this);
            content[index] = item;
        }
        
        protected virtual void ForceAdd(IItem item) {
            content.Add(item);
            (item as Item)?.MoveTo(this);
        }

        protected virtual void ForceAddAt(IItem item, int index) {
            while (content.Count < index - 1) {
                content.Add(null);
            }
            content.Add(item);
            (item as Item)?.MoveTo(this);
        }

        protected virtual void ForceDrop(int index) {
            (content[index] as Item)?.MoveTo(null);
            content[index] = null;
        }


        /// <summary>
        /// TODO: Implementar
        /// </summary>
        public virtual IItem? GetItemAt(int index) {
            if (!isValidIndex(index))
                return null;
            return content[index];
        }

        /// <summary>
        /// TODO: Implementar
        /// </summary>
        public virtual bool Drop(IItem item) {

            int index = content.IndexOf(item);
            if (index == -1)
                return false;
            ForceDrop(index);
            return true;
        }

        /// <summary>
        /// TODO: Implementar
        /// </summary>
        public virtual bool Drop(int index) {
            if (!isValidIndex(index))
                return false;
            ForceDrop(index);
            return false;
        }

        public virtual bool isValidIndex(int index) {
            return index > 0 && index < content.Count;
        }
        
        /// <summary>
        /// Comprueba si es un número e slot que debería poder usarse
        /// </summary>
        /// <param name="index"></param>
        public virtual bool isValidSlot(int index) {
            return index > 0 && index < Size;
        }


        /// <summary>
        /// TODO: Implementar
        /// </summary>
        public virtual ICollection<IItem> ListItems() {
            return (ICollection<IItem>)content.Where(value => value != null).ToArray();
        }

        /// <summary>
        /// Comprueba si el inventario contiene el item concreto
        /// </summary>
        /// <param name="item">item (no null) a comprobar</param>
        /// <returns>Si contiene el item (no null)</returns>
        public virtual bool Contains(IItem item) {
            if (item is Item actualItem)
                return actualItem.Location == this;
            return item != null && content.Contains(item);
        }


        /// <summary>
        /// TODO: Implementar
        /// </summary>
        public virtual IItem? Find(Func<IItem, bool> condition) {
            return content.OfType<IItem>()
                    .FirstOrDefault(condition);
        }

        /// <summary>
        /// TODO: Implementar
        /// </summary>
        public virtual T? Find<T>(Func<T, bool> condition) where T : class, IItem {
            return content.OfType<T>()
                    .FirstOrDefault(condition);
        }

        /// <summary>
        /// TODO: Implementar
        /// </summary>
        public virtual void Clear() {
            foreach (var item in content) {
                (item as Item)?.MoveTo(null);
            }
            content = new IItem?[Size];
        }

        /// <summary>
        /// TODO: Implementar
        /// </summary>
        public virtual bool Transfer(IItem item, IInventory target) {
            int index = content.IndexOf(item);
            if (index == -1)
                return false;
            if (!Drop(index))
                return false; //No puede hacer drop
            if (target.Store(item))
                return true; // Ha salido bien todo

            ForceStore(item, index);
            return false;
        }

        

       
    }
}