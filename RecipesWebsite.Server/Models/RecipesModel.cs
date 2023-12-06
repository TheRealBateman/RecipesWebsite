using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipesWebsite.Server.Models
{
    public class RecipesModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string RecipeName { get; set; }
        public string Description { get; set; }
        public List<string> Ingredients { get; set; }
        public List<string> Directions { get; set; }
    }
}
