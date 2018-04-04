using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MotorbikeService.Models
{
    public class MotorBike
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string VIN { get; set; }
        public string Plate { get; set; }
        public int Mileage { get; set; }
        public int BuildYear { get; set; }
    }
}