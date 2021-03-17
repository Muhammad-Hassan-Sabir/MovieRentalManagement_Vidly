using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Dtos
{
    public class MovieDto
    {

        public int Id { get; set; }


        [Required]
        [StringLength(255)]
        public string Name { get; set; }


        [Required]
        [Range(1, 10, ErrorMessage = "The field Number in Stock must be between 1 and 20")]
        public int NumberInStock { get; set; }


        [Required]
        public DateTime ReleaseDate { get; set; }


    

        [Required]
        public int GenresId { get; set; }



        public GenreDto Genres { get; set; }









    }
}