using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAccess;
using SimpleInjector;
using SimpleInjector.Lifestyles;
using BusinessLogic;

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
                        MineStyle = "mine-clay-1",
                        Description = "Clay is produced here. By increasing its level, you increase the clay production.",
                    },
                    new Mine
                    {
                        Level = 0,
                        Type = ResourceType.Clay,
                        MineStyle = "mine-clay-2",
                        Description = "Clay is produced here. By increasing its level, you increase the clay production.",
                    },
                    new Mine
                    {
                        Level = 0,
                        Type = ResourceType.Clay,
                        MineStyle = "mine-clay-3",
                        Description = "Clay is produced here. By increasing its level, you increase the clay production.",
                    },
                    new Mine
                    {
                        Level = 0,
                        Type = ResourceType.Iron,
                        MineStyle = "mine-iron-1",
                        Description = "Here miners produce the precious resource of iron. By increasing the mine`s level, you increase the iron production.",
                    },
                    new Mine
                    {
                        Level = 0,
                        Type = ResourceType.Iron,
                        MineStyle = "mine-iron-2",
                        Description = "Here miners produce the precious resource of iron. By increasing the mine`s level, you increase the iron production.",
                    },
                    new Mine
                    {
                        Level = 0,
                        Type = ResourceType.Wheat,
                        MineStyle = "mine-wheat-1",
                        Description = "Your population`s food is produced here. By increasing the farm`s level, you increase its crop production.",
                    },
                    new Mine
                    {
                        Level = 0,
                        Type = ResourceType.Wheat,
                        MineStyle = "mine-wheat-2",
                        Description = "Your population`s food is produced here. By increasing the farm`s level, you increase its crop production.",
                    },
                    new Mine
                    {
                        Level = 0,
                        Type = ResourceType.Wheat,
                        MineStyle = "mine-wheat-3",
                        Description = "Your population`s food is produced here. By increasing the farm`s level, you increase its crop production.",
                    },
                    new Mine
                    {
                        Level = 0,
                        Type = ResourceType.Wheat,
                        MineStyle = "mine-wheat-4",
                        Description = "Your population`s food is produced here. By increasing the farm`s level, you increase its crop production.",
                    },
                    new Mine
                    {
                        Level = 0,
                        Type = ResourceType.Wheat,
                        MineStyle = "mine-wheat-5",
                        Description = "Your population`s food is produced here. By increasing the farm`s level, you increase its crop production.",
                    },
                    new Mine
                    {
                        Level = 0,
                        Type = ResourceType.Wheat,
                        MineStyle = "mine-wheat-6",
                        Description = "Your population`s food is produced here. By increasing the farm`s level, you increase its crop production.",
                    },
                    new Mine
                    {
                        Level = 0,
                        Type = ResourceType.Wood,
                        MineStyle = "mine-wood-1",
                        Description = "The woodcutter cuts down trees in order to produce lumber. The further you extend the woodcutter, the more lumber is produced.",
                    },
                    new Mine
                    {
                        Level = 0,
                        Type = ResourceType.Wood,
                        MineStyle = "mine-wood-2",
                        Description = "The woodcutter cuts down trees in order to produce lumber. The further you extend the woodcutter, the more lumber is produced.",
                    },
                    new Mine
                    {
                        Level = 0,
                        Type = ResourceType.Wood,
                        MineStyle = "mine-wood-3",
                        Description = "The woodcutter cuts down trees in order to produce lumber. The further you extend the woodcutter, the more lumber is produced.",
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
                },
                Buildings = new List<Building>
                {
                    new Building
                    {
                        Level = 0,
                        BuildingTypeId = null,
                    },
                    new Building
                    {
                        Level = 0,
                        BuildingTypeId = null,
                    },
                    new Building
                    {
                        Level = 0,
                        BuildingTypeId = null,
                    },
                    new Building
                    {
                        Level = 0,
                        BuildingTypeId = null,
                    },
                        new Building
                    {
                        Level = 0,
                        BuildingTypeId = null,
                    },
                    new Building
                    {
                        Level = 0,
                        BuildingTypeId = null,
                    },
                    new Building
                    {
                        Level = 0,
                        BuildingTypeId = null,
                    },
                    new Building
                    {
                        Level = 0,
                        BuildingTypeId = null,
                    },
                        new Building
                    {
                        Level = 0,
                        BuildingTypeId = null,
                    },
                    new Building
                    {
                        Level = 0,
                        BuildingTypeId = null,
                    },
                    new Building
                    {
                        Level = 0,
                        BuildingTypeId = null,
                    },
                    new Building
                    {
                        Level = 0,
                        BuildingTypeId = null,
                    },
                    new Building
                    {
                        Level = 0,
                        BuildingTypeId = null,
                    },
                }
            });
            dbContext.SaveChanges();
            return RedirectToAction("Index", "Cities");
        }
    }
}