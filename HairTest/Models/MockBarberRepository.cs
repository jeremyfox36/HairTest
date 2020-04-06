using System;
using System.Collections.Generic;
using System.Linq;

namespace HairTest.Models
{
    public class MockBarberRepository : IBarberRepository
    {
        public MockBarberRepository()
        {
        }

        public IEnumerable<Barber> AllBarbers =>
            new List<Barber>
            {
                new Barber(){ id = "userId.1", Role = "Admin", Name = "Joe Bloggs", Rating = 5, Lat = 123.456f, Lon = 345.123f }
                ,new Barber(){ id = "userId.2", Name = "Hairy Mary", Rating = 3, Lat = 123.456f, Lon = 345.123f }
                ,new Barber(){ id = "userId.3", Name = "Big Al", Rating = 1, Lat = 123.456f, Lon = 345.123f }
                ,new Barber(){ id = "userId.4", Name = "Ally Pally", Rating = 5, Lat = 123.456f, Lon = 345.123f }
                ,new Barber(){ id = "userId.5", Name = "Gaz Smith", Rating = 2, Lat = 123.456f, Lon = 345.123f }
            };

        public IEnumerable<Barber> GetNearestBarbers => throw new NotImplementedException();

        public Barber GetBarberById(string barberId)
        {
            return AllBarbers.FirstOrDefault(b => b.id == barberId); 
        }
    }
}
