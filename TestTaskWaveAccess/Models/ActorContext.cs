using Microsoft.EntityFrameworkCore;

namespace TestTaskWaveAccess.Models
{
    public class ActorContext : ApplicationContext
    {
        public ActorContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }
    }
}
