using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using TestTaskWaveAccess.Models;
using X.PagedList;

namespace MvcMovie.Models
{
    public class MovieGenreViewModel
    {
        public IPagedList<Movie> Movies { get; set; }
        public SelectList Genres { get; set; }
        [Display(Name = "Genre")]
        public string MovieGenre { get; set; }
        public string SearchString { get; set; }
    }
}