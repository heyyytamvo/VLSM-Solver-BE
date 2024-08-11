var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();

// Add the CustomerService to the dependency injection container
// builder.Services.AddScoped<CustomerService>();
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapControllers();
app.Run("http://*:5003");

