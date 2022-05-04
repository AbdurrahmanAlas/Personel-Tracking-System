using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PersonelTakıp.Models.Entity;
using PersonelTakıp.MyModel;

namespace PersonelTakıp.Controllers
{
    //[Authorize]
    //[Authorize(Roles = "Admin")]
    public class PersonellerController : Controller
    {
        PersonelEntities db = new PersonelEntities();
        // GET: Personeller
        public ActionResult Index()
        {
            var model = db.Personeller.ToList();




            return View(model);
        }
        [HttpGet]

        private void Yenile(MyPersoneller model)
        {
            List<DaıreBas> BaskanlıkList = db.DaıreBas.OrderBy(x => x.DaıreBas1).ToList();
            model.DaireBaskanlıkListesi = (from x in BaskanlıkList

                                           select new SelectListItem

                                           {

                                               Text = x.DaıreBas1,
                                               Value = x.ID.ToString()


                                           }



                                         ).ToList();
            List<Birimler> BirimList = db.Birimler.OrderBy(x => x.Birim).ToList();
            model.BirimListesi = (from x in BirimList

                                  select new SelectListItem

                                  {

                                      Text = x.Birim,
                                      Value = x.ID.ToString()


                                  }



                                         ).ToList();
        }

        public ActionResult Ekle()
        {
            var model = new MyPersoneller();
            Yenile(model);

            return View(model);
        }

        [HttpPost]
        public ActionResult Ekle(Personeller p)
        {
         
                if (Request.Files.Count > 0)
            {
                string dosyaadı = Path.GetFileName(Request.Files[0].FileName);
                string uzantı = Path.GetExtension(Request.Files[0].FileName);
                string yol = "~/Resim/" + dosyaadı + uzantı;
                Request.Files[0].SaveAs(Server.MapPath(yol));
                p.Aciklama = "/Resim/" + dosyaadı + uzantı;

            }

            if (!ModelState.IsValid)

            {
                var model = new MyPersoneller();
                Yenile(model);
                return View(model);



            }
            db.Entry(p).State = System.Data.Entity.EntityState.Added;
            db.SaveChanges();

            return RedirectToAction("Index");
        }
        [HttpPost]
        public JsonResult GetBirim(int id2)
        {

            var model = new MyPersoneller();
            List<Birimler> birimliste = db.Birimler.Where(x => x.DaıreID == id2).OrderBy(x => x.Birim).ToList();
            model.BirimListesi = (from x in birimliste
                                  select new SelectListItem

                                  {
                                      Text = x.Birim,
                                      Value = x.ID.ToString()



                                  }



           ).ToList();
            model.BirimListesi.Insert(0, new SelectListItem { Text = "Seiniz", Value = "" });
            return Json(model.BirimListesi, JsonRequestBehavior.AllowGet);

        }
        [HttpGet]
        public ActionResult MiktarEkle(int id)
        {
            var model = db.Personeller.Find(id);
            var personel = new MyPersoneller();
            personel.ID = model.ID;


            personel.Adi = model.Adi;
            personel.Soyadi = model.Soyadi;
            return View(personel);

        }
        [HttpPost]
        public ActionResult MiktarEkle(Personeller p)
        {
            var model = db.Personeller.Find(p.ID);

            //model.ızın = p.ızın;
            model.ızın = model.ızın + p.ızın;
            db.SaveChanges();

            return RedirectToAction("Index");

        }
        [HttpGet]
        public ActionResult MiktarAzalt(int id)
        {
            var model = db.Personeller.Find(id);
            var personel = new MyPersoneller();
            personel.ID = model.ID;
          
          
            personel.Adi = model.Adi;
            personel.Soyadi = model.Soyadi;
            personel.Tc = model.Tc;
            
            personel.ızın = model.ızın;
            personel.Sicil = model.Sicil;
            personel.Tel_1 = model.Tel_1;

            personel.GirisTarih = model.GirisTarih;
            personel.DonusTarih = model.DonusTarih;
            return View(personel);

        }
        [HttpPost]
        public ActionResult MiktarAzalt(Personeller p,Personelızınlerı d)
        {
            var model = db.Personeller.Find(p.ID);
            model.ızın = model.ızın - p.ızın;
            var personel = new MyPersonelızınlerı();
            personel.ID = model.ID;
            personel.PersonelID = model.ID;
            personel.Adi = model.Adi;
            personel.Soyadi = model.Soyadi;
            personel.IzınTuru = d.IzınTuru;
            personel.AlınanIzınSayısı = d.AlınanIzınSayısı;
            personel.GıdısTarih = model.GirisTarih;

            personel.DonusTarih = model.DonusTarih;
          

            personel.DonusTarih = model.DonusTarih;


            db.Personelızınlerı.Add(d);
            db.SaveChanges();

            return RedirectToAction("Index");

        }

        [HttpGet]
        public ActionResult GuncelleBilgiGetir(int id,Personeller p)
        {
           
            var model = db.Personeller.Find(id);
        

            var personel = new MyPersoneller();
            personel.ID = model.ID;
            personel.DaıreID = model.DaıreID;
            personel.BırımID = model.BırımID;
            personel.Adi = model.Adi;
            personel.Soyadi = model.Soyadi;
            personel.Tc = model.Tc;
            personel.Tel_1 = model.Tel_1;
            personel.ızın = model.ızın;
            personel.Sicil = model.Sicil;
            personel.Adres = model.Adres;
            personel.GirisTarih = model.GirisTarih;
            Yenile(personel);
            model.ızın = model.ızın - p.ızın;
            db.SaveChanges();
            List<Birimler> birimlist = db.Birimler.Where(x => x.DaıreID == model.DaıreID).OrderBy(x => x.Birim).ToList();
            personel.BirimListesi = (from x in birimlist

                                  select new SelectListItem
                                  {

                                      Text = x.Birim,
                                      Value = x.ID.ToString()




                                  }).ToList();



            return View(personel);


        }
        [HttpPost]
        public ActionResult Guncelle(Personeller p)
        {
            if (Request.Files.Count > 0)
            {
                string dosyaadı = Path.GetFileName(Request.Files[0].FileName);
                string uzantı = Path.GetExtension(Request.Files[0].FileName);
                string yol = "~/Resim/" + dosyaadı + uzantı;
               
                Request.Files[0].SaveAs(Server.MapPath(yol));
      
                p.Aciklama = "/Resim/" + dosyaadı + uzantı;

            }
        
            if (!ModelState.IsValid)//model dogrulanmazsa
            {

                var model = db.Personeller.Find(p.ID);
                var personel = new MyPersoneller();
                Yenile(personel);
                List<Birimler> birimlist = db.Birimler.Where(x => x.DaıreID == model.DaıreID).OrderBy(x => x.Birim).ToList();
                personel.BirimListesi = (from x in birimlist

                                      select new SelectListItem
                                      {

                                          Text = x.Birim,
                                          Value = x.ID.ToString()




                                      }).ToList();



                return View(personel);



            }

            db.Entry(p).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();



            return RedirectToAction("Index");

        }
        public ActionResult SilBilgiGetir(Personeller p)
        {


            var model = db.Personeller.Find(p.ID);
            if (model == null) return HttpNotFound();

            return View(model);






        }
        public ActionResult Sil(Personeller p)
        {

            db.Entry(p).State = System.Data.Entity.EntityState.Deleted;
            db.SaveChanges();

            return RedirectToAction("Index");



        }




        public ActionResult PersonelListe()
        {
            var model = db.Personeller.ToList();

            return View(model);
        }
    }
}