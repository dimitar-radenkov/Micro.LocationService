using System;
using System.Threading.Tasks;
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
        public async Task<IActionResult> AddLocation(
            Guid memberId,
            [FromBody]LocationBindingModel locationBindingModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var location = await this.locationRepository.AddAsync(
                locationBindingModel.Latitude,
                locationBindingModel.Longitude,
                locationBindingModel.Altitude,
                locationBindingModel.MemberID);

            return this.Created(
                $"/locations/{memberId}/{location.ID}",
                location);
        }

        [HttpGet("{memberId}")]
        public async Task<IActionResult> GetLocationsForMember(Guid memberId)
        {
            return this.Ok(await this.locationRepository.AllForMemberAsync(memberId));
        }

        [HttpGet("latest/{memberId}")]
        public async Task<IActionResult> GetLatestForMember(Guid memberId)
        {
            return this.Ok(await this.locationRepository.GetLatestForMemberAsync(memberId));
        }
    }
}