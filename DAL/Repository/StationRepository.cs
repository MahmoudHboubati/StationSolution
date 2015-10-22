using Core.Domain;
using Core.Repositories;
using Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class StationRepository : IStationRepository
    {
        StationEFEbContext context = new StationEFEbContext();

        public IList<StationStatus> GetStationStatus(Expression<Func<StationStatus, bool>> condition)
        {
            return context.StationsStatuses.Where(condition).ToList();
        }
    }
}
