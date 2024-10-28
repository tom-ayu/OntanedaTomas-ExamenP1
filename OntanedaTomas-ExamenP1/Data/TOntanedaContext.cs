using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OntanedaTomas_ExamenP1.Models;

    public class TOntanedaContext : DbContext
    {
        public TOntanedaContext (DbContextOptions<TOntanedaContext> options)
            : base(options)
        {
        }

        public DbSet<OntanedaTomas_ExamenP1.Models.TOntaneda> TOntaneda { get; set; } = default!;

public DbSet<OntanedaTomas_ExamenP1.Models.Celular> Celular { get; set; } = default!;
    }
