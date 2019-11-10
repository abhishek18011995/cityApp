using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CityApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CityApp.Controllers
{
    [Route("api/[controller]")]
    public class CitiesController : ControllerBase
    {
        private readonly ILogger logger;

        public CitiesController(ILogger<CitiesController> _logger)
        {
            logger = _logger;
        }

        [HttpGet]
        public IActionResult GetCities()
        {
            //var result = new JsonResult(CitiesDataStore.Current.Cities);
            //result.ContentType = "application/json";
            var result = CitiesDataStore.Current.Cities;
            return Ok(result);
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {

            try
            {

                var cities = CitiesDataStore.Current.Cities;
                //var cities = new JsonResult(CitiesDataStore.Current.Cities);
                var result = cities.FirstOrDefault(city => city.Id == id);
                if (result == null)
                {
                    logger.LogInformation($"City with ID {id} doesn't exist");
                    return NotFound();
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                logger.LogCritical($"Exception while getting City with ID {id}");
                return StatusCode(500, "A problem occured while handling your request");
            }
        }

        //// DELETE api/<controller>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
