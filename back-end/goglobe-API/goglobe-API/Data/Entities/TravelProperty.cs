namespace goglobe_API.Data.Entities
{
    public class TravelProperty
    {
        public int Id { get; set; }
        public int TravelOfferId { get; set; }
        public TravelOffer TravelOffer { get; set; }
        public int PropertyId { get; set; }
    }
}
