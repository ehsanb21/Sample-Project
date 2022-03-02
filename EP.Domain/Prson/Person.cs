using EP.Domain.State;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EP.Domain.City;
using System.ComponentModel.DataAnnotations.Schema;

namespace EP.Domain.Person
{
    public class Person
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string FirstName { get; set; }

        [StringLength(50)]
        public string LastName { get; set; }

        [ForeignKey("IranStateId")]
        public virtual IranState IranState { get; set; }
        public int IranStateId { get; set; }

        [ForeignKey("IranCityId")]
        public virtual IranCity IranCity { get; set; }
        public int IranCityId { get; set; }
    }

    /// <summary>
    /// fluent-api
    /// </summary>
    public class PersonConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(p => p.FirstName).IsRequired().HasMaxLength(50);
            builder.Property(p => p.LastName).IsRequired().HasMaxLength(50);            
            builder.Property(p => p.IranStateId).IsRequired();
            builder.Property(p => p.IranCityId).IsRequired();

        }
    }
}
