using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CustomerRegister.Core.Entities
{

    public abstract class BaseEntity
    {
        protected BaseEntity()
        {

        }

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; private set; }
    }
}
