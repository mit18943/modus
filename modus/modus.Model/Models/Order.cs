using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace modus.Model.Models
{
    public class Order
    {
        [BsonId]
        public Guid Id { get; set; }
        public User User { get; set; }
        public Product Product { get; set; }

        
    }
}
