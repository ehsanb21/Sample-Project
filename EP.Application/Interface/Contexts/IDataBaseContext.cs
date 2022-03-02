using EP.Domain.City;
using EP.Domain.Person;
using EP.Domain.State;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EP.Application.Interface.Contexts
{
    public interface IDataBaseContext
    {
        DbSet<IranState> IranStates { get; set; }
        DbSet<IranCity> cites { get; set; }
        DbSet<Person> People { get; set; }
        int SaveChanges();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
        Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default);
        int SaveChanges(bool acceptAllChangesOnSuccess);
    }
}
