using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Airports.Service.Contracts;
using Airports.Core.DTO;

namespace Airports.Controllers
{
    [ApiController]
    public class AirportsController : ControllerBase
    {
        private readonly IAirportsService _airportService;

        public AirportsController(IAirportsService airportService)
        {
            _airportService = airportService;
        }

        // GET api/airports/BWS
        [HttpGet, Route("api/airports/{iso}")]
        public ActionResult<AirportDto> Airports(string iso)
        {
            try
            {
                var result = _airportService.GetAirportsByIso(iso);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet, Route("api/airports/refresh")]
        public ActionResult<string> Refresh()
        {
            try
            {
                var result = _airportService.RefreshData();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost, Route("api/airports")]
        public ActionResult<int> UpdateAirport([FromBody] AirportDto airport)
        {
            throw new NotImplementedException();

        }
        [HttpPut, Route("api/airports")]
        public ActionResult<int> AddAirport([FromBody] AirportDto airport)
        {
            if (airport == null)
            {
                return UnprocessableEntity();
            }
            try
            {
                var result = _airportService.AddAirport(airport);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }


    }
}