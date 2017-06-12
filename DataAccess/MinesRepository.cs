using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class MinesRepository: IMinesRepository
    {
        private readonly ApplicationDbContext dbContext;

        public MinesRepository()
        {
            this.dbContext = new ApplicationDbContext();
        }
        public void SaveChanges()
        {
            dbContext.SaveChanges();
        }
    }
}
