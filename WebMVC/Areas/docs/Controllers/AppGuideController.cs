using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace WebMVC.Areas.docs.Controllers
{
    [Area("Docs")]
    public class AppGuideController : Controller
    {
        private IMediator _mediator;

        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
        // GET: AppGuide
        public  ActionResult Index()
        {
            
           // await Mediator.Send(command);
            return View();
        }

        // GET: AppGuide/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AppGuide/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AppGuide/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult<bool>> Create(CreateNodeCommand command)
        {

            return await Mediator.Send(command);
           
        }

        // GET: AppGuide/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AppGuide/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AppGuide/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AppGuide/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}