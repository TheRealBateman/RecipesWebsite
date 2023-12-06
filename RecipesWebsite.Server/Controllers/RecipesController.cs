using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using RecipesWebsite.Server.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RecipesWebsite.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class RecipesController : ControllerBase
    {
        private readonly IMongoCollection<RecipesModel> _collection;
        public RecipesController(IMongoCollection<RecipesModel> collection) {
            _collection = collection;
        }
        // GET: api/<RecipesController>
        [HttpGet]
        public IEnumerable<RecipesModel> Get()
        {
            return _collection.Find<RecipesModel>(FilterDefinition<RecipesModel>.Empty).ToList();
        }

        // GET api/<RecipesController>/5
        [HttpGet("{id}")]
        public RecipesModel Get(string id)
        {
            return _collection.Find<RecipesModel>(x=>x.Id==id).FirstOrDefault();
        }

        // POST api/<RecipesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<RecipesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<RecipesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
