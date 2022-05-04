using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PersonelTakıp.Models.Entity;
using PersonelTakıp.MyModel;

namespace PersonelTakıp.Controllers
{
    //[Authorize(Roles ="Admin")]
    public class DaıreBasController : Controller
    {

        PersonelEntities db = new PersonelEntities();
        // GET: DaıreBas
        public ActionResult Index()
        {
            return View(db.DaıreBas.ToList());
        }

        public ActionResult Ekle()
        {
            return View();


        }
        public ActionResult Ekle2(DaıreBas p)
        {
            db.DaıreBas.Add(p);
            db.SaveChanges();
            
            return RedirectToAction("Index");


        }
        public ActionResult DaıreGetır(DaıreBas p)
        {
            if (!ModelState.IsValid) 
            {
                return View();
            }
  


            var model = db.DaıreBas.Find(p.ID);
            MyDaıreBas k = new MyDaıreBas();
            k.ID = model.ID;
            k.DaıreBas1 = model.DaıreBas1;
            k.Acıklama = model.Acıklama;
            if(model==null)
            {

                return HttpNotFound();
            }
            return View(k);


        }
        public ActionResult Guncelle(DaıreBas p)
        {

            db.Entry(p).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");


        }

        public ActionResult SilBilgiGetir(DaıreBas p)
        {

            var model = db.DaıreBas.Find(p.ID);
            if (model == null) return HttpNotFound();


            return View(model);


        }
        public ActionResult Sil(DaıreBas p)
        {

            db.Entry(p).State= System.Data.Entity.EntityState.Deleted;
            db.SaveChanges();
            return RedirectToAction("Index");

        }

    }
}