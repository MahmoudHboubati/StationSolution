using Core.Domain;
using Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace StationAPI.Controllers
{
    public class ApiBaseController : ApiController
    {

    }

    public class StationController : ApiBaseController
    {
        public IStationProvider provider;

        public StationController(IStationProvider provider)
        {
            this.provider = provider;
        }

        public IEnumerable<StationStatus> GetLiveStations(int Top = 10)
        {
            return provider.GetLiveStations(Top);
        }
    }
}
