using System;
using LocationService.Data;
using LocationService.Models;
using Microsoft.AspNetCore.Mvc;

namespace LocationService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationsController : Controller
    {
        private readonly ILocationRepository locationRepository;
        public LocationsController(ILocationRepository repository)
        {
            this.locationRepository = repository;
        }

        [HttpPost]
        public IActionResult AddLocation(Guid memberId, [FromBody]Location locationRecord)
        {
            this.locationRepository.Add(locationRecord);

            return this.Created(
                $"/locations/{memberId}/{locationRecord.ID}",
                locationRecord);
        }

        [HttpGet("{memberId}")]
        public IActionResult GetLocationsForMember(Guid memberId)
        {
            return this.Ok(this.locationRepository.AllForMember(memberId));
        }

        [HttpGet("latest/{memberId}")]
        public IActionResult GetLatestForMember(Guid memberId)
        {
            return this.Ok(this.locationRepository.GetLatestForMember(memberId));
        }
    }
}