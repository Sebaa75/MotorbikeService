using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MotorbikeService.Models
{
    public class ServiceWork
    {
        public int Id { get; set; }
        public DateTime date { get; set; }
        public int Mileage { get; set; }
        public string Comment { get; set; }
    }
}