using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class MinesService : IMinesService
    {
        private readonly IUserRepository userRepository;
        private readonly IMinesRepository minesRepository;

        public MinesService(IUserRepository userRepository, IMinesRepository minesRepository)
        {
            this.userRepository = userRepository;
            this.minesRepository = minesRepository;
        }
        

        public City UpdteResources(string userId)
        {
            var user = userRepository.GetUser(userId);
            var city = user.Cities.First();
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
            minesRepository.SaveChanges();
            return city;

        }
    }
}
