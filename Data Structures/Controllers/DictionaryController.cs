using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace Data_Structures.Controllers
{
    public class DictionaryController : Controller
    {
        static Dictionary<int, string> myDictionary = new Dictionary<int, string>();
        // GET: Dictionary
        public ActionResult Index()
        {
            ViewBag.MyDictionary = myDictionary;
            return View();
        }
        public ActionResult AddOne()
        {
            myDictionary.Add(myDictionary.Count, "New entry " + (myDictionary.Count + 1));
            ViewBag.MyDictionary = myDictionary;
            return View("Index");
        }
        public ActionResult AddHuge()
        {
            for (int i = 0; i <= 2000; i++)
            {
                myDictionary.Add(myDictionary.Count, "New entry " + (myDictionary.Count + 1));
                ViewBag.MyDictionary = myDictionary;
            }
            return View("Index");
        }
        public ActionResult Display()
        {
            foreach (KeyValuePair<int, string> item in myDictionary)
            {
                ViewBag.MyDictionary = myDictionary;
            }
            return View("Display");
        }
        public ActionResult Delete()
        {
            int x = 10;
            if (myDictionary.Count > 0)
            {
                myDictionary.Remove(x);
            }
            if (myDictionary.Count < 10)
            {
                ViewBag.ErrorMessage = "There is no item to delete.";
            }
            return View("Index");
        }
        public ActionResult Clear()
        {
            while (myDictionary.Count > 0)
            {
                myDictionary.Clear();
            }
            ViewBag.MyDictionary = myDictionary;
            return View("Index");
        }
        public ActionResult Search()
        {
            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
            int searchValue = 40;
            sw.Start();
            //loop to do all the work

            foreach (KeyValuePair<int, string> entry in myDictionary)
            {
                if (entry.Key == searchValue)
                {
                    sw.Stop();
                    TimeSpan fs = sw.Elapsed;
                    ViewBag.Stopwatch = fs;
                    ViewBag.Status = "Found";
                    return View("Index");
                }
            }
            sw.Stop();
            TimeSpan ts = sw.Elapsed;
            ViewBag.Stopwatch = ts;
            ViewBag.Status = "Not Found";
            return View("Index");
        }
        public ActionResult Return()
        {
            return View("~/Views/Home/Index.cshtml");
        }
    }
}