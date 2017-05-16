using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using WebApplication2.Models;

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
    }

    public class BuildingViewModel
    {
        public int CityId { get; set; }
        public int BuildingId { get; set; }
        public IEnumerable<SelectListItem> BuildingTypes { get; set; }
        public int? SelectedBuildingType { get; set; }
    }
}