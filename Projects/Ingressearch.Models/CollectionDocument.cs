using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ingressearch.Models
{

    /// <summary>
    /// CollectionDocuments represent the Bson documents stored in a given collection.
    /// </summary>
    public class CollectionDocument
    {
        /// <summary>
        /// The unique collection document id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The Id of the collection this document is part of.
        /// </summary>
        public int CollectionId { get; set; }

        /// <summary>
        /// The date this document was created.
        /// </summary>
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// The date this document was update.
        /// </summary>
        public DateTime? UpdatedDate { get; set; }

        /// <summary>
        /// The document arbitrary data.
        /// </summary>
        public JObject Data { get; set; }
    }

}
