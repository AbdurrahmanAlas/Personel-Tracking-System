using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PersonelTakıp.Models.Entity;
using PersonelTakıp.MyModel;

namespace PersonelTakıp.Controllers
{
    public class PersonelızınController : Controller
    {
        PersonelEntities db = new PersonelEntities();
        // GET: Personelızın
        public ActionResult Index()
        {
            var model = db.Personelızınlerı.ToList();


            return View(model);
        }
        [HttpGet]
        public ActionResult Ekle()
        {
            return View();


        }
        [HttpPost]
        public ActionResult Ekle2(Personelızınlerı p)
        {
            db.Personelızınlerı.Add(p);
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

            //personel.GirisTarih = model.GirisTarih;
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


            personel.IzınTuru = d.IzınTuru;
            personel.AlınanIzınSayısı = d.AlınanIzınSayısı;
            personel.GıdısTarih = model.GirisTarih;

            personel.DonusTarih = model.DonusTarih;
            personel.PersonelID = model.ID;
           
            personel.DonusTarih = model.DonusTarih;


            db.Personelızınlerı.Add(d);
            db.SaveChanges();

            return RedirectToAction("Index");

        }
        public ActionResult SilBilgiGetir(Personeller p)
        {


            var model = db.Personelızınlerı.Find(p.ID);
            if (model == null) return HttpNotFound();

            return View(model);






        }
        public ActionResult Sil(Personelızınlerı  p)
        {

            db.Entry(p).State = System.Data.Entity.EntityState.Deleted;
            db.SaveChanges();

            return RedirectToAction("Index");



        }
    }
}