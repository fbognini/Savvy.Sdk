using Savvy.Sdk.Requests;
using Savvy.Sdk;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSavvyApiService(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// emulate "authenticate" logig
GetTokenRequest? defaultGetTokenRequest = null;

app.MapPost("/token", async (GetTokenRequest request, ISavvyApiPaymentService savvyApiPaymentService) =>
{
    return await savvyApiPaymentService.GetToken(request);
})
.WithName("GetToken")
.WithOpenApi();

app.MapPost("/authenticate", async (GetTokenRequest request, ISavvyApiPaymentService savvyApiPaymentService) =>
{
    defaultGetTokenRequest = request;

    return await savvyApiPaymentService.GetToken(request);
})
.WithName("Authenticate")
.WithOpenApi();

app.MapPost("/new-card", async (InitializeVirtualCardRequest request, ISavvyApiPaymentService savvyApiPaymentService) =>
{
    await savvyApiPaymentService.Authenticate(defaultGetTokenRequest!);

    request.RequestId = Guid.NewGuid().ToString();

    return await savvyApiPaymentService.InitializeVirtualCard(request);
})
.WithName("NewCard")
.WithOpenApi();

app.Run();