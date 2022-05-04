using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PersonelTakıp.MyModel
{
    public class MyPersoneller
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MyPersoneller()
        {
            this.Personelızınlerı = new HashSet<MyPersonelızınlerı>();
            this.BirimListesi = new List<SelectListItem>();
            BirimListesi.Insert(0, new SelectListItem { Text = "Önce Daire başkanlıgı seçilmelidir", Value = "" });
        }

        public int ID { get; set; }
        public Nullable<int> DaıreID { get; set; }
        public Nullable<int> BırımID { get; set; }
        public string Adi { get; set; }
        public string Soyadi { get; set; }
        public string Sicil { get; set; }
        public string Tel_1 { get; set; }
        public string Tc { get; set; }
        public string Email { get; set; }
        public string Adres { get; set; }
        public string Aciklama { get; set; }
        public Nullable<bool> IsActıve { get; set; }
        public Nullable<int> ızın { get; set; }
        public Nullable<System.DateTime> GirisTarih { get; set; }
        public Nullable<System.DateTime> DonusTarih { get; set; }
        public Nullable<int> PersonelID { get; set; }
        public string IzınTuru { get; set; }
        public Nullable<System.DateTime> GıdısTarih { get; set; }
        
        public Nullable<int> AlınanIzınSayısı { get; set; }
        public Nullable<int> KalanIzınSayısı { get; set; }
        public virtual MyBirimler Birimler { get; set; }
        public virtual MyDaıreBas DaıreBas { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MyPersonelızınlerı> Personelızınlerı { get; set; }
        public virtual List<SelectListItem> BirimListesi { get; set; }
        public virtual List<SelectListItem> DaireBaskanlıkListesi { get; set; }
    }
}