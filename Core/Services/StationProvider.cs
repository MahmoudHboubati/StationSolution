using Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public class BaseProvider
    {
    }

    public class StationProvider : BaseProvider, IStationProvider
    {
        IStationRepository repository { get; set; }

        public StationProvider(IStationRepository repository) { this.repository = repository; }

        public IEnumerable<Domain.StationStatus> GetLiveStations(int Top)
        {
            return repository.GetStationStatus(w => w.isOnline == true)
                .OrderByDescending(o => o.EventDateTime)
                .Take(Top);
        }
    }
}
