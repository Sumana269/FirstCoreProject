using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FirstCoreProject.Models
{
    public class Books
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Please Enter Book Name")]
        [Display(Name ="Book Name")]
        public string BookName { get; set; }

        [Required(ErrorMessage ="Please enter Author Name")]
        [Display(Name="Author Name")]
        public string Author { get; set; }
       
        [Required(ErrorMessage = "Provide the GenreName")]
        [Display(Name = "Genre Name")]
        public string Genre { get; set; }

        [Required(ErrorMessage ="Please Provide the Date")]
        public DateTime PublishedDate { get; set; }
    }
}
