using Microsoft.EntityFrameworkCore;
using MvcPostGres.Models;

namespace MvcPostGres.Data
{
    public class HospitalContext : DbContext
    {
        public HospitalContext(DbContextOptions<HospitalContext> options)
            : base(options)
        {
        }
        public DbSet<Departamento> Departamentos { get; set; }
    }
}
