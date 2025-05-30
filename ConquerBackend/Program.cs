using ConquerBackend.Presentation;
using ConquerBackend.Presentation.Middleware;
using Hangfire;
using HangfireBasicAuthenticationFilter;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddAppDI(builder.Configuration);
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping;
    });
builder.Services.AddCors(p => p.AddPolicy("MyCors", build =>
{
    build.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseCors("MyCors");
app.UseHangfireDashboard("/test/job-dashboard", new DashboardOptions
{
    Authorization = new[]
    {
        new HangfireCustomBasicAuthenticationFilter
        {
            User = "admin",
            Pass = "password123"
        }
    }
});
app.Use(async (context, next) => // Middleware 1
{
    Console.WriteLine($"Middleware 1 Request Received: {context.Request.Path}");
    await next(); // Gọi middleware tiếp theo
    Console.WriteLine($"Middleware 1 Response Sent: {context.Response.StatusCode}");
});

app.Use(async (context, next) => // Middleware 2
{
    Console.WriteLine($"Middleware 2 Request Received: {context.Request.Path}");
    await next(); // Gọi middleware tiếp theo (nếu có)
    Console.WriteLine($"Middleware 2 Response Sent: {context.Response.StatusCode}");
});


app.MapControllers();

app.Run();
