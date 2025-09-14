using CaRentalProject.AllServices;
using CaRentalProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace CaRentalProject.Controllers
{
    public class AIController : Controller
    {
        [HttpGet]
        public IActionResult ChatBot()
        {
            return View(new RapidApiChatViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> ChatBot(RapidApiChatViewModel model, [FromServices] RapiApiChatBotService chatService)
        {
            if (!string.IsNullOrWhiteSpace(model.Prompt))
            {
                ModelState.Clear();
                model.Answer = await chatService.GetAnswerAsync(model.Prompt);
            }
            return View(model);
        }
    }
}
    