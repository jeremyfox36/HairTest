using System;
namespace HairTest.Models
{
    public class Barber
    {
        public Barber()
        {
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int Rating { get; set; }
        public float Lat { get; set; }
        public float Lon { get; set; }
    }
}
