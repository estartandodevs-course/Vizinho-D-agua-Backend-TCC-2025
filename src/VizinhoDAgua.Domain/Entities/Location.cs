using NetTopologySuite.Geometries;

namespace VizinhoDAgua.Domain.Entities
{
    public class Location : Entity
    {
        public string City { get; private set; } = string.Empty;
        public string StateCode { get; private set; } = string.Empty;
        public string? PostalCode { get; private set; }
        public string? Road { get; private set; }
        public string? Neighborhood { get; private set; }
        public Geometry? Geometry { get; private set; }
        
        public Location() { } // EF Core

        public Location(string city, string stateCode, string? road, string? postalCode, string? neighborhood, Geometry geometry)
        {
            City = city;
            Road = road;
            PostalCode = postalCode;
            Neighborhood = neighborhood;

            if (stateCode.Length != 2)
                throw new ArgumentException("Must have a valid state code");

            StateCode = stateCode;
            Geometry = geometry;
        }
    }
}
