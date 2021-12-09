using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace modus.Model
{
    public class Artist
    {
        [BsonId]
        public string Id { get; init; } // Id = Künstlername, muss manuell zugewiesen werden
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthdate { get; set; }
    }
}
