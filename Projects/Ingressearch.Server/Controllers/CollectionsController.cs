using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ingressearch.Models;
using Newtonsoft.Json.Linq;
using Ingressearch.Server.DataAccess.Collections;

namespace Ingressearch.Server.Controllers
{

    /// <summary>
    /// The controller for collection management.
    /// </summary>
    [ApiController]
    [Route("api/v1/collections")]
    public class CollectionsController : ControllerBase
    {

        private readonly ILogger<CollectionsController> _logger;

        private readonly CollectionsRepository _repo;

        /// <summary>
        /// DI Injected contructor.
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="collectionsRepository"></param>
        public CollectionsController(
            ILogger<CollectionsController> logger,
            CollectionsRepository collectionsRepository)
        {
            _logger = logger;
            _repo = collectionsRepository;
        }

        /// <summary>
        /// Retrieve all collections.
        /// </summary>
        /// <param name="collectionName"></param>
        /// <returns></returns>
        [HttpGet, Route("")]
        public async Task<IActionResult> RetrieveCollections()
        {
            var collections = await _repo.RetrieveCollections();
            return Ok(collections);
        }

        /// <summary>
        /// Retrieve all collections.
        /// </summary>
        /// <param name="collectionName"></param>
        /// <returns></returns>
        [HttpGet, Route("{collectionId:int}", Name = "RetrieveCollection")]
        public async Task<IActionResult> RetrieveCollection(
            [FromRoute] int collectionId)
        {
            var collection = await _repo.RetrieveCollection(collectionId);
            return Ok(collection);
        }

        /// <summary>
        /// Create a new collection.
        /// </summary>
        /// <param name="collectionName"></param>
        /// <returns></returns>
        [HttpPost, Route("")]
        public async Task<IActionResult> CreateCollection(
            [FromBody] Collection collection)
        {
            var createdCollection = await _repo.CreateCollection(collection);
            return CreatedAtRoute("RetrieveCollection", new { collectionId = createdCollection.Id }, createdCollection);
        }

        /// <summary>
        /// Update a collection
        /// </summary>
        /// <param name="collectionId"></param>
        /// <param name="collection"></param>
        /// <returns></returns>
        [HttpPut, Route("{collectionId:int}")]
        public async Task<IActionResult> UpdateCollection(
            [FromRoute] int collectionId,
            [FromBody] Collection collection)
        {
            var updatedCollection = await _repo.UpdateCollection(collectionId, collection);
            return Ok(updatedCollection);
        }

        /// <summary>
        /// Delete a collection.
        /// </summary>
        /// <param name="collectionId"></param>
        /// <returns></returns>
        [HttpDelete, Route("{collectionId:int}")]
        public async Task<IActionResult> DeleteCollection(
            [FromRoute] int collectionId)
        {
            await _repo.DeleteCollection(collectionId);
            return NoContent();
        }

    }

}
