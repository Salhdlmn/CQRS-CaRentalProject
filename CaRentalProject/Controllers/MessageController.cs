using CaRentalProject.CQRS.Commands.MessageCommands;
using CaRentalProject.CQRS.Handlers.MessageHandlers;
using CaRentalProject.CQRS.Queries.MessageQueries;
using Microsoft.AspNetCore.Mvc;

namespace CaRentalProject.Controllers
{
    public class MessageController : Controller
    {
        private readonly GetMessageQueryHandler _getMessageQueryHandler;
        private readonly GetMessageByIdQueryHandler _getMessageByIdQueryHandler;
        private readonly CreateMessageCommandHandler _createMessageCommandHandler;
        private readonly UpdateMessageCommandHandler _updateMessageCommandHandler;
        private readonly RemoveMessageCommandHandler _removeMessageCommandHandler;

        public MessageController(GetMessageQueryHandler getMessageQueryHandler, GetMessageByIdQueryHandler getMessageByIdQueryHandler, CreateMessageCommandHandler createMessageCommandHandler, UpdateMessageCommandHandler updateMessageCommandHandler, RemoveMessageCommandHandler removeMessageCommandHandler)
        {
            _getMessageQueryHandler = getMessageQueryHandler;
            _getMessageByIdQueryHandler = getMessageByIdQueryHandler;
            _createMessageCommandHandler = createMessageCommandHandler;
            _updateMessageCommandHandler = updateMessageCommandHandler;
            _removeMessageCommandHandler = removeMessageCommandHandler;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _getMessageQueryHandler.Handle();
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateMessage()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateMessage(CreateMessageCommand command)
        {
            await _createMessageCommandHandler.Handle(command);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteMessage(int id)
        {
            await _removeMessageCommandHandler.Handle(new RemoveMessageCommand(id));
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateMessage(int id)
        {
            var values = await _getMessageByIdQueryHandler.Handle(new GetMessageByIdQuery(id));
            return View(values);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateMessage(UpdateMessageCommand command)
        {
            await _updateMessageCommandHandler.Handle(command);
            return RedirectToAction("Index");
        }
    }
}
