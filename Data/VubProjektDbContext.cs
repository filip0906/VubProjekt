using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VubProjekt.Models;

    public class VubProjektDbContext : DbContext
    {
        public VubProjektDbContext (DbContextOptions<VubProjektDbContext> options)
            : base(options)
        {
        }

        public DbSet<VubProjekt.Models.Footballer> Footballer { get; set; } = default!;
    }
