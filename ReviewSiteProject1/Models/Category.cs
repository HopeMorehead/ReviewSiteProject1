using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ReviewSiteProject1.Models
{
    public class Category
    {

        [Key]

        public int CategoryID { get; set; }


        [Display(Name = "Category")]
        public string Name { get; set; }
        public virtual ICollection<TechnologyReview>TehnologyReviews { get; set; }


    }
}