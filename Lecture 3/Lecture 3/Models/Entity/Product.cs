using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lecture_3.Models.Entity
{
    public class Product
    {
        public int ID { get; set; }


        public string Name { get; set; }

        public int Quantity { get; set; }

        public int Price { get; set; }
        public string Description { get; set; }

    }
}