using EPlastBoard.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPlastBoard.DAL
{
    public class EPlastBoardDBContext : DbContext
    {
        protected readonly IConfiguration Configuration;
        public EPlastBoardDBContext(IConfiguration configuration)
        {
            Configuration = configuration;
            Database.Migrate();
            DataSeed.Initialize(this);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(Configuration.GetConnectionString("ConnectionString"));

        }
        public DbSet<Board> Boards { get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet<Column> Columns { get; set; }

    }
}
