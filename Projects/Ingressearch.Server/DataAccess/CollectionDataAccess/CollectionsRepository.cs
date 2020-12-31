using Ingressearch.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ingressearch.Server.DataAccess.Collections
{

    /// <summary>
    /// The repository class for collections.
    /// </summary>
    public class CollectionsRepository
    {

        public async Task<Collection> RetrieveCollection(int collectionId)
        {
            throw new NotImplementedException();
        } 

        public async Task<IEnumerable<Collection>> RetrieveCollections()
        {
            throw new NotImplementedException();
        }

        public async Task<Collection> CreateCollection(Collection collection)
        {
            throw new NotImplementedException();
        }

        public async Task<Collection> UpdateCollection(int collectionId, Collection collection)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteCollection(int collectionId)
        {
            throw new NotImplementedException();
        }

    }

}
