using BoligBlik.MVC.ProxyServices.BoardMembers.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BoligBlik.MVC.Controllers
{
    public class BoardMemberController : Controller
    {
        private readonly IBoardMemberServices _boardMemberServices;
        public BoardMemberController(IBoardMemberServices boardMemberServices)
        {
            _boardMemberServices = boardMemberServices;   
        }
        // GET: BoardMemberController
        public ActionResult Index()
        {
            return View();
        }

        // GET: BoardMemberController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: BoardMemberController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BoardMemberController/Create
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

        // GET: BoardMemberController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: BoardMemberController/Edit/5
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

        // GET: BoardMemberController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: BoardMemberController/Delete/5
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
