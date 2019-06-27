using Avana.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace Avana.DataAccess.Core
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {

        }

        public DbSet<Device> Devices { get; set; }
        public DbSet<ModelFamily> ModelFamilies { get; set; }
    }
}
