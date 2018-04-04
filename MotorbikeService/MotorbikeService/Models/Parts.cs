using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MotorbikeService.Models
{
    public class Parts
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public string Suplier { get; set; }
        public double Amount { get; set; }
        public double Price { get; set; }
        public  PartsType PartsType{ get; set; }
    }
}