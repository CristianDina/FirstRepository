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
    public class CitiesController : Controller
    {
        ApplicationDbContext dbContext = new ApplicationDbContext();
        // GET: Mines
       
        public ActionResult Index()
        {
            var userId = this.User.Identity.GetUserId();
            var user = dbContext.Users.Find(userId);
            return View(user);
        }

        [HttpPost]
        public ActionResult AddCity()
        {
            var userId = this.User.Identity.GetUserId();
            var user = dbContext.Users.Find(userId);

            user.Cities.Add(new City
            {
                Mines = new List<Mine>
                {
                               new Mine
                               {
                                   Level = 0,
                                   Type = ResourceType.Clay,
                               },
                               new Mine
                               {
                                   Level = 0,
                                   Type = ResourceType.Clay,
                               },
                               new Mine
                               {
                                   Level = 0,
                                   Type = ResourceType.Clay,
                               },
                               new Mine
                               {
                                   Level = 0,
                                   Type = ResourceType.Iron,
                               },
                               new Mine
                               {
                                   Level = 0,
                                   Type = ResourceType.Iron,
                               },
                               new Mine
                               {
                                   Level = 0,
                                   Type = ResourceType.Wheat,
                               },
                               new Mine
                               {
                                   Level = 0,
                                   Type = ResourceType.Wheat,
                               },
                               new Mine
                               {
                                   Level = 0,
                                   Type = ResourceType.Wheat,
                               },
                               new Mine
                               {
                                   Level = 0,
                                   Type = ResourceType.Wheat,
                               },
                               new Mine
                               {
                                   Level = 0,
                                   Type = ResourceType.Wheat,
                               },
                               new Mine
                               {
                                   Level = 0,
                                   Type = ResourceType.Wheat,
                               },
                               new Mine
                               {
                                   Level = 0,
                                   Type = ResourceType.Wood,
                               },
                               new Mine
                               {
                                   Level = 0,
                                   Type = ResourceType.Wood,
                               },
                               new Mine
                               {
                                   Level = 0,
                                   Type = ResourceType.Wood,
                               },
                },
                Resources = new List<Resource>
                {
                    new Resource
                    {
                        Type = ResourceType.Clay,
                        LastUpdate = DateTime.Now,
                    },
                    new Resource
                    {
                        Type = ResourceType.Iron,
                        LastUpdate = DateTime.Now,
                    },
                    new Resource
                    {
                        Type = ResourceType.Wheat,
                        LastUpdate = DateTime.Now,
                    },
                    new Resource
                    {
                        Type = ResourceType.Wood,
                        LastUpdate = DateTime.Now,
                    },
                }
            });
            dbContext.SaveChanges();
            return RedirectToAction("Index", "Cities");
        }
    }
}