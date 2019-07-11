using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using RandomPasscode.Models;


namespace RandomPasscode.Controllers

{
    public class HomeController : Controller
    {
        [HttpGet("")]
        public IActionResult Index()
        {
            if (HttpContext.Session.GetInt32("Count") == null)
            {
                HttpContext.Session.SetInt32("Count", 1);
            }
            else
            {
                int? Count = HttpContext.Session.GetInt32("Count");
                Count++;
                HttpContext.Session.SetInt32("Count", (int)Count);
            }
            Random rand = new Random();
            string[] Char = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
            List<string> RandList = new List<string>();
            string NewPasscode = "";
            for (var i = 0; i <= 14; i++)
            {
                int idx = rand.Next(Char.Length);
                //Adds a random character at its index to the Random List
                NewPasscode += Char[idx];
            }
               //Converts randomPasscode in to a string 
            ViewBag.RandomPasscode = NewPasscode;

            ViewBag.Count = HttpContext.Session.GetInt32("Count");
            return View();
        }
    }
}