using EntityPizza.Dal;
using EntityPizza.Models;
using System.Linq;
using System.Web.Mvc;

namespace EntityPizza.Controllers
{
    public class PizzaController : Controller
    {
        private PizzaContext _ctxPizza = new PizzaContext();

        // GET: Pizza
        public ActionResult Index()
        {
            var lst = _ctxPizza.Pizzas.ToList();
            return View(lst);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Pizza pizza)
        {
            if (ModelState.IsValid)
            {
                _ctxPizza.Pizzas.Add(pizza);
                _ctxPizza.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pizza);
        }

        public ActionResult Edit(int id)
        {
            var pizza = _ctxPizza.Pizzas.First(p => p.Id == id);
            return View(pizza);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Pizza pizza)
        {
            if (ModelState.IsValid)
            {
                Pizza pizzaUpdate = _ctxPizza.Pizzas.First(p => p.Id == pizza.Id);
                pizzaUpdate.Descricao = pizza.Descricao;
                pizzaUpdate.Valor = pizza.Valor;
                _ctxPizza.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pizza);
        }

        public ActionResult Details(int id)
        {
            return View(_ctxPizza.Pizzas.First(p => p.Id == id));
        }

        public ActionResult Delete(int id)
        {
            var pizza = _ctxPizza.Pizzas.First(p => p.Id == id);
            return View(pizza);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirm(int id)
        {
            var pizza = _ctxPizza.Pizzas.First(p => p.Id == id);
            _ctxPizza.Pizzas.Remove(pizza);
            _ctxPizza.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}