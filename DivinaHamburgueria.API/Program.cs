using DivinaHamburgueria.API.HostedServices;
using DivinaHamburgueria.API.Hypermedia.Enricher;
using DivinaHamburgueria.API.Hypermedia.Filters;
using DivinaHamburgueria.Infra.IoC;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var filterOptions = new HypermediaFilterOptions();
filterOptions.ContentResponseEnricherList.Add(new AlarmEnricher());
filterOptions.ContentResponseEnricherList.Add(new CustomerEnricher());
filterOptions.ContentResponseEnricherList.Add(new DeliveryOrderEnricher());
filterOptions.ContentResponseEnricherList.Add(new HallOrderEnricher());
filterOptions.ContentResponseEnricherList.Add(new InventoryEnricher());
filterOptions.ContentResponseEnricherList.Add(new InventoryItemEnricher());
filterOptions.ContentResponseEnricherList.Add(new MenuItemRecipeEnricher());
filterOptions.ContentResponseEnricherList.Add(new MenuItemResaleEnricher());
filterOptions.ContentResponseEnricherList.Add(new MenuEnricher());
filterOptions.ContentResponseEnricherList.Add(new ProviderEnricher());
filterOptions.ContentResponseEnricherList.Add(new PurchaseOrderEnricher());
filterOptions.ContentResponseEnricherList.Add(new QuantityAlarmTriggeredEnricher());
filterOptions.ContentResponseEnricherList.Add(new UnityEnricher());
builder.Services.AddSingleton(filterOptions);

builder.Services.AddInfrastructureAPI(builder.Configuration);
builder.Services.AddInfrastructureJWT(builder.Configuration);

builder.Services.AddHostedService<InventorySupervisorService>();

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();
builder.Services.AddInfrastructureSwagger();


builder.Services.AddCors(p => p.AddPolicy("corsapp", builder =>
{
    builder.WithOrigins("*").AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
}));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("corsapp");

app.UseStatusCodePages();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.MapControllerRoute("DefaultApi", "{controller=value}/{id?}");

app.Run();
