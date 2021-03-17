using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Vidly.Models;

namespace Vidly.ViewModel
{
    public class MovieFormViewModel
    {


        public IEnumerable<Genre> Genres { get; set; }

        public int? Id { get; set; }


        [Required]
        [StringLength(255)]
        public string Name { get; set; }


        [Required]
        [Display(Name = "Number in Stock")]
        [Range(1, 20, ErrorMessage = "The field Number in Stock must be between 1 and 20")]
        public int NumberInStock { get; set; }



        [Required]
        [Display(Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }


        [Display(Name = "Genre")]
        [Required]
        public int? GenresId { get; set; }

        public MovieFormViewModel()
        {
            Id = 0;
        }

        public MovieFormViewModel(Movie movie)
        {

            Id = movie.Id;
            Name = movie.Name;
            ReleaseDate = movie.ReleaseDate;
            NumberInStock = movie.NumberInStock;
            GenresId = movie.GenresId;


        }

        public string Title {

            get
            {
                return Id != 0 ? "Edit Movie" : "New Movie";
            }
            
                
                
                }


    }
}