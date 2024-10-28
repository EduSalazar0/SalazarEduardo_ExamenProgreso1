using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SalazarEduardo_ExamenProgreso1.Models;

namespace SalazarEduardo_ExamenProgreso1
{
    public class Context : DbContext
    {
        public Context (DbContextOptions<Context> options)
            : base(options)
        {
        }

        public DbSet<SalazarEduardo_ExamenProgreso1.Models.Celular> Celular { get; set; } = default!;
        public DbSet<SalazarEduardo_ExamenProgreso1.Models.ESalazar> ESalazar { get; set; } = default!;
    }
}
