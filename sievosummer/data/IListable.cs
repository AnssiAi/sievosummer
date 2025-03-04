using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sievosummer.data
{
    public interface IListable<T, M>
    {
        public void AddNew(M item);
        public T GetById(int id);
        public void UpdateItem(T item);

        public List<T> GetAll();

    }
}
