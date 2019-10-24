using System;
using System.Collections.Generic;
using System.Text;
using Airports.Core.DTO;

namespace Airports.Core.DTO
{
    public class AirportDto
    {
        public int AirportId { get; set; }
        public string Iata { get; set; }
        public double Lon { get; set; }
        public double Lat { get; set; }
        public string Iso { get; set; }
        public int Status { get; set; }
        public string Name { get; set; }
        public string Continent { get; set; }
        public string Type { get; set; }
        public string Size { get; set; }
    }
}
