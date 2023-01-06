using System.Threading.Tasks.Dataflow;
using buberBreakfast.Services.Breakfasts;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

{
    builder.Services.AddControllers();
    builder.Services.AddScoped<IBreakfastServices, BreakfastServices>();
}

builder.Services.AddControllers();

var app = builder.Build();
{
    app.UseExceptionHandler("/error");
    app.UseHttpsRedirection();
    app.MapControllers();
    app.Run();
}