using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRace
{
    public class Car
    {
        public string name { get; set; }
        public string brand { get; set; }
        public string model { get; set; }
        public int year { get; set; }
        public int speed { get; set; }

        public decimal traveledDistance { get; set; }
        public decimal raceTrackDistance { get; set; }
        public int racingTime { get; set; }
    }
}