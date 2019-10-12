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
            myQueue.Enqueue("New Entry " + (myQueue.Count+ 1));

            ViewBag.MyQueue = myQueue;

            return View("Index");
        }

        public ActionResult AddHugeList()
        {

            myQueue.Clear();
           
            while (myQueue.Count < 2000)
                

            {
                myQueue.Enqueue("New Entry " + (myQueue.Count + 1));
                
            }

            ViewBag.MyQueue = myQueue;


            return View("Index");
        }

        public ActionResult Display()
        {

            foreach(string element in myQueue)
            {
                ViewBag.mystuff = element;

            }

           


            return View("Index");


        }




        public ActionResult DeleteFrom()
        {
            
            return View("Index");
        }





        public ActionResult Clear()
        {

            myQueue.Clear();
            ViewBag.MyQueue = myQueue;
            return View("Index");
        }



        public ActionResult Search()
        {


            return View("Index");
        }



        public ActionResult Return()
        {
            ViewBag.MyQueue = myQueue;
            return RedirectToAction("Index","Home");
        }





    }
}