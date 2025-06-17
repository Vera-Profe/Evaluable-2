
// using System.Collections;
// using System.Data;
// using System.Linq;

// namespace VideoGame.Inventory {

//     public abstract class GenericInventory<T> where T : ICollection<IItem?> {

//         /// <summary>
//         /// Capacidad máxima del inventario
//         /// </summary>
//         public int Size { get; protected set; }

//         protected T content;


//         /// <summary>
//         /// Crea el inventario asociado a un jugador
//         /// </summary>
//         /// <param name="size">Capacidad máxima del inventario</param>
//         public GenericInventory() {

//         }


//         /// <summary>
//         /// Guarda un item en el inventario
//         /// </summary>
//         /// <param name="item">Item a insertar</param>
//         public abstract bool Store(IItem item);

//         /// <summary>
//         /// TODO: Implementar
//         /// </summary>
//         public abstract bool StoreAt(IItem item, int index);

//         protected abstract void ForceStore(IItem item, int index);

//         protected abstract void ForceDrop(int index);

//         public abstract IItem? GetItemAt(int index);

//         public abstract bool Drop(IItem item);

//         public abstract bool Drop(int index);

//         public abstract bool isValidIndex(int index);



//         public virtual ICollection<IItem> ListItems() {
//             return content.ToArray();
//         }

//         public virtual bool Contains(IItem item) {
//             if (item is Item actualItem)
//                 return actualItem.Location == this;
//             return item != null && content.Contains(item);
//         }



//         public virtual IItem? Find(Func<IItem, bool> condition) {
//             return content.OfType<IItem>()
//                     .FirstOrDefault(condition);
//         }

//         /// <summary>
//         /// TODO: Implementar
//         /// </summary>
//         public virtual T? Find<T>(Func<T, bool> condition) where T : class, IItem {
//             return content.OfType<T>()
//                     .FirstOrDefault(condition);
//         }

//         /// <summary>
//         /// TODO: Implementar
//         /// </summary>
//         public abstract void Clear();


//         public abstract bool Transfer(IItem item, PlayerInventory target);
//     }


//     public abstract class ArrayInventory : GenericInventory<IItem?[]> {

//     }
    
//     public abstract class ListInventory : GenericInventory<List<IItem?>>
//     {
        
//     }
// }
