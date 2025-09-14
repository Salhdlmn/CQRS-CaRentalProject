using CaRentalProject.CQRS.Handlers.EmployeeHandlers;
using Microsoft.AspNetCore.Mvc;

namespace CaRentalProject.ViewComponents
{
    public class _DefaultEmployeeComponent:ViewComponent
    {
        private readonly GetEmployeeQueryHandler _handler;

        public _DefaultEmployeeComponent(GetEmployeeQueryHandler handler)
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
