using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolWebApp.Domain;

namespace ToolWebApp.Dao
{
    public class TurretRepository : IRepository<Turret>
    {
        public void Delete(string id)
        {
            using (MyDbContext myDb = new MyDbContext())
            {
                var turret = myDb.Turret.Where( t => t.TurretCode == id ).FirstOrDefault();    
                if (turret != null)
                {
                    myDb.Turret.Remove(turret);
                    myDb.SaveChanges();
                }
            }
        }

        public Turret GetById(string id)
        {
           using(MyDbContext myDb = new MyDbContext()) 
            { 
                return myDb.Turret.Where(t => t.TurretCode == id).FirstOrDefault();
            }
        }

        public void Insert(Turret item)
        {
            using(MyDbContext myDb = new MyDbContext())
            {
                myDb.Turret.Add(item);
                myDb.SaveChanges();
            }
        }

        public List<Turret> ReadAll()
        {
            using (MyDbContext myDb = new MyDbContext())
            {
                return myDb.Turret.ToList();
            }
        }

        public void Update(Turret item)
        {
            using (MyDbContext myDb = new MyDbContext())
            {
                var turret = myDb.Turret.Where(t=> t.TurretCode == item.TurretCode).FirstOrDefault();
                if(turret != null)
                {
                    turret.TurretCode = item.TurretCode;
                    turret.Description = item.Description;  
                    myDb.SaveChanges();
                }
            }
        }
    }
}
