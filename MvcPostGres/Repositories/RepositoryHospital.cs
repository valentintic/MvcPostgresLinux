using Microsoft.EntityFrameworkCore;
using MvcPostGres.Data;
using MvcPostGres.Models;

namespace MvcPostGres.Repositories
{
    public class RepositoryHospital
    {
        private HospitalContext context;
        public RepositoryHospital(HospitalContext context)
        {
            this.context = context;
        }

        public async Task<List<Departamento>> GetDepartamentosAsync()
        {
            return await this.context.Departamentos.ToListAsync();
        }

        public async Task<Departamento> GetDepartamentoAsync(int id)
        {
            return await this.context.Departamentos.FindAsync(id);
        }
        public async Task<Departamento> AddDepartamentoAsync(Departamento departamento)
        {
            this.context.Departamentos.Add(departamento);
            await this.context.SaveChangesAsync();
            return departamento;
        }

        public async Task<Departamento> UpdateDepartamentoAsync(Departamento departamento)
        {
            this.context.Departamentos.Update(departamento);
            await this.context.SaveChangesAsync();
            return departamento;
        }

        public async Task DeleteDepartamentoAsync(int id)
        {
            var departamento = await this.context.Departamentos.FindAsync(id);
            if (departamento != null)
            {
                this.context.Departamentos.Remove(departamento);
                await this.context.SaveChangesAsync();
            }
        }
    }
}
