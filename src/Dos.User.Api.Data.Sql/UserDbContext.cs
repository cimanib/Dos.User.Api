using Dos.User.Api.Common;
using Dos.User.Api.Domain.AggregateModels;
using Microsoft.EntityFrameworkCore;

namespace Dos.User.Api.Data.Sql
{
    public class UserDbContext : DbContext
    {
        private readonly IEntityTypeConfiguration<UserEntity> _userConfig;
        public DbSet<UserEntity> Users { get; set; }

        public UserDbContext(DbContextOptions<UserDbContext> options)
        : base(options) { }

        public UserDbContext(
           DbContextOptions<UserDbContext> options,
           IEntityTypeConfiguration<UserEntity> userConfig) : base(options)
        {
            _userConfig = Guard.IsNotNull(userConfig, nameof(userConfig));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(_userConfig);
        }

    }
}