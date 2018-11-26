using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PerfectHotel.Web.Data.Migrations;
using PerfectHotel.Web.Models;
using PerfectHotel.Web.Services;
using ApplicationUser = PerfectHotel.Web.Models.ApplicationUser;

namespace PerfectHotel.Web.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        private readonly string _tenantId;
        private readonly IEntityTypeProvider _entityTypeProvider;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options,
            ITenantProvider tenantProvider,
            IEntityTypeProvider entityTypeProvider)
            : base(options)
        {
            _entityTypeProvider = entityTypeProvider;
            _tenantId = tenantProvider.GetTenantId();
        }

        public DbSet<Player> Players { get; set; }

        public DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            foreach (var entityType in _entityTypeProvider.GetEntityTypes())
            {
                var method = SetGlobalQueryMethod.MakeGenericMethod(entityType);
                method.Invoke(this, new object[] {builder});
            }

            base.OnModelCreating(builder);
        }

        public readonly MethodInfo SetGlobalQueryMethod = typeof(ApplicationDbContext)
            .GetMethods(BindingFlags.Public | BindingFlags.Instance)
            .Single(t => t.IsGenericMethod && t.Name == "SetGlobalQuery");

        public void SetGlobalQuery<T>(ModelBuilder builder) where T : BaseEntity
        {
            builder.Entity<T>().HasKey(e => e.Id);
            builder.Entity<T>().HasQueryFilter(e => e.TenantId == _tenantId && !e.IsDeleted);
        }
    }
}
