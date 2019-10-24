using Airports.Core.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Airports.Service.Contracts
{
    public interface IAirportsService
    {
        IEnumerable<AirportDto> GetAirportsByIso(string iso);
        int RefreshData();
        int UpdateAirport(AirportDto airport);
        int AddAirport(AirportDto airport);
    }
}
