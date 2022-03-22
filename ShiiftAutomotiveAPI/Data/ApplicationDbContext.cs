using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ShiiftAutomotiveAPI.Models;

    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext (DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<ShiiftAutomotiveAPI.Models.Illustration> Illustration { get; set; }

        public DbSet<ShiiftAutomotiveAPI.Models.Purchase> Purchase { get; set; }

        public DbSet<ShiiftAutomotiveAPI.Models.TypeIllustration> TypeIllustration { get; set; }

        public DbSet<ShiiftAutomotiveAPI.Models.User> User { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder options)
        //    => options.UseSqlServer("Server=localhost,1433; Database=ShiiftAutomotiveAPI;User=sa; Password=Bootcamp18");
}
