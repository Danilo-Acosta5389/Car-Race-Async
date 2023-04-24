using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRace
{
    public class RandomEvent
    {
        public string? eventName { get; set; }
        public string? description { get; set; }
        public double duration { get; set; }
        public int speedDecrease { get; set; }

        public RandomEvent(string name, string descr, int dur, int speedDec)
        {
            this.eventName = name;
            this.description = descr;
            this.duration = dur;
            this.speedDecrease = speedDec;
        }
    }
    
}
