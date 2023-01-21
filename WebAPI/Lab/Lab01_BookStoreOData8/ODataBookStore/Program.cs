using Microsoft.AspNetCore.OData;
using Microsoft.AspNetCore.OData.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;
using ODataBookStore;
using ODataBookStore.EDM;

static IEdmModel GetEdmModel()
{
    ODataConventionModelBuilder oDataConventionModelBuilder = new ODataConventionModelBuilder();
    oDataConventionModelBuilder.EntitySet<Book>("Books");
    oDataConventionModelBuilder.EntitySet<Press>("Presses");
    return oDataConventionModelBuilder.GetEdmModel();
}

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<BookStoreContext>(opt => opt.UseInMemoryDatabase("BookLists"));
builder.Services.AddControllers().AddOData(option => option.Select().Filter().Count().OrderBy().Expand().SetMaxTop(100).AddRouteComponents("odata", GetEdmModel()));
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

app.UseHttpsRedirection();
app.UseODataBatching();

////Test Middleware
//app.Use(async (context, next) =>
//        {
//            var endpoint = context.GetEndpoint();
//            if (endpoint != null)
//            {
//                await next(context);
//            }

//            IEnumerable<string> templates;
//            IODataRoutingMetadata metaData = endpoint.Metadata.GetMetadata<IODataRoutingMetadata>();
//            if (metaData != null)
//            {
//                templates = metaData.Template.GetTemplates();
//            }
//            await next(context);

//        }
//);

app.UseAuthorization();

app.MapControllers();

app.Run();
