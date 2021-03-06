﻿using Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public interface IStationProvider
    {

        IEnumerable<StationStatus> GetLiveStations(int Top);
    }
}
