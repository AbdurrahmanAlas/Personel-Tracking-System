using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PersonelTakıp.MyModel
{
    public class MyBirimler
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MyBirimler()
        {
            this.Personeller = new HashSet<MyPersoneller>();
        }

        public int ID { get; set; }
        [Required(ErrorMessage = "Birim alanı boş geçilemez")]
        public string Birim { get; set; }
        [Required(ErrorMessage = "Acıklama alanı boş geçilemez")]
        public string Aciklama { get; set; }

        public Nullable<int> DaıreID { get; set; }

        public virtual MyDaıreBas DaıreBas { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MyPersoneller> Personeller { get; set; }




    }
}