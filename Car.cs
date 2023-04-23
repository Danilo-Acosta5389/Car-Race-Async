using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRace
{
    public class Car
    {
        public string? name { get; set; }
        public string? brand { get; set; }
        public string? model { get; set; }
        public int year { get; set; }
        public int speed { get; set; }

        public decimal hasTraveledDist { get; set; }
        public decimal raceTrackDistance { get; set; }
        public decimal racingTime { get; set; }

        public bool finishedRace { get; set; }

        //public decimal CarTraveling()
        //{
        //    // X = (Y - 20) * 1.33
        //    // Y = done_temperature
        //    return ((hasTraveledDist - 20) * 10) - racingTime;
        //}

    }
}