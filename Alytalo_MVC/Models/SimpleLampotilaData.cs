using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alytalo_MVC.Models
{
    public class SimpleLampotilaData
    {
        public int Lampotila_id { get; set; }
        public int Huone { get; set; }

        public int? NykyLampotila { get; set; }

        public int? TavoiteLampotila { get; set; }

    }
}
