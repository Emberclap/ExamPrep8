using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace StreetRacing
{
    public class Race
    {
        public Race(string name, string type, int laps, int capacity, int maxHorsePower)
        {
            Name = name;
            Type = type;
            Laps = laps;
            Capacity = capacity;
            MaxHorsePower = maxHorsePower;
            Participants = new List<Car>();
        }

        public string Name { get; set; }
        public string Type { get; set; }
        public int Laps { get; set; }
        public int Capacity { get; set; }
        public int MaxHorsePower { get; set; }
        public List<Car> Participants { get; set; }
        public int Count => Participants.Count;

        public void Add(Car car)
        {
            if (!Participants.Any(x => x.LicensePlate == car.LicensePlate) && this.Capacity > Count && car.HorsePower <= this.MaxHorsePower)
            {
                Participants.Add(car);
            }
        }
        public bool Remove(string licensePlate) => Participants.Remove(Participants.FirstOrDefault(x => x.LicensePlate == licensePlate));

        public Car FindParticipant (string licensePlate)
        {
            Car car = null;
            car = this.Participants.FirstOrDefault(x=>x.LicensePlate == licensePlate);
            return car;

        }
        public Car GetMostPowerfulCar()
        {
            
            if (Participants.Count > 0)
            {
                int max = this.Participants.Max(x => x.HorsePower);
                Car car = this.Participants.Find(x=> x.HorsePower == max);
                return car;
            }
            return null;
        }
        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Race: {this.Name} - Type: {this.Type} (Laps: {this.Laps})");
            foreach (var car in Participants)
            {
                sb.AppendLine(car.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
