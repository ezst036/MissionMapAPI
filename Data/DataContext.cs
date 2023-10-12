using Microsoft.EntityFrameworkCore;

namespace missionmap.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Mission> missionmap_mission => Set<Mission>();
    }
}
