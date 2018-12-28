using System;
using System.Collections.Generic;
using LocationService.Models;

namespace LocationService.Data
{
    public interface ILocationRepository
    {
        Location Add(Location locationRecord);
        Location Update(Location locationRecord);
        Location Get(Guid memberId, Guid recordId);
        Location Delete(Guid memberId, Guid recordId);
        Location GetLatestForMember(Guid memberId);
        IEnumerable<Location> AllForMember(Guid memberId);
    }
}
