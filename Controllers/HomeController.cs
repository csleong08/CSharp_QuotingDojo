using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
// using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuotingDojo.Models;
using DbConnection;

namespace QuotingDojo.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet("")]
        public IActionResult Index()
        {
            return View("Index");
        }

        [HttpPost("AddQuote")]
        public IActionResult AddQuote(Quotes author)
        {
            if(ModelState.IsValid)
            {
                // string Now = DateTime.Now.ToString("h:mm tt MMMM dd yyyy");
                // string Now = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
                DateTime now = DateTime.Now;
                string Now = now.ToString("yyyy-MM-dd HH:mm:ss.fff");
                string query = $"INSERT INTO quotes (name, message, created_at, updated_at) VALUES ('{author.name}', '{author.quote}', '{Now}', '{Now}')";
                DbConnector.Execute(query);
                return RedirectToAction("Quotes");
            }else{
                return View("Index");
            }
        }
        
        [HttpGet("Quotes")]
        public IActionResult Quotes()
        {
            // string query = "SELECT * FROM quotes ORDER BY id DESC";
            // var allQuotes = DbConnector.Query(query);
            List<Dictionary<string, object>> allQuotes = DbConnector.Query("SELECT * FROM quotes ORDER BY id DESC");
            ViewBag.allQuotes = allQuotes;
            return View("Quotes");
        }
    }
}
