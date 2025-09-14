using CaRentalProject.AllServices;
using CaRentalProject.Context;
using CaRentalProject.CQRS.Handlers.AboutHandlers;
using CaRentalProject.CQRS.Handlers.BookingHandlers;
using CaRentalProject.CQRS.Handlers.CarHandlers;
using CaRentalProject.CQRS.Handlers.EmployeeHandlers;
using CaRentalProject.CQRS.Handlers.FeatureHandlers;
using CaRentalProject.CQRS.Handlers.LocationHandlers;
using CaRentalProject.CQRS.Handlers.MessageHandlers;
using CaRentalProject.CQRS.Handlers.ServiceHandlers;
using CaRentalProject.CQRS.Handlers.SliderHandlers;
using CaRentalProject.CQRS.Handlers.TestimonialHandlers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<CaRentalContext>();
builder.Services.AddScoped<AirportDbService>();
builder.Services.AddScoped<RapidApiGasPrice>();
builder.Services.AddScoped<GetCarLabelReviewQueryHandler>();
builder.Services.AddScoped<GetCarFuelTypeQueryHandler>();

builder.Services.AddScoped<RapiApiChatBotService>();



builder.Services.AddHttpClient<RapidAPIAirportService>();


// AboutHandlers
builder.Services.AddScoped<CreateAboutCommandHandler>();
builder.Services.AddScoped<GetAboutByIdQueryHandler>();
builder.Services.AddScoped<GetAboutQueryHandler>();
builder.Services.AddScoped<RemoveAboutCommandHandler>();
builder.Services.AddScoped<UpdateAboutCommandHandler>();

// BookingHandlers
builder.Services.AddScoped<CreateBookingCommandHandler>();
builder.Services.AddScoped<GetBookingByIdQueryHandler>();
builder.Services.AddScoped<GetBookingQueryHandler>();
builder.Services.AddScoped<RemoveBookingCommandHandler>();
builder.Services.AddScoped<UpdateBookingCommandHandler>();

// CarHandlers
builder.Services.AddScoped<CreateCarCommandHandler>();
builder.Services.AddScoped<GetCarByIdQueryHandler>();
builder.Services.AddScoped<GetCarQueryHandler>();
builder.Services.AddScoped<RemoveCarCommandHandler>();
builder.Services.AddScoped<UpdateCarCommandHandler>();

// EmployeeHandlers
builder.Services.AddScoped<CreateEmployeeCommandHandler>();
builder.Services.AddScoped<GetEmployeeByIdQueryHandler>();
builder.Services.AddScoped<GetEmployeeQueryHandler>();
builder.Services.AddScoped<RemoveEmployeeCommandHandler>();
builder.Services.AddScoped<UpdateEmployeeCommandHandler>();

// FeatureHandlers
builder.Services.AddScoped<CreateFeatureCommandHandler>();
builder.Services.AddScoped<GetFeatureByIdQueryHandler>();
builder.Services.AddScoped<GetFeatureQueryHandler>();
builder.Services.AddScoped<RemoveFeatureCommandHandler>();
builder.Services.AddScoped<UpdateFeatureCommandHandler>();

// LocationHandlers
builder.Services.AddScoped<CreateLocationCommandHandler>();
builder.Services.AddScoped<GetLocationByIdQueryHandler>();
builder.Services.AddScoped<GetLocationQueryHandler>();
builder.Services.AddScoped<RemoveLocationCommandHandler>();
builder.Services.AddScoped<UpdateLocationCommandHandler>();

// MessageHandlers
builder.Services.AddScoped<CreateMessageCommandHandler>();
builder.Services.AddScoped<GetMessageByIdQueryHandler>();
builder.Services.AddScoped<GetMessageQueryHandler>();
builder.Services.AddScoped<RemoveMessageCommandHandler>();
builder.Services.AddScoped<UpdateMessageCommandHandler>();

// ServiceHandlers
builder.Services.AddScoped<CreateServiceCommandHandler>();
builder.Services.AddScoped<GetServiceByIdQueryHandler>();
builder.Services.AddScoped<GetServiceQueryHandler>();
builder.Services.AddScoped<RemoveServiceCommandHandler>();
builder.Services.AddScoped<UpdateServiceCommandHandler>();

// SliderHandlers
builder.Services.AddScoped<CreateSliderCommandHandler>();
builder.Services.AddScoped<GetSliderByIdQueryHandler>();
builder.Services.AddScoped<GetSliderQueryHandler>();
builder.Services.AddScoped<RemoveSliderCommandHandler>();
builder.Services.AddScoped<UpdateSliderCommandHandler>();

// TestimonialHandlers
builder.Services.AddScoped<CreateTestimonialCommandHandler>();
builder.Services.AddScoped<GetTestimonialByIdQueryHandler>();
builder.Services.AddScoped<GetTestimonialQueryHandler>();
builder.Services.AddScoped<RemoveTestimonialCommandHandler>();
builder.Services.AddScoped<UpdateTestimonialCommandHandler>();




// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Default}/{action=Index}/{id?}");
});



app.Run();
