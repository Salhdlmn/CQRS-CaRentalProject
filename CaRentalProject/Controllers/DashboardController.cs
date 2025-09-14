using CaRentalProject.AllServices;
using CaRentalProject.CQRS.Handlers.CarHandlers;
using CaRentalProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace CaRentalProject.Controllers
{
    public class DashboardController : Controller
    {
        private readonly RapidApiGasPrice _rapidApiGasPrice;
        private readonly GetCarLabelReviewQueryHandler _getCarLabelReviewQueryHandler;
        private readonly GetCarFuelTypeQueryHandler _getCarFuelTypeQueryHandler;

        public DashboardController(RapidApiGasPrice rapidApiGasPrice, GetCarLabelReviewQueryHandler getCarLabelReviewQueryHandler, GetCarFuelTypeQueryHandler getCarFuelTypeQueryHandler)
        {
            _rapidApiGasPrice = rapidApiGasPrice;
            _getCarLabelReviewQueryHandler = getCarLabelReviewQueryHandler;
            _getCarFuelTypeQueryHandler = getCarFuelTypeQueryHandler;
        }

        public async Task< IActionResult >Index()
        {
            //var gasPrices = await _rapidApiGasPrice.GetGasPricesAsync();

            var gasPrices = new RapidApiGasPriceViewModel()
            {
                dieselTL = "50",
                gasolineTL = "51",
                lpgTL = "25"
            };

            var result = _getCarLabelReviewQueryHandler.Handle();

            var chartModel = new Models.CarLabelReviewViewModel
            {
                Labels = result.Select(r => r.Brand).ToList(),
                Reviews = result.Select(r => r.AvgReview).ToList()
            };

            var result2= _getCarFuelTypeQueryHandler.Handle();

            var chartModel2 = new Models.CarFuelTypeChartViewModel
            {
                Labels = result2.Select(r => r.FuelType).ToList(),
                Counts = result2.Select(r => r.Count).ToList()
            };

            var vm=new Models.DashboardViewModel
            {
                GasPrices = gasPrices,
                LabelReviewChart = chartModel,
                FuelTypeChart = chartModel2

            };


            return View(vm);
        }


    }
}
