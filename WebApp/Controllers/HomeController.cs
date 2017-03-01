using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        List<FilmModel> myfilms = new List<FilmModel>();
        const int cost = 30;

        void AddFilms()
        {
            myfilms.Add(new FilmModel() { Info = "Это первый фильм, он ничего", Price = 10, Name = "Harry Potter 1", Img_path = "/Content/Image/Гарри1.jpg"});
            myfilms.Add(new FilmModel() { Info = "Это второй фильм, он странный", Price = 20, Name = "Harry Potter 2", Img_path = "/Content/Image/Гарри2.jpg" });
            myfilms.Add(new FilmModel() { Info = "Это третий фильм, он нравится всем", Price = 30, Name = "Harry Potter 3", Img_path = "/Content/Image/Гарри3.jpg" });

            string[] films = new string[myfilms.Count];
            for (int i = 0; i < myfilms.Count; i++)
            {
                films[i] = myfilms[i].Name;
            }
            ViewBag.MyFilms = new SelectList(films);
        }       

        public ActionResult Index()
        {
            AddFilms();

            return View(myfilms);
        }

        [HttpPost]
        public ActionResult Index(string MyFilms, string Days)
        {
            AddFilms();

            foreach (FilmModel film in myfilms)
            {
                if (film.Name == MyFilms)
                {
                    string result = "Цена: " + Convert.ToInt32(Days) * film.Price;
                    ViewBag.OrderPrice = result;
                }
            }

            return View(myfilms);
        }
    }
}