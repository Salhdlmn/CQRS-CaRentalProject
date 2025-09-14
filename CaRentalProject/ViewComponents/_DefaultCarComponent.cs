using CaRentalProject.CQRS.Handlers.CarHandlers;
using Microsoft.AspNetCore.Mvc;

namespace CaRentalProject.ViewComponents
{
    public class _DefaultCarComponent:ViewComponent
    {
        private readonly GetCarQueryHandler _handler;

        public _DefaultCarComponent(GetCarQueryHandler handler)
        {
            _handler = handler;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _handler.Handle();
            return View(values);
        }
    }
}
