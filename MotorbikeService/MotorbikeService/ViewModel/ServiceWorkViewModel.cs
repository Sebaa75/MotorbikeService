using MotorbikeService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MotorbikeService.ViewModel
{
    public class ServiceWorkViewModel
    {
        public ServiceWork ServiceWork { get; set; }
        public SelectList ListParts { get; set; }
        public SelectList ListMotorBikes { get; set; }
        public int PartsId { get; set; }
        public int MotorBikeId { get; set; }

    }
}