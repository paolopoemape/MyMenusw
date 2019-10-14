using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyMenus.Controllers
{
    public class QueueController : Controller
    {
        static Queue<string> myQueue = new Queue<string>();
        

        // GET: Queue


        public ActionResult Index()
        {
           
            ViewBag.MyQueue = myQueue;
           
            return View();
        }

        public ActionResult AddOne()
        {
           myQueue.Enqueue("New Entry " + (myQueue.Count+ 1) );

           return View("Index");
        }

        public ActionResult AddHugeList()
        {

            myQueue.Clear();
           
            while (myQueue.Count < 2000)
                

            {
                myQueue.Enqueue( "New Entry " + (myQueue.Count + 1));
                
            }

            ViewBag.MyQueue = myQueue;


          return View("Index");
        }

        public ActionResult Display(String display="display")
        {
            ViewBag.MyQueue = myQueue;
            
            return View("Index");
            
        }

       


        public ActionResult DeleteFrom(string Elemento )
        {
            if (!myQueue.Where((item) => item.Contains(Elemento)).Any())
            {
                ViewBag.error = $"The item {Elemento} doesn't exist ";
                return View("Index");
            }

            myQueue = new Queue<string>( myQueue.Where((item) => !item.Contains(Elemento)));


            return View("Index");
        }
        
        

       public ActionResult Clear()
       {

           myQueue.Clear();
           ViewBag.MyQueue = myQueue;
           return View("Index");
       }
       


       public ActionResult Search(String Elemento)
       {
            ViewBag.Accion = "Buscar";

            if (!myQueue.Where((item) => item.Contains(Elemento)).Any())
            {
                ViewBag.error1 = $"The item {Elemento} doesn't exist, Processing Time: ";

                System.Diagnostics.Stopwatch sw1 = new System.Diagnostics.Stopwatch();

                sw1.Start();

                //ViewBag.MyQueue = new Queue<string>(myQueue.Where((item) => item.Contains(Elemento)));
                //loop to do all the work

                sw1.Stop();

                TimeSpan ts1 = sw1.Elapsed;

                ViewBag.StopWatch1 = ts1;


                return View("Index");


            }
            else
            {
                System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();

                sw.Start();

                //ViewBag.MyQueue = new Queue<string>(myQueue.Where((item) => item.Contains(Elemento)));
                //loop to do all the work

                sw.Stop();

                TimeSpan ts = sw.Elapsed;

                ViewBag.StopWatch1 = $"Item found, Processing time " + ts;

                return View("Index");
            }
       }

        
       public ActionResult Return()
       {
           ViewBag.MyQueue = myQueue;
           return RedirectToAction("Index","Home");
       }




    }
}