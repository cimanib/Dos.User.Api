using Dos.User.Api.Domain.AggregateModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dos.User.Api.Data.Sql.EntityConfigurations
{
    public class UserEntityTypeConfiguration : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder
                .HasKey(o => o.Id);

            builder
                .Property(o => o.Id)
                .ValueGeneratedOnAdd();

            builder
                .Property(o => o.First_Name)
                .IsRequired();

            builder
                .Property(o => o.Last_Name)
                .IsRequired(false);

            builder
                .Property(o => o.Address)
                .IsRequired();

            builder
                .Property(o => o.City)
                .IsRequired();

            builder
                .Property(o => o.Date_Of_Birth)
                .IsRequired();

            builder
                .Property(o => o.Country)
                .IsRequired(false);

            builder
                .Property(o => o.Zip_Code)
                .IsRequired();

            builder
                .Ignore(b => b.DomainEvents);
        }
    }
}