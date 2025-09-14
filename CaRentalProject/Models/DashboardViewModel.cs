namespace CaRentalProject.Models
{
    public class DashboardViewModel
    {
        public RapidApiGasPriceViewModel GasPrices { get; set; }

        public CarLabelReviewViewModel  LabelReviewChart { get; set; }

        public CarFuelTypeChartViewModel FuelTypeChart { get; set; }
    }
}
