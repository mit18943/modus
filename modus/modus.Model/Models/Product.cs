using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace modus.Model
{
    public class Product
    {
        [BsonId]
        public Guid Id { get; init; }
        public string Name { get; set; }
        public char? Size { get; set; }
        public Album Album { get; set; }

       
    }
}
