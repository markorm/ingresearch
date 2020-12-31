using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ingressearch.Models;
using Newtonsoft.Json.Linq;
using Ingressearch.Server.DataAccess.Collections;
using Ingressearch.Server.DataAccess.CollectionDataAccess;

namespace Ingressearch.Server.Controllers
{

    /// <summary>
    /// The controller for collection document management.
    /// </summary>
    [ApiController]
    [Route("api/v1/collections/{collectionId:int}/documents")]
    public class CollectionDocumentsController : ControllerBase
    {

        private readonly ILogger<CollectionDocumentsController> _logger;

        private readonly CollectionDocumentsRepository _repo;

        /// <summary>
        /// DI Injected constructor.
        /// </summary>
        /// <param name="logger"></param>
        public CollectionDocumentsController(
            ILogger<CollectionDocumentsController> logger,
            CollectionDocumentsRepository collectionDocumentsRepository)
        {
            _logger = logger;
            _repo = collectionDocumentsRepository;
        }

        /// <summary>
        /// Search collection documents.
        /// </summary>
        /// <param name="collectionId"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        [HttpGet, Route("search")]
        public async Task<IActionResult> Search(
            [FromRoute] int collectionId,
            [FromBody] JObject args)
        {
            var documents = await _repo.Search(collectionId, args);
            return Ok(documents);
        }

        /// <summary>
        /// Retrieve saved collection searches.
        /// </summary>
        /// <param name="collectionId"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        [HttpGet, Route("search/saved")]
        public async Task<IActionResult> RetrieveSavedSearches(
            [FromRoute] int collectionId,
            [FromBody] JObject args)
        {
            var searches = await _repo.RetrieveSavedSearches(collectionId);
            return Ok(searches);
        }

        /// <summary>
        /// Retrieve a single saved collection search.
        /// </summary>
        /// <param name="collectionId"></param>
        /// <param name="saveId"></param>
        /// <returns></returns>
        [HttpGet, Route("search/saved/{saveId:int}")]
        public async Task<IActionResult> RetrieveSavedSearch(
            [FromRoute] int collectionId,
            [FromRoute] int saveId)
        {
            var search = await _repo.RetrieveSavedSearch(collectionId, saveId);
            return Ok(search);
        }

        /// <summary>
        /// Save a collection search
        /// </summary>
        /// <param name="collectionId"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        [HttpPost, Route("search/saved")]
        public async Task<IActionResult> CreateSearch(
            [FromRoute] int collectionId,
            [FromBody] CollectionDocumentSearch args)
        {
            var search = await _repo.CreateSearch(collectionId, args);
            return CreatedAtAction(nameof(RetrieveSavedSearch), search);
        }

        /// <summary>
        /// Save a collection search
        /// </summary>
        /// <param name="collectionId"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        [HttpPut, Route("search/saved/{saveId:int}")]
        public async Task<IActionResult> UpdateCollectionSearch(
            [FromRoute] int collectionId,
            [FromRoute] int saveId,
            [FromBody] CollectionDocumentSearch args)
        {
            var search = await _repo.UpdateSearch(collectionId, saveId, args);
            return Ok(search);
        }

        /// <summary>
        /// Delete a collection search
        /// </summary>
        /// <param name="collectionId"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        [HttpDelete, Route("search/saved/{saveId:int}")]
        public async Task<IActionResult> DeleteCollectionSearch(
            [FromRoute] int collectionId,
            [FromRoute] int saveId)
        {
            await _repo.DeleteSearch(collectionId, saveId);
            return NoContent();
        }

        /// <summary>
        /// Add a document to a collection.
        /// </summary>
        /// <param name="collectionId"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPost, Route("{documentId:int}", Name = "RetrieveCollectionDocument")]
        public async Task<IActionResult> RetrieveCollectionDocument(
            [FromRoute] int collectionId,
            [FromRoute] int documentId)
        {
            var document = await _repo.RetrieveCollectionDocument(collectionId, documentId);
            return Ok(document);
        }

        /// <summary>
        /// Add a document to a collection.
        /// </summary>
        /// <param name="collectionId"></param>
        /// <param name="collectionDocument"></param>
        /// <returns></returns>
        [HttpPost, Route("")]
        public async Task<IActionResult> CreateCollectionDocument(
            [FromRoute] int collectionId,
            [FromBody] CollectionDocument collectionDocument)
        {
            var createdCollectionDocument = await _repo.CreateCollectionDocument(collectionId, collectionDocument);
            return CreatedAtRoute(
                "RetrieveCollectionDocument",
                new { collectionId = createdCollectionDocument.CollectionId, documentId = createdCollectionDocument.Id },
                createdCollectionDocument);
        }

        /// <summary>
        /// Update a document in a collection.
        /// </summary>
        /// <param name="collectionId"></param>
        /// <param name="documentId"></param>
        /// <param name="collectionDocument"></param>
        /// <returns></returns>
        [HttpPost, Route("{documentId:int}")]
        public async Task<IActionResult> UpdateCollectionDocument(
            [FromRoute] int collectionId,
            [FromRoute] int documentId,
            [FromBody] CollectionDocument collectionDocument)
        {
            var createdCollectionDocument = await _repo.UpdateCollectionDocument(collectionId, documentId, collectionDocument);
            return Ok(createdCollectionDocument);
        }

        /// <summary>
        /// Delete a document from a collection.
        /// </summary>
        /// <param name="collectionId"></param>
        /// <param name="documentId"></param>
        /// <returns></returns>
        [HttpDelete, Route("{documentId:int}")]
        public async Task<IActionResult> DeleteCollectionDocument(
            [FromRoute] int collectionId,
            [FromRoute] int documentId)
        {
            await _repo.DeleteCollectionDocument(collectionId, documentId);
            return NoContent();
        }

    }

}
