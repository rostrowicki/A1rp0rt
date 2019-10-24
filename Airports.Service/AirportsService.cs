using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using Airports.Data.DO;
using Airports.Data.Repository;
using Airports.Service.Contracts;
using Airports.Core.DTO;
using Newtonsoft.Json;

namespace Airports.Service
{
    public class AirportsService : IAirportsService
    {
        private readonly AirportsRepository airportsRepository;

        public AirportsService()
        {
            airportsRepository = new AirportsRepository();
        }

        public IEnumerable<AirportDto> GetAirportsByIso(string iso)
        {
            try
            {
                Task<IEnumerable<Airport>> airportTask = airportsRepository.GetAirportsByIso(iso);
                Task.WhenAll(airportTask);

                var airportReturnSet = new List<AirportDto>();
                foreach (var item in airportTask.Result)
                {
                    airportReturnSet.Add(item.ToDto());
                }
                return airportReturnSet;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int RefreshData()
        {
            // Load json from remote URI
            string remoteUri = "https://raw.githubusercontent.com/jbrooksuk/JSON-Airports/master/airports.json";
            List<AirportDto> items = new List<AirportDto>();
            using (WebClient wc = new WebClient())
            {
                string json = wc.DownloadString(remoteUri);
                items = JsonConvert.DeserializeObject<List<AirportDto>>(json);
            }
            // Save into DB
            if (items.Count > 0)
            {
                return airportsRepository.UpdateAirportData(items);
            }
            return items.Count;
        }

        public int UpdateAirport(AirportDto airport)
        {
            throw new NotImplementedException();
        }

        public int AddAirport(AirportDto airport)
        {
            try
            {
                var airportTask = airportsRepository.AddAirport(airport);
                Task.WhenAll(airportTask);
                return airportTask.Result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
