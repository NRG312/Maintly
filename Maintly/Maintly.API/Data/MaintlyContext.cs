using Maintly.API.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Reflection.PortableExecutable;

namespace Maintly.API.Data
{
    public class MaintlyContext: DbContext
    {
        public DbSet<Models.Machine> Machines { get; set; }
        public DbSet<Models.Process> Processes { get; set; }
        public DbSet<Component> Components { get; set; }
        public DbSet<Incident> Incidents { get; set; }


        public MaintlyContext(DbContextOptions<MaintlyContext> options)
            :base(options)
        {

        }
    }
}
