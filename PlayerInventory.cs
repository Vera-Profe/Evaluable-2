
using System.Data;
using System.Linq;

namespace VideoGame.Inventory {

    public partial class PlayerInventory {

        /// <summary>
        /// Jugador que contiene al inventario
        /// </summary>
        public Player parent { get; }

        /// <summary>
        /// Capacidad máxima del inventario
        /// </summary>
        public int Size { get; }

        IItem?[] content;


        /// <summary>
        /// Crea el inventario asociado a un jugador
        /// </summary>
        /// <param name="player">Dueño del inventario</param>
        /// <param name="size">Capacidad máxima del inventario</param>
        public PlayerInventory(Player player, int size = 10) {
            this.parent = player;
            this.Size = size;
            content = new IItem[size];
        }

        /// <summary>
        /// TODO: Implementar
        /// </summary>
        public bool Store(IItem item) {
            if (item == null)
                return false;

            int? freeIndex = null;
            foreach (int index in Enumerable.Range(0, content.Length)) {
                if (content[index] == item) { 
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
            return false;
        }

        /// <summary>
        /// TODO: Implementar
        /// </summary>
        public bool StoreAt(IItem item, int index) {
            if (content[index] == item)
                return true;
            if (content[index] != null)
                return false;
            if(Contains(item))
                return false;
            ForceStore(item, index);
            return true;
        }

        protected void ForceStore(IItem item, int index) {
            (item as Item)?.MoveTo(this);
            content[index] = item;
        }

        protected void ForceDrop( int index) {
            (content[index] as Item)?.MoveTo(null);
            content[index] = null;
        }


        /// <summary>
        /// TODO: Implementar
        /// </summary>
        public IItem? GetItemAt(int index) {
            if (isValidIndex(index))
                return null;
            return content[index];
        }

        /// <summary>
        /// TODO: Implementar
        /// </summary>
        public bool Drop(IItem item) {

            int index = content.ToList().IndexOf(item);
            if (index == -1)
                return false;
            ForceDrop(index);
            return true;
        }

        /// <summary>
        /// TODO: Implementar
        /// </summary>
        public bool Drop(int index) {
            if (isValidIndex(index))
                return false;
            ForceDrop(index);
            return false;
        }

        public bool isValidIndex(int index) {
            return index < 0 || index >= content.Length;
        }


        /// <summary>
        /// TODO: Implementar
        /// </summary>
        public ICollection<IItem> ListItems() {
            return (ICollection<IItem>) content.Where(value => value != null).ToArray();
        }

        /// <summary>
        /// TODO: Implementar
        /// </summary>
        public bool Contains(IItem item) {
            if (item is Item actualItem)
                return actualItem.Location == this;
            return item != null && content.Contains(item);
        }


        /// <summary>
        /// TODO: Implementar
        /// </summary>
        public IItem? Find(Func<IItem, bool> condition) {
            return content.OfType<IItem>()
                    .FirstOrDefault(condition);
        }

        /// <summary>
        /// TODO: Implementar
        /// </summary>
        public T? Find<T>(Func<T, bool> condition) where T : class, IItem {
            return content.OfType<T>()
                    .FirstOrDefault(condition);
        }

        /// <summary>
        /// TODO: Implementar
        /// </summary>
        public void Clear() {
            foreach (var item in content) {
                (item as Item)?.MoveTo(null);
            }
            content = new IItem?[Size];
        }

        /// <summary>
        /// TODO: Implementar
        /// </summary>
        public bool Transfer(IItem item, PlayerInventory target) {
            int index = content.ToList().IndexOf(item);
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