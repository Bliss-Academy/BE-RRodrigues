using BancoAPI.Data.Entitites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace BancoAPI.Data.Entities
{
    public enum TrasactionType
    {
        Income=0,
        Expense=1
    }
    public class TransactionEntity : EntityBase
    {
        public TrasactionType type { get; set; }
        public decimal value { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string attachment { get; set; }

    }

    public class TransactionConfiguration : EntityBaseConfiguration<TransactionEntity>
    {
        public override void Configure(EntityTypeBuilder<TransactionEntity> builder)
        {
            base.Configure(builder);

            builder.ToTable("Transactions");

            builder.Property(x => x.title)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.description)
                .HasMaxLength(200);

            builder.Property(x => x.type)
                .IsRequired();

        }
    }

}
