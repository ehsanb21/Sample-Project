using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EP.Application.Interface.Contexts;
using EP.Domain.City;
using EP.Domain.Person;
using EP.Domain.State;
using Microsoft.EntityFrameworkCore;

namespace EP.Persistence
{
    public class DataBaseContext:DbContext,IDataBaseContext
    {
        public DbSet<IranState> IranStates { get; set; }
        public DbSet<IranCity> cites { get; set; }
        public DbSet<Person> People { get; set; }        

        public DataBaseContext(DbContextOptions options):base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            var cascadeFKs = builder.Model.GetEntityTypes()
                  .SelectMany(t => t.GetForeignKeys())
                  .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);

            foreach (var fk in cascadeFKs)
                fk.DeleteBehavior = DeleteBehavior.Restrict;
        }
    }
}
