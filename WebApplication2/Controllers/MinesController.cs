using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    [Authorize]
    public class MinesController : Controller
    {
        ApplicationDbContext dbContext = new ApplicationDbContext();
        // GET: Mines
       
        public ActionResult Index()
        {
            var userId = this.User.Identity.GetUserId();
            var user = dbContext.Users.Find(userId);
            var city = user.Cities.First();
            return View(city);
        }

        public ActionResult Details(int mineId)
        {
            var mine = dbContext.Mines.Find(mineId);
            return View(mine);
        }

        [HttpPost]
        public ActionResult DetailsUpgrade(int mineId)
        {
            Upgrade(mineId);
            return RedirectToAction("Details", "Mines", new { mineId});
        }

        [HttpPost]
        public ActionResult IndexUpgrade(int mineId)
        {
            Upgrade(mineId);
            return RedirectToAction("Index", "Mines");
        }

        public void Upgrade(int mineId)
        {
            var mine = dbContext.Mines.Find(mineId);
            mine.Upgrade();
            dbContext.SaveChanges();
        }
    }
}