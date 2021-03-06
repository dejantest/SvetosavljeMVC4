﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Xml.Linq;
using Svetosavlje.Models;
using Svetosavlje.Data_Layer;
using Svetosavlje.Services;
using Svetosavlje.Data_Layer.Interfaces;

namespace Svetosavlje.Controllers
{
    public class HomeController : Controller
    {
        private Blogs blogs = new Blogs();
        private ListArhiva listArhiva = new ListArhiva();
        private PitanjaPastiru pitanjaPastiru = new PitanjaPastiru();
        private SvetiDana svetiDana = new SvetiDana();
        private IzDanaUDan izDanaUDan = new IzDanaUDan();


        [OutputCache(VaryByParam = "none", Duration = 60)]
        public ActionResult Index()
        {
            ViewBag.Message = "Welcome to ASP.NET MVC!";

            DateTime today = DateTime.Today.AddDays(-13);     // Julian date

            Random random = new Random();
            int Month = random.Next(1, 4);
            int Day = random.Next(1, 30);


            Svetosavlje.Models.Main M = new Main(blogs.GetNews(),     //blogs.GetNews(10)
                                                  blogs.GetMissionNews(),
                                                  blogs.GetEditorNews(),
                                                  listArhiva.GetTopicList(10),
                                                  pitanjaPastiru.GetQuestionList(0, 10),
                                                  svetiDana.GetSaintNamesList(today.Month, today.Day),
                                                  izDanaUDan.GetQuote(1, /*today.Month, today.Day*/Month, Day),
                                                  izDanaUDan.GetZachala(today.Month, today.Day, today.Year),
                                                  izDanaUDan.GetFastingType(today.Month, today.Day));

            return View(M);
        }


        public ActionResult About()
        {
            return View();
        }


        public ActionResult Molitve()
        {
            return View();
        }


        public ActionResult Biblioteka()
        {
            return View();
        }

        public ActionResult Pojanje()
        {
            return View();
        }

        public ActionResult Svetinje()
        {
            return View();
        }

        public ActionResult Crkvenoslovenski()
        {
            return View();
        }
    }

    public class ListArhiva : ITopicList
    {
        private DatabaseProvider _provider = new DatabaseProvider();

        public IList<MailListTopicInfo> GetTopicList(int rows)
        {
            return _provider.GetTopicList(rows);
        }

    }

    public class Blogs : IBlogProvider
    {
        private BlogProvider _provider = new BlogProvider();


        public IList<WPBlogModel> GetNews()
        {
            return _provider.GetNews();
        }

        public IList<WPBlogModel> GetEditorNews()
        {
            return _provider.GetEditorNews();
        }

        public IList<WPBlogModel> GetMissionNews()
        {
            return _provider.GetMissionNews();
        }
    }





    public class IzDanaUDan : IQuote, IFastingType, IZachala
    {

        private DatabaseProvider _provider = new DatabaseProvider();

        public string GetQuote(int Autor, int Mjesec, int Dan)
        {
            return _provider.GetQuote(Autor, Mjesec, Dan);
        }

        public string GetFastingType(int Mjesec, int Dan)
        {
            return _provider.GetFastingType(Mjesec, Dan);
        }

        public string GetZachala(int Mjesec, int Dan, int Godina)
        {
            return _provider.GetZachala(Mjesec, Dan, Godina);
        }

    }

}
