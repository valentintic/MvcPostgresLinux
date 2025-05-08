using Microsoft.AspNetCore.Mvc;
using MvcPostGres.Models;
using MvcPostGres.Repositories;

namespace MvcPostGres.Controllers
{
    public class DepartamentoController : Controller
    {
        private RepositoryHospital repo;
        public DepartamentoController(RepositoryHospital repo)
        {
            this.repo = repo;
        }

        public async Task<IActionResult> Index()
        {
            var departamentos = await this.repo.GetDepartamentosAsync();
            return View(departamentos);
        }

        public async Task<IActionResult> Details(int id)
        {
            var departamento = await this.repo.GetDepartamentoAsync(id);
            if (departamento == null)
            {
                return NotFound();
            }
            return View(departamento);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Departamento departamento)
        {
            if (ModelState.IsValid)
            {
                await this.repo.AddDepartamentoAsync(departamento);
                return RedirectToAction(nameof(Index));
            }
            return View(departamento);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var departamento = await this.repo.GetDepartamentoAsync(id);
            if (departamento == null)
            {
                return NotFound();
            }
            return View(departamento);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Departamento departamento)
        {
            if (id != departamento.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                await this.repo.UpdateDepartamentoAsync(departamento);
                return RedirectToAction(nameof(Index));
            }
            return View(departamento);
        }
        public async Task<IActionResult> Delete(int id)
        {
            var departamento = await this.repo.GetDepartamentoAsync(id);
            if (departamento == null)
            {
                return NotFound();
            }
            return View(departamento);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await this.repo.DeleteDepartamentoAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
