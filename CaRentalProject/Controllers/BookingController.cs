using CaRentalProject.CQRS.Commands.BookingCommands;
using CaRentalProject.CQRS.Handlers.BookingHandlers;
using CaRentalProject.CQRS.Handlers.CarHandlers;
using CaRentalProject.CQRS.Queries.BookingQueries;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CaRentalProject.Controllers
{
    public class BookingController : Controller
    {
        private readonly GetBookingQueryHandler _getBookingQueryHandler;
        private readonly GetBookingByIdQueryHandler _getBookingByIdQueryHandler;
        private readonly CreateBookingCommandHandler _createBookingCommandHandler;
        private readonly UpdateBookingCommandHandler _updateBookingCommandHandler;
        private readonly RemoveBookingCommandHandler _removeBookingCommandHandler;
        private readonly GetCarQueryHandler _getCarQueryHandler;

        public BookingController(GetBookingQueryHandler getBookingQueryHandler, GetBookingByIdQueryHandler getBookingByIdQueryHandler, CreateBookingCommandHandler createBookingCommandHandler, UpdateBookingCommandHandler updateBookingCommandHandler, RemoveBookingCommandHandler removeBookingCommandHandler, GetCarQueryHandler getCarQueryHandler)
        {
            _getBookingQueryHandler = getBookingQueryHandler;
            _getBookingByIdQueryHandler = getBookingByIdQueryHandler;
            _createBookingCommandHandler = createBookingCommandHandler;
            _updateBookingCommandHandler = updateBookingCommandHandler;
            _removeBookingCommandHandler = removeBookingCommandHandler;
            _getCarQueryHandler = getCarQueryHandler;
        }

        public async Task<IActionResult> Index()
        {
            var bookings = await _getBookingQueryHandler.Handle();
            return View(bookings);
        }

        [HttpGet]
        public async Task<IActionResult> CreateBooking()
        {
            var cars = await _getCarQueryHandler.Handle();
            ViewBag.Cars = cars
                .Select(c => new SelectListItem
                {
                    Value = c.CarId.ToString(),
                    Text = c.Brand + " " + c.Model
                }).ToList();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateBooking(CreateBookingCommand command)
        {
            await _createBookingCommandHandler.Handle(command);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> DeleteBooking(int id)
        {
            await _removeBookingCommandHandler.Handle(new RemoveBookingCommand(id));
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateBooking(int id)
        {
            var cars = await _getCarQueryHandler.Handle();
            ViewBag.Cars = cars
                .Select(c => new SelectListItem
                {
                    Value = c.CarId.ToString(),
                    Text = c.Brand + " " + c.Model
                }).ToList();

            var booking = await _getBookingByIdQueryHandler.Handle(new GetBookingByIdQuery(id));
            return View(booking);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateBooking(UpdateBookingCommand command)
        {
            await _updateBookingCommandHandler.Handle(command);
            return RedirectToAction("Index");


        }
    }
}
