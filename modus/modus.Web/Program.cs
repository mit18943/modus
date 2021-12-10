using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using modus.Model;
using modus.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace modus.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
           /* BaseRepository db = new MongoCRUD("modusdb");

            Artist a = new Artist
            {
                Id = "2Pac",
                FirstName = "Tupac",
                LastName = "Shakur",
                Birthdate = new DateTime(1971, 6, 16)
            };

            Product p1 = new Product
            {
                Name = "T-Shirt",
                Size = 'S',
                AlbumTitle = "All Eyez On Me",
                Date = new DateTime(1996, 2, 13),
                Genre = "Hip-Hop",
                ArtistId = a.Id
            };
            Product p2 = new Product
            {
                Name = "Cap",
                Size = 'X',
                AlbumTitle = "Me Against The World",
                Date = new DateTime(1995, 3, 14),
                Genre = "Hip-Hop",
                ArtistId = a.Id
            };


            User u = new User
            {
                FirstName = "L",
                LastName = "M",
                Email = "lm@mail.com",
                Address = new Address { Street = "Spengergasse", Postcode = "1050", City = "Vienna", Country = "Austria" }
            };


            Order o = new Order { ProductIdList = new List<string>() { p1.Id, p2.Id }, User = u };



            db.InsertRecord("Order", o);
            //db.InsertRecord("Artist", a);
            //db.InsertRecord("Product", p1);
            //db.InsertRecord("Product", p2);

            var recs = db.LoadRecords<Order>("Order");

            //db.DeleteRecord<Order>("Order", new Guid("eea76c59-c598-40f3-8fb2-0d33b2b30b88"));
           */
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
