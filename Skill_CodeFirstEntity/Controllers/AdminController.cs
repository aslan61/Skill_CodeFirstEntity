using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Skill_CodeFirstEntity.Models.Sınıflar;

namespace Skill_CodeFirstEntity.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        Context context = new Context();
        public ActionResult Index()
        {
            
            var degerler = context.Yeteneklers.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniYetenek()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniYetenek(Yetenekler y) 
        { 
            context.Yeteneklers.Add(y);
            context.SaveChanges();
            return View();
        }
        public ActionResult YetenekSil(int id)
        {
            var deger = context.Yeteneklers.Find(id);
            context.Yeteneklers.Remove(deger);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult YetenekGetir(int id)
        {
            var deger = context.Yeteneklers.Find(id);
            return View("YetenekGetir",deger);
        }
        [HttpPost]
        public ActionResult YetenekGetir(Yetenekler y)
        {
            var deger = context.Yeteneklers.Find(y.ID);
            deger.Açıklama = y.Açıklama;
            deger.Deger = y.Deger;
            context.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}