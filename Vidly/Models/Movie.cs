using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Movie
    {

        public int Id { get; set; }


        [Required]
        [StringLength(255)]
        public string Name { get; set; }


        [Required]
        [Display(Name = "Number in Stock")]
        [Range(1, 20, ErrorMessage = "The field Number in Stock must be between 1 and 20")]
        public int NumberInStock { get; set; }

        [Required]
        [Display(Name ="Release Date")]
        public DateTime ReleaseDate { get; set; }

       
        public DateTime DateAdded { get; set; }

   
        public Genre Genres{ get; set; }


        [Display(Name = "Genre")]
        [Required]
        public int GenresId { get; set; }



        public int NumberAvailable { get; set; }



    }
}