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

        public decimal hasTraveledDist { get; set; } = 0;
        public decimal raceTrackDistance { get; set; }
        public double racingTime { get; set; }


        public Car(string name, string brand, string model, int year, int speed, decimal raceTrackDist, double raceTime) 
        {
            this.name = name;
            this.brand = brand;
            this.model = model;
            this.year = year;
            this.speed = speed;
            this.raceTrackDistance = raceTrackDist;
            this.racingTime = racingTime;
        }
    }
}