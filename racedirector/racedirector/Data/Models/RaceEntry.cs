using System.Collections.Generic;

namespace racedirector.Data.Models
{
    public class RaceEntry
    {
        public int ID { get; set; }
        public string Number { get; set; }
        public string Sponsor { get; set; }
        public Driver Driver { get; set; } = new Driver();
        public Car Car { get; set; } = new Car();
        public Classification Class { get; set; } = new Classification();
        public Classification PaxClass { get; set; } = new Classification();
        public Competition Competition { get; set; } = new Competition();
        public ICollection<Run> Runs { get; set; }
    }
}