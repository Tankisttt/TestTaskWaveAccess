using System.Collections.Generic;

namespace TestTaskWaveAccess.Models
{
    public class IndexViewModel
    {
        public IEnumerable<Movie> Movies { get; set; }
        public IEnumerable<User> Users { get; set; }
        public IEnumerable<Actor> Actors { get; set; }
    }
}