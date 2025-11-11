namespace VizinhoDAgua.Domain.Entities
{
    public class Location : Entity
    { 
        public string? City { get; private set; }
        public string? Road { get; private set; }
        public string? PostalCode { get; private set; }
        public string? Neighborhood { get; private set; }
        public string? State { get; private set; }        
        public string? Coords { get; private set; }
        
        public Location() { } // EF Core

        public Location(string? city, string? road, string? postalCode, string? neighborhood, 
            string? state, string? coords)
        {
            City = city;
            Road = road;
            PostalCode = postalCode;
            Neighborhood = neighborhood;
            State = state;
            Coords = coords;
        }
    }
}
