using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace modus.Model
{
    public class Product
    {
        [BsonId]
        public string Id { get { return Name + "-" + AlbumTitle; } set { } } // Wird generiert auf Name und Titel
        public string Name { get; set; }
        public char? Size { get; set; }
        public string AlbumTitle { get; set; }
        public DateTime? Date { get; set; }
        public string Genre { get; set; }
        public string ArtistId { get; set; }
    }
}
