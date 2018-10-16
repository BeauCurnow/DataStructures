using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace Data_Structures.Controllers
{
    public class QueueController : Controller
    {
        static Queue<String> myQueue = new Queue<string>();
        // GET: Queue
        public ActionResult Index()
        {
            ViewBag.MyQueue = myQueue;
            return View();
        }
        public ActionResult AddOne()
        {
            myQueue.Enqueue("New Entry " + (myQueue.Count + 1));
            ViewBag.MyQueue = myQueue;
            return View("Index");
        }
        public ActionResult AddHugeList()
        {
            int i = 2000;
            do
            {
                myQueue.Enqueue("New Entry " + (myQueue.Count + 1));
                ViewBag.MyQueue = myQueue;
                --i;
            }
            while (i != 0);
            return View("Index");
        }
        public ActionResult Display()
        {
            foreach (var x in myQueue)
            {
                ViewBag.MyQueue = myQueue;
            }
            return View("displayIndexQueue");
        }
        public ActionResult Delete()
        {
            if (myQueue.Count() >= 1)
            {
                myQueue.Dequeue();
                return View("Index");
            }
            else
            {
                return View("displayIndexQueue");
            }
        }
        public ActionResult Clear()
        {
            myQueue.Clear();
            return View("displayIndexQueue");
        }
        public ActionResult Search()
        {
            if (myQueue.Count > 0)
            {
                string SearchTerm = "New Entry 1450";
                System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
                sw.Start();
                string Found = "found";
                string NotFound = "not found";
                ViewBag.Status = NotFound;
                for (int counter = 0; counter < myQueue.Count(); counter++)
                {
                    if (SearchTerm == myQueue.ElementAt(counter))
                    {
                        sw.Stop();
                        TimeSpan fs = sw.Elapsed;
                        ViewBag.StopWatch = fs;
                        ViewBag.Status = Found;
                        return View("Index");
                    }
                }
                sw.Stop();
                TimeSpan ts = sw.Elapsed;
                ViewBag.StopWatch = ts;
                return View("Index");
            }
            else
            {
                return View("displayIndexQueue");
            }
        }
        public ActionResult Menu()
        {
            return View("~/Views/Home/Index.cshtml");
        }
    }
}