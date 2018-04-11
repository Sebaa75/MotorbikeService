using MotorbikeService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MotorbikeService.ViewModel
{
    public class PartsViewModel
    {
        public Parts Parts { get; set; }
        public System.Web.Mvc.SelectList ListWorks { get; set; }
        public System.Web.Mvc.SelectList ListMotorBikes { get; set; }
        public int WorksId { get; set; }
        public int MotorBikeId { get; set; }

    }
}