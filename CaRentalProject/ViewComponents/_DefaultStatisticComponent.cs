using CaRentalProject.CQRS.Handlers.BookingHandlers;
using CaRentalProject.CQRS.Handlers.CarHandlers;
using CaRentalProject.CQRS.Handlers.MessageHandlers;
using CaRentalProject.CQRS.Handlers.TestimonialHandlers;
using Microsoft.AspNetCore.Mvc;

namespace CaRentalProject.ViewComponents
{
    public class _DefaultStatisticComponent : ViewComponent
    {
        private readonly GetCarQueryHandler _getCarQueryHandler;

        private readonly GetBookingQueryHandler _getBookingQueryHandler;

        private readonly GetTestimonialQueryHandler _getTestimonialQueryHandler;

        private readonly GetMessageQueryHandler _getMessageQueryHandler;

        public _DefaultStatisticComponent(GetCarQueryHandler getCarQueryHandler, GetBookingQueryHandler getBookingQueryHandler, GetTestimonialQueryHandler getTestimonialQueryHandler, GetMessageQueryHandler getMessageQueryHandler)
        {
            _getCarQueryHandler = getCarQueryHandler;
            _getBookingQueryHandler = getBookingQueryHandler;
            _getTestimonialQueryHandler = getTestimonialQueryHandler;
            _getMessageQueryHandler = getMessageQueryHandler;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var totalCar = (await _getCarQueryHandler.Handle()).Count();
            var totalReservation = (await _getBookingQueryHandler.Handle()).Count();
            var totalTestimonial = (await _getTestimonialQueryHandler.Handle()).Count();
            var totalMessage = (await _getMessageQueryHandler.Handle()).Count();

            var model = new Models.StatisticViewModel
            {
                TotalCar = totalCar,
                TotalReservation = totalReservation,
                TotalTestimonial = totalTestimonial,
                TotalMessage = totalMessage
            };
            return View(model);
        }
    }
}
