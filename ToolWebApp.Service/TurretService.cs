using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolWebApp.Dao;
using ToolWebApp.Domain;

namespace ToolWebApp.Service
{
    public class TurretService : IService<Turret>
    {
             
        public void Add(Turret item)
        {
            TurretRepository dao = new TurretRepository();
             dao.Insert(item);

        }

        public List<Turret> GetAll()
        {
            var dao = new TurretRepository();
            return dao.ReadAll();
        }

        public Turret GetById(string id)
        {
            var dao = new TurretRepository();
            return dao.GetById(id);
        }

        public void Modify(Turret item)
        {
            var dao = new TurretRepository();
            dao.Update(item);
        }

        public void Remove(string id)
        {
            var dao = new TurretRepository();
            dao.Delete(id);
        }
    }
}
