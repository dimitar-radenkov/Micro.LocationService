using System;

namespace LocationService.Models
{
    public class LocationBindingModel
    {
        public float Latitude { get; set; }

        public float Longitude { get; set; }

        public float Altitude { get; set; }

        public Guid MemberID { get; set; }
    }
}
