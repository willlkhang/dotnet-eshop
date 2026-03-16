var builder = WebApplication.CreateBuilder(args);

//add service to the container

var app = builder.Build();

//config the HTTP request pipeline

app.Run();