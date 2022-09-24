namespace goglobe_API.Data.Entities
{
    public class TravelPhoto
    {
        public int Id { get; set; }
        public int TravelOfferId { get; set; }
        public TravelOffer TravelOffer { get; set; }
        public int PhotoId { get; set; }
        public Photo Photo { get; set; }
    }
}
