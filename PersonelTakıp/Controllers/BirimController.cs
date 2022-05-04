using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PersonelTakıp.Models.Entity;
using PersonelTakıp.MyModel;

namespace PersonelTakıp.Controllers
{
    //[Authorize]
    //[Authorize(Roles = "Admin")]
    public class BirimController : Controller
    {
        // GET: Birim
        PersonelEntities db = new PersonelEntities();
        public ActionResult Index()
        {

            var model = db.Birimler.ToList();


            return View(model);



        }
     
        [HttpGet]
        public ActionResult Ekle()
        {
            SelecteBilgiGetir();

            return View();


        }

        private void SelecteBilgiGetir()
        {
            var model = new MyBirimler();

            ViewBag.DaıreID = new SelectList(db.DaıreBas, "ID", "DaıreBas1", model.DaıreID);
        }

        [HttpPost]
        public ActionResult Ekle(Birimler p)
        {
            if (!ModelState.IsValid)

            {
                ViewBag.DaıreID = new SelectList(db.DaıreBas, "ID", "DaıreBas1", p.DaıreID);



                return View("Ekle");
            }


            db.Entry(p).State = System.Data.Entity.EntityState.Added;
            db.SaveChanges();


            return RedirectToAction("Index");


        }

public ActionResult GuncelleBilgiGetir(int id)
{
            MyBirimler model = new MyBirimler();


    var ara = db.Birimler.Find(id);
            model.ID = ara.ID;
            model.DaıreID = ara.DaıreID;
            model.Birim = ara.Birim;
            model.Aciklama = ara.Aciklama;


    SelecteBilgiGetir();

    return View(model);


}
public ActionResult Guncelle(Birimler p)
{

    if (!ModelState.IsValid)
    {
        SelecteBilgiGetir();
        return RedirectToAction("GuncelleBilgiGetir");




    }
    db.Entry(p).State = System.Data.Entity.EntityState.Modified;
    db.SaveChanges();


    return RedirectToAction("Index");

}
public ActionResult SilBilgiGetir(Birimler p)
{


    var model = db.Birimler.Find(p.ID);
    if (model == null) return HttpNotFound();

    return View(model);






}
        public ActionResult DepartmanDetay(int id)
        {

            var degerler = db.Personeller.Where(x => x.BırımID == id).ToList();
            var dpt = db.Birimler.Where(x => x.ID == id).Select(y =>
                  y.Birim).FirstOrDefault();
            ViewBag.d = dpt;

            return View(degerler);

        }

        public ActionResult DepartmanPersonelIzın(int id)
        {

            var degerler = db.Personelızınlerı.Where(x => x.PersonelID == id).ToList();
            var per = db.Personelızınlerı.Where(x => x.PersonelID == id).Select(y => y.Personeller.Adi + "" + y.Personeller.Soyadi).FirstOrDefault();
            ViewBag.dpers = per;
            return View(degerler);

        }

        public ActionResult Sil(Birimler p)
{

    db.Entry(p).State = System.Data.Entity.EntityState.Deleted;
    db.SaveChanges();

    return RedirectToAction("Index");



}

    }
}
