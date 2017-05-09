using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HomNayAnGi.Models.ViewModels
{
    public class AccountViewModel
    {
        public int id { get; set; }
        public string fullname { get; set; }
        public string address { get; set; }
        public double rating { get; set; }
        public int rateQuantity { get; set; }
        public int? age { get; set; }
        public bool? gender { get; set; }
        public string userId { get; set; }
    }
}