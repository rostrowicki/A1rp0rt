using Airports.Core.DTO;

namespace Airports.Data.DO
{
    public static class DtoMapper {
                public static AirportDto ToDto(this Airport airport)
        {
            return new AirportDto()
            {
                AirportId = airport.AirportId,
                Iata = airport.Iata,
                Lon = airport.Lon,
                Lat = airport.Lat,
                Iso = airport.Iso,
                Status = airport.Status,
                Name = airport.Name,
                Continent = airport.Continent,
                Type = airport.Type,
                Size = airport.Size,
            };
        }
    }
}