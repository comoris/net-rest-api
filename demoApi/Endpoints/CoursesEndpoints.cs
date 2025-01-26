using System;
using coursesApi.Dtos;

namespace coursesApi.Endpoints;

public static class CoursesEndpoints
{

    const string GetCourseEndpointName = "GetCourseById";

    private static readonly List<CourseDto> courses = [
         new CourseDto(1, "C# Basics", "Programming", 9.99m, new DateOnly(2021, 1, 1)),
        new CourseDto(2, "C# Intermediate", "Programming", 19.99m, new DateOnly(2021, 2, 1)),
        new CourseDto(3, "C# Advanced", "Programming", 29.99m, new DateOnly(2021, 3, 1))
     ];

    public static RouteGroupBuilder MapCoursesEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("/courses").WithParameterValidation();

        // GET all
        group.MapGet("/", () => courses);

        // GET by id
        group.MapGet("/{id}", (int id) =>
        {
            var course = courses.Find(c => c.Id == id);

            return course is null ? Results.NotFound() : Results.Ok(course);

        }).WithName(GetCourseEndpointName);

        // POST
        group.MapPost("/", (CreateCourseDto newCourse) =>
        {
            CourseDto course = new(
                courses.Count + 1,
                newCourse.Name,
                newCourse.Genre,
                newCourse.Price,
                newCourse.ReleaseDate
            );

            courses.Add(course);

            return Results.CreatedAtRoute(GetCourseEndpointName, new { id = course.Id }, course);
        });

        // PUT 
        group.MapPut("/{id}", (int id, UpdateCourseDto updateCourse) =>
        {
            var index = courses.FindIndex(c => c.Id == id);
            if (index == -1)
            {
                return Results.NotFound();
            }

            courses[index] = new CourseDto(
                id,
                updateCourse.Name,
                updateCourse.Genre,
                updateCourse.Price,
                updateCourse.ReleaseDate
            );

            return Results.NoContent();
        });

        // DELETE
        group.MapDelete("/{id}", (int id) =>
            {
                courses.RemoveAll(c => c.Id == id);

                return Results.NoContent();
            });

        return group;
    }
}
