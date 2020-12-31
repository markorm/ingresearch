using System;

namespace Ingressearch.Models
{

    /// <summary>
    /// Collections are containers that group documents together.
    /// </summary>
    public class Collection
    {
        /// <summary>
        /// The Id of the collection.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The name of the collection.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The date this collection was created.
        /// </summary>
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// The date this collection was update.
        /// </summary>
        public DateTime? UpdatedDate { get; set; }
    }

}
