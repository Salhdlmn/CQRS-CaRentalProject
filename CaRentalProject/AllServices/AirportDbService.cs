using CaRentalProject.Context;
using CaRentalProject.Entities;
using CaRentalProject.Models;
using Microsoft.EntityFrameworkCore;

namespace CaRentalProject.AllServices
{
    public class AirportDbService
    {
        private readonly CaRentalContext _dbContext;

        public AirportDbService(CaRentalContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task SaveAirportsToDatabaseAsync(List<RapidApiCountryAndAirportViewModel> viewModels)
        {
            foreach (var vm in viewModels)
            {
                // Zaten ekli mi kontrol et (örn. AirportCode + City'e göre)
                if (string.IsNullOrWhiteSpace(vm.Airport_Code))
                    continue;
                bool exists = await _dbContext.Locations.AnyAsync(x =>
                 x.AirportCode == vm.Airport_Code &&
                 x.City == vm.City &&
                 x.Country == vm.Country_Alpha2 &&
                 x.Latitude == vm.Latitude &&
                 x.Longitude == vm.Longitude);


                if (!exists)
                {
                    var location = new Location
                    {
                        AirportName = vm.Airport_Name,
                        AreaCode = vm.Area_Code,
                        AirportCode = vm.Airport_Code,
                        City = vm.City,
                        Country = vm.Country_Alpha2,
                        Latitude = vm.Latitude,
                        Longitude = vm.Longitude
                    };

                    _dbContext.Locations.Add(location);
                }
            }

            await _dbContext.SaveChangesAsync();
        }
    }
}
