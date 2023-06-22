using realEstateAPI.Models.Domain;

namespace realEstateAPI.Models.DTO
{
    public class UpdatePropertyRequestDto
    {
        public string Address { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public bool IsAvailable { get; set; }
        public bool IsForSale { get; set; }
        public bool IsForRent { get; set; }
        public string? ProprtyImageUrl { get; set; }


        public Guid AgentId { get; set; }
        public Agent Agent { get; set; }

        public Guid PropertyDetailsId { get; set; }
        public PropertyDetails PropertyDetails { get; set; }

        //public Guid CityId { get; set; }
        //public City City { get; set; }

        public Guid PropertyTypeId { get; set; }
        public PropertyType PropertyType { get; set; }
        public object Location { get; internal set; }
    }
}
