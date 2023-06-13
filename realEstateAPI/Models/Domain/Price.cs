namespace realEstateAPI.Models.Domain
{
    public class Price
    {
        public Guid Id { get; set; }
        public decimal Amount { get; set; }
        public string Currency { get; set; }
    }
}
