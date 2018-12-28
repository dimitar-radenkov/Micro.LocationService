using System;
using System.Collections.Generic;
using System.Linq;
using LocationService.Models;

namespace LocationService.Data
{
    public class InMemoryLocationRepository : ILocationRepository
    {
        private IList<Location> locationsList;

        public InMemoryLocationRepository()
        {
            this.locationsList = new List<Location>();
        }

        public Location Add(Location location)
        {
            this.locationsList.Add(location);

            return location;
        }

        public IEnumerable<Location> AllForMember(Guid memberId)
        {
            return this.locationsList.Where(x => x.MemberID == memberId);
        }

        public Location Delete(Guid memberId, Guid recordId)
        {
            var location = this.locationsList
                .FirstOrDefault(l => l.MemberID == memberId && l.ID == recordId);

            if (location != null)
            {
                this.locationsList.Remove(location);
                return location;
            }

            return null;
        }

        public Location Get(Guid memberId, Guid recordId)
        {
            return this.locationsList
                .FirstOrDefault(l => l.MemberID == memberId && l.ID == recordId);
        }

        public Location GetLatestForMember(Guid memberId)
        {
            return this.locationsList.LastOrDefault(l => l.MemberID == memberId);
        }

        public Location Update(Location location)
        {
            var existingLocation = this.locationsList
                .FirstOrDefault(x => x.ID == location.ID && x.MemberID == location.MemberID);

            if (existingLocation == null)
            {
                return null;
            }

            var index = this.locationsList.IndexOf(existingLocation);
            this.locationsList[index] = location;

            return location;
        }
    }
}
