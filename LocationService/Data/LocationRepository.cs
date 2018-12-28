using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LocationService.Models;

namespace LocationService.Data
{
    public class LocationRepository : ILocationRepository
    {
        private readonly LocationServiceDbContext db;

        public LocationRepository(LocationServiceDbContext db)
        {
            this.db = db;
        }

        public async Task<Location> AddAsync(Location location)
        {
            await this.db.Locations.AddAsync(location);

            return location;
        }

        public IEnumerable<Location> AllForMember(Guid memberId)
        {
            throw new NotImplementedException();
        }

        public Location Delete(Guid memberId, Guid recordId)
        {
            throw new NotImplementedException();
        }

        public Location Get(Guid memberId, Guid recordId)
        {
            throw new NotImplementedException();
        }

        public Location GetLatestForMember(Guid memberId)
        {
            throw new NotImplementedException();
        }

        public Location Update(Location location)
        {
            throw new NotImplementedException();
        }
    }
}
