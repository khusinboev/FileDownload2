using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace FileDownload2.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Quote> Quotes { get; set; }
    }
}
