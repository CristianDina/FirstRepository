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
        public ActionResult Index(int? cityId)
        {
            var userId = this.User.Identity.GetUserId();
            var user = dbContext.Users.Find(userId);
            var city = user.Cities.First();
            if (cityId != null)
            {
                city = dbContext.Cities.Find(cityId);
            }

            this.UpdteResources(city);
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
            return RedirectToAction("Details", "Mines", new { mineId });
        }

        [HttpPost]
        public ActionResult IndexUpgrade(int mineId, int cityId)
        {
            Upgrade(mineId);
            return RedirectToAction("Index", "Mines", new { cityId });
        }

        public void Upgrade(int mineId)
        {
            var mine = dbContext.Mines.Find(mineId);
            mine.Upgrade();
            dbContext.SaveChanges();
        }

        [HttpPost]
        public ActionResult NewUpgrade(int mineId, Boolean fastUpgrade)
        {
            var mine = dbContext.Mines.Find(mineId);
            var city = mine.City;
            var needed = mine.GetUpgradeRequirements();
            var have = city.Resources;
            if (fastUpgrade)
            {
                needed = needed.Select(n=>(amount: n.amount * 10, type: n.type)).ToArray();
            }

            var amounts = needed.Select(n => n.amount);

            var r = needed.Join(have, n => n.type, h => h.Type,(n, h) => (needed: n, have: h));
            if (!r.All(_ => _.needed.amount < _.have.Value))
            {
                return View(new MessageViewModel { Message = $"Not Enough Resources" });
            }

            mine.Level++;
            mine.UpgradeCompletion = DateTime.Now.AddHours(0.5 * mine.Level);
            dbContext.SaveChanges();

            foreach(var item in r)
            {
                item.have.Value -= item.needed.amount;
            }

            return View(new MessageViewModel { Message = $"Mine.Id = {mineId} {fastUpgrade}" });
        }

        private void UpdteResources(City city)
        {
            var start = DateTime.Now;
            foreach (var res in city.Resources)
            {
                foreach (var mine in city.Mines)
                {
                    if (mine.Type == res.Type)
                    {
                        res.Value += mine.GetProductionPerHour() * (start - res.LastUpdate).TotalHours;
                    }
                }
                res.LastUpdate = start;
            }
            dbContext.SaveChanges();

        }
    }
}