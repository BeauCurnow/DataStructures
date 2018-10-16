using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Data_Structures.Controllers
{
   public class StackController : Controller
   {
      static Stack<string> myStack = new Stack<string>();
      // GET: Stack
      public ActionResult Index()
      {
         ViewBag.MyStack = myStack;

         return View();
      }

      public ActionResult AddOne()
      {
         myStack.Push("New Entry " + (myStack.Count + 1));
         ViewBag.MyStack = myStack;

         return View("Index");
      }

      public ActionResult AddList()
      {
         for (int StackCounter = 0; StackCounter < 2000; StackCounter++)
         {
            myStack.Push("New Entry " + (myStack.Count + 1));
            ViewBag.MyStack = myStack;
         }

         return View("Index");

      }

      public ActionResult Display()
      {
         foreach (var x in myStack)
         {
            ViewBag.MyStack = myStack;
         }

         return View("StackDisplay");
      }

      public ActionResult Delete()
      {
         if (myStack.Count > 0)
         {
            myStack.Pop();
         }

         return View("Index");
      }

      public ActionResult Clear()
      {
         while (myStack.Count > 0)
         {
            myStack.Clear();
         }

         return View("Index");
      }

      public ActionResult Search()
      {
         string SearchTerm = "New Entry 1450";
         System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
         sw.Start();
         string Found = "found";
         string NotFound = "not found";
         ViewBag.Status = NotFound;
         for (int counter = 0; counter < myStack.Count(); counter++)
         {
            if (SearchTerm == myStack.ElementAt(counter))
            {
               sw.Stop();
               TimeSpan fs = sw.Elapsed;
               ViewBag.StopWatch = fs;
               ViewBag.Status = Found;

               return View("Stopwatch");
            }
         }
            sw.Stop();
            TimeSpan ts = sw.Elapsed;
            ViewBag.StopWatch = ts;

            return View("Stopwatch");
      }

      public ActionResult Menu()
      {
         return View("~/Views/Home/Index.cshtml");
      }
   }
}