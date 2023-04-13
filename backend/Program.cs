var MyAllowAllOrigins = "_myAllowAllOrigins";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy(MyAllowAllOrigins,
                          policy =>
                          {
                              policy.AllowAnyOrigin()
                                .AllowAnyHeader()
                                .AllowAnyMethod();
                          });
});

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
Console.WriteLine("starting");
app.UseHttpsRedirection();
app.UseCors(MyAllowAllOrigins);
app.UseAuthorization();

app.MapControllers();


app.Run();
