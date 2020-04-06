using System;
namespace HairTest.Models
{
    public class Barber
    {
        public Barber()
        {
        }

        public string id { get; set; }
        public string Name { get; set; }
        public string Role { get; set; }

        public int Rating { get; set; }
        public float Lat { get; set; }
        public float Lon { get; set; }
    }
}
