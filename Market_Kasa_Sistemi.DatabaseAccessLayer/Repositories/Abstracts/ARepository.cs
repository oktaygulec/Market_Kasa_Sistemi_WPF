using Market_Kasa_Sistemi.DatabaseAccessLayer.DatabaseContext;
using Market_Kasa_Sistemi.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace Market_Kasa_Sistemi.DatabaseAccessLayer.Repositories
{
    public abstract class ARepository<T> where T : IModel
    {
        public readonly DBContext context;

        public ARepository(DBContext context)
        {
            this.context = context;
        }

        public abstract Task<object> Add(T item);
        public abstract Task<T> GetItem(object value);
        public abstract Task<int> Remove(T item);
        public abstract Task<List<T>> ToList();
        public abstract Task<ObservableCollection<T>> ToObservableCollection();
        public abstract Task<int> Update(T item);
    }
}
