using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LocationService.Models;

namespace LocationService.Data
{
    public interface ILocationRepository
    {
        Task<Location> AddAsync(Location location);
        Location Update(Location location);
        Location Get(Guid memberId, Guid recordId);
        Location Delete(Guid memberId, Guid recordId);
        Location GetLatestForMember(Guid memberId);
        IEnumerable<Location> AllForMember(Guid memberId);
    }
}
