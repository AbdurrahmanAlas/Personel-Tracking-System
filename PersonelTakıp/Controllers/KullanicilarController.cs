using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PersonelTakıp.Models.Entity;
using System.Web.Security;
namespace PersonelTakıp.Controllers
{
    [AllowAnonymous]
    public class KullanicilarController : Controller
    {
    PersonelEntities db = new PersonelEntities();
        // GET: Login
       


         

        // GET: Login
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]

        public ActionResult Login(Kullanicilar p)
        {
            var kullanici = db.Kullanicilar.FirstOrDefault(x => x.KullaniciAdi == p.KullaniciAdi && x.Sifre == p.Sifre);
            if (kullanici != null)
            {
                FormsAuthentication.SetAuthCookie(p.KullaniciAdi, false);
                //Session["oturum"] = kullanici;

                ViewBag.kullanici = kullanici;

                return RedirectToAction("Index","DaıreBas");
                

            }

            ViewBag.hata = "Kullanıcı Adı veya şifre hatalı";
            return View();
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");


        }
        [HttpGet]
        public ActionResult Kaydol()
        {


            return View();
        }
        [HttpPost]
        public ActionResult Kaydol(Kullanicilar k)
        {
            if (!ModelState.IsValid) return View();

            k.Role = "Kullanıcı";
            db.Entry(k).State = System.Data.Entity.EntityState.Added;
            db.SaveChanges();
            return RedirectToAction("Login");




        }

        //[HttpGet]
        //public PartialViewResult partial1()
        //{

        //    return PartialView();

        //}
        //[HttpPost]
        //public PartialViewResult partial1(Kullanicilar p)
        //{
        //    db.Kullanicilar.Add(p);
        //    db.SaveChanges();
        //    return PartialView();


        //}


    }
    
    
}