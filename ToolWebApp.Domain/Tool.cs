using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolWebApp.Domain
{
    public class Tool
    {
        
        public virtual string IdTool { get; set; }
        public virtual string BoschCode { get; set; }

        public virtual string Description { get; set; }

        public virtual string PrimarySupplier { get; set; }

        public virtual string SecondarySupplier { get; set; }

        public virtual string PrimarySharpener { get; set; }

        public virtual string SecondarySharpener { get; set; }

        public virtual int? Quantity { get; set; }


        public virtual string TurretCode { get; set; }

        public virtual string PresettingQuoteNGEM1 { get; set; }

        public virtual string PresettingQuoteNGEM2 { get; set; }

        public virtual string PresettingDiameter { get; set; }

        public virtual string Presetting { get; set; }

        public virtual int? Life { get; set; }

        public virtual string SProposal { get; set; }

        public virtual string FProposal { get; set; }

        public virtual string SValue { get; set; }

        public virtual string FValue { get; set; }

        public virtual string Refrigeration { get; set; }

        public virtual string Accessories { get; set; }

        public Turret turret { get; set; }
        public List<string> TurretCodes { get; set; }

    }
}
