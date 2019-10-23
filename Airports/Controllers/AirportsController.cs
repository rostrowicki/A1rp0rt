using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Airports.Data.DO;
using Airports.Service.Contracts;

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
        public ActionResult<Airport> Airports(string iso)
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
                var result = _airportService.UpdateAirportData();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}