using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierManagementSystem.model
{
    public class Location
    {
        public int LocationId { get; set; }
        public string? LocationName { get; set; }
        public string? LocationAddress { get; set; }

        public Location(int locationId, string? locationName, string? locationAddress)
        {
            LocationId = locationId;
            LocationName = locationName;
            LocationAddress = locationAddress;
        }

        public override string ToString()
        {
            return $"Location ID: {LocationId}, " +
                   $"Name: {LocationName}, " +
                   $"Address: {LocationAddress}";
        }


    }


}
