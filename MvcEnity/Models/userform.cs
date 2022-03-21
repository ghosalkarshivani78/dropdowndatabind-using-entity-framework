using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace MvcEnity.Models
{
    public class userform
    {
       

        public int id { get; set; }

         [Required(ErrorMessage = "Enter First Name")]
        public string firstname { get; set; }


         [Required(ErrorMessage = "Enter Last Name")]
        public string lastname { get; set; }


         [Required(ErrorMessage = "Enter Email")]
         [RegularExpression(@"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}", ErrorMessage = "Invalid Email")]
        public string email { get; set; }


         [Required(ErrorMessage = "Enter address")]
        public string address { get; set; }

            //public List<SelectListItem> city { get; set; }

         [Required(ErrorMessage = "Enter city")]
        public string cityid { get; set; }

         [Required(ErrorMessage = "Enter Number")]
        public string number { get; set; }

         public SelectList cities {get;set;}
         

    }

   
}