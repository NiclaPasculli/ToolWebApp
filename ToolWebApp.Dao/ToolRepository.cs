using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations.Model;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading.Tasks;
using System.Web.WebPages.Html;
using ToolWebApp.Domain;

namespace ToolWebApp.Dao
{
    public class ToolRepository : IRepository<Tool>
    {
        

        public Tool GetById(string id)
        {
            using (MyDbContext myDb = new MyDbContext())
            {

                return myDb.Tool.Where(x => x.IdTool == id).FirstOrDefault();
            }
        }
        public void InsertTool(Tool item)
        {
            using (MyDbContext myDb = new MyDbContext())
            {
                
                myDb.Tool.Add(item);
                myDb.SaveChanges();

            }

        }





        public List<KeyValuePair<string, string>> GetAllTurretCodes()
        {
            using (MyDbContext myDb = new MyDbContext())
            {
                var turretCodes = myDb.Turret
                    .Join(
                        myDb.Tool,
                        turret => turret.TurretCode,
                        tool => tool.TurretCode,
                        (turret, tool) => new { TurretCode = turret.TurretCode, Description = turret.Description }
                    )
                    .Distinct()
                    .ToList();

                return turretCodes.Select(turret => new KeyValuePair<string, string>(turret.TurretCode, turret.Description)).ToList();
            }
        }

        //public void SaveTool(Tool item)
        //{
        //    using (MyDbContext myDb = new MyDbContext())
        //    {
        //        var tool = GetById(item.IdTool);
        //        if(tool != null)
        //        {

        //            tool.BoschCode = item.BoschCode;
        //            tool.Description = item.Description;
        //            tool.PrimarySupplier = item.PrimarySupplier;
        //            tool.SecondarySupplier = item.SecondarySupplier;
        //            tool.PrimarySharpener = item.PrimarySharpener;
        //            tool.SecondarySharpener = item.SecondarySharpener;
        //            tool.Quantity = item.Quantity;
        //            tool.TurretCode = item.TurretCode;
        //            myDb.SaveChanges();
        //        }
        //        else
        //        {
        //            myDb.Tool.Add(item);
        //            myDb.SaveChanges();
        //        }
        //    }

        //}



        public void Update(Tool item)
        {
            using (MyDbContext myDb = new MyDbContext())
            {
                var tool = myDb.Tool.Where(t => t.IdTool.Equals(item.IdTool)).FirstOrDefault();
                if (tool != null)
                {
                   
                    tool.BoschCode = item.BoschCode;
                    tool.Description = item.Description;
                    tool.PrimarySupplier = item.PrimarySupplier;
                    tool.SecondarySupplier = item.SecondarySupplier;
                    tool.PrimarySharpener = item.PrimarySharpener;
                    tool.SecondarySharpener = item.SecondarySharpener;
                    tool.Quantity = item.Quantity;
                    tool.TurretCode = item.TurretCode;
                    myDb.SaveChanges();
                }
            }

        }

        public void Delete(string id)
        {
            using (MyDbContext myDb = new MyDbContext())
            {

                var itemDelete = myDb.Tool.Where(t => t.IdTool.Equals(id)).FirstOrDefault();
                if (itemDelete != null)
                {
                    myDb.Tool.Remove(itemDelete);
                    myDb.SaveChanges();
                }
            }

        }

        public bool Update(Tool item, string id)
        {
            throw new NotImplementedException();
        }



        public Tool GetByBoschCode(string id)
        {
            using (MyDbContext myDb = new MyDbContext())
            {

                return myDb.Tool.Where(x => x.BoschCode == id).FirstOrDefault();


            }

        }

        public List<Tool> GetByDescription(string description)
        {
            using(MyDbContext myDb = new MyDbContext())
            {
                return myDb.Tool.Where(x => x.Description.Contains(description)).ToList();
            }
        }

        public List<Tool> GetByPrimarySupplier(string id)
        {
            using (MyDbContext myDb = new MyDbContext())
            {
                return myDb.Tool.Where(x => x.PrimarySupplier == id).ToList();

            }
        }

        public List<Tool> OrderbyQuantity()
        {
            using (MyDbContext myDb = new MyDbContext())
            {
                return myDb.Tool.OrderBy(x => x.Quantity).ToList();
            }
        }

        public List<Tool> ReadAll()
        {
            using (MyDbContext myDb = new MyDbContext())
            {
                return myDb.Tool.ToList();
            }
        }

        public void Insert(Tool item)
        {
            throw new NotImplementedException();
        }

        public List<Tool> Search(string id, string turretCode)
        {
            using (MyDbContext myDb = new MyDbContext())
            {
                IQueryable<Tool> query = myDb.Tool;

                if (!string.IsNullOrEmpty(id))
                {
                    query = query.Where(x => x.IdTool == id);
                }

                if (!string.IsNullOrEmpty(turretCode))
                {
                    query = query.Where(x => x.TurretCode == turretCode);
                }

                return query.ToList();
            }
        }



    }


}
