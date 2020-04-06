using System;
using System.Collections.Generic;

namespace HairTest.Models
{
    public interface IBarberRepository
    {
        IEnumerable<Barber> AllBarbers { get; }
        IEnumerable<Barber> GetNearestBarbers { get; }
        Barber GetBarberById(string barberId);
    }
}
