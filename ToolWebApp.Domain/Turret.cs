using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolWebApp.Domain
{
    public class Turret
    {
        public virtual string TurretCode { get; set; }

        public virtual string Description { get; set; }

        public List<Tool> Tools { get; set; }
    }
}
