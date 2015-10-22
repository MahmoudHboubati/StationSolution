using Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repositories
{
    public interface IStationRepository
    {
        IList<StationStatus> GetStationStatus(Expression<Func<StationStatus, bool>> condition);
    }
}
