using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolWebApp.Dao
{
    public interface IRepository<T>
    {
        List<T> ReadAll();

        T GetById(string id);


        void Insert(T item);

        void Update(T item);


        void Delete(string id);
    }
}
