using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class City
    {
        public int CityId { get; set; }
        public virtual IList<Mine> Mines { get; set; }
        public virtual IList<Resource> Resources { get; set; }
        public virtual IList<Building> Buildings { get; set; }

        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }

    public class Resource
    {

        public int ResourceId { get; set; }

        public int CityId { get; set; }
        public virtual City City { get; set; }

        public DateTime LastUpdate { get; set; }
        public ResourceType Type { get; set; }

        public double Value { get; set; }
    }

    public class Mine
    {
        public int MineId { get; set; }

        public int CityId { get; set; }
        public virtual City City { get; set; }

        public int Level { get; set; }

        public string MineStyle { get; set; }

        public DateTime UpgradeCompletion { get; set; } = DateTime.Now;

        public string Description { get; set; }

        public bool isUpgrading { get { return this.UpgradeCompletion > DateTime.Now; } }

        internal void Upgrade()
        {
            Level++;
        }

        public double GetProductionPerHour(int? level = null)
        {
            return (level ?? this.Level) * 13;
        }

        internal (int amount, ResourceType type)[] GetUpgradeRequirements()
        {
            return new[]
            {
                (10*(this.Level+1), ResourceType.Clay),
                (10*(this.Level+1), ResourceType.Wood),
                (10*(this.Level+1), ResourceType.Iron),
                (10*(this.Level+1), ResourceType.Wheat),
            };
        }

        public ResourceType Type { get; set; }
    }

    public class Building
    {
        public int BuildingId { get; set; }
        public int Level { get; set; }
        public int? BuildingTypeId { get; set; }
        public virtual BuildingType BuildingType { get; set; }
        public int CityId { get; set; }
        public virtual City City { get; set; }
    }

    public class BuildingType
    {
        public int BuildingTypeId { get; set; }
        public string Action { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public enum ResourceType
    {
        Wheat,
        Iron,
        Clay,
        Wood
    }


}