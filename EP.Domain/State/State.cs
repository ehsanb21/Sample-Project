using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EP.Domain.State
{
    public class IranState
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string Name { get; set; }


        /// <summary>
        /// fluent-api
        /// </summary>
        public class StateConfiguration : IEntityTypeConfiguration<IranState>
        {
            public void Configure(EntityTypeBuilder<IranState> builder)
            {
                builder.HasKey(x => x.Id);
                builder.Property(p => p.Name).IsRequired().HasMaxLength(50);              
            }
        }
    }
}
