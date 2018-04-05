using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MotorbikeService.Models
{
    public class PartsWorks
    {
        public int Id { get; set; }
        public int PartsId { get; set; }
        public int ServiceWorkId { get; set; }
    }
}