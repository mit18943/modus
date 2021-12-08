using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace modus.Model
{
    public class Album
    {
        [BsonId]
        public Guid Id { get; init; }
        public string Name { get; set; } = string.Empty;
        public DateTime? Date { get; set; } = null;
        public string Genre { get; set; } = string.Empty;
        public Artist Artist { get; set; }
    }
}
