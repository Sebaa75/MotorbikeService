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
        public SelectList ListMotur { get; set; }
        public int PartId { get; set; }
        public int MoturId { get; set; }

    }
}