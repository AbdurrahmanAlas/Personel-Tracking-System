using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PersonelTakıp.MyModel
{
    public class MyPersonelızınlerı
    {
        public int ID { get; set; }
        public Nullable<int> PersonelID { get; set; }
        public string Adi { get; set; }
        public string Soyadi { get; set; }
        public string IzınTuru { get; set; }
        public Nullable<System.DateTime> GıdısTarih { get; set; }
        public Nullable<System.DateTime> DonusTarih { get; set; }
        public Nullable<int> AlınanIzınSayısı { get; set; }
        public Nullable<int> KalanIzınSayısı { get; set; }

        public virtual MyPersoneller Personeller { get; set; }
    }
}