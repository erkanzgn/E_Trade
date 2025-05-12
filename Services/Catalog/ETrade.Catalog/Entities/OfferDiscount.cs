using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace ETrade.Catalog.Entities
{
    public class OfferDiscount
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string OfferDiscountId { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string ImgUrl { get; set; }
        public string ButonTitle { get; set; }
    }
}
