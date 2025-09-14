using CaRentalProject.AllServices;
using CaRentalProject.Context;
using CaRentalProject.CQRS.Commands.BookingCommands;
using CaRentalProject.CQRS.Commands.MessageCommands;
using CaRentalProject.CQRS.Handlers.BookingHandlers;
using CaRentalProject.CQRS.Handlers.CarHandlers;
using CaRentalProject.CQRS.Handlers.MessageHandlers;
using CaRentalProject.CQRS.Handlers.SliderHandlers;
using CaRentalProject.Entities;
using CaRentalProject.Models;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MimeKit;
using System.Globalization;
using System.Net.Mail;


namespace CaRentalProject.Controllers
{
    public class DefaultController : Controller

    {

        private readonly CaRentalContext _dbContext;
        private readonly RapidAPIAirportService _airportService;
        private readonly GetCarQueryHandler _getCarQueryHandler;
        private readonly GetSliderQueryHandler _getSliderQueryHandler;
        private readonly AirportDbService _airportDbService;
        private readonly GetBookingQueryHandler _getBookingQueryHandler;
        private readonly CreateBookingCommandHandler _createBookingCommandHandler;
        private readonly CreateMessageCommandHandler _createMessageCommandHandler;
        private readonly RapiApiChatBotService _chatService;
        private readonly RapidApiGasPrice _rapidApiGasPrice;
        public DefaultController(RapidAPIAirportService airportService, GetCarQueryHandler getCarQueryHandler, GetSliderQueryHandler getSliderQueryHandler, AirportDbService airportDbService, GetBookingQueryHandler getBookingQueryHandler, CreateBookingCommandHandler createBookingCommandHandler, CreateMessageCommandHandler createMessageCommandHandler, RapiApiChatBotService chatService, RapidApiGasPrice rapidApiGasPrice)
        {
            _airportService = airportService;
            _getCarQueryHandler = getCarQueryHandler;
            _getSliderQueryHandler = getSliderQueryHandler;
            _airportDbService = airportDbService;
            _getBookingQueryHandler = getBookingQueryHandler;
            _createBookingCommandHandler = createBookingCommandHandler;
            _createMessageCommandHandler = createMessageCommandHandler;
            _chatService = chatService;
            _rapidApiGasPrice = rapidApiGasPrice;
        }
        private double CalculateDistance(double lat1, double lon1, double lat2, double lon2)
        {
            const double R = 6371; // Dünya yarıçapı (km)
            var dLat = (lat2 - lat1) * (Math.PI / 180);
            var dLon = (lon2 - lon1) * (Math.PI / 180);

            var a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
                    Math.Cos(lat1 * (Math.PI / 180)) * Math.Cos(lat2 * (Math.PI / 180)) *
                    Math.Sin(dLon / 2) * Math.Sin(dLon / 2);

            var c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
            return R * c;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var allcars = await _getCarQueryHandler.Handle();
            var sliders = await _getSliderQueryHandler.Handle();
            var carModels = allcars
            .Select(c => $"{c.Brand} {c.Model}") // Marka ve modeli birleştir
            .Distinct()
            .ToList();
            var airports = await _airportService.GetAirportsAsync();
            await _airportDbService.SaveAirportsToDatabaseAsync(airports);

            var viewModel = new ReservationViewModel
            {
                CarSearch = new ReservationSearchViewModel(),
                Sliders = sliders,
                CarModels = carModels,
                Airports = airports
            };
            return View(viewModel);
        }

        [HttpPost]

        public async Task<IActionResult> Index(ReservationViewModel model)
        {



            if (model.CarSearch.PickUpLocation == model.CarSearch.DropOffLocation)
            {
                TempData["ErrorMessage"] = "Alış ve teslim havalimanı aynı olamaz!";
                return RedirectToAction("Index");
            }


            var carSearch = model.CarSearch;

            return RedirectToAction("ListAvailableCars", "Default", new
            {
                carModel = carSearch.CarModel,
                pickUpLocation = carSearch.PickUpLocation,
                dropOffLocation = carSearch.DropOffLocation,
                pickUpDate = carSearch.PickUpDate.ToString("yyyy-MM-dd"),
                dropOffDate = carSearch.DropOffDate.ToString("yyyy-MM-dd")

            });
        }

        [HttpGet]

        public async Task<IActionResult> ListAvailableCars(string carModel, string pickUpLocation, string dropOffLocation, DateTime pickUpDate, DateTime dropOffDate)
        {
            var allCars = await _getCarQueryHandler.Handle();
            var allBookings = await _getBookingQueryHandler.Handle();
            var airports = await _airportService.GetAirportsAsync();

            var pickUpAirport = airports.FirstOrDefault(a => a.Airport_Name == pickUpLocation);
            var dropOffAirport = airports.FirstOrDefault(a => a.Airport_Name == dropOffLocation);

            double distanceKm = 0;
            if (pickUpAirport != null && dropOffAirport != null)
            {
               
                distanceKm = CalculateDistance(
                    double.Parse(pickUpAirport.Latitude, CultureInfo.InvariantCulture),
                    double.Parse(pickUpAirport.Longitude, CultureInfo.InvariantCulture),
                    double.Parse(dropOffAirport.Latitude, CultureInfo.InvariantCulture),
                    double.Parse(dropOffAirport.Longitude, CultureInfo.InvariantCulture)
                );
            }

            var availableCars = allCars
          .Where(car =>
              (string.IsNullOrEmpty(carModel) || $"{car.Brand} {car.Model}" == carModel) &&
              !allBookings.Any(b =>
                  b.CarId == car.CarId &&
                  // Zaman aralığı çakışıyorsa ele
                  (pickUpDate < b.DropOffDate && dropOffDate > b.PickUpDate)
              )
             ).ToList();

            //var gasPriceInfo = await _rapidApiGasPrice.GetGasPricesAsync();

            var gasPriceInfo = new RapidApiGasPriceViewModel()
            {
                dieselTL = "50",
                gasolineTL = "51",
                lpgTL = "25"
            };

            double fuelPricePerLiter = double.Parse(
    gasPriceInfo.gasolineTL.Replace(" ₺", "").Replace(',', '.'),
    CultureInfo.InvariantCulture
);

            double fuelConsumptionPer100Km = 6.0; // şimdilik sabit, DB’den araç bazlı alabilirsin

            double litersNeeded = (distanceKm / 100) * fuelConsumptionPer100Km;
            double estimatedFuelCost = litersNeeded * fuelPricePerLiter;
            double averageWayTimeHours = Math.Round(distanceKm / 100, 2); // Ortalama hız 90 km/s
            ViewBag.v1=averageWayTimeHours;


            var viewModel = new ReservationSearchViewModel
            {
                CarModel = carModel,
                PickUpLocation = pickUpLocation,
                DropOffLocation = dropOffLocation,
                PickUpDate = pickUpDate,
                DropOffDate = dropOffDate,
                AvailableCars = availableCars,
                Distance = distanceKm,
                EstimatedFuelCost = estimatedFuelCost
            };
            

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> ListAvailableCars(ReservationSearchViewModel model)
        {
            if (model.CarTypeId == 0)
            {
                ModelState.AddModelError("", "Lütfen bir araç seçin.");
                return View(model);
            }

            var booking = new Booking
            {
                CarId = model.CarTypeId,
                PickUpAirport = model.PickUpLocation,
                DropOffAirport = model.DropOffLocation,
                PickUpDate = model.PickUpDate,
                DropOffDate = model.DropOffDate
            };

            await _createBookingCommandHandler.Handle(new CreateBookingCommand
            {
                CarId = booking.CarId,
                PickUpAirport = booking.PickUpAirport,
                DropOffAirport = booking.DropOffAirport,
                PickUpDate = booking.PickUpDate,
                DropOffDate = booking.DropOffDate
            });
            TempData["SuccessMessage"] = "Rezervasyon başarıyla oluşturuldu!";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public PartialViewResult SendMessage()
        {
            return PartialView();
        }

        [HttpPost]

        public async Task<IActionResult> SendMessage(CreateMessageCommand command, [FromServices] RapiApiChatBotService chatService)
        {
            await _createMessageCommandHandler.Handle(command);

            string prompt = $"Sen bir araç kiralama şirketi adına profesyonel müşteri temsilcisi gibi cevap yazacaksın. Sana müşteri tarafından Bize Ulaşın bölümünden gelen mesaj verilecek. Sadece resmi mail içeriği oluştur. Şirketimin adı CaRental Rent A Car. Mesaj: {command.MessageDetail}";

            string aiResponse = await chatService.GetAnswerAsync(prompt);

            MimeMessage mimeMessage = new MimeMessage();

            var senderNameSurname = command.Name + " " + command.Surname;

            MailboxAddress mailboxAddressFrom = new MailboxAddress(senderNameSurname, "salihdilmen94@gmail.com");
            mimeMessage.From.Add(mailboxAddressFrom);

            MailboxAddress mailboxAddressTo = new MailboxAddress("User", command.Email);
            mimeMessage.To.Add(mailboxAddressTo);

            var bodyBuilder = new BodyBuilder();
            bodyBuilder.TextBody = aiResponse;
            mimeMessage.Body = bodyBuilder.ToMessageBody();
            mimeMessage.Subject = "CaRental Rent A Car - Yanıt";

            using (var client = new MailKit.Net.Smtp.SmtpClient())
            {
                client.Connect("smtp.gmail.com", 587, false);
                client.Authenticate("salihdilmen94@gmail.com", "jbiy kzys npan fvdc");
                client.Send(mimeMessage);
                client.Disconnect(true);
            }

            return RedirectToAction("Index");
        }


    }
}
