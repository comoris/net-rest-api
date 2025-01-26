using coursesApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace coursesApi.Data;

public class CourseStoreContext(DbContextOptions<CourseStoreContext> options) : DbContext(options)
{
    public DbSet<Course> Courses => Set<Course>();
    public DbSet<Genre> Genres => Set<Genre>();
}
