using modus.Model.Models;
using System;

namespace modus.Model
{
    class Program
    {
        static void Main(string[] args)
        {
            MongoCRUD db = new MongoCRUD("modusdb");

            Product p = new Product
            {
                Name = "T-Shirt",
                Size = 'S',
                Album = new Album
                {
                    Name = "Illmatic",
                    Date = new DateTime(1994,1,1),
                    Genre = "Hip-Hop",
                    Artist = new Artist
                    {
                       FirstName = "Nasir",
                       LastName = "Jones",
                       Name = "Nas"
                    }
                }
            };

            User u = new User
            {
                FirstName = "L",
                LastName = "M",
                Email = "lm@mail.com",
                Address = new Address { Street = "Spengergasse", Postcode = "1050", City = "Vienna", Country = "Austria" }
            };

            Order o = new Order { Product = p, User = u };

            

            db.InsertRecord("Order", o);


            //var recs = db.LoadRecords<Order>("Order");

            //var oneRec = db.LoadRecordById<Order>("Order", new Guid(""));

            //db.DeleteRecord<Product>("Order", oneRec.Id);
        }

    }
}
