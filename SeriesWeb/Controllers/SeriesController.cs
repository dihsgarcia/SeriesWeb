using Microsoft.AspNetCore.Mvc;
using SeriesWeb.Models;
using SeriesWeb.Repos;

namespace SeriesWeb.Controllers
{
    public class SeriesController : Controller
    {
       
        static SerieRepositorio repositorio = new SerieRepositorio();
      
        public IActionResult Index()
        {
            IEnumerable<Serie> listaSeries = repositorio.Lista();
            return View(listaSeries);
        }

        public IActionResult Create()
        {
            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Serie obj)
        {
            var novaSerie = new Serie
            {
                Id = repositorio.ProximoId(),
                Genero = obj.Genero,
                Titulo = obj.Titulo,
                Descricao = obj.Descricao,
                Ano = obj.Ano,
                Excluido = obj.Excluido
            };

            if (ModelState.IsValid)
            {
                repositorio.Insere(novaSerie);
                TempData["success"] = "Nova Serie criada com sucesso";
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var serie = repositorio.RetornaPorId((int)id);
            if (serie is null)
            {
                return NotFound();
            }

            return View(serie);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Serie obj)
        {     
            if (ModelState.IsValid)
            {
                repositorio.Atualiza(id, obj);
                TempData["success"] = "Serie Atualizada com sucesso";
                return RedirectToAction(nameof(Index));
            }
            return View(obj);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var serie = repositorio.RetornaPorId((int)id);
            if (serie is null)
            {
                return NotFound();
            }

            return View(serie);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
           var serie = repositorio.RetornaPorId((int)id);

            if (serie == null)
            {
                return NotFound();
            }

            repositorio.Exclui((int)id);
            TempData["success"] = "Serie Deletada com sucesso";
            return RedirectToAction("Index");

        }

    }
}
