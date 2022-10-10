using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjApiAula20221003.Models;

namespace ProjApiAula20221003.Data
{
    public class ProjApiAula20221003Context : DbContext
    {
        public ProjApiAula20221003Context(DbContextOptions<ProjApiAula20221003Context> options)
            : base(options)
        {
        }

        public DbSet<ProjApiAula20221003.Models.Cliente> Cliente { get; set; }

        public DbSet<ProjApiAula20221003.Models.Endereco> Endereco { get; set;}
    }
}
