using coursesApi.Endpoints;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapCoursesEndpoints();

app.Run();
