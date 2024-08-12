var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();

// Add the CustomerService to the dependency injection container
builder.Services.AddScoped<VLSMService>();
var app = builder.Build();
app.UseCors(builder =>
        builder
        .AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader());

app.MapGet("/", () => "Hello World!");

app.MapControllers();
app.Run("http://*:5003");

