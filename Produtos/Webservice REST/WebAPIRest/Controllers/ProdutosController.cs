using Microsoft.AspNetCore.Mvc;
using WebAPIRest.Models;

namespace WebAPIRest.Controllers
{
    public class ProdutosController : Controller
    {
        // GET: AlunosController
        public ActionResult Index()
        {
            IEnumerable<Produto> produtos = null;


            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7216/api/Produtos");

                //HTTP GET
                var responseTask = client.GetAsync("Produtos");
                responseTask.Wait();
                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadFromJsonAsync<IList<Produto>>();
                    readTask.Wait();
                    produtos = readTask.Result;
                }
                else
                {
                    produtos = Enumerable.Empty<Produto>();
                    ModelState.AddModelError(string.Empty, "Erro no servidor. Contate o Administrador.");
                }

            }


            return View(produtos);
        }

        // GET: AlunosController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AlunosController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AlunosController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AlunosController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AlunosController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AlunosController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AlunosController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
