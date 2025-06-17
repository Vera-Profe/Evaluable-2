
namespace VideoGame.Inventory {

    public interface IInventory {



        /// <summary>
        /// Capacidad máxima del inventario
        /// </summary>
        public int Size { get; }



        /// <summary>
        /// Guarda un item
        /// </summary>
        public bool Store(IItem item) {

            return false;
        }

        /// <summary>
        /// Guarda un item en una posición
        /// </summary>
        public bool StoreAt(IItem item, int index) {

            return false;
        }

        public IItem? GetItemAt(int index) {
            return null;
        }

        /// <summary>
        /// TODO: Implementar
        /// </summary>
        public bool Drop(IItem item) {

            return false;
        }

        /// <summary>
        /// TODO: Implementar
        /// </summary>
        public bool Drop(int index) {
            return false;
        }


        /// <summary>
        /// TODO: Implementar
        /// </summary>
        public ICollection<IItem> ListItems();

        /// <summary>
        /// TODO: Implementar
        /// </summary>
        public bool Contains(IItem item);


        /// <summary>
        /// TODO: Implementar
        /// </summary>
        public IItem? Find(Func<IItem, bool> condition);

        /// <summary>
        /// TODO: Implementar
        /// </summary>
        public T? Find<T>(Func<T, bool> condition) where T : class, IItem {
            return null;
        }

        public void Clear();

        /// <summary>
        /// TODO: Implementar
        /// </summary>
        public bool Transfer(IItem item, IInventory target);

        protected void ForceStore(IItem item, int index);
    }
}