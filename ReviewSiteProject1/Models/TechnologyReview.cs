using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ReviewSiteProject1.Models
{
    public class TechnologyReview
    {

        [Key]

        public int ReviewID { get; set; }
        public string Product { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string post { get; set; }



        [ForeignKey("Category")]
        public int CategoryID { get; set; }
        public virtual Category Category { get; set; }









    }
}