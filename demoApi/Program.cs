using coursesApi.Data;
using coursesApi.Endpoints;

var builder = WebApplication.CreateBuilder(args);

var connString = builder.Configuration.GetConnectionString("CoursesStore");
builder.Services.AddSqlite<CourseStoreContext>(connString);


var app = builder.Build();

app.MapCoursesEndpoints();

app.Run();
