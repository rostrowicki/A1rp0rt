using Airports.Data.DO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Airports.Service.Contracts
{
    public interface IAirportsService
    {
        IEnumerable<Airport> GetAirportsByIso(string iso);
        int UpdateAirportData();
    }
}
