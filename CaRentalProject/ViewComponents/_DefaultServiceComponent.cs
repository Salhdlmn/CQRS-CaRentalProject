using CaRentalProject.CQRS.Handlers.ServiceHandlers;
using Microsoft.AspNetCore.Mvc;

namespace CaRentalProject.ViewComponents
{
    public class _DefaultServiceComponent:ViewComponent
    {
        private readonly GetServiceQueryHandler _handler;

        public _DefaultServiceComponent(GetServiceQueryHandler handler)
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
