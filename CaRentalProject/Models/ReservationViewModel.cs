using CaRentalProject.CQRS.Commands.MessageCommands;
using CaRentalProject.CQRS.Results.SliderResults;

namespace CaRentalProject.Models
{
    public class ReservationViewModel
    {
        public List<string> CarModels { get; set; } = new(); // Marka + Model birleşimi
        public List<RapidApiCountryAndAirportViewModel> Airports { get; set; } = new(); // API'den gelen verile
        public List<GetSliderQueryResult> Sliders { get; set; }

        public CreateMessageCommand Message { get; set; }

        public ReservationSearchViewModel CarSearch { get; set; } = new();
    }
}
