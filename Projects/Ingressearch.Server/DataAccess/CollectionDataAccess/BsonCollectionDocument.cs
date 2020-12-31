using Ingressearch.Models;
using LiteDB;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ingressearch.Server.DataAccess.Collections
{

    /// <summary>
    /// The BSON storable version of a CollectionDocument.
    /// </summary>
    public class BsonCollectionDocument: CollectionDocument
    {

        /// <summary>
        /// Parameterless constructor.
        /// </summary>
        public BsonCollectionDocument() { }

        /// <summary>
        /// Create an instance from a CollectionDocument.
        /// </summary>
        /// <param name="collectionDocument"></param>
        public BsonCollectionDocument(CollectionDocument collectionDocument)
        {
            Id = collectionDocument.Id;
            CollectionId = collectionDocument.Id;
            CreatedDate = collectionDocument.CreatedDate;
            UpdatedDate = collectionDocument.UpdatedDate;

            // We need to turn the JObject into json before it can be re-serialized as the BsonValue type.
            var dataJson = JsonConvert.SerializeObject(collectionDocument.Data);
            Data = LiteDB.JsonSerializer.Deserialize(dataJson);
        }

        /// <summary>
        /// The BSON serializable document data.
        /// </summary>
        public new BsonValue Data { get; set; }

        /// <summary>
        /// Create a collection document from this BsonCollectionDocument.
        /// </summary>
        /// <remarks>
        /// This returns a new instance, not simply a casted type.
        /// </remarks>
        /// <returns></returns>
        public CollectionDocument ToCollectionDocument()
        {
            return new()
            {
                Id = Id,
                CollectionId = CollectionId,
                CreatedDate = CreatedDate,
                UpdatedDate = UpdatedDate,
                Data = JsonConvert.DeserializeObject<JObject>(Data.AsString)
            };
        }

    }

}
