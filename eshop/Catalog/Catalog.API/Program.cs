var builder = WebApplication.CreateBuilder(args);

//add Services to the container

var app = builder.Build();

//configure the HTTP request pipeline

app.Run();