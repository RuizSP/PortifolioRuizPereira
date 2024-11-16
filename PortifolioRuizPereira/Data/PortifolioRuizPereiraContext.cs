using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PortifolioRuizPereira.Models;

namespace PortifolioRuizPereira.Data
{
    public class PortifolioRuizPereiraContext : DbContext
    {
        public PortifolioRuizPereiraContext (DbContextOptions<PortifolioRuizPereiraContext> options)
            : base(options)
        {
        }

        public DbSet<PortifolioRuizPereira.Models.Projeto> Projeto { get; set; } = default!;
        public DbSet<PortifolioRuizPereira.Models.Usuario> Usuario { get; set; } = default!;
    }
}
