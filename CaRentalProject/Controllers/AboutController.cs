using CaRentalProject.CQRS.Commands.AboutCommands;
using CaRentalProject.CQRS.Handlers.AboutHandlers;
using CaRentalProject.CQRS.Queries.AboutQueries;
using Microsoft.AspNetCore.Mvc;

namespace CaRentalProject.Controllers
{
    public class AboutController : Controller
    {
        private readonly GetAboutQueryHandler _getAboutQueryHandler;
        private readonly GetAboutByIdQueryHandler _getAboutByIdQueryHandler;
        private readonly CreateAboutCommandHandler _createAboutCommandHandler;
        private readonly UpdateAboutCommandHandler _updateAboutCommandHandler;
        private readonly RemoveAboutCommandHandler _removeAboutCommandHandler;

        public AboutController(GetAboutQueryHandler getAboutQueryHandler, GetAboutByIdQueryHandler getAboutByIdQueryHandler, CreateAboutCommandHandler createAboutCommandHandler, UpdateAboutCommandHandler updateAboutCommandHandler, RemoveAboutCommandHandler removeAboutCommandHandler)
        {
            _getAboutQueryHandler = getAboutQueryHandler;
            _getAboutByIdQueryHandler = getAboutByIdQueryHandler;
            _createAboutCommandHandler = createAboutCommandHandler;
            _updateAboutCommandHandler = updateAboutCommandHandler;
            _removeAboutCommandHandler = removeAboutCommandHandler;
        }

        public async Task< IActionResult> Index()
        {
            var values= await _getAboutQueryHandler.Handle();
            return View(values);
        }
        [HttpGet]

        public async Task<IActionResult> CreateAbout()
        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> CreateAbout(CreateAboutCommand command)
        {
            await _createAboutCommandHandler.Handle(command);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteAbout(int id)
        {
         await _removeAboutCommandHandler.Handle(new RemoveAboutCommand(id));
            return RedirectToAction("Index");
        }

        [HttpGet]
        
        public async Task<IActionResult> UpdateAbout(int id)
        {
            var value= await _getAboutByIdQueryHandler.Handle(new GetAboutByIdQuery(id));
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateAbout(UpdateAboutCommand command)
        {
            await _updateAboutCommandHandler.Handle(command);
            return RedirectToAction("Index");
        }
    }
}
