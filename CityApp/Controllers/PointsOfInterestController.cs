using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CityApp.Models;
using CityApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CityApp.Controllers
{
    [Route("api/cities")]
    public class PointsOfInterestController : ControllerBase
    {
        private readonly ILogger logger;
        private ILocalMailService localMailService;

        public PointsOfInterestController(ILocalMailService _localMailService, ILogger<PointsOfInterestController> _logger)
        {
            logger = _logger;
            localMailService = _localMailService;
        }

        [HttpGet("{cityID}/pointsofinterest")]
        public IActionResult GetPointsOfInterests(int cityID)
        {

            var city = CitiesDataStore.Current.Cities.FirstOrDefault(_city => _city.Id == cityID);
            if (city == null || city.PointsOfInterests == null)
            {
                return NotFound();
            }
            return Ok(city.PointsOfInterests);
        }

        [HttpGet("{cityID}/pointsofinterest/{pid}", Name = "GetPointsOfInterests")]
        public IActionResult GetPointsOfInterest(int cityID, int pid)
        {
            var city = CitiesDataStore.Current.Cities.FirstOrDefault(_city => _city.Id == cityID);
            if (city == null)
            {
                return NotFound();
            }
            if (city.PointsOfInterests != null)
            {
                var pointOfInterest = city.PointsOfInterests.FirstOrDefault(poi => poi.PId == pid);
                if (pointOfInterest == null)
                {
                    return NotFound();
                }
                return Ok(pointOfInterest);
            }
            else
            {
                return NotFound();
            }
        }


        // POST PointsOfInterest
        [HttpPost("{cityId}/pointsofinterest")]
        public IActionResult CreatePointOfInterest(int cityId, [FromBody]PointOfInterestForCreationDto pointOfInterest)
        {
            if(pointOfInterest == null)
            {
                return BadRequest();
            }

            if (pointOfInterest.Name == pointOfInterest.Description) {
                ModelState.AddModelError("Description", "Name and Description should not be same");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var city = CitiesDataStore.Current.Cities.FirstOrDefault(_city => _city.Id == cityId);
            if (city == null)
            {
                return NotFound();
            }

            var MaxPoiId = CitiesDataStore.Current.Cities.SelectMany(_city => _city.PointsOfInterests).Max(poi => poi.PId);
            PointsOfInterestsDto newPoi = new PointsOfInterestsDto()
            {
                PId = ++MaxPoiId,
                Name = pointOfInterest.Name,
                Description = pointOfInterest.Description
            };

            city.PointsOfInterests.Add(newPoi);

            return CreatedAtRoute("GetPointsOfInterests", new { cityID = cityId, pid = newPoi.PId }, newPoi);
        }


        // PUT PointOfInterest
        [HttpPut("{cityID}/pointsofinterest/{pid}")]
        public IActionResult UpdatePointOfInterest(int cityId, int pid, [FromBody]PointOfInterestForUpdationDto pointOfInterest)
        {
            if(pointOfInterest == null)
            {
                return BadRequest();
            }
            
            if (pointOfInterest.Name == pointOfInterest.Description)
            {
                ModelState.AddModelError("Description", "Name and Description should not be same");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var city = CitiesDataStore.Current.Cities.FirstOrDefault(_city => _city.Id == cityId);
            if (city == null)
            {
                return NotFound();
            }

            var _poi = city.PointsOfInterests.FirstOrDefault(_p => _p.PId == pid);
            if (_poi == null)
            {
                return NotFound();
            }

            _poi.Name = pointOfInterest.Name;
            _poi.Description = pointOfInterest.Description;

            //return CreatedAtRoute("GetPointsOfInterests", new { cityID = cityId, pid }, _poi);
            return NoContent();

        }

        [HttpDelete("{cityID}/pointsofinterest/{pid}")]
        public IActionResult DeletePointOfInterest(int cityID, int pid)
        {
            var city = CitiesDataStore.Current.Cities.FirstOrDefault(_city => _city.Id == cityID);
            if (city == null)
            {
                logger.LogInformation($"City with ID {cityID} doesn't exist");
                return NotFound();
            }

            var _poi = city.PointsOfInterests.FirstOrDefault(_p => _p.PId == pid);
            if (_poi == null)
            {
                logger.LogInformation($"Pointsofinterest with ID {pid} doesn't exist");
                return NotFound();
            }

            city.PointsOfInterests.Remove(_poi);
            localMailService.Send("Mobile", "Get me oneplus");
            return Ok("Successfully deleted");

        }
    }
}
