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
        private IUserRepository userRepository;
        private IMinesRepository minesRepository;
        public MinesService()
        {
            userRepository = new UserRepository();
            minesRepository = new MinesRepository();
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
