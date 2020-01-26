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
                new Barber(){ id = 1, Name = "Joe Bloggs", Rating = 5, Lat = 123.456f, Lon = 345.123f }
                ,new Barber(){ id = 2, Name = "Hairy Mary", Rating = 3, Lat = 123.456f, Lon = 345.123f }
                ,new Barber(){ id = 3, Name = "Big Al", Rating = 1, Lat = 123.456f, Lon = 345.123f }
                ,new Barber(){ id = 4, Name = "Ally Pally", Rating = 5, Lat = 123.456f, Lon = 345.123f }
                ,new Barber(){ id = 5, Name = "Gaz Smith", Rating = 2, Lat = 123.456f, Lon = 345.123f }
            };

        public IEnumerable<Barber> GetNearestBarbers => throw new NotImplementedException();

        public Barber GetBarberById(int barberId)
        {
            return AllBarbers.FirstOrDefault(b => b.id == barberId); 
        }
    }
}
