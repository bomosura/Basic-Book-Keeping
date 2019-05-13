using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
namespace BasicBookKeeping.Infrastructure.Data
{
    public class DataContext : IdentityDbContext
    {
        private readonly IHttpContextAccessor _httpContext = null;
        public Guid InstanceId { get; }


        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {

            InstanceId = Guid.NewGuid();
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public DataContext(DbContextOptions<DataContext> options, IHttpContextAccessor httpContext) 
            : this(options)
        {
            _httpContext = httpContext;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
