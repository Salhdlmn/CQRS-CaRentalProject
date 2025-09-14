using CaRentalProject.CQRS.Results.CarResults;

namespace CaRentalProject.Models
{
    public class ReservationSearchViewModel
    {
        public int CarTypeId { get; set; } // örn: "Toyota Corolla"
        public string CarModel { get; set; }
        public string PickUpLocation { get; set; }
        public string DropOffLocation { get; set; }
        public DateTime PickUpDate { get; set; }
        public DateTime DropOffDate { get; set; }


        public double Distance { get; set; } // Mesafe bilgisi eklendi
        public double EstimatedFuelCost { get; set; }
        public List<GetCarQueryResult> AvailableCars { get; set; } = new List<GetCarQueryResult>();
    }
}
