using Microsoft.Extensions.Configuration;
using EP.Persistence;
using Microsoft.EntityFrameworkCore;
using MediatR;
using EP.Application.People.Commands;
using EP.Application.Interface.Contexts;
using EP.Application.People.Queres;
using System.Reflection;
using EP.Application.MappingProfile;
using Microsoft.AspNetCore.OData;
using Microsoft.AspNetCore.OData.Batch;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddCors(options => options.AddPolicy(MyAllowSpecificOrigins, builder =>
{
    builder
        .AllowAnyHeader()
        .AllowAnyMethod()
        .SetIsOriginAllowed((host) => true)
        .AllowCredentials();
}));


builder.Services.AddControllers().AddOData(options => options.Select().Filter().OrderBy());
builder.Services.AddControllersWithViews();
builder.Services.AddMediatR(typeof(SendPersonCommand).Assembly);
builder.Services.AddMediatR(typeof(GetPersonQuery).Assembly);
builder.Services.AddAutoMapper(typeof(PersonMappingProfile));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


#region Connection
string connection = builder.Configuration["ConnectionStrings:SqlConnection"];
builder.Services.AddDbContext<DataBaseContext>(option => option.UseSqlServer(connection));
builder.Services.AddScoped<IDataBaseContext, DataBaseContext>();
#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    options.RoutePrefix = string.Empty;
});
app.UseCors(MyAllowSpecificOrigins);

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");    
    app.MapFallbackToFile("index.html");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{id?}");
app.MapFallbackToFile("index.html");

app.MapControllers();

app.Run();
