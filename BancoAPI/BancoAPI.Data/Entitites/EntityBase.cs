using BancoAPI.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoAPI.Data.Entitites
{
    public class EntityBase
    {
        public int id { get; set; }
        public string userId { get; set; }
        public DateTimeOffset created { get; set; }
        public DateTimeOffset updated { get; set; }
    }

    public class EntityBaseConfiguration<TEntity> : IEntityTypeConfiguration<TEntity>
        where TEntity : EntityBase
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.HasKey(x => x.id);


            builder.Property(x => x.userId)
                .IsRequired();

            builder.Property(x => x.created)
                .HasDefaultValueSql("GETUTCDATE()")
                .ValueGeneratedOnAdd();

            builder.Property(x => x.updated)
                .HasDefaultValueSql("GETUTCDATE()")
                .ValueGeneratedOnAddOrUpdate();
        }
    }

}
