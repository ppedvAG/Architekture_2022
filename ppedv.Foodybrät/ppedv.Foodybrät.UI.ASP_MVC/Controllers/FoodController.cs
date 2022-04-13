using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ppedv.Foodybrät.Contracts;
using ppedv.Foodybrät.Logic;
using ppedv.Foodybrät.Model;

namespace ppedv.Foodybrät.UI.ASP_MVC.Controllers
{
    public class FoodController : Controller
    {
        Core core;
        public FoodController(IUnitOfWork uow = null)
        {
            core = new Core(uow);
        }

        // GET: FoodController
        public ActionResult Index()
        {
            return View(core.UnitOfWork.FoodRepository.Query());
            return View();
        }

        // GET: FoodController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: FoodController/Create
        public ActionResult Create()
        {
            return View(new Food() { Description = "NEU" });
        }

        // POST: FoodController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Food newFood)
        {
            try
            {

                core.UnitOfWork.FoodRepository.Add(newFood);
                core.UnitOfWork.SaveAll();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: FoodController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: FoodController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Food food)
        {
            try
            {
                core.UnitOfWork.FoodRepository.Update(food);
                core.UnitOfWork.SaveAll();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: FoodController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(core.UnitOfWork.FoodRepository.GetById(id));
        }

        // POST: FoodController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                var toKill = core.UnitOfWork.FoodRepository.GetById(id);
                core.UnitOfWork.FoodRepository.Delete(toKill);
                core.UnitOfWork.SaveAll();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
