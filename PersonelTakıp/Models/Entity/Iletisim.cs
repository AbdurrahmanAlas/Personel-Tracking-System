//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PersonelTakıp.Models.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class Iletisim
    {
        public int ID { get; set; }
        public string AdiSoyadi { get; set; }
        public string Email { get; set; }
        public string Baslik { get; set; }
        public string Mesaj { get; set; }
        public Nullable<System.DateTime> Tarih { get; set; }
    }
}
