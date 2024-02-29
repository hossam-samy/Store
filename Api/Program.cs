using Application;
using Infrastructure;
using Infrastructure.Services.Localization;
using Microsoft.Extensions.Localization;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddApplication().
    AddInfrastructure(builder.Configuration);

builder.Services.AddMvc();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddLocalization();
builder.Services.
    AddSingleton<IStringLocalizerFactory, JsonStringLocalizerFactory>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddMvc().AddDataAnnotationsLocalization(op =>
{
    op.DataAnnotationLocalizerProvider = (type, factory) =>
    factory.Create(typeof(JsonStringLocalizerFactory));
});
builder.Services.Configure<RequestLocalizationOptions>(options => {

    var supportedCultures = new[] {
      new CultureInfo("en-US"),
      new CultureInfo("ar-EG")

    };
    options.DefaultRequestCulture = new Microsoft.AspNetCore.Localization.RequestCulture(culture: supportedCultures[0]);
    options.SupportedCultures = supportedCultures;
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();   
var supportedCultures = new[] { "en-US", "ar-EG" };
var localizationOptions = new RequestLocalizationOptions().
    SetDefaultCulture(supportedCultures[0]).
    AddSupportedCultures(supportedCultures);
app.UseRequestLocalization(localizationOptions);
app.UseAuthentication();    
app.UseAuthorization();

app.MapControllers();

app.Run();
