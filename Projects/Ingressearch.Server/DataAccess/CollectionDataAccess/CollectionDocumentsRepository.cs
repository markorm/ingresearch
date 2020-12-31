using Ingressearch.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ingressearch.Server.DataAccess.CollectionDataAccess
{

    public class CollectionDocumentsRepository
    {

        public async Task<IEnumerable<CollectionDocument>> Search(int collectionId, JObject args)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<CollectionDocumentSearch>> RetrieveSavedSearches(int collectionId)
        {
            throw new NotImplementedException();
        }

        public async Task<CollectionDocumentSearch> RetrieveSavedSearch(int collectionId, int saveId)
        {
            throw new NotImplementedException();
        }

        public async Task<CollectionDocumentSearch> CreateSearch(int collectionId, CollectionDocumentSearch args)
        {
            throw new NotImplementedException();
        }

        public async Task<CollectionDocumentSearch> UpdateSearch(int collectionId, int saveId, CollectionDocumentSearch args)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteSearch(int collectionId, int saveId)
        {
            throw new NotImplementedException();
        }

        public async Task<CollectionDocument> RetrieveCollectionDocument(int collectionId, int collectionDocumentId)
        {
            throw new NotImplementedException();
        }

        public async Task<CollectionDocument> CreateCollectionDocument(int collectionId, CollectionDocument collectionDocument)
        {
            throw new NotImplementedException();
        }

        public async Task<CollectionDocument> UpdateCollectionDocument(int collectionId, int documentId, CollectionDocument collectionDocument)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteCollectionDocument(int collectionId, int documentId)
        {
            throw new NotImplementedException();
        }

    }

}
