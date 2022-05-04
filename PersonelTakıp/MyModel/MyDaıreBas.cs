using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PersonelTakıp.MyModel
{
    public class MyDaıreBas
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MyDaıreBas()
        {
            this.Birimler = new HashSet<MyBirimler>();
            this.Personeller = new HashSet<MyPersoneller>();
        }

        public int ID { get; set; }
        [Required(ErrorMessage ="Daıre baskanlık alanı boş geçilemez")]
        public string DaıreBas1 { get; set; }
        [Required(ErrorMessage = "Acıklama alanı boş geçilemez")]
        public string Acıklama { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MyBirimler> Birimler { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MyPersoneller> Personeller { get; set; }
    }
}