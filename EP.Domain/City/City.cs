using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EP.Domain.State;
using System.ComponentModel.DataAnnotations.Schema;

namespace EP.Domain.City
{
    public class IranCity
    {
        public int Id { get; set; }
        
        [StringLength(50)]
        public string Name { get; set; }

        [ForeignKey("IranStateId")]
        public virtual IranState IranState { get; set; }
        public int IranStateId { get; set; }

        /// <summary>
        /// fluent-api
        /// </summary>
        public class CityConfiguration : IEntityTypeConfiguration<IranCity>
        {
            public void Configure(EntityTypeBuilder<IranCity> builder)
            {
                builder.HasKey(x => x.Id);
                builder.Property(p => p.Name).IsRequired().HasMaxLength(50);
                builder.Property(p => p.IranStateId).IsRequired();
            }
        }
    }
}
