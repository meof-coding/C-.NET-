using ClassworkrGPC;
using ClassworkrGPC.DataAccess;
using ClassworkrGPC.Services;

var builder = WebApplication.CreateBuilder(args);

// Additional configuration is required to successfully run gRPC on macOS.
// For instructions on how to configure Kestrel and gRPC clients on macOS, visit https://go.microsoft.com/fwlink/?linkid=2099682
builder.Services.AddDbContext<NorthwindContext>();
// Add services to the container.
builder.Services.AddGrpc();
builder.Services.AddTransient<CustomerService.CustomerServiceBase, CustomerServiceImpl>();
var app = builder.Build();

// Configure the HTTP request pipeline.
// app.MapGrpcService<GreeterService>();
app.MapGrpcService<CustomerServiceImpl>();
app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();
