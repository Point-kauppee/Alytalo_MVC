//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Alytalo_MVC.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Kiukaat
    {
        public int Kiuas_id { get; set; }
        public int Huone { get; set; }
        public string KiukaanTila { get; set; }
        public Nullable<decimal> NykyLampotila { get; set; }
        public Nullable<decimal> TavoiteLampotila { get; set; }
    
        public virtual Huoneet Huoneet { get; set; }
    }
}
