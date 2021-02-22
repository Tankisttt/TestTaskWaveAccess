using Microsoft.EntityFrameworkCore;

namespace TestTaskWaveAccess.Models
{
    public class MovieContext : ApplicationContext
    {
        public MovieContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }
    }
}
