using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Airports.Data.DO
{
    public class Airport: AirportDbTable
    {
        [Key, Column("Airport_Id")]        
        public int AirportId { get; set; }
        [Column("IATA")]
        public string Iata { get; set; }
        [Column("LON")]
        public double Lon { get; set; }
        [Column("LAT")]
        public double Lat { get; set; }
        [Column("ISO")]
        public string Iso { get; set; }
        public int Status { get; set; }
        public string Name { get; set; }
        public string Continent { get; set; }
        public string Type { get; set; }
        public string Size { get; set; }
    }
}

//  Example entity:
//        "iata": "VAO",
//        "lon": "158.66667",
//        "lat": "-7.566667",
//        "iso": "SB",
//        "status": 1,
//        "name": "Suavanao Airport",
//        "continent": "OC",
//        "type": "airport",
//        "size": "small"