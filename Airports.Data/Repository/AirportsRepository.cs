using System;
using System.Collections.Generic;
using System.Text;
using Airports.Data.ORM;
using Airports.Data.DO;
using Airports.Core.DTO;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq;

namespace Airports.Data.Repository
{
    public class AirportsRepository
    {
        private readonly AirportsContext context;

        public AirportsRepository()
        {
            context = new AirportsContext();
        }

        public async Task<IEnumerable<Airport>> GetAirportsByIso(string iso)
        {
            var airports = await context.Airports.Where(q => q.Iso == iso).ToListAsync();
            return airports;
        }

        public int UpdateAirportData(List<AirportDto> airports)
        {
            if (airports.Count > 0)
            {
                var airportList = ToAirportsDO(airports);

                var truncateTask = TruncateDb();
                Task.WaitAll(truncateTask);

                var addRangeTask = context.Airports.AddRangeAsync(airportList.ToList());
                Task.WaitAll(addRangeTask);

                return context.SaveChanges();
            }
            return 0;
        }

        private IEnumerable<Airport> ToAirportsDO(List<AirportDto> airports)
        {
            var list = new List<Airport>();
            foreach (var item in airports)
            {
                // TODO to be replaced with AutoMapper
                list.Add(new Airport()
                {
                    Continent = item.Continent,
                    Iata = item.Iata,
                    Iso = item.Iso,
                    Lat = item.Lat,
                    Lon = item.Lon,
                    Name = item.Name,
                    Size = item.Size,
                    Status = item.Status,
                    Type = item.Type,
                });
            }
            return list;
        }

        private async Task<int> TruncateDb()
        {
            var count = await context.Database.ExecuteSqlCommandAsync("DELETE FROM [Airports]");
            return count;
        }
    }
}
