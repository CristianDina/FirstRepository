using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class CityFilterViewController : Controller
    {
        ApplicationDbContext dbContext = new ApplicationDbContext();
        // GET: CityFilterView
        public ActionResult Index(CityFilterViewModel filterView)
        {
            IQueryable<City> query = dbContext.Cities;
            if (filterView.Name != null)
            {
                query = query.Where(u => u.ApplicationUser.UserName.Contains(filterView.Name));
                filterView.Results = query.ToList();
            }
            if (filterView.Email != null)
            {
                query = query.Where(u => u.ApplicationUser.Email.Contains(filterView.Email));
                filterView.Results = query.ToList();
            }
            if (filterView.MinTroupCount != null)
            {
                query = query.Where(u => u.Troops.Sum(s => s.TroopCount)>filterView.MinTroupCount);
                filterView.Results = query.ToList();
            }
            if (filterView.MaxTroupCount != null)
            {
                query = query.Where(u => u.Troops.Sum(s => s.TroopCount) < filterView.MaxTroupCount);
                filterView.Results = query.ToList();
            }

            return View(filterView);
        }
    }
}