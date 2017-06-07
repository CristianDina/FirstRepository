using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using DataAccess;

namespace WebApplication2.Controllers
{
    public class BuildingsController : Controller
    {
        ApplicationDbContext dbContext = new ApplicationDbContext();

        // GET: Buildings
        public ActionResult Index(int? cityId)
        {
            var userId = this.User.Identity.GetUserId();
            var user = dbContext.Users.Find(userId);
            var city = user.Cities.FirstOrDefault();
            if (cityId != null)
            {
                city = dbContext.Cities.Find(cityId);
            }

            return View(city);
        }

        [HttpPost]
        public ActionResult Build(BuildingViewModel build, int cityId)
        {
            var building = dbContext.Buildings.Find(build.BuildingId);
            building.BuildingTypeId = build.SelectedBuildingType;
            building.Level = 1;
            dbContext.SaveChanges();
            return RedirectToAction("Index", "Buildings", new { cityId});

        }

        public ActionResult Build(int buildingId, int cityId)
        {
            return View(new BuildingViewModel
            {
                CityId = cityId, 
                BuildingId = buildingId,
                BuildingTypes = this.dbContext.BuildingTypes.Select(b => new SelectListItem
                {
                    Value = b.BuildingTypeId.ToString(),
                    Text = b.Name
                })

            });
        }

        [HttpPost]
        public ActionResult Upgrade(int buildingId, int cityId)
        {
            var building = dbContext.Buildings.Find(buildingId);
            building.Level++;
            dbContext.SaveChanges();
            return RedirectToAction("Index", "Buildings",new { cityId});
        }

        public ActionResult Details(int buildingId)
        {
            var building = dbContext.Buildings.Find(buildingId);
            return View(building);
        }

        public ActionResult Barn(int? buildingId, int? cityId) // to be used
        {
            var building = dbContext.Buildings.Find(buildingId);
            return RedirectToAction("Index", "Buildings", new { cityId });
        }

        public ActionResult Granary(int? buildingId, int? cityId) // to be used
        {
            var building = dbContext.Buildings.Find(buildingId);
            return RedirectToAction("Index", "Buildings", new { cityId });
        }

        public ActionResult Train(int cityId, int quantity, int troopTypeId)
        {
            var city = dbContext.Cities.Find(cityId);


            // danger
            var resources = city.Resources;
            var needed = (dbContext.TroopTypes.Find(troopTypeId).Attack + dbContext.TroopTypes.Find(troopTypeId).Defence) / 10;
            

            foreach(var res in resources)
            {
                if (needed > res.Value)
                {
                    
                    return View();
                    //return RedirectToAction("Index", "Buildings", new { cityId });

                }
            }
            
            foreach (var res in resources)
            {
                res.Value -= needed;
            }
            // end of danger


            if (city.Troops.Any(t => t.TroopTypeId == troopTypeId))
            {
                foreach(var troop in city.Troops)
                {
                    if (troop.TroopTypeId == troopTypeId)
                        troop.TroopCount += quantity;
                }
                
            } else
            {
                city.Troops.Add(new Troop { TroopCount = quantity, CityId = cityId, City = city, TroopTypeId = troopTypeId });
            }
            dbContext.SaveChanges();
            return RedirectToAction("Index", "Buildings", new { cityId });
        }
    }

    public class BuildingViewModel
    {
        public int CityId { get; set; }
        public int BuildingId { get; set; }
        public IEnumerable<SelectListItem> BuildingTypes { get; set; }
        public int? SelectedBuildingType { get; set; }
    }
}