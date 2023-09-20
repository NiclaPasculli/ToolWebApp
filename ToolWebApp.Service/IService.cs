using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolWebApp.Service
{
    public interface IService<T>
    {
        List<T> GetAll();

        T GetById(string id);





        void Remove(string id);



        void Add(T item);

        void Modify(T item);


    }
}
