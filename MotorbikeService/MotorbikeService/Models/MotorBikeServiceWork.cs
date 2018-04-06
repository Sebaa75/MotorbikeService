using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MotorbikeService.Models
{
    public class MotorBikeServiceWork
    {
        public int Id { get; set; }
        public int MotorBikeId { get; set; }
        public int ServiceWorkId { get; set; }
        public virtual ServiceWork ServiceWork { get; set; }
        public virtual MotorBike MotorBike { get; set; }
    }
}