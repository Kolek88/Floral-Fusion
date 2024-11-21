using StringLibrary;
// need to install Firebaseadmin and Google.Cloud.Firestore sdk

var builder = WebApplication.CreateBuilder(args);

// NEED THIS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder =>
        {
            builder.WithOrigins("https://localhost:7206")
            .AllowAnyMethod()
            .AllowAnyHeader()
            .SetIsOriginAllowed(origin => true)
            .AllowCredentials();
        });
});


var app = builder.Build();

FlowerShopBusiness FlowerBiz = new FlowerShopBusiness();
FlowerBiz.initFirestore();

// route
app.MapGet("/", () => "Hello World!");


app.MapGet("/orders", async c =>
{
    await FlowerBiz.RestoreOrders();

    c.Response.WriteAsJsonAsync(FlowerBiz.OrderList.Orders);
});


app.MapPost("/orders/addedit", async (Order order) =>
{
    await FlowerBiz.SaveOrder(order);

    return Results.NoContent();
});


app.MapPost("/orders/delete", async (Order order) =>
{
    await FlowerBiz.DeleteOrder(order.OrderID);

    return Results.NoContent();
});

// NEED THIS
app.UseCors("AllowAll");

app.Run();